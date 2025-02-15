namespace Phaeyz.Exif;

/// <summary>
/// Special behavior used during tag serialization and deserialization.
/// </summary>
public enum TagBehavior
{
    /// <summary>
    /// Only the root tag will have this behavior.
    /// </summary>
    Root = 0,

    /// <summary>
    /// Indicates an entry which cannot be serialized and deserialized round-tripped if there are modifications
    /// to either the EXIF or the image.
    /// </summary>
    CannotRoundTrip = 1,

    /// <summary>
    /// The tag is a UINT32 value which is an offset to data within the buffer, but the length is not not known.
    /// </summary>
    /// <remarks>
    /// In a best-effort attempt, during deserialization all offsets are tracked and a best effort is attempted in order to
    /// discern the size of the data block, and the value is surfaced like a byte sequence. During serialization a UINT32
    /// offset is written to the entry, and the data block is written like a byte sequence.
    /// </remarks>
    PreserveDataBlock = 2,

    /// <summary>
    /// Indicates no special behavior used when serializing or deserializing.
    /// </summary>
    StandardValue = 3,

    /// <summary>
    /// The tag is an array of UINT32 values which point to offsets starting a directory series.
    /// </summary>
    IfdPointer = 4,

    /// <summary>
    /// The tag is an array of UINT32 values which point to offsets starting a directory series. When parsing
    /// IFDs referenced by this pointer, the byte offset is reset to the byte offset.
    /// </summary>
    ScopedIfdPointer = 5,

    /// <summary>
    /// That tag is a UINT32 which points to an unknown byte sequence, and is related to another tag in the
    /// same directory which is a UINT32 which is the length of the byte sequence.
    /// </summary>
    OffsetAndLengthPair = 6,
}
