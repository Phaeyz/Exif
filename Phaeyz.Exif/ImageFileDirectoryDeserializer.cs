using System.Collections;
using System.Text;
using Phaeyz.Marshalling;

namespace Phaeyz.Exif;

/// <summary>
/// Deserializes an EXIF buffer into an image file directory collection.
/// </summary>
internal class ImageFileDirectoryDeserializer
{
    private readonly ReadOnlyMemory<byte> _exifBuffer;
    private readonly TagProvider _tagProvider;
    private readonly ByteConverter _byteConverter;
    private readonly HashSet<int> _offsets = new([0]);
    private readonly List<(EntryReference entryReference, int absoluteOffset)> _preserveBlocks = [];
    private readonly List<EntryReference> _cannotRoundTripEntries = [];

    /// <summary>
    /// Initializes a new instance of the deserializer.
    /// </summary>
    /// <param name="exifBuffer">
    /// The EXIF buffer containing the serialized image file directory collection.
    /// </param>
    /// <param name="tagProvider">
    /// A provider used for sourcing tag details required for deserialization instructions.
    /// </param>
    /// <param name="byteConverter">
    /// The byte converter used during deserialization.
    /// </param>
    private ImageFileDirectoryDeserializer(ReadOnlyMemory<byte> exifBuffer, TagProvider tagProvider, ByteConverter byteConverter)
    {
        _exifBuffer = exifBuffer;
        _byteConverter = byteConverter;
        _tagProvider = tagProvider;
    }

    /// <summary>
    /// Deserializes the EXIF buffer into the destination image file directory collection.
    /// </summary>
    /// <param name="dest">
    /// The destination image file directory collection.
    /// </param>
    /// <param name="exifBuffer">
    /// The EXIF buffer containing the serialized image file directory collection.
    /// </param>
    /// <param name="tagProvider">
    /// A provider used for sourcing tag details required for deserialization instructions.
    /// </param>
    /// <param name="byteConverter">
    /// The byte converter used during deserialization.
    /// </param>
    /// <param name="startingOffset">
    /// The offset within the destination buffer to begin deserialization.
    /// </param>
    /// <param name="startIsPointer">
    /// If true, the first byte of the startingOffset begins a pointer to the an image file directory.
    /// If false, the first byte of the startingOffset is the image file directory itself.
    /// </param>
    /// <param name="cannotRoundTripEntries">
    /// On output, this receives a list of entries which, without intervention, may not round trip. This means if the image file directory
    /// collection is reserialized, these entries may not be valid.
    /// </param>
    /// <exception cref="Phaeyz.Exif.ExifException">
    /// A deserialization error occurred indicating the buffer is not valid EXIF.
    /// </exception>
    public static void Deserialize(
        ImageFileDirectoryCollection dest,
        ReadOnlyMemory<byte> exifBuffer,
        TagProvider tagProvider,
        ByteConverter byteConverter,
        int startingOffset,
        bool startIsPointer,
        out List<EntryReference> cannotRoundTripEntries)
    {
        // Create the deserializer.
        ImageFileDirectoryDeserializer deserializer = new(exifBuffer, tagProvider, byteConverter);
        cannotRoundTripEntries = deserializer._cannotRoundTripEntries;

        // If the startingOffset is a pointer, read the pointer to get the offset to the first byte of the IFD.
        ScopedOffset offset = new(0, startingOffset);
        if (startIsPointer)
        {
            deserializer.ValidateRange(offset, 4);
            offset = deserializer.ReadOffsetAndValidateNewRange(offset, 0);

            // A zero offset means no more data.
            if (offset.RelativeOffset == 0)
            {
                return;
            }
        }

        // Begin deserializing the image file directory collection.
        deserializer.Deserialize(dest, Tag.Root, 0, offset);

        // After deserialization is complete, do a best effort to preserve necessary data blocks.
        deserializer.DeserializePreservedBlocks();
    }

    /// <summary>
    /// Recursively deserializes image file directories from the EXIF buffer.
    /// </summary>
    /// <param name="dest">
    /// The current recursive destination image file directory collection.
    /// </param>
    /// <param name="parentTag">
    /// The entry tag of the parent which tracks the destination image file directory collection.
    /// </param>
    /// <param name="parentIndex">
    /// The current index of the image file directory being deserialized for the parent tag.
    /// </param>
    /// <param name="offset">
    /// The current offset in the EXIF buffer for deserialization.
    /// </param>
    /// <exception cref="Phaeyz.Exif.ExifException">
    /// A deserialization error occurred indicating the buffer is not valid EXIF.
    /// </exception>
    private void Deserialize(ImageFileDirectoryCollection dest, Tag parentTag, int parentIndex, ScopedOffset offset)
    {
        const int entrySize = 12;

        while (true)
        {
            // Read the count of entries
            ValidateRange(offset, 2);
            ushort entryCount = _byteConverter.ToUInt16(_exifBuffer[offset.Value..].Span);
            offset += 2;

            // Validate the buffer contains sufficient space for the entire image file directory, plus the trailing offset.
            ValidateRange(offset, entryCount * entrySize + 4);
            ImageFileDirectory ifd = new(entryCount);

            // Iterate through each entry to deserialize each one.
            for (int i = 0; i < entryCount; i++, offset += entrySize)
            {
                // Read the tag value to produce a tag for this entry.
                ushort tagValue = _byteConverter.ToUInt16(_exifBuffer[offset.Value..].Span);

                Tag tag = _tagProvider.Match(tagValue, parentTag, parentIndex)
                    ?? Tag.Create(parentTag, parentIndex, tagValue, null);

                // Read the type and count.
                var type = (EntryType)_byteConverter.ToUInt16(_exifBuffer[(offset.Value + 2)..].Span);
                int count = _byteConverter.ToInt32(_exifBuffer[(offset.Value + 4)..].Span);

                // Now use that data to deserialize a value for the entry.
                object value = DeserializeValue(tag, offset + 8, type, count);

                // For IFDs, recursively deserialize
                if (tag.Behavior == TagBehavior.IfdPointer || tag.Behavior == TagBehavior.ScopedIfdPointer)
                {
                    // Technically it is possible for there to be multiple IFD pointers in the entry value.
                    // This deserializer supports reading multiple pointers, though this is typically very rare.
                    List<int> ifdOffsets = value is IEnumerable enumerable
                        ? enumerable.Cast<object>().Select(obj => (int)Convert.ToUInt32(obj)).ToList()
                        : [(int)Convert.ToUInt32(value)];

                    // Iterate each pointer.
                    int index = 0;
                    List<ImageFileDirectoryCollection> ifdPointers = ifdOffsets
                        .Select(ifdOffset => new ScopedOffset(offset.AbsoluteOffset, ifdOffset))
                        .Select(ifdOffset =>
                    {
                        // Track the offset which helps us recover preserved blocks.
                        _offsets.Add(ifdOffset);

                        // Recursively deserialize.
                        ImageFileDirectoryCollection entryIfds = [];

                        Deserialize(
                            entryIfds,
                            tag,
                            index,
                            tag.Behavior == TagBehavior.ScopedIfdPointer ? ifdOffset.Scope() : ifdOffset);

                        // When tracking multiple pointers, the parent index should be a continuation of all previous pointers.
                        index += entryIfds.Count;

                        return entryIfds;
                    }).ToList();

                    // Add the IFD entry.
                    ifd.Add(tag, new Entry(tag, type, ifdPointers.Count == 1 ? ifdPointers[0] : ifdPointers));
                }
                else
                {
                    // Add a standard entry.
                    ifd.Add(tag, new Entry(tag, type, value));

                    // Check if the tag instructs to attempt to preserve the data block.
                    if (tag.Behavior == TagBehavior.PreserveDataBlock)
                    {
                        // The type must be an offset, and value not an array of offsets.
                        if ((type == EntryType.Int32 || type == EntryType.UInt32) && (value is int || value is uint))
                        {
                            _offsets.Add(offset.AbsoluteOffset + Convert.ToInt32(value));
                            _preserveBlocks.Add((new EntryReference(ifd, tag), offset.AbsoluteOffset));
                        }
                    }
                    // If the tag indicates this entry has potential round trip issues, track the entry.
                    if (tag.Behavior == TagBehavior.CannotRoundTrip)
                    {
                        _cannotRoundTripEntries.Add(new EntryReference(ifd, tag));
                    }
                }
            }

            // If any offset-and-length pairs were deserialized, deserialize the byte sequence for it.
            foreach (KeyValuePair<Tag, Entry> tagEntryOffset in
                ifd.Where(kvp => kvp.Key.Behavior == TagBehavior.OffsetAndLengthPair).ToList())
            {
                // If an entry was found, but the corresponding length entry was not found, that is an error in the EXIF.
                if (!ifd.TryGetValue(tagEntryOffset.Key.Related!, out Entry? dataLengthEntry))
                {
                    throw new ExifException($"IFD \"{parentTag}\" contains data tag \"{tagEntryOffset.Key}\" but not length tag \"{tagEntryOffset.Key.Related!}\".");
                }

                // Translate the offset to a reference which can be used for deserialization.
                ScopedOffset dataOffset = new(offset.AbsoluteOffset, (int)Convert.ToUInt32(tagEntryOffset.Value.Value));
                int dataLength = (int)Convert.ToUInt32(dataLengthEntry.Value);

                // Validate and track the byte sequence beginning and ending offsets.
                ValidateRange(dataOffset, dataLength);
                _offsets.Add(dataOffset);
                _offsets.Add(dataOffset + dataLength);

                // Deserialize the byte sequence.
                var data = new byte[dataLength];
                _byteConverter.CopyTo(_exifBuffer.Slice(dataOffset, dataLength).Span, data);

                // Update the offset entry to be the byte sequence.
                ifd[tagEntryOffset.Key] = new Entry(tagEntryOffset.Value.Tag, EntryType.ByteSequence, data);

                // And remove the length entry since it is not needed anymore.
                ifd.Remove(tagEntryOffset.Key.Related!);
            }

            // Track this deserialized entry.
            dest.Add(ifd);

            // Read the next IFD pointer.
            ValidateRange(_exifBuffer, offset, 4);
            offset = ReadOffsetAndValidateNewRange(offset, 0);
            if (offset.RelativeOffset == 0)
            {
                break;
            }
            parentIndex++;
        }
    }

    /// <summary>
    /// Preserves data blocks for relevant entries.
    /// </summary>
    private void DeserializePreservedBlocks()
    {
        if (_preserveBlocks.Count > 0)
        {
            List<int> orderedOffsets = [.. _offsets.Order()];

            // Iterate the entries to preserve data blocks.
            foreach (((ImageFileDirectory ifd, Tag tag), int absoluteOffset) in _preserveBlocks)
            {
                // Read the offset and length of the data block to preserve.
                ScopedOffset preserveOffset = new(absoluteOffset, Convert.ToInt32(ifd[tag].Value));
                int preserveLength = 0;
                if (preserveOffset < _exifBuffer.Length)
                {
                    int nextOffset = orderedOffsets.FirstOrDefault(o => preserveOffset < o, _exifBuffer.Length);
                    preserveLength = nextOffset - preserveOffset;
                }

                // Copy it the data block to preserve.
                byte[] preserveData = new byte[preserveLength];
                if (preserveLength > 0)
                {
                    _byteConverter.CopyTo(_exifBuffer.Slice(preserveOffset, preserveLength).Span, preserveData);
                }

                // Replace the entry with the byte sequence of the preserved data block.
                ifd[tag] = new Entry(tag, EntryType.ByteSequence, preserveData);
            }
        }

        // Clear the list since these blocks have now been preserved.
        _preserveBlocks.Clear();
    }

    /// <summary>
    /// Deserializes an entry value based on it's type and count.
    /// </summary>
    /// <param name="tag">
    /// The tag which contains important deserialization details for the entry.
    /// </param>
    /// <param name="offset">
    /// The offset where the data value exists in the EXIF buffer.
    /// </param>
    /// <param name="type">
    /// The type of the value.
    /// </param>
    /// <param name="count">
    /// The number of typed elements in the value.
    /// </param>
    /// <returns>
    /// The deserialized entry value.
    /// </returns>
    /// <exception cref="Phaeyz.Exif.ExifException">
    /// A deserialization error occurred indicating the buffer is not valid EXIF.
    /// </exception>
    private object DeserializeValue(Tag tag, ScopedOffset offset, EntryType type, int count)
    {
        if (count <= 0)
        {
            throw new ExifException($"Invalid IFD count \"{count}\" (Tag={tag}, Type={type}).");
        }

        switch (type)
        {
            case EntryType.Byte:
            case EntryType.ByteSequence:
                if (count == 1)
                {
                    return type == EntryType.ByteSequence
                        ? new byte[1] { _exifBuffer.Span[offset] }
                        : _exifBuffer.Span[offset];
                }
                else
                {
                    var value = new byte[count];
                    int valueOffset = count <= 4 ? offset : ReadOffsetAndValidateNewRange(offset, count * sizeof(byte));
                    _byteConverter.CopyTo(_exifBuffer[valueOffset..].Span, value, count);
                    return value;
                }
            case EntryType.SByte:
                if (count == 1)
                {
                    return (sbyte)_exifBuffer.Span[offset];
                }
                else
                {
                    var value = new sbyte[count];
                    int valueOffset = count <= 4 ? offset : ReadOffsetAndValidateNewRange(offset, count * sizeof(sbyte));
                    _byteConverter.CopyTo(_exifBuffer[valueOffset..].Span, value, count);
                    return value;
                }
            case EntryType.UInt16:
                if (count == 1)
                {
                    return _byteConverter.ToUInt16(_exifBuffer[offset.Value..].Span);
                }
                else
                {
                    var value = new ushort[count];
                    int valueOffset = count <= 2 ? offset : ReadOffsetAndValidateNewRange(offset, count * sizeof(ushort));
                    _byteConverter.CopyTo(_exifBuffer[valueOffset..].Span, value, count);
                    return value;
                }
            case EntryType.Int16:
                if (count == 1)
                {
                    return _byteConverter.ToInt16(_exifBuffer[offset.Value..].Span);
                }
                else
                {
                    var value = new short[count];
                    int valueOffset = count <= 2 ? offset : ReadOffsetAndValidateNewRange(offset, count * sizeof(short));
                    _byteConverter.CopyTo(_exifBuffer[valueOffset..].Span, value, count);
                    return value;
                }
            case EntryType.UInt32:
                if (count == 1)
                {
                    return _byteConverter.ToUInt32(_exifBuffer[offset.Value..].Span);
                }
                else
                {
                    var value = new uint[count];
                    int valueOffset = ReadOffsetAndValidateNewRange(offset, count * sizeof(uint));
                    _byteConverter.CopyTo(_exifBuffer[valueOffset..].Span, value, count);
                    return value;
                }
            case EntryType.Int32:
                if (count == 1)
                {
                    return _byteConverter.ToInt32(_exifBuffer[offset.Value..].Span);
                }
                else
                {
                    var value = new int[count];
                    int valueOffset = ReadOffsetAndValidateNewRange(offset, count * sizeof(int));
                    _byteConverter.CopyTo(_exifBuffer[valueOffset..].Span, value, count);
                    return value;
                }
            case EntryType.Single:
                if (count == 1)
                {
                    return _byteConverter.ToSingle(_exifBuffer[offset.Value..].Span);
                }
                else
                {
                    var value = new float[count];
                    int valueOffset = ReadOffsetAndValidateNewRange(offset, count * sizeof(float));
                    _byteConverter.CopyTo(_exifBuffer[valueOffset..].Span, value, count);
                    return value;
                }
            case EntryType.Double:
                if (count == 1)
                {
                    return _byteConverter.ToDouble(_exifBuffer[offset.Value..].Span);
                }
                else
                {
                    var value = new double[count];
                    int valueOffset = ReadOffsetAndValidateNewRange(offset, count * sizeof(double));
                    _byteConverter.CopyTo(_exifBuffer[valueOffset..].Span, value, count);
                    return value;
                }
            case EntryType.Ascii:
                {
                    int valueOffset = count <= 4 ? offset : ReadOffsetAndValidateNewRange(offset, count);
                    if (count > int.MaxValue)
                    {
                        throw new ExifException("Unsupported string length.");
                    }
                    return Encoding.ASCII.GetNullTerminatedString(_exifBuffer.Slice(valueOffset, count).Span, out _);
                }
            case EntryType.UnsignedRational:
                if (count == 1)
                {
                    int valueOffset = ReadOffsetAndValidateNewRange(offset, 2 * sizeof(uint));
                    return new UnsignedRational(
                        _byteConverter.ToUInt32(_exifBuffer[valueOffset..].Span),
                        _byteConverter.ToUInt32(_exifBuffer[(valueOffset + sizeof(uint))..].Span));
                }
                else
                {
                    int valueOffset = ReadOffsetAndValidateNewRange(offset, 2 * sizeof(uint));
                    var value = new UnsignedRational[count];
                    for (int i = 0; i < count; i++, valueOffset += (2 * sizeof(int)))
                    {
                        value[i] = new UnsignedRational(
                            _byteConverter.ToUInt32(_exifBuffer[valueOffset..].Span),
                            _byteConverter.ToUInt32(_exifBuffer[(valueOffset + sizeof(uint))..].Span));
                    }
                    return value;
                }
            case EntryType.SignedRational:
                if (count == 1)
                {
                    int valueOffset = ReadOffsetAndValidateNewRange(offset, 2 * sizeof(int));
                    return new SignedRational(
                        _byteConverter.ToInt32(_exifBuffer[valueOffset..].Span),
                        _byteConverter.ToInt32(_exifBuffer[(valueOffset + sizeof(int))..].Span));
                }
                else
                {
                    int valueOffset = ReadOffsetAndValidateNewRange(offset, 2 * sizeof(int));
                    var value = new SignedRational[count];
                    for (int i = 0; i < count; i++, valueOffset += (2 * sizeof(int)))
                    {
                        value[i] = new SignedRational(
                            _byteConverter.ToInt32(_exifBuffer[valueOffset..].Span),
                            _byteConverter.ToInt32(_exifBuffer[(valueOffset + sizeof(int))..].Span));
                    }
                    return value;
                }
            default:
                throw new ExifException($"Unsupported IFD type \"{type}\" (Tag={tag}).");
        }
    }

    /// <summary>
    /// Reads an offset at a specified offset. Once the offset is read, the specified number of bytes is validated to be at the new offset.
    /// </summary>
    /// <param name="offset">
    /// The offset containing pointer offset to read.
    /// </param>
    /// <param name="byteCount">
    /// The number of bytes to validate at the new offset.
    /// </param>
    /// <returns>
    /// The offset read at the specified offset.
    /// </returns>
    private ScopedOffset ReadOffsetAndValidateNewRange(ScopedOffset offset, int byteCount)
    {
        // Read the new offset at the specified offset.
        int newRelativeOffset = _byteConverter.ToInt32(_exifBuffer[offset.Value..].Span);

        // Validate the byte range at the new offset.
        ScopedOffset newOffset = ValidateRange(new ScopedOffset(offset.AbsoluteOffset, newRelativeOffset), byteCount);

        // Track the new offset.
        _offsets.Add(newOffset);
        if (byteCount > 0)
        {
            _offsets.Add(newOffset + byteCount);
        }
        return newOffset;
    }

    /// <summary>
    /// Validates the byte range within the EXIF buffer.
    /// </summary>
    /// <param name="offset">
    /// The beginning offset of the byte range to validate.
    /// </param>
    /// <param name="byteCount">
    /// The length of the byte range to validate. This may be zero to validate the offset.
    /// </param>
    /// <returns>
    /// Returns the value of offset.
    /// </returns>
    private ScopedOffset ValidateRange(ScopedOffset offset, int byteCount) => ValidateRange(_exifBuffer, offset, byteCount);

    /// <summary>
    /// Validates the byte range within the specified EXIF buffer.
    /// </summary>
    /// <param name="exifBuffer">
    /// The EXIF buffer to validate against the byte range.
    /// </param>
    /// <param name="offset">
    /// The beginning offset of the byte range to validate.
    /// </param>
    /// <param name="byteCount">
    /// The length of the byte range to validate. This may be zero to validate the offset.
    /// </param>
    /// <returns>
    /// Returns the value of offset.
    /// </returns>
    public static ScopedOffset ValidateRange(ReadOnlyMemory<byte> exifBuffer, ScopedOffset offset, int byteCount)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(byteCount);
        if (offset < 0 || offset > exifBuffer.Length || byteCount > exifBuffer.Length - offset)
        {
            throw new ExifException("The range reference is outside the available EXIF buffer.");
        }
        return offset;
    }
}