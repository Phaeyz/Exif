namespace Phaeyz.Exif.Tags;

/// <summary>
/// Tags which may appear in any root image file directory.
/// </summary>
public class TagIfd : Tag
{
    /// <summary>
    /// Indicates the identification of the Interoperability rule. Use "R98" for stating ExifR98 Rules. Four bytes used including the termination code (NULL). see the separate volume of Recommended Exif Interoperability Rules (ExifR98) for other tags used for ExifR98.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag ImageWidth = Create(Root, null, 0x0100, "ImageWidth", true, [("Exif.Image.ImageWidth", "Image")]);

    /// <summary>
    /// Indicates the identification of the Interoperability rule. Use "R98" for stating ExifR98 Rules. Four bytes used including the termination code (NULL). see the separate volume of Recommended Exif Interoperability Rules (ExifR98) for other tags used for ExifR98.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag ImageHeight = Create(Root, null, 0x0101, "ImageHeight", true, [("Exif.Image.ImageLength", "Image")]);

    /// <summary>
    /// Indicates the identification of the Interoperability rule. Use "R98" for stating ExifR98 Rules. Four bytes used including the termination code (NULL). see the separate volume of Recommended Exif Interoperability Rules (ExifR98) for other tags used for ExifR98.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16[n].
    /// </remarks>
    public static readonly Tag BitsPerSample = Create(Root, null, 0x0102, "BitsPerSample", true, [("Exif.Image.BitsPerSample", "Image")]);

    /// <summary>
    /// Indicates the identification of the Interoperability rule. Use "R98" for stating ExifR98 Rules. Four bytes used including the termination code (NULL). see the separate volume of Recommended Exif Interoperability Rules (ExifR98) for other tags used for ExifR98.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag Compression = Create(Root, null, 0x0103, "Compression", true, [("Exif.Image.Compression", "Image")]);

    /// <summary>
    /// Indicates the identification of the Interoperability rule. Use "R98" for stating ExifR98 Rules. Four bytes used including the termination code (NULL). see the separate volume of Recommended Exif Interoperability Rules (ExifR98) for other tags used for ExifR98.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag PhotometricInterpretation = Create(Root, null, 0x0106, "PhotometricInterpretation", true, [("Exif.Image.PhotometricInterpretation", "Image")]);

    /// <summary>
    /// Indicates the identification of the Interoperability rule. Use "R98" for stating ExifR98 Rules. Four bytes used including the termination code (NULL). see the separate volume of Recommended Exif Interoperability Rules (ExifR98) for other tags used for ExifR98.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag ImageDescription = Create(Root, null, 0x010E, "ImageDescription", true, [("Exif.Image.ImageDescription", "Image")]);

    /// <summary>
    /// Indicates the identification of the Interoperability rule. Use "R98" for stating ExifR98 Rules. Four bytes used including the termination code (NULL). see the separate volume of Recommended Exif Interoperability Rules (ExifR98) for other tags used for ExifR98.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag Make = Create(Root, null, 0x010F, "Make", true, [("Exif.Image.Make", "Image")]);

    /// <summary>
    /// Indicates the identification of the Interoperability rule. Use "R98" for stating ExifR98 Rules. Four bytes used including the termination code (NULL). see the separate volume of Recommended Exif Interoperability Rules (ExifR98) for other tags used for ExifR98.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag Model = Create(Root, null, 0x0110, "Model", true, [("Exif.Image.Model", "Image")]);

    /// <summary>
    /// Indicates the identification of the Interoperability rule. Use "R98" for stating ExifR98 Rules. Four bytes used including the termination code (NULL). see the separate volume of Recommended Exif Interoperability Rules (ExifR98) for other tags used for ExifR98.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag Orientation = Create(Root, null, 0x0112, "Orientation", true, [("Exif.Image.Orientation", "Image")]);

    /// <summary>
    /// Indicates the identification of the Interoperability rule. Use "R98" for stating ExifR98 Rules. Four bytes used including the termination code (NULL). see the separate volume of Recommended Exif Interoperability Rules (ExifR98) for other tags used for ExifR98.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag SamplesPerPixel = Create(Root, null, 0x0115, "SamplesPerPixel", true, [("Exif.Image.SamplesPerPixel", "Image")]);

    /// <summary>
    /// Indicates the identification of the Interoperability rule. Use "R98" for stating ExifR98 Rules. Four bytes used including the termination code (NULL). see the separate volume of Recommended Exif Interoperability Rules (ExifR98) for other tags used for ExifR98.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag RowsPerStrip = Create(Root, null, 0x0116, "RowsPerStrip", true, [("Exif.Image.RowsPerStrip", "Image")]);

    /// <summary>
    /// Indicates the identification of the Interoperability rule. Use "R98" for stating ExifR98 Rules. Four bytes used including the termination code (NULL). see the separate volume of Recommended Exif Interoperability Rules (ExifR98) for other tags used for ExifR98.
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag XResolution = Create(Root, null, 0x011A, "XResolution", true, [("Exif.Image.XResolution", "Image")]);

    /// <summary>
    /// The number of pixels per &lt;ResolutionUnit&gt; in the &lt;ImageLength&gt; direction. The same value as &lt;XResolution&gt; is designated.
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag YResolution = Create(Root, null, 0x011B, "YResolution", true, [("Exif.Image.YResolution", "Image")]);

    /// <summary>
    /// Indicates whether pixel components are recorded in a chunky or planar format. In JPEG compressed files a JPEG marker is used instead of this tag. If this field does not exist, the TIFF default of 1 (chunky) is assumed.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag PlanarConfiguration = Create(Root, null, 0x011C, "PlanarConfiguration", true, [("Exif.Image.PlanarConfiguration", "Image")]);

    /// <summary>
    /// The unit for measuring &lt;XResolution&gt; and &lt;YResolution&gt;. The same unit is used for both &lt;XResolution&gt; and &lt;YResolution&gt;. If the image resolution is unknown, 2 (inches) is designated.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag ResolutionUnit = Create(Root, null, 0x0128, "ResolutionUnit", true, [("Exif.Image.ResolutionUnit", "Image")]);

    /// <summary>
    /// A transfer function for the image, described in tabular style. Normally this tag is not necessary, since color space is specified in the color space information tag (&lt;ColorSpace&gt;).
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16[768].
    /// </remarks>
    public static readonly Tag TransferFunction = Create(Root, null, 0x012D, "TransferFunction", true, [("Exif.Image.TransferFunction", "Image")]);

    /// <summary>
    /// This tag records the name and version of the software or firmware of the camera or image input device used to generate the image. The detailed format is not specified, but it is recommended that the example shown below be followed. When the field is left blank, it is treated as unknown.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag Software = Create(Root, null, 0x0131, "Software", true, [("Exif.Image.Software", "Image")]);

    /// <summary>
    /// The date and time of image creation. In Exif standard, it is the date and time the file was changed.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag ModifyDate = Create(Root, null, 0x0132, "ModifyDate", true, [("Exif.Image.DateTime", "Image")]);

    /// <summary>
    /// This tag records the name of the camera owner, photographer or image creator. The detailed format is not specified, but it is recommended that the information be written as in the example below for ease of Interoperability. When the field is left blank, it is treated as unknown. Ex.) "Camera owner, John Smith; Photographer, Michael Brown; Image creator, Ken James"
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag Artist = Create(Root, null, 0x013B, "Artist", true, [("Exif.Image.Artist", "Image")]);

    /// <summary>
    /// The chromaticity of the white point of the image. Normally this tag is not necessary, since color space is specified in the colorspace information tag (&lt;ColorSpace&gt;).
    /// </summary>
    /// <remarks>
    /// Expected type is URational[2].
    /// </remarks>
    public static readonly Tag WhitePoint = Create(Root, null, 0x013E, "WhitePoint", true, [("Exif.Image.WhitePoint", "Image")]);

    /// <summary>
    /// The chromaticity of the three primary colors of the image. Normally this tag is not necessary, since colorspace is specified in the colorspace information tag (&lt;ColorSpace&gt;).
    /// </summary>
    /// <remarks>
    /// Expected type is URational[6].
    /// </remarks>
    public static readonly Tag PrimaryChromaticities = Create(Root, null, 0x013F, "PrimaryChromaticities", true, [("Exif.Image.PrimaryChromaticities", "Image")]);

    /// <summary>
    /// The offset to the start byte (SOI) of JPEG compressed thumbnail data. This is not used for primary image JPEG data.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag ThumbnailOffset = CreateOffsetAndLengthPair(Root, null, 0x0201, "ThumbnailOffset", 0x0202, "ThumbnailLength", [("Exif.Image.JPEGInterchangeFormat", "Image")]);

    /// <summary>
    /// The matrix coefficients for transformation from RGB to YCbCr image data. No default is given in TIFF; but here the value given in Appendix E, "Color Space Guidelines", is used as the default. The color space is declared in a color space information tag, with the default being the value that gives the optimal image characteristics Interoperability this condition.
    /// </summary>
    /// <remarks>
    /// Expected type is URational[3].
    /// </remarks>
    public static readonly Tag YCbCrCoefficients = Create(Root, null, 0x0211, "YCbCrCoefficients", true, [("Exif.Image.YCbCrCoefficients", "Image")]);

    /// <summary>
    /// The sampling ratio of chrominance components in relation to the luminance component. In JPEG compressed data a JPEG marker is used instead of this tag.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16[2].
    /// </remarks>
    public static readonly Tag YCbCrSubSampling = Create(Root, null, 0x0212, "YCbCrSubSampling", true, [("Exif.Image.YCbCrSubSampling", "Image")]);

    /// <summary>
    /// The position of chrominance components in relation to the luminance component. This field is designated only for JPEG compressed data or uncompressed YCbCr data. The TIFF default is 1 (centered); but when Y:Cb:Cr = 4:2:2 it is recommended in this standard that 2 (co-sited) be used to record data, in order to improve the image quality when viewed on TV systems. When this field does not exist, the reader shall assume the TIFF default. In the case of Y:Cb:Cr = 4:2:0, the TIFF default (centered) is recommended. If the reader does not have the capability of supporting both kinds of &lt;YCbCrPositioning&gt;, it shall follow the TIFF default regardless of the value in this field. It is preferable that readers be able to support both centered and co-sited positioning.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag YCbCrPositioning = Create(Root, null, 0x0213, "YCbCrPositioning", true, [("Exif.Image.YCbCrPositioning", "Image")]);

    /// <summary>
    /// The reference black point value and reference white point value. No defaults are given in TIFF, but the values below are given as defaults here. The color space is declared in a color space information tag, with the default being the value that gives the optimal image characteristics Interoperability these conditions.
    /// </summary>
    /// <remarks>
    /// Expected type is URational[6].
    /// </remarks>
    public static readonly Tag ReferenceBlackWhite = Create(Root, null, 0x0214, "ReferenceBlackWhite", true, [("Exif.Image.ReferenceBlackWhite", "Image")]);

    /// <summary>
    /// Copyright information. In this standard the tag is used to indicate both the photographer and editor copyrights. It is the copyright notice of the person or organization claiming rights to the image. The Interoperability copyright statement including date and rights should be written in this field; e.g., "Copyright, John Smith, 19xx. All rights reserved.". In this standard the field records both the photographer and editor copyrights, with each recorded in a separate part of the statement. When there is a clear distinction between the photographer and editor copyrights, these are to be written in the order of photographer followed by editor copyright, separated by NULL (in this case since the statement also ends with a NULL, there are two NULL codes). When only the photographer copyright is given, it is terminated by one NULL code. When only the editor copyright is given, the photographer copyright part consists of one space followed by a terminating NULL code, then the editor copyright is given. When the field is left blank, it is treated as unknown.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag Copyright = Create(Root, null, 0x8298, "Copyright", true, [("Exif.Image.Copyright", "Image")]);
}