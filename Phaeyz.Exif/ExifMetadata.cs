using Phaeyz.Marshalling;

namespace Phaeyz.Exif;

/// <summary>
/// A container used to store EXIF.
/// </summary>
public class ExifMetadata : ImageFileDirectoryCollection
{
    private ByteOrderMode _byteOrderMode = ByteOrderMode.BigEndian;

    /// <summary>
    /// A magic number expected to appear after the byte order mode, and used for validating the byte order mode.
    /// </summary>
    public const ushort MagicNumber = 0x002A;

    /// <summary>
    /// The byte order mode used when serializing the EXIF metadata.
    /// </summary>
    /// <remarks>
    /// This defaults to <see cref="Phaeyz.Exif.ByteOrderMode.BigEndian"/>, however when deserializing,
    /// the byte order mode defaults to what is read from the buffer.
    /// </remarks>
    public ByteOrderMode ByteOrderMode
    {
        get => _byteOrderMode;
        set
        {
            if (!Enum.IsDefined(value))
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            _byteOrderMode = value;
        }
    }

    /// <summary>
    /// Deserializes a buffer as EXIF metadata.
    /// </summary>
    /// <param name="exifBuffer">
    /// The buffer containing EXIF metadata.
    /// </param>
    /// <param name="tagProvider">
    /// A provider used for sourcing tag details required for deserialization instructions.
    /// If <c>null</c>, the default tag provider is used.
    /// </param>
    /// <returns>
    /// Returns the deserialized EXIF metadata.
    /// </returns>
    /// <exception cref="Phaeyz.Exif.ExifException">
    /// A deserialization error occurred indicating the buffer is not valid EXIF.
    /// </exception>
    public static ExifMetadata Deserialize(
        ReadOnlyMemory<byte> exifBuffer,
        TagProvider? tagProvider = null) => Deserialize(exifBuffer, tagProvider, out _);

    /// <summary>
    /// Deserializes a buffer as EXIF metadata.
    /// </summary>
    /// <param name="exifBuffer">
    /// The buffer containing EXIF metadata.
    /// </param>
    /// <param name="tagProvider">
    /// A provider used for sourcing tag details required for deserialization instructions.
    /// If <c>null</c>, the default tag provider is used.
    /// </param>
    /// <param name="cannotRoundTripEntries">
    /// On output, this receives a list of entries which, without intervention, may not round trip. This means if the image file directory
    /// collection is reserialized, these entries may not be valid. The default tag provider does not have any tags which are
    /// marked as "cannot round trip".
    /// </param>
    /// <returns>
    /// Returns the deserialized EXIF metadata.
    /// </returns>
    /// <exception cref="Phaeyz.Exif.ExifException">
    /// A deserialization error occurred indicating the buffer is not valid EXIF.
    /// </exception>
    public static ExifMetadata Deserialize(
        ReadOnlyMemory<byte> exifBuffer,
        TagProvider? tagProvider,
        out List<EntryReference> cannotRoundTripEntries)
    {
        // Use the default tag provider if one was not provided.
        tagProvider ??= TagProvider.Default;

        // Attempt to read the byte order mode.
        ImageFileDirectoryDeserializer.ValidateRange(exifBuffer, new(0, 0), 4);
        ByteOrderMode byteOrderMode = (ByteOrderMode)ByteConverter.SystemEndian.ToUInt16(exifBuffer.Span);

        // Get the byte converter from the byte order mode.
        ByteConverter byteConverter = byteOrderMode == ByteOrderMode.BigEndian
            ? ByteConverter.BigEndian
            : byteOrderMode == ByteOrderMode.LittleEndian
            ? ByteConverter.LittleEndian
            : throw new ExifException("Invalid EXIF byte order mode.");

        // Verify the byte order mode produced a valid magic number.
        ushort magicNumber = byteConverter.ToUInt16(exifBuffer[2..4].Span);
        if (magicNumber != MagicNumber)
        {
            throw new ExifException("Invalid EXIF does not have the required magic number.");
        }

        // Now deserialize.
        ExifMetadata exif = new()
        {
            ByteOrderMode = byteOrderMode
        };
        ImageFileDirectoryDeserializer.Deserialize(exif, exifBuffer, tagProvider, byteConverter, 4, true, out cannotRoundTripEntries);
        return exif;
    }

    /// <summary>
    /// Serializes the EXIF metadata to a new memory stream.
    /// </summary>
    /// <returns>
    /// The memory stream containing the serialized EXIF metadata.
    /// </returns>
    public MemoryStream Serialize() => ImageFileDirectorySerializer.Serialize(this);
}