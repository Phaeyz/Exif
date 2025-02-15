using System.Buffers;
using System.Text;
using Phaeyz.Marshalling;

namespace Phaeyz.Exif;

/// <summary>
/// Serializes EXIF metadata to a new memory stream.
/// </summary>
internal class ImageFileDirectorySerializer
{
    /// <summary>
    /// The ByteConverter to use when serializing multi-byte values.
    /// </summary>
    private ByteConverter ByteConverter { get; set; }

    /// <summary>
    /// Serialize tasks which are not IFDs. These are prioritized over the IFD serialization tasks.
    /// </summary>
    private Queue<SerializeTask> StandardSerializeQueue { get; } = [];

    /// <summary>
    /// Serialize tasks for IFDs. These have less prioritization than standard serialize tasks.
    /// </summary>
    private Queue<SerializeTask> DirectorySerializeQueue { get; } = [];

    /// <summary>
    /// THe stream the EXIF metadata being serialized to.
    /// </summary>
    private MemoryStream Stream { get; } = new();

    /// <summary>
    /// Creates and initializes a new instance of the <see cref="Phaeyz.Exif.ImageFileDirectorySerializer"/> class.
    /// </summary>
    /// <param name="exifMetadata">
    /// The EXIF metadata to serialize.
    /// </param>
    /// <exception cref="Phaeyz.Exif.ExifException">
    /// The EXIF byte order mode is invalid.
    /// </exception>
    private ImageFileDirectorySerializer(ExifMetadata exifMetadata)
    {
        // Get the byte converter from the byte order mode.
        ByteConverter = exifMetadata.ByteOrderMode == ByteOrderMode.BigEndian
            ? ByteConverter.BigEndian
            : exifMetadata.ByteOrderMode == ByteOrderMode.LittleEndian
            ? ByteConverter.LittleEndian
            : throw new ExifException("Invalid EXIF byte order mode.");
    }

    /// <summary>
    /// Determines whether or not the entry is an offset-and-length-pair entry.
    /// </summary>
    /// <param name="entry">
    /// The entry to determine whether or not it is an offset-and-length-pair entry.
    /// </param>
    /// <returns>
    /// <c>true</c> if the entry is an offset-and-length-pair entry; otherwise, <c>false</c>.
    /// </returns>
    private static bool IsEntryOffsetAndLengthPair(Entry entry) =>
        entry.Tag.Behavior == TagBehavior.OffsetAndLengthPair &&
        entry.Tag.Related is not null &&
        entry.Type == EntryType.ByteSequence &&
        entry.Value is IEnumerable<byte>;

    /// <summary>
    /// Reserves a pointer offset where a new serialization task may be enqueued.
    /// </summary>
    /// <param name="relativeToAbsoluteOffset">
    /// An absolute offset which pointers are relative to.
    /// </param>
    /// <returns>
    /// A scoped offset to where the pointer value will be written.
    /// </returns>
    private ScopedOffset ReservePointerOffset(int relativeToAbsoluteOffset)
    {
        ScopedOffset offset = new(relativeToAbsoluteOffset, (int)Stream.Position - relativeToAbsoluteOffset);
        Stream.Seek(4, SeekOrigin.Current);
        return offset;
    }

    #region Serialize

    /// <summary>
    /// Serializes the EXIF metadata to a new memory stream.
    /// </summary>
    /// <param name="exifMetadata">
    /// The EXIF metadata to serialize.
    /// </param>
    /// <returns>
    /// The memory stream containing the serialized EXIF metadata.
    /// </returns>
    public static MemoryStream Serialize(ExifMetadata exifMetadata)
    {
        ArgumentNullException.ThrowIfNull(exifMetadata);

        ImageFileDirectorySerializer serializer = new(exifMetadata);

        // Serialize the EXIF header
        serializer.Stream.WriteUInt16((ushort)exifMetadata.ByteOrderMode, serializer.ByteConverter);
        serializer.Stream.WriteUInt16(ExifMetadata.MagicNumber, serializer.ByteConverter);

        // Enqueue the first image file directory for serialization.
        serializer.DirectorySerializeQueue.Enqueue(new()
        {
            PointerOffset = serializer.ReservePointerOffset(0),
            Serialize = relativeToAbsoluteOffset => serializer.Serialize(relativeToAbsoluteOffset, exifMetadata, 0)
        });

        // This is the working loop keeps serializing and keeps tracks of pointers until there are no more tasks.
        while (true)
        {
            // Get the next task, prioritizing non-IFDs first.
            SerializeTask serializeTask;
            if (serializer.StandardSerializeQueue.Count > 0)
            {
                serializeTask = serializer.StandardSerializeQueue.Dequeue();
            }
            else if (serializer.DirectorySerializeQueue.Count > 0)
            {
                serializeTask = serializer.DirectorySerializeQueue.Dequeue();
            }
            else
            {
                // Exit the loop when there are no more tasks.
                break;
            }

            // Get the current stream position because this is where the content will be serialized to.
            // But before we serialized, we need to seek back to the pointer offset.
            int streamPosition = (int)serializer.Stream.Position;

            // Serialize the pointer offset and then the content.
            serializer.Stream.Position = serializeTask.PointerOffset;
            serializer.Stream.WriteInt32(streamPosition - serializeTask.PointerOffset.AbsoluteOffset, serializer.ByteConverter);

            // Now restore the original position and begin serialization of the task.
            serializer.Stream.Position = streamPosition;
            serializeTask.Serialize(serializeTask.ScopeOffset ? streamPosition : serializeTask.PointerOffset.AbsoluteOffset);
        }

        // No more tasks, so reset the stream position and give it to the caller.
        serializer.Stream.Position = 0;
        return serializer.Stream;
    }

    private void Serialize(
        int relativeToAbsoluteOffset,
        ImageFileDirectoryCollection imageFileDirectoryCollection,
        int ifdIndex)
    {
        // Get the current IFD being serialized in this collection.
        ImageFileDirectory imageFileDirectory = imageFileDirectoryCollection[ifdIndex];

        // Serialize the number of entries in the image file directory. Make sure to account for the fact that
        // offset-and-length-pair entries will be serialized as two entries.
        int serializeCount = imageFileDirectory.Count + imageFileDirectory.Count(kvp => IsEntryOffsetAndLengthPair(kvp.Value));
        Stream.WriteUInt16((ushort)serializeCount, ByteConverter);

        // Serialize each entry in the image file directory.
        foreach ((Tag tag, Entry entry) in imageFileDirectory)
        {
            SerializeEntry(relativeToAbsoluteOffset, entry);
        }

        // If there is a subsequent IFD, enqueue it for serialization.
        if (ifdIndex + 1 < imageFileDirectoryCollection.Count)
        {
            DirectorySerializeQueue.Enqueue(new()
            {
                PointerOffset = ReservePointerOffset(relativeToAbsoluteOffset),
                Serialize = relativeToAbsoluteOffset => Serialize(relativeToAbsoluteOffset, imageFileDirectoryCollection, ifdIndex + 1)
            });
        }
        else
        {
            // If this is the last IFD in the collection, write a zero offset to indicate the end of the IFD chain.
            Stream.WriteUInt32(0, ByteConverter);
        }
    }

    #endregion Serialize

    #region SerializeEntry

    /// <summary>
    /// Serializes an entry by testing the type and routing to the correct serialization method.
    /// </summary>
    /// <param name="relativeToAbsoluteOffset">
    /// An absolute offset which pointers are relative to.
    /// </param>
    /// <param name="entry">
    /// The entry to serialize.
    /// </param>
    /// <exception cref="Phaeyz.Exif.ExifException">
    /// The entry value is null, the type is not supported, or the entry value is a zero-length enumerable.
    /// </exception>
    private void SerializeEntry(int relativeToAbsoluteOffset, Entry entry)
    {
        if (entry.Value is null)
        {
            throw new ExifException($"An entry value is null (Tag={entry.Tag}).");
        }

        if (entry.Tag.Behavior == TagBehavior.IfdPointer || entry.Tag.Behavior == TagBehavior.ScopedIfdPointer)
        {
            SerializeEntryImageFileDirectories(relativeToAbsoluteOffset, entry);
            return;
        }

        switch (entry.Type)
        {
            case EntryType.Byte:
            case EntryType.ByteSequence:
                SerializeEntryByte(relativeToAbsoluteOffset, entry);
                break;
            case EntryType.SByte:
                SerializeEntrySByte(relativeToAbsoluteOffset, entry);
                break;
            case EntryType.UInt16:
                SerializeEntryUInt16(relativeToAbsoluteOffset, entry);
                break;
            case EntryType.Int16:
                SerializeEntryInt16(relativeToAbsoluteOffset, entry);
                break;
            case EntryType.UInt32:
                SerializeEntryUInt32(relativeToAbsoluteOffset, entry);
                break;
            case EntryType.Int32:
                SerializeEntryInt32(relativeToAbsoluteOffset, entry);
                break;
            case EntryType.Single:
                SerializeEntrySingle(relativeToAbsoluteOffset, entry);
                break;
            case EntryType.Double:
                SerializeEntryDouble(relativeToAbsoluteOffset, entry);
                break;
            case EntryType.Ascii:
                SerializeEntryAsciiString(relativeToAbsoluteOffset, entry);
                break;
            case EntryType.UnsignedRational:
                SerializeEntryUnsignedRational(relativeToAbsoluteOffset, entry);
                break;
            case EntryType.SignedRational:
                SerializeEntrySignedRational(relativeToAbsoluteOffset, entry);
                break;
            default:
                throw new ExifException($"Unsupported IFD type \"{entry.Type}\" (Tag={entry.Tag}).");
        }
    }

    #endregion SerializeEntry

    #region SerializeEntryByte

    /// <summary>
    /// Serializes an entry with a <c>byte</c> or <c>byte</c> sequence value.
    /// </summary>
    /// <param name="relativeToAbsoluteOffset">
    /// An absolute offset which pointers are relative to.
    /// </param>
    /// <param name="entry">
    /// The entry to serialize.
    /// </param>
    /// <exception cref="Phaeyz.Exif.ExifException">
    /// The entry value is a zero-length enumerable.
    /// </exception>
    private void SerializeEntryByte(int relativeToAbsoluteOffset, Entry entry)
    {
        bool isPreservedDataBlock =
            entry.Tag.Behavior == TagBehavior.PreserveDataBlock &&
            entry.Type == EntryType.ByteSequence &&
            entry.Value is IEnumerable<byte>;

        bool isOffsetAndLengthPair = IsEntryOffsetAndLengthPair(entry);

        Stream.WriteUInt16(entry.Tag.Value, ByteConverter);
        Stream.WriteUInt16((ushort)(isPreservedDataBlock || isOffsetAndLengthPair ? EntryType.UInt32 : entry.Type), ByteConverter);

        if (entry.Value is IEnumerable<byte> values)
        {
            int count = values.Count();
            if (count == 0)
            {
                throw new ExifException($"An entry value has zero elements (Tag={entry.Tag}).");
            }
            Stream.WriteInt32(isPreservedDataBlock || isOffsetAndLengthPair ? 1 : count, ByteConverter);
            if (!isPreservedDataBlock && !isOffsetAndLengthPair && count <= 4)
            {
                foreach (byte value in values)
                {
                    Stream.WriteUInt8(value);
                }
                Stream.Seek(4 - count, SeekOrigin.Current);
            }
            else
            {
                StandardSerializeQueue.Enqueue(new()
                {
                    PointerOffset = ReservePointerOffset(relativeToAbsoluteOffset),
                    Serialize = relativeToAbsoluteOffset =>
                    {
                        foreach (byte value in values)
                        {
                            Stream.WriteUInt8(value);
                        }
                    }
                });

                if (isOffsetAndLengthPair)
                {
                    Stream.WriteUInt16(entry.Tag.Related!.Value, ByteConverter);
                    Stream.WriteUInt16((ushort)EntryType.UInt32, ByteConverter);
                    Stream.WriteInt32(1, ByteConverter);
                    Stream.WriteUInt32((uint)count, ByteConverter);
                }
            }
        }
        else
        {
            Stream.WriteInt32(1, ByteConverter);
            Stream.WriteUInt8((byte)entry.Value);
            Stream.Seek(3, SeekOrigin.Current);
        }
    }

    #endregion SerializeEntryByte

    #region SerializeEntrySByte

    /// <summary>
    /// Serializes an entry with a <c>sbyte</c> or <c>sbyte</c> enumerable.
    /// </summary>
    /// <param name="relativeToAbsoluteOffset">
    /// An absolute offset which pointers are relative to.
    /// </param>
    /// <param name="entry">
    /// The entry to serialize.
    /// </param>
    /// <exception cref="Phaeyz.Exif.ExifException">
    /// The entry value is a zero-length enumerable.
    /// </exception>
    private void SerializeEntrySByte(int relativeToAbsoluteOffset, Entry entry)
    {
        Stream.WriteUInt16(entry.Tag.Value, ByteConverter);
        Stream.WriteUInt16((ushort)entry.Type, ByteConverter);

        if (entry.Value is IEnumerable<sbyte> values)
        {
            int count = values.Count();
            if (count == 0)
            {
                throw new ExifException($"An entry value has zero elements (Tag={entry.Tag}).");
            }
            Stream.WriteInt32(count, ByteConverter);
            if (count <= 4)
            {
                foreach (sbyte value in values)
                {
                    Stream.WriteInt8(value);
                }
                Stream.Seek(4 - count, SeekOrigin.Current);
            }
            else
            {
                StandardSerializeQueue.Enqueue(new()
                {
                    PointerOffset = ReservePointerOffset(relativeToAbsoluteOffset),
                    Serialize = relativeToAbsoluteOffset =>
                    {
                        foreach (sbyte value in values)
                        {
                            Stream.WriteInt8(value);
                        }
                    }
                });
            }
        }
        else
        {
            Stream.WriteInt32(1, ByteConverter);
            Stream.WriteInt8((sbyte)entry.Value);
            Stream.Seek(3, SeekOrigin.Current);
        }
    }

    #endregion SerializeEntrySByte

    #region SerializeEntryUInt16

    /// <summary>
    /// Serializes an entry with a <c>ushort</c> or <c>ushort</c> enumerable.
    /// </summary>
    /// <param name="relativeToAbsoluteOffset">
    /// An absolute offset which pointers are relative to.
    /// </param>
    /// <param name="entry">
    /// The entry to serialize.
    /// </param>
    /// <exception cref="Phaeyz.Exif.ExifException">
    /// The entry value is a zero-length enumerable.
    /// </exception>
    private void SerializeEntryUInt16(int relativeToAbsoluteOffset, Entry entry)
    {
        Stream.WriteUInt16(entry.Tag.Value, ByteConverter);
        Stream.WriteUInt16((ushort)entry.Type, ByteConverter);

        if (entry.Value is IEnumerable<ushort> values)
        {
            int count = values.Count();
            if (count == 0)
            {
                throw new ExifException($"An entry value has zero elements (Tag={entry.Tag}).");
            }
            Stream.WriteInt32(count, ByteConverter);
            if (count <= 2)
            {
                foreach (ushort value in values)
                {
                    Stream.WriteUInt16(value, ByteConverter);
                }
                Stream.Seek(count == 1 ? 2 : 0, SeekOrigin.Current);
            }
            else
            {
                StandardSerializeQueue.Enqueue(new()
                {
                    PointerOffset = ReservePointerOffset(relativeToAbsoluteOffset),
                    Serialize = relativeToAbsoluteOffset =>
                    {
                        foreach (ushort value in values)
                        {
                            Stream.WriteUInt16(value, ByteConverter);
                        }
                    }
                });
            }
        }
        else
        {
            Stream.WriteInt32(1, ByteConverter);
            Stream.WriteUInt16((ushort)entry.Value, ByteConverter);
            Stream.Seek(2, SeekOrigin.Current);
        }
    }

    #endregion SerializeEntryUInt16

    #region SerializeEntryInt16

    /// <summary>
    /// Serializes an entry with a <c>short</c> or <c>short</c> enumerable.
    /// </summary>
    /// <param name="relativeToAbsoluteOffset">
    /// An absolute offset which pointers are relative to.
    /// </param>
    /// <param name="entry">
    /// The entry to serialize.
    /// </param>
    /// <exception cref="Phaeyz.Exif.ExifException">
    /// The entry value is a zero-length enumerable.
    /// </exception>
    private void SerializeEntryInt16(int relativeToAbsoluteOffset, Entry entry)
    {
        Stream.WriteUInt16(entry.Tag.Value, ByteConverter);
        Stream.WriteUInt16((ushort)entry.Type, ByteConverter);

        if (entry.Value is IEnumerable<short> values)
        {
            int count = values.Count();
            if (count == 0)
            {
                throw new ExifException($"An entry value has zero elements (Tag={entry.Tag}).");
            }
            Stream.WriteInt32(count, ByteConverter);
            if (count <= 2)
            {
                foreach (short value in values)
                {
                    Stream.WriteInt16(value, ByteConverter);
                }
                Stream.Seek(count == 1 ? 2 : 0, SeekOrigin.Current);
            }
            else
            {
                StandardSerializeQueue.Enqueue(new()
                {
                    PointerOffset = ReservePointerOffset(relativeToAbsoluteOffset),
                    Serialize = relativeToAbsoluteOffset =>
                    {
                        foreach (short value in values)
                        {
                            Stream.WriteInt16(value, ByteConverter);
                        }
                    }
                });
            }
        }
        else
        {
            Stream.WriteInt32(1, ByteConverter);
            Stream.WriteInt16((short)entry.Value, ByteConverter);
            Stream.Seek(2, SeekOrigin.Current);
        }
    }

    #endregion SerializeEntryInt16

    #region SerializeEntryUInt32

    /// <summary>
    /// Serializes an entry with a <c>uint</c> or <c>uint</c> enumerable.
    /// </summary>
    /// <param name="relativeToAbsoluteOffset">
    /// An absolute offset which pointers are relative to.
    /// </param>
    /// <param name="entry">
    /// The entry to serialize.
    /// </param>
    /// <exception cref="Phaeyz.Exif.ExifException">
    /// The entry value is a zero-length enumerable.
    /// </exception>
    private void SerializeEntryUInt32(int relativeToAbsoluteOffset, Entry entry)
    {
        Stream.WriteUInt16(entry.Tag.Value, ByteConverter);
        Stream.WriteUInt16((ushort)entry.Type, ByteConverter);

        if (entry.Value is IEnumerable<uint> values)
        {
            int count = values.Count();
            if (count == 0)
            {
                throw new ExifException($"An entry value has zero elements (Tag={entry.Tag}).");
            }
            Stream.WriteInt32(count, ByteConverter);
            if (count == 1)
            {
                Stream.WriteUInt32(values.First(), ByteConverter);
            }
            else
            {
                StandardSerializeQueue.Enqueue(new()
                {
                    PointerOffset = ReservePointerOffset(relativeToAbsoluteOffset),
                    Serialize = relativeToAbsoluteOffset =>
                    {
                        foreach (uint value in values)
                        {
                            Stream.WriteUInt32(value, ByteConverter);
                        }
                    }
                });
            }
        }
        else
        {
            Stream.WriteInt32(1, ByteConverter);
            Stream.WriteUInt32((uint)entry.Value, ByteConverter);
        }
    }

    #endregion SerializeEntryUInt32

    #region SerializeEntryInt32

    /// <summary>
    /// Serializes an entry with a <c>int</c> or <c>int</c> enumerable.
    /// </summary>
    /// <param name="relativeToAbsoluteOffset">
    /// An absolute offset which pointers are relative to.
    /// </param>
    /// <param name="entry">
    /// The entry to serialize.
    /// </param>
    /// <exception cref="Phaeyz.Exif.ExifException">
    /// The entry value is a zero-length enumerable.
    /// </exception>
    private void SerializeEntryInt32(int relativeToAbsoluteOffset, Entry entry)
    {
        Stream.WriteUInt16(entry.Tag.Value, ByteConverter);
        Stream.WriteUInt16((ushort)entry.Type, ByteConverter);

        if (entry.Value is IEnumerable<int> values)
        {
            int count = values.Count();
            if (count == 0)
            {
                throw new ExifException($"An entry value has zero elements (Tag={entry.Tag}).");
            }
            Stream.WriteInt32(count, ByteConverter);
            if (count == 1)
            {
                Stream.WriteInt32(values.First(), ByteConverter);
            }
            else
            {
                StandardSerializeQueue.Enqueue(new()
                {
                    PointerOffset = ReservePointerOffset(relativeToAbsoluteOffset),
                    Serialize = relativeToAbsoluteOffset =>
                    {
                        foreach (int value in values)
                        {
                            Stream.WriteInt32(value, ByteConverter);
                        }
                    }
                });
            }
        }
        else
        {
            Stream.WriteInt32(1, ByteConverter);
            Stream.WriteInt32((int)entry.Value, ByteConverter);
        }
    }

    #endregion SerializeEntryInt32

    #region SerializeEntrySingle

    /// <summary>
    /// Serializes an entry with a <c>float</c> or <c>float</c> enumerable.
    /// </summary>
    /// <param name="relativeToAbsoluteOffset">
    /// An absolute offset which pointers are relative to.
    /// </param>
    /// <param name="entry">
    /// The entry to serialize.
    /// </param>
    /// <exception cref="Phaeyz.Exif.ExifException">
    /// The entry value is a zero-length enumerable.
    /// </exception>
    private void SerializeEntrySingle(int relativeToAbsoluteOffset, Entry entry)
    {
        Stream.WriteUInt16(entry.Tag.Value, ByteConverter);
        Stream.WriteUInt16((ushort)entry.Type, ByteConverter);

        if (entry.Value is IEnumerable<float> values)
        {
            int count = values.Count();
            if (count == 0)
            {
                throw new ExifException($"An entry value has zero elements (Tag={entry.Tag}).");
            }
            Stream.WriteInt32(count, ByteConverter);
            if (count == 1)
            {
                Stream.WriteSingle(values.First());
            }
            else
            {
                StandardSerializeQueue.Enqueue(new()
                {
                    PointerOffset = ReservePointerOffset(relativeToAbsoluteOffset),
                    Serialize = relativeToAbsoluteOffset =>
                    {
                        foreach (float value in values)
                        {
                            Stream.WriteSingle(value, ByteConverter);
                        }
                    }
                });
            }
        }
        else
        {
            Stream.WriteInt32(1, ByteConverter);
            Stream.WriteSingle((float)entry.Value, ByteConverter);
        }
    }

    #endregion SerializeEntrySingle

    #region SerializeEntryDouble

    /// <summary>
    /// Serializes an entry with a <c>double</c> or <c>double</c> enumerable.
    /// </summary>
    /// <param name="relativeToAbsoluteOffset">
    /// An absolute offset which pointers are relative to.
    /// </param>
    /// <param name="entry">
    /// The entry to serialize.
    /// </param>
    /// <exception cref="Phaeyz.Exif.ExifException">
    /// The entry value is a zero-length enumerable.
    /// </exception>
    private void SerializeEntryDouble(int relativeToAbsoluteOffset, Entry entry)
    {
        Stream.WriteUInt16(entry.Tag.Value, ByteConverter);
        Stream.WriteUInt16((ushort)entry.Type, ByteConverter);

        if (entry.Value is IEnumerable<double> values)
        {
            int count = values.Count();
            if (count == 0)
            {
                throw new ExifException($"An entry value has zero elements (Tag={entry.Tag}).");
            }
            Stream.WriteInt32(count, ByteConverter);
            StandardSerializeQueue.Enqueue(new()
            {
                PointerOffset = ReservePointerOffset(relativeToAbsoluteOffset),
                Serialize = relativeToAbsoluteOffset =>
                {
                    foreach (double value in values)
                    {
                        Stream.WriteDouble(value, ByteConverter);
                    }
                }
            });
        }
        else
        {
            Stream.WriteInt32(1, ByteConverter);
            StandardSerializeQueue.Enqueue(new()
            {
                PointerOffset = ReservePointerOffset(relativeToAbsoluteOffset),
                Serialize = relativeToAbsoluteOffset =>
                {
                    Stream.WriteDouble((double)entry.Value, ByteConverter);
                }
            });
        }
    }

    #endregion SerializeEntryDouble

    #region SerializeEntryAsciiString

    /// <summary>
    /// Serializes an entry with an ASCII string.
    /// </summary>
    /// <param name="relativeToAbsoluteOffset">
    /// An absolute offset which pointers are relative to.
    /// </param>
    /// <param name="entry">
    /// The entry to serialize.
    /// </param>
    private void SerializeEntryAsciiString(int relativeToAbsoluteOffset, Entry entry)
    {
        Stream.WriteUInt16(entry.Tag.Value, ByteConverter);
        Stream.WriteUInt16((ushort)entry.Type, ByteConverter);

        string stringValue = (string)entry.Value;
        int bufferLength = stringValue.Length + 1;
        bool returnBuffer = true;
        byte[] buffer = ArrayPool<byte>.Shared.Rent(bufferLength);
        try
        {
            Encoding.ASCII.GetBytes(stringValue, buffer.AsSpan());
            buffer[bufferLength - 1] = 0;
            Stream.WriteInt32(bufferLength, ByteConverter);
            if (bufferLength <= 4)
            {
                for (int i = 0; i < bufferLength; i++)
                {
                    Stream.WriteUInt8(buffer[i]);
                }
                Stream.Seek(4 - bufferLength, SeekOrigin.Current);
            }
            else
            {
                StandardSerializeQueue.Enqueue(new()
                {
                    PointerOffset = ReservePointerOffset(relativeToAbsoluteOffset),
                    Serialize = relativeToAbsoluteOffset =>
                    {
                        try
                        {
                            for (int i = 0; i < bufferLength; i++)
                            {
                                Stream.WriteUInt8(buffer[i]);
                            }
                        }
                        finally
                        {
                            ArrayPool<byte>.Shared.Return(buffer);
                        }
                    }
                });
                returnBuffer = false;
            }
        }
        finally
        {
            if (returnBuffer)
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }
    }

    #endregion SerializeEntryAsciiString

    #region SerializeEntryUnsignedRational

    /// <summary>
    /// Serializes an entry with an unsigned rational or an unsigned rational enumerable.
    /// </summary>
    /// <param name="relativeToAbsoluteOffset">
    /// An absolute offset which pointers are relative to.
    /// </param>
    /// <param name="entry">
    /// The entry to serialize.
    /// </param>
    /// <exception cref="Phaeyz.Exif.ExifException">
    /// The entry value is a zero-length enumerable.
    /// </exception>
    private void SerializeEntryUnsignedRational(int relativeToAbsoluteOffset, Entry entry)
    {
        Stream.WriteUInt16(entry.Tag.Value, ByteConverter);
        Stream.WriteUInt16((ushort)entry.Type, ByteConverter);

        if (entry.Value is IEnumerable<UnsignedRational> values)
        {
            int count = values.Count();
            if (count == 0)
            {
                throw new ExifException($"An entry value has zero elements (Tag={entry.Tag}).");
            }
            Stream.WriteInt32(count, ByteConverter);
            StandardSerializeQueue.Enqueue(new()
            {
                PointerOffset = ReservePointerOffset(relativeToAbsoluteOffset),
                Serialize = relativeToAbsoluteOffset =>
                {
                    foreach (UnsignedRational value in values)
                    {
                        Stream.WriteUInt32(value.Numerator, ByteConverter);
                        Stream.WriteUInt32(value.Denominator, ByteConverter);
                    }
                }
            });
        }
        else
        {
            Stream.WriteInt32(1, ByteConverter);
            StandardSerializeQueue.Enqueue(new()
            {
                PointerOffset = ReservePointerOffset(relativeToAbsoluteOffset),
                Serialize = relativeToAbsoluteOffset =>
                {
                    UnsignedRational value = (UnsignedRational)entry.Value;
                    Stream.WriteUInt32(value.Numerator, ByteConverter);
                    Stream.WriteUInt32(value.Denominator, ByteConverter);
                }
            });
        }
    }

    #endregion SerializeEntryUnsignedRational

    #region SerializeEntrySignedRational

    /// <summary>
    /// Serializes an entry with a signed rational or a signed rational enumerable.
    /// </summary>
    /// <param name="relativeToAbsoluteOffset">
    /// An absolute offset which pointers are relative to.
    /// </param>
    /// <param name="entry">
    /// The entry to serialize.
    /// </param>
    /// <exception cref="Phaeyz.Exif.ExifException">
    /// The entry value is a zero-length enumerable.
    /// </exception>
    private void SerializeEntrySignedRational(int relativeToAbsoluteOffset, Entry entry)
    {
        Stream.WriteUInt16(entry.Tag.Value, ByteConverter);
        Stream.WriteUInt16((ushort)entry.Type, ByteConverter);

        if (entry.Value is IEnumerable<SignedRational> values)
        {
            int count = values.Count();
            if (count == 0)
            {
                throw new ExifException($"An entry value has zero elements (Tag={entry.Tag}).");
            }
            Stream.WriteInt32(count, ByteConverter);
            StandardSerializeQueue.Enqueue(new()
            {
                PointerOffset = ReservePointerOffset(relativeToAbsoluteOffset),
                Serialize = relativeToAbsoluteOffset =>
                {
                    foreach (SignedRational value in values)
                    {
                        Stream.WriteInt32(value.Numerator, ByteConverter);
                        Stream.WriteInt32(value.Denominator, ByteConverter);
                    }
                }
            });
        }
        else
        {
            Stream.WriteInt32(1, ByteConverter);
            StandardSerializeQueue.Enqueue(new()
            {
                PointerOffset = ReservePointerOffset(relativeToAbsoluteOffset),
                Serialize = relativeToAbsoluteOffset =>
                {
                    SignedRational value = (SignedRational)entry.Value;
                    Stream.WriteInt32(value.Numerator, ByteConverter);
                    Stream.WriteInt32(value.Denominator, ByteConverter);
                }
            });
        }
    }

    #endregion SerializeEntrySignedRational

    #region SerializeEntryImageFileDirectories

    /// <summary>
    /// Serializes an entry with an unsigned rational or an unsigned rational enumerable.
    /// </summary>
    /// <param name="relativeToAbsoluteOffset">
    /// An absolute offset which pointers are relative to.
    /// </param>
    /// <param name="entry">
    /// The entry to serialize.
    /// </param>
    /// <exception cref="Phaeyz.Exif.ExifException">
    /// The entry value is a zero-length enumerable.
    /// </exception>
    private void SerializeEntryImageFileDirectories(int relativeToAbsoluteOffset, Entry entry)
    {
        Stream.WriteUInt16(entry.Tag.Value, ByteConverter);
        Stream.WriteUInt16((ushort)entry.Type, ByteConverter);

        if (entry.Value is IEnumerable<ImageFileDirectoryCollection> imageFileDirectories)
        {
            int count = imageFileDirectories.Count();
            if (count == 0)
            {
                throw new ExifException($"An entry value has zero elements (Tag={entry.Tag}).");
            }
            Stream.WriteInt32(count, ByteConverter);
            if (count == 1)
            {
                DirectorySerializeQueue.Enqueue(new()
                {
                    PointerOffset = ReservePointerOffset(relativeToAbsoluteOffset),
                    Serialize = relativeToAbsoluteOffset => Serialize(relativeToAbsoluteOffset, imageFileDirectories.First(), 0),
                    ScopeOffset = entry.Tag.Behavior == TagBehavior.ScopedIfdPointer
                });
            }
            else
            {
                // If there is more than one, the pointers must be written as an array of pointers (i.e. uints)
                // outside of the IFD as it won't fit in the IFD.
                StandardSerializeQueue.Enqueue(new()
                {
                    PointerOffset = ReservePointerOffset(relativeToAbsoluteOffset),
                    Serialize = relativeToAbsoluteOffset =>
                    {
                        foreach (ImageFileDirectoryCollection imageFileDirectoryCollection in imageFileDirectories)
                        {
                            DirectorySerializeQueue.Enqueue(new()
                            {
                                PointerOffset = ReservePointerOffset(relativeToAbsoluteOffset),
                                Serialize = relativeToAbsoluteOffset => Serialize(relativeToAbsoluteOffset, imageFileDirectoryCollection, 0),
                                ScopeOffset = entry.Tag.Behavior == TagBehavior.ScopedIfdPointer
                            });
                        }
                    }
                });
            }
        }
        else
        {
            Stream.WriteInt32(1, ByteConverter);
            DirectorySerializeQueue.Enqueue(new()
            {
                PointerOffset = ReservePointerOffset(relativeToAbsoluteOffset),
                Serialize = relativeToAbsoluteOffset => Serialize(relativeToAbsoluteOffset, (ImageFileDirectoryCollection)entry.Value, 0)
            });
        }
    }

    #endregion SerializeEntryImageFileDirectories

    /// <summary>
    /// A task containing instructions for writing a pointer value to a new serialization location.
    /// </summary>
    private struct SerializeTask
    {
        /// <summary>
        /// The offset where the pointer value should be written.
        /// </summary>
        public ScopedOffset PointerOffset { get; set; }

        /// <summary>
        /// A function which serializes content. The only parameter is the absolute offset all pointers should be relative to.
        /// </summary>
        public Action<int> Serialize { get; set; }

        /// <summary>
        /// Indicates the new serialization location should begin a new relative offset scope.
        /// </summary>
        public bool ScopeOffset { get; set; }
    }
}