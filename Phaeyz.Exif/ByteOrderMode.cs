namespace Phaeyz.Exif;

/// <summary>
/// The byte-order mode embedded into EXIF metadata.
/// </summary>
public enum ByteOrderMode : ushort
{
    /// <summary>
    /// Little endian.
    /// </summary>
    LittleEndian    = 0x4949, // "II"

    /// <summary>
    /// Big endian.
    /// </summary>
    BigEndian       = 0x4D4D, // "MM"
}