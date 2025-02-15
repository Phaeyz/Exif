namespace Phaeyz.Exif;

/// <summary>
/// The type of an entry value.
/// </summary>
public enum EntryType : ushort
{
    /// <summary>
    /// A signed 8-bit value.
    /// </summary>
    Byte                                    = 1,

    /// <summary>
    /// A series of ASCII characters terminated by a NIL value.
    /// </summary>
    Ascii                                   = 2,

    /// <summary>
    /// An unsigned 16-bit value.
    /// </summary>
    UInt16                                  = 3,

    /// <summary>
    /// An unsigned 16-bit value.
    /// </summary>
    UInt32                                  = 4,

    /// <summary>
    /// Two unsigned 32-bit values (a numerator and a denominator) making a rational, rendered through the UnsignedRational type.
    /// </summary>
    UnsignedRational                        = 5,

    /// <summary>
    /// A signed 8-bit value.
    /// </summary>
    SByte                                   = 6,

    /// <summary>
    /// A sequence of uninterpreted bytes. In the EXIF spec this is the "UNKNOWN" type.
    /// </summary>
    /// <remarks>
    /// The only real difference between Byte with more than 1 count, and ByteSequence is semantics. Historically Byte
    /// usually refers to an actual 8-bit unsigned value, where ByteSequence (aka "UNKNOWN") is more like a buffer.
    /// </remarks>
    ByteSequence                            = 7,

    /// <summary>
    /// A signed 16-bit value.
    /// </summary>
    Int16                                   = 8,

    /// <summary>
    /// A signed 32-bit value.
    /// </summary>
    Int32                                   = 9,

    /// <summary>
    /// Two signed 32-bit values (a numerator and a denominator) making a rational, rendered through the SignedRational type.
    /// </summary>
    SignedRational                          = 10,

    /// <summary>
    /// A 32-bit floating-point value.
    /// </summary>
    Single                                  = 11,

    /// <summary>
    /// A 64-bit floating-point value.
    /// </summary>
    Double                                  = 12,
}