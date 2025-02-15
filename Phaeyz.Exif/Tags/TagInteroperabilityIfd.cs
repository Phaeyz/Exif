namespace Phaeyz.Exif.Tags;

/// <summary>
/// Tags which may appear in the interopability image file directory.
/// </summary>
public class TagInteroperabilityIfd : Tag
{
    /// <summary>
    /// Indicates the identification of the Interoperability rule. Use "R98" for stating ExifR98 Rules. Four bytes used including the termination code (NULL). see the separate volume of Recommended Exif Interoperability Rules (ExifR98) for other tags used for ExifR98.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag InteropIndex = Create(TagExifIfd.InteroperabilityIfd, null, 0x0001, "InteropIndex", true, [("Exif.Iop.InteroperabilityIndex", "Iop")]);

    /// <summary>
    /// Indicates the identification of the Interoperability rule. Use "R98" for stating ExifR98 Rules. Four bytes used including the termination code (NULL). see the separate volume of Recommended Exif Interoperability Rules (ExifR98) for other tags used for ExifR98.
    /// </summary>
    /// <remarks>
    /// Expected type is Undefined.
    /// </remarks>
    public static readonly Tag InteropVersion = Create(TagExifIfd.InteroperabilityIfd, null, 0x0002, "InteropVersion", true, [("Exif.Iop.InteroperabilityVersion", "Iop")]);

    /// <summary>
    /// File format of image file
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag RelatedImageFileFormat = Create(TagExifIfd.InteroperabilityIfd, null, 0x1000, "RelatedImageFileFormat", true, [("Exif.Iop.RelatedImageFileFormat", "Iop")]);

    /// <summary>
    /// Image width
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag RelatedImageWidth = Create(TagExifIfd.InteroperabilityIfd, null, 0x1001, "RelatedImageWidth", true, [("Exif.Iop.RelatedImageWidth", "Iop")]);

    /// <summary>
    /// Image height
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag RelatedImageHeight = Create(TagExifIfd.InteroperabilityIfd, null, 0x1002, "RelatedImageHeight", true, [("Exif.Iop.RelatedImageLength", "Iop")]);
}
