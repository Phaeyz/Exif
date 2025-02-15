namespace Phaeyz.Exif.Tags;

/// <summary>
/// Tags which may appear in the root 0th image file directory.
/// </summary>
public class TagIfd0 : Tag
{
    /// <summary>
    /// Indicates the identification of the Interoperability rule. Use "R98" for stating ExifR98 Rules. Four bytes used including the termination code (NULL). see the separate volume of Recommended Exif Interoperability Rules (ExifR98) for other tags used for ExifR98.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag ProcessingSoftware = Create(Root, 0, 0x000B, "ProcessingSoftware", true, [("Exif.Image.ProcessingSoftware", "Image")]);

    /// <summary>
    /// Indicates the identification of the Interoperability rule. Use "R98" for stating ExifR98 Rules. Four bytes used including the termination code (NULL). see the separate volume of Recommended Exif Interoperability Rules (ExifR98) for other tags used for ExifR98.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag SubfileType = Create(Root, 0, 0x00FE, "SubfileType", true, [("Exif.Image.NewSubfileType", "Image")]);

    /// <summary>
    /// Indicates the identification of the Interoperability rule. Use "R98" for stating ExifR98 Rules. Four bytes used including the termination code (NULL). see the separate volume of Recommended Exif Interoperability Rules (ExifR98) for other tags used for ExifR98.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag OldSubfileType = Create(Root, 0, 0x00FF, "OldSubfileType", true, [("Exif.Image.SubfileType", "Image")]);

    /// <summary>
    /// Indicates the identification of the Interoperability rule. Use "R98" for stating ExifR98 Rules. Four bytes used including the termination code (NULL). see the separate volume of Recommended Exif Interoperability Rules (ExifR98) for other tags used for ExifR98.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag Thresholding = Create(Root, 0, 0x0107, "Thresholding", true, [("Exif.Image.Thresholding", "Image")]);

    /// <summary>
    /// Indicates the identification of the Interoperability rule. Use "R98" for stating ExifR98 Rules. Four bytes used including the termination code (NULL). see the separate volume of Recommended Exif Interoperability Rules (ExifR98) for other tags used for ExifR98.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag CellWidth = Create(Root, 0, 0x0108, "CellWidth", true, [("Exif.Image.CellWidth", "Image")]);

    /// <summary>
    /// Indicates the identification of the Interoperability rule. Use "R98" for stating ExifR98 Rules. Four bytes used including the termination code (NULL). see the separate volume of Recommended Exif Interoperability Rules (ExifR98) for other tags used for ExifR98.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag CellLength = Create(Root, 0, 0x0109, "CellLength", true, [("Exif.Image.CellLength", "Image")]);

    /// <summary>
    /// Indicates the identification of the Interoperability rule. Use "R98" for stating ExifR98 Rules. Four bytes used including the termination code (NULL). see the separate volume of Recommended Exif Interoperability Rules (ExifR98) for other tags used for ExifR98.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag FillOrder = Create(Root, 0, 0x010A, "FillOrder", true, [("Exif.Image.FillOrder", "Image")]);

    /// <summary>
    /// Indicates the identification of the Interoperability rule. Use "R98" for stating ExifR98 Rules. Four bytes used including the termination code (NULL). see the separate volume of Recommended Exif Interoperability Rules (ExifR98) for other tags used for ExifR98.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag DocumentName = Create(Root, 0, 0x010D, "DocumentName", true, [("Exif.Image.DocumentName", "Image")]);

    /// <summary>
    /// Indicates the identification of the Interoperability rule. Use "R98" for stating ExifR98 Rules. Four bytes used including the termination code (NULL). see the separate volume of Recommended Exif Interoperability Rules (ExifR98) for other tags used for ExifR98.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag MinSampleValue = Create(Root, 0, 0x0118, "MinSampleValue");

    /// <summary>
    /// Indicates the identification of the Interoperability rule. Use "R98" for stating ExifR98 Rules. Four bytes used including the termination code (NULL). see the separate volume of Recommended Exif Interoperability Rules (ExifR98) for other tags used for ExifR98.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag MaxSampleValue = Create(Root, 0, 0x0119, "MaxSampleValue");

    /// <summary>
    /// The name of the page from which this image was scanned.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag PageName = Create(Root, 0, 0x011D, "PageName", true, [("Exif.Image.PageName", "Image")]);

    /// <summary>
    /// X position of the image. The X offset in ResolutionUnits of the left side of the image, with respect to the left side of the page.
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag XPosition = Create(Root, 0, 0x011E, "XPosition", true, [("Exif.Image.XPosition", "Image")]);

    /// <summary>
    /// Y position of the image. The Y offset in ResolutionUnits of the top of the image, with respect to the top of the page. In the TIFF coordinate scheme, the positive Y direction is down, so that YPosition is always positive.
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag YPosition = Create(Root, 0, 0x011F, "YPosition", true, [("Exif.Image.YPosition", "Image")]);

    /// <summary>
    /// The precision of the information contained in the GrayResponseCurve.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag GrayResponseUnit = Create(Root, 0, 0x0122, "GrayResponseUnit", true, [("Exif.Image.GrayResponseUnit", "Image")]);

    /// <summary>
    /// The page number of the page from which this image was scanned.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16[2].
    /// </remarks>
    public static readonly Tag PageNumber = Create(Root, 0, 0x0129, "PageNumber", true, [("Exif.Image.PageNumber", "Image")]);

    /// <summary>
    /// This tag records information about the host computer used to generate the image.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag HostComputer = Create(Root, 0, 0x013C, "HostComputer", true, [("Exif.Image.HostComputer", "Image")]);

    /// <summary>
    /// A predictor is a mathematical operator that is applied to the image data before an encoding scheme is applied.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag Predictor = Create(Root, 0, 0x013D, "Predictor", true, [("Exif.Image.Predictor", "Image")]);

    /// <summary>
    /// The purpose of the HalftoneHints field is to convey to the halftone function the range of gray levels within a colorimetrically-specified image that should retain tonal detail.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16[2].
    /// </remarks>
    public static readonly Tag HalftoneHints = Create(Root, 0, 0x0141, "HalftoneHints", true, [("Exif.Image.HalftoneHints", "Image")]);

    /// <summary>
    /// The tile width in pixels. This is the number of columns in each tile.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag TileWidth = Create(Root, 0, 0x0142, "TileWidth", true, [("Exif.Image.TileWidth", "Image")]);

    /// <summary>
    /// The tile length (height) in pixels. This is the number of rows in each tile.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag TileLength = Create(Root, 0, 0x0143, "TileLength", true, [("Exif.Image.TileLength", "Image")]);

    /// <summary>
    /// The set of inks used in a separated (PhotometricInterpretation=5) image.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag InkSet = Create(Root, 0, 0x014C, "InkSet", true, [("Exif.Image.InkSet", "Image")]);

    /// <summary>
    /// A description of the printing environment for which this separation is intended.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag TargetPrinter = Create(Root, 0, 0x0151, "TargetPrinter", true, [("Exif.Image.TargetPrinter", "Image")]);

    /// <summary>
    /// XMP Metadata (Adobe technote 9-14-02)
    /// </summary>
    /// <remarks>
    /// Expected type is Byte.
    /// </remarks>
    public static readonly Tag ApplicationNotes = Create(Root, 0, 0x02BC, "ApplicationNotes", true, [("Exif.Image.XMLPacket", "Image")]);

    /// <summary>
    /// Rating tag used by Windows
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag Rating = Create(Root, 0, 0x4746, "Rating", true, [("Exif.Image.Rating", "Image")]);

    /// <summary>
    /// Rating tag used by Windows, value in percent
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag RatingPercent = Create(Root, 0, 0x4749, "RatingPercent", true, [("Exif.Image.RatingPercent", "Image")]);

    /// <summary>
    /// PixelScale (0x830E)
    /// </summary>
    public static readonly Tag PixelScale = Create(Root, 0, 0x830E, "PixelScale");

    /// <summary>
    /// Contains an IPTC/NAA record
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32->Unknown.
    /// </remarks>
    public static readonly Tag IptcNaa = CreatePreserveDataBlock(Root, 0, 0x83BB, "IPTC-NAA", [("Exif.Image.IPTCNAA", "Image")]);

    /// <summary>
    /// IntergraphMatrix (0x8480)
    /// </summary>
    public static readonly Tag IntergraphMatrix = Create(Root, 0, 0x8480, "IntergraphMatrix");

    /// <summary>
    /// ModelTiePoint (0x8482)
    /// </summary>
    /// <remarks>
    /// Expected type is Double[n].
    /// </remarks>
    public static readonly Tag ModelTiePoint = Create(Root, 0, 0x8482, "ModelTiePoint");

    /// <summary>
    /// SEMInfo (0x8546)
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag SemInfo = Create(Root, 0, 0x8546, "SEMInfo");

    /// <summary>
    /// ModelTransform (0x85D8)
    /// </summary>
    /// <remarks>
    /// Expected type is Double[16].
    /// </remarks>
    public static readonly Tag ModelTransform = Create(Root, 0, 0x85D8, "ModelTransform");

    /// <summary>
    /// Contains information embedded by the Adobe Photoshop application
    /// </summary>
    /// <remarks>
    /// Expected type is Byte.
    /// </remarks>
    public static readonly Tag PhotoshopSettings = Create(Root, 0, 0x8649, "PhotoshopSettings", true, [("Exif.Image.ImageResources", "Image")]);

    /// <summary>
    /// A pointer to the Exif IFD. Interoperability, Exif IFD has the same structure as that of the IFD specified in TIFF. ordinarily, however, it does not contain image data as in the case of TIFF.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag ExifOffset = CreateIfdPointer(Root, null, 0x8769, "ExifOffset", false, [("Exif.Image.ExifTag", "Image")]);

    /// <summary>
    /// Contains an InterColor Consortium (ICC) format color space characterization/profile
    /// </summary>
    /// <remarks>
    /// Expected type is Undefined.
    /// </remarks>
    public static readonly Tag IccProfile = Create(Root, 0, 0x8773, "ICC_Profile", true, [("Exif.Image.InterColorProfile", "Image")]);

    /// <summary>
    /// GeoTiffDirectory (0x87AF)
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16[n].
    /// </remarks>
    public static readonly Tag GeoTiffDirectory = Create(Root, 0, 0x87AF, "GeoTiffDirectory");

    /// <summary>
    /// GeoTiffDoubleParams (0x87B0)
    /// </summary>
    /// <remarks>
    /// Expected type is Double[n].
    /// </remarks>
    public static readonly Tag GeoTiffDoubleParams = Create(Root, 0, 0x87B0, "GeoTiffDoubleParams");

    /// <summary>
    /// GeoTiffAsciiParams (0x87B1)
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag GeoTiffAsciiParams = Create(Root, 0, 0x87B1, "GeoTiffAsciiParams");

    /// <summary>
    /// A pointer to the GPS Info IFD. The Interoperability structure of the GPS Info IFD, like that of Exif IFD, has no image data.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag GpsInfo = CreateIfdPointer(Root, null, 0x8825, "GPSInfo", false, [("Exif.Image.GPSTag", "Image")]);

    /// <summary>
    /// ImageSourceData (0x935C)
    /// </summary>
    /// <remarks>
    /// Expected type is Undefined.
    /// </remarks>
    public static readonly Tag ImageSourceData = Create(Root, 0, 0x935C, "ImageSourceData");

    /// <summary>
    /// Title tag used by Windows, encoded in UCS2
    /// </summary>
    /// <remarks>
    /// Expected type is Byte.
    /// </remarks>
    public static readonly Tag XpTitle = Create(Root, 0, 0x9C9B, "XPTitle", true, [("Exif.Image.XPTitle", "Image")]);

    /// <summary>
    /// Comment tag used by Windows, encoded in UCS2
    /// </summary>
    /// <remarks>
    /// Expected type is Byte.
    /// </remarks>
    public static readonly Tag XpComment = Create(Root, 0, 0x9C9C, "XPComment", true, [("Exif.Image.XPComment", "Image")]);

    /// <summary>
    /// Author tag used by Windows, encoded in UCS2
    /// </summary>
    /// <remarks>
    /// Expected type is Byte.
    /// </remarks>
    public static readonly Tag XpAuthor = Create(Root, 0, 0x9C9D, "XPAuthor", true, [("Exif.Image.XPAuthor", "Image")]);

    /// <summary>
    /// Keywords tag used by Windows, encoded in UCS2
    /// </summary>
    /// <remarks>
    /// Expected type is Byte.
    /// </remarks>
    public static readonly Tag XpKeywords = Create(Root, 0, 0x9C9E, "XPKeywords", true, [("Exif.Image.XPKeywords", "Image")]);

    /// <summary>
    /// Subject tag used by Windows, encoded in UCS2
    /// </summary>
    /// <remarks>
    /// Expected type is Byte.
    /// </remarks>
    public static readonly Tag XpSubject = Create(Root, 0, 0x9C9F, "XPSubject", true, [("Exif.Image.XPSubject", "Image")]);

    /// <summary>
    /// GDALMetadata (0xA480)
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag GdalMetadata = Create(Root, 0, 0xA480, "GDALMetadata");

    /// <summary>
    /// GDALNoData (0xA481)
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag GdalNoData = Create(Root, 0, 0xA481, "GDALNoData");

    /// <summary>
    /// Print Image Matching, description needed.
    /// </summary>
    /// <remarks>
    /// Expected type is Undefined.
    /// </remarks>
    public static readonly Tag PrintIm = Create(Root, 0, 0xC4A5, "PrintIM", true, [("Exif.Image.PrintImageMatching", "Image")]);

    /// <summary>
    /// This tag encodes the DNG four-tier version number. For files compliant with version 1.1.0.0 of the DNG specification, this tag should contain the bytes: 1, 1, 0, 0.
    /// </summary>
    /// <remarks>
    /// Expected type is Byte[4].
    /// </remarks>
    public static readonly Tag DngVersion = Create(Root, 0, 0xC612, "DNGVersion", true, [("Exif.Image.DNGVersion", "Image")]);

    /// <summary>
    /// This tag specifies the oldest version of the Digital Negative specification for which a file is compatible. Readers shouldnot attempt to read a file if this tag specifies a version number that is higher than the version number of the specification the reader was based on. In addition to checking the version tags, readers should, for all tags, check the types, counts, and values, to verify it is able to correctly read the file.
    /// </summary>
    /// <remarks>
    /// Expected type is Byte[4].
    /// </remarks>
    public static readonly Tag DngBackwardVersion = Create(Root, 0, 0xC613, "DNGBackwardVersion", true, [("Exif.Image.DNGBackwardVersion", "Image")]);

    /// <summary>
    /// Defines a unique, non-localized name for the camera model that created the image in the raw file. This name should include the manufacturer's name to avoid conflicts, and should not be localized, even if the camera name itself is localized for different markets (see LocalizedCameraModel). This string may be used by reader software to index into per-model preferences and replacement profiles.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag UniqueCameraModel = Create(Root, 0, 0xC614, "UniqueCameraModel", true, [("Exif.Image.UniqueCameraModel", "Image")]);

    /// <summary>
    /// Similar to the UniqueCameraModel field, except the name can be localized for different markets to match the localization of the camera name.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag LocalizedCameraModel = Create(Root, 0, 0xC615, "LocalizedCameraModel", true, [("Exif.Image.LocalizedCameraModel", "Image")]);

    /// <summary>
    /// ColorMatrix1 defines a transformation matrix that converts XYZ values to reference camera native color space values, under the first calibration illuminant. The matrix values are stored in row scan order. The ColorMatrix1 tag is required for all non-monochrome DNG files.
    /// </summary>
    /// <remarks>
    /// Expected type is SRational[n].
    /// </remarks>
    public static readonly Tag ColorMatrix1 = Create(Root, 0, 0xC621, "ColorMatrix1", true, [("Exif.Image.ColorMatrix1", "Image")]);

    /// <summary>
    /// ColorMatrix2 defines a transformation matrix that converts XYZ values to reference camera native color space values, under the second calibration illuminant. The matrix values are stored in row scan order.
    /// </summary>
    /// <remarks>
    /// Expected type is SRational[n].
    /// </remarks>
    public static readonly Tag ColorMatrix2 = Create(Root, 0, 0xC622, "ColorMatrix2", true, [("Exif.Image.ColorMatrix2", "Image")]);

    /// <summary>
    /// CameraCalibration1 defines a calibration matrix that transforms reference camera native space values to individual camera native space values under the first calibration illuminant. The matrix is stored in row scan order. This matrix is stored separately from the matrix specified by the ColorMatrix1 tag to allow raw converters to swap in replacement color matrices based on UniqueCameraModel tag, while still taking advantage of any per-individual camera calibration performed by the camera manufacturer.
    /// </summary>
    /// <remarks>
    /// Expected type is SRational[n].
    /// </remarks>
    public static readonly Tag CameraCalibration1 = Create(Root, 0, 0xC623, "CameraCalibration1", true, [("Exif.Image.CameraCalibration1", "Image")]);

    /// <summary>
    /// CameraCalibration2 defines a calibration matrix that transforms reference camera native space values to individual camera native space values under the second calibration illuminant. The matrix is stored in row scan order. This matrix is stored separately from the matrix specified by the ColorMatrix2 tag to allow raw converters to swap in replacement color matrices based on UniqueCameraModel tag, while still taking advantage of any per-individual camera calibration performed by the camera manufacturer.
    /// </summary>
    /// <remarks>
    /// Expected type is SRational[n].
    /// </remarks>
    public static readonly Tag CameraCalibration2 = Create(Root, 0, 0xC624, "CameraCalibration2", true, [("Exif.Image.CameraCalibration2", "Image")]);

    /// <summary>
    /// ReductionMatrix1 defines a dimensionality reduction matrix for use as the first stage in converting color camera native space values to XYZ values, under the first calibration illuminant. This tag may only be used if ColorPlanes is greater than 3. The matrix is stored in row scan order.
    /// </summary>
    /// <remarks>
    /// Expected type is SRational[n].
    /// </remarks>
    public static readonly Tag ReductionMatrix1 = Create(Root, 0, 0xC625, "ReductionMatrix1", true, [("Exif.Image.ReductionMatrix1", "Image")]);

    /// <summary>
    /// ReductionMatrix2 defines a dimensionality reduction matrix for use as the first stage in converting color camera native space values to XYZ values, under the second calibration illuminant. This tag may only be used if ColorPlanes is greater than 3. The matrix is stored in row scan order.
    /// </summary>
    /// <remarks>
    /// Expected type is SRational[n].
    /// </remarks>
    public static readonly Tag ReductionMatrix2 = Create(Root, 0, 0xC626, "ReductionMatrix2", true, [("Exif.Image.ReductionMatrix2", "Image")]);

    /// <summary>
    /// Normally the stored raw values are not white balanced, since any digital white balancing will reduce the dynamic range of the final image if the user decides to later adjust the white balance; however, if camera hardware is capable of white balancing the color channels before the signal is digitized, it can improve the dynamic range of the final image. AnalogBalance defines the gain, either analog (recommended) or digital (not recommended) that has been applied the stored raw values.
    /// </summary>
    /// <remarks>
    /// Expected type is URational[n].
    /// </remarks>
    public static readonly Tag AnalogBalance = Create(Root, 0, 0xC627, "AnalogBalance", true, [("Exif.Image.AnalogBalance", "Image")]);

    /// <summary>
    /// Specifies the selected white balance at time of capture, encoded as the coordinates of a perfectly neutral color in linear reference space values. The inclusion of this tag precludes the inclusion of the AsShotWhiteXY tag.
    /// </summary>
    /// <remarks>
    /// Expected type is URational[n].
    /// </remarks>
    public static readonly Tag AsShotNeutral = Create(Root, 0, 0xC628, "AsShotNeutral", true, [("Exif.Image.AsShotNeutral", "Image")]);

    /// <summary>
    /// Specifies the selected white balance at time of capture, encoded as x-y chromaticity coordinates. The inclusion of this tag precludes the inclusion of the AsShotNeutral tag.
    /// </summary>
    /// <remarks>
    /// Expected type is URational[2].
    /// </remarks>
    public static readonly Tag AsShotWhiteXy = Create(Root, 0, 0xC629, "AsShotWhiteXY", true, [("Exif.Image.AsShotWhiteXY", "Image")]);

    /// <summary>
    /// Camera models vary in the trade-off they make between highlight headroom and shadow noise. Some leave a significant amount of highlight headroom during a normal exposure. This allows significant negative exposure compensation to be applied during raw conversion, but also means normal exposures will contain more shadow noise. Other models leave less headroom during normal exposures. This allows for less negative exposure compensation, but results in lower shadow noise for normal exposures. Because of these differences, a raw converter needs to vary the zero point of its exposure compensation control from model to model. BaselineExposure specifies by how much (in EV units) to move the zero point. Positive values result in brighter default results, while negative values result in darker default results.
    /// </summary>
    /// <remarks>
    /// Expected type is SRational.
    /// </remarks>
    public static readonly Tag BaselineExposure = Create(Root, 0, 0xC62A, "BaselineExposure", true, [("Exif.Image.BaselineExposure", "Image")]);

    /// <summary>
    /// Specifies the relative noise level of the camera model at a baseline ISO value of 100, compared to a reference camera model. Since noise levels tend to vary approximately with the square root of the ISO value, a raw converter can use this value, combined with the current ISO, to estimate the relative noise level of the current image.
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag BaselineNoise = Create(Root, 0, 0xC62B, "BaselineNoise", true, [("Exif.Image.BaselineNoise", "Image")]);

    /// <summary>
    /// Specifies the relative amount of sharpening required for this camera model, compared to a reference camera model. Camera models vary in the strengths of their anti-aliasing filters. Cameras with weak or no filters require less sharpening than cameras with strong anti-aliasing filters.
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag BaselineSharpness = Create(Root, 0, 0xC62C, "BaselineSharpness", true, [("Exif.Image.BaselineSharpness", "Image")]);

    /// <summary>
    /// Some sensors have an unpredictable non-linearity in their response as they near the upper limit of their encoding range. This non-linearity results in color shifts in the highlight areas of the resulting image unless the raw converter compensates for this effect. LinearResponseLimit specifies the fraction of the encoding range above which the response may become significantly non-linear.
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag LinearResponseLimit = Create(Root, 0, 0xC62E, "LinearResponseLimit", true, [("Exif.Image.LinearResponseLimit", "Image")]);

    /// <summary>
    /// CameraSerialNumber contains the serial number of the camera or camera body that captured the image.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag CameraSerialNumber = Create(Root, 0, 0xC62F, "CameraSerialNumber", true, [("Exif.Image.CameraSerialNumber", "Image")]);

    /// <summary>
    /// Contains information about the lens that captured the image. If the minimum f-stops are unknown, they should be encoded as 0/0.
    /// </summary>
    /// <remarks>
    /// Expected type is URational[4].
    /// </remarks>
    public static readonly Tag DngLensInfo = Create(Root, 0, 0xC630, "DNGLensInfo", true, [("Exif.Image.LensInfo", "Image")]);

    /// <summary>
    /// This tag is used by Adobe Camera Raw to control the sensitivity of its 'Shadows' slider.
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag ShadowScale = Create(Root, 0, 0xC633, "ShadowScale", true, [("Exif.Image.ShadowScale", "Image")]);

    /// <summary>
    /// Provides a way for camera manufacturers to store private data in the DNG file for use by their own raw converters, and to have that data preserved by programs that edit DNG files.
    /// </summary>
    /// <remarks>
    /// Expected type is Undefined.
    /// </remarks>
    public static readonly Tag PrivateData = Create(Root, 0, 0xC634, "PrivateData", true, [("Exif.Image.DNGPrivateData", "Image")]);

    /// <summary>
    /// MakerNoteSafety lets the DNG reader know whether the EXIF MakerNote tag is safe to preserve along with the rest of the EXIF data. File browsers and other image management software processing an image with a preserved MakerNote should be aware that any thumbnail image embedded in the MakerNote may be stale, and may not reflect the current state of the full size image.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag MakerNoteSafety = Create(Root, 0, 0xC635, "MakerNoteSafety", true, [("Exif.Image.MakerNoteSafety", "Image")]);

    /// <summary>
    /// The illuminant used for the first set of color calibration tags (ColorMatrix1, CameraCalibration1, ReductionMatrix1). The legal values for this tag are the same as the legal values for the LightSource EXIF tag. If set to 255 (Other), then the IFD must also include a IlluminantData1 tag to specify the x-y chromaticity or spectral power distribution function for this illuminant.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag CalibrationIlluminant1 = Create(Root, 0, 0xC65A, "CalibrationIlluminant1", true, [("Exif.Image.CalibrationIlluminant1", "Image")]);

    /// <summary>
    /// The illuminant used for an optional second set of color calibration tags (ColorMatrix2, CameraCalibration2, ReductionMatrix2). The legal values for this tag are the same as the legal values for the CalibrationIlluminant1 tag; however, if both are included, neither is allowed to have a value of 0 (unknown). If set to 255 (Other), then the IFD must also include a IlluminantData2 tag to specify the x-y chromaticity or spectral power distribution function for this illuminant.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag CalibrationIlluminant2 = Create(Root, 0, 0xC65B, "CalibrationIlluminant2", true, [("Exif.Image.CalibrationIlluminant2", "Image")]);

    /// <summary>
    /// This tag contains a 16-byte unique identifier for the raw image data in the DNG file. DNG readers can use this tag to recognize a particular raw image, even if the file's name or the metadata contained in the file has been changed. If a DNG writer creates such an identifier, it should do so using an algorithm that will ensure that it is very unlikely two different images will end up having the same identifier.
    /// </summary>
    /// <remarks>
    /// Expected type is Byte[16].
    /// </remarks>
    public static readonly Tag RawDataUniqueId = Create(Root, 0, 0xC65D, "RawDataUniqueID", true, [("Exif.Image.RawDataUniqueID", "Image")]);

    /// <summary>
    /// If the DNG file was converted from a non-DNG raw file, then this tag contains the file name of that original raw file.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag OriginalRawFileName = Create(Root, 0, 0xC68B, "OriginalRawFileName", true, [("Exif.Image.OriginalRawFileName", "Image")]);

    /// <summary>
    /// If the DNG file was converted from a non-DNG raw file, then this tag contains the compressed contents of that original raw file. The contents of this tag always use the big-endian byte order. The tag contains a sequence of data blocks. Future versions of the DNG specification may define additional data blocks, so DNG readers should ignore extra bytes when parsing this tag. DNG readers should also detect the case where data blocks are missing from the end of the sequence, and should assume a default value for all the missing blocks. There are no padding or alignment bytes between data blocks.
    /// </summary>
    /// <remarks>
    /// Expected type is Undefined.
    /// </remarks>
    public static readonly Tag OriginalRawFileData = Create(Root, 0, 0xC68C, "OriginalRawFileData", true, [("Exif.Image.OriginalRawFileData", "Image")]);

    /// <summary>
    /// This tag contains an ICC profile that, in conjunction with the AsShotPreProfileMatrix tag, provides the camera manufacturer with a way to specify a default color rendering from camera color space coordinates (linear reference values) into the ICC profile connection space. The ICC profile connection space is an output referred colorimetric space, whereas the other color calibration tags in DNG specify a conversion into a scene referred colorimetric space. This means that the rendering in this profile should include any desired tone and gamut mapping needed to convert between scene referred values and output referred values.
    /// </summary>
    /// <remarks>
    /// Expected type is Undefined.
    /// </remarks>
    public static readonly Tag AsShotIccProfile = Create(Root, 0, 0xC68F, "AsShotICCProfile", true, [("Exif.Image.AsShotICCProfile", "Image")]);

    /// <summary>
    /// This tag is used in conjunction with the AsShotICCProfile tag. It specifies a matrix that should be applied to the camera color space coordinates before processing the values through the ICC profile specified in the AsShotICCProfile tag. The matrix is stored in the row scan order. If ColorPlanes is greater than three, then this matrix can (but is not required to) reduce the dimensionality of the color data down to three components, in which case the AsShotICCProfile should have three rather than ColorPlanes input components.
    /// </summary>
    /// <remarks>
    /// Expected type is SRational[n].
    /// </remarks>
    public static readonly Tag AsShotPreProfileMatrix = Create(Root, 0, 0xC690, "AsShotPreProfileMatrix", true, [("Exif.Image.AsShotPreProfileMatrix", "Image")]);

    /// <summary>
    /// This tag is used in conjunction with the CurrentPreProfileMatrix tag. The CurrentICCProfile and CurrentPreProfileMatrix tags have the same purpose and usage as the AsShotICCProfile and AsShotPreProfileMatrix tag pair, except they are for use by raw file editors rather than camera manufacturers.
    /// </summary>
    /// <remarks>
    /// Expected type is Undefined.
    /// </remarks>
    public static readonly Tag CurrentIccProfile = Create(Root, 0, 0xC691, "CurrentICCProfile", true, [("Exif.Image.CurrentICCProfile", "Image")]);

    /// <summary>
    /// This tag is used in conjunction with the CurrentICCProfile tag. The CurrentICCProfile and CurrentPreProfileMatrix tags have the same purpose and usage as the AsShotICCProfile and AsShotPreProfileMatrix tag pair, except they are for use by raw file editors rather than camera manufacturers.
    /// </summary>
    /// <remarks>
    /// Expected type is SRational[n].
    /// </remarks>
    public static readonly Tag CurrentPreProfileMatrix = Create(Root, 0, 0xC692, "CurrentPreProfileMatrix", true, [("Exif.Image.CurrentPreProfileMatrix", "Image")]);

    /// <summary>
    /// The DNG color model documents a transform between camera colors and CIE XYZ values. This tag describes the colorimetric reference for the CIE XYZ values. 0 = The XYZ values are scene-referred. 1 = The XYZ values are output-referred, using the ICC profile perceptual dynamic range. This tag allows output-referred data to be stored in DNG files and still processed correctly by DNG readers.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag ColorimetricReference = Create(Root, 0, 0xC6BF, "ColorimetricReference", true, [("Exif.Image.ColorimetricReference", "Image")]);

    /// <summary>
    /// SRawType (0xC6C5)
    /// </summary>
    public static readonly Tag SRawType = Create(Root, 0, 0xC6C5, "SRawType");

    /// <summary>
    /// PanasonicTitle (0xC6D2)
    /// </summary>
    /// <remarks>
    /// Expected type is Undefined.
    /// </remarks>
    public static readonly Tag PanasonicTitle = Create(Root, 0, 0xC6D2, "PanasonicTitle");

    /// <summary>
    /// PanasonicTitle2 (0xC6D3)
    /// </summary>
    /// <remarks>
    /// Expected type is Undefined.
    /// </remarks>
    public static readonly Tag PanasonicTitle2 = Create(Root, 0, 0xC6D3, "PanasonicTitle2");

    /// <summary>
    /// A UTF-8 encoded string associated with the CameraCalibration1 and CameraCalibration2 tags. The CameraCalibration1 and CameraCalibration2 tags should only be used in the DNG color transform if the string stored in the CameraCalibrationSignature tag exactly matches the string stored in the ProfileCalibrationSignature tag for the selected camera profile.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag CameraCalibrationSig = Create(Root, 0, 0xC6F3, "CameraCalibrationSig", true, [("Exif.Image.CameraCalibrationSignature", "Image")]);

    /// <summary>
    /// A UTF-8 encoded string associated with the camera profile tags. The CameraCalibration1 and CameraCalibration2 tags should only be used in the DNG color transfer if the string stored in the CameraCalibrationSignature tag exactly matches the string stored in the ProfileCalibrationSignature tag for the selected camera profile.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag ProfileCalibrationSig = Create(Root, 0, 0xC6F4, "ProfileCalibrationSig", true, [("Exif.Image.ProfileCalibrationSignature", "Image")]);

    /// <summary>
    /// A list of file offsets to extra Camera Profile IFDs. Note that the primary camera profile tags should be stored in IFD 0, and the ExtraCameraProfiles tag should only be used if there is more than one camera profile stored in the DNG file.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32->Unknown.
    /// </remarks>
    public static readonly Tag ProfileIfd = CreatePreserveDataBlock(Root, 0, 0xC6F5, "ProfileIFD", [("Exif.Image.ExtraCameraProfiles", "Image")]);

    /// <summary>
    /// A UTF-8 encoded string containing the name of the "as shot" camera profile, if any.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag AsShotProfileName = Create(Root, 0, 0xC6F6, "AsShotProfileName", true, [("Exif.Image.AsShotProfileName", "Image")]);

    /// <summary>
    /// A UTF-8 encoded string containing the name of the camera profile. This tag is optional if there is only a single camera profile stored in the file but is required for all camera profiles if there is more than one camera profile stored in the file.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag ProfileName = Create(Root, 0, 0xC6F8, "ProfileName", true, [("Exif.Image.ProfileName", "Image")]);

    /// <summary>
    /// This tag specifies the number of input samples in each dimension of the hue/saturation/value mapping tables. The data for these tables are stored in ProfileHueSatMapData1, ProfileHueSatMapData2 and ProfileHueSatMapData3 tags. The most common case has ValueDivisions equal to 1, so only hue and saturation are used as inputs to the mapping table.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32[3].
    /// </remarks>
    public static readonly Tag ProfileHueSatMapDims = Create(Root, 0, 0xC6F9, "ProfileHueSatMapDims", true, [("Exif.Image.ProfileHueSatMapDims", "Image")]);

    /// <summary>
    /// This tag contains the data for the first hue/saturation/value mapping table. Each entry of the table contains three 32-bit IEEE floating-point values. The first entry is hue shift in degrees; the second entry is saturation scale factor; and the third entry is a value scale factor. The table entries are stored in the tag in nested loop order, with the value divisions in the outer loop, the hue divisions in the middle loop, and the saturation divisions in the inner loop. All zero input saturation entries are required to have a value scale factor of 1.0.
    /// </summary>
    /// <remarks>
    /// Expected type is Float[n].
    /// </remarks>
    public static readonly Tag ProfileHueSatMapData1 = Create(Root, 0, 0xC6FA, "ProfileHueSatMapData1", true, [("Exif.Image.ProfileHueSatMapData1", "Image")]);

    /// <summary>
    /// This tag contains the data for the second hue/saturation/value mapping table. Each entry of the table contains three 32-bit IEEE floating-point values. The first entry is hue shift in degrees; the second entry is a saturation scale factor; and the third entry is a value scale factor. The table entries are stored in the tag in nested loop order, with the value divisions in the outer loop, the hue divisions in the middle loop, and the saturation divisions in the inner loop. All zero input saturation entries are required to have a value scale factor of 1.0.
    /// </summary>
    /// <remarks>
    /// Expected type is Float[n].
    /// </remarks>
    public static readonly Tag ProfileHueSatMapData2 = Create(Root, 0, 0xC6FB, "ProfileHueSatMapData2", true, [("Exif.Image.ProfileHueSatMapData2", "Image")]);

    /// <summary>
    /// This tag contains a default tone curve that can be applied while processing the image as a starting point for user adjustments. The curve is specified as a list of 32-bit IEEE floating-point value pairs in linear gamma. Each sample has an input value in the range of 0.0 to 1.0, and an output value in the range of 0.0 to 1.0. The first sample is required to be (0.0, 0.0), and the last sample is required to be (1.0, 1.0). Interpolated the curve using a cubic spline.
    /// </summary>
    /// <remarks>
    /// Expected type is Float[n].
    /// </remarks>
    public static readonly Tag ProfileToneCurve = Create(Root, 0, 0xC6FC, "ProfileToneCurve", true, [("Exif.Image.ProfileToneCurve", "Image")]);

    /// <summary>
    /// This tag contains information about the usage rules for the associated camera profile.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag ProfileEmbedPolicy = Create(Root, 0, 0xC6FD, "ProfileEmbedPolicy", true, [("Exif.Image.ProfileEmbedPolicy", "Image")]);

    /// <summary>
    /// A UTF-8 encoded string containing the copyright information for the camera profile. This string always should be preserved along with the other camera profile tags.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag ProfileCopyright = Create(Root, 0, 0xC6FE, "ProfileCopyright", true, [("Exif.Image.ProfileCopyright", "Image")]);

    /// <summary>
    /// This tag defines a matrix that maps white balanced camera colors to XYZ D50 colors.
    /// </summary>
    /// <remarks>
    /// Expected type is SRational[n].
    /// </remarks>
    public static readonly Tag ForwardMatrix1 = Create(Root, 0, 0xC714, "ForwardMatrix1", true, [("Exif.Image.ForwardMatrix1", "Image")]);

    /// <summary>
    /// This tag defines a matrix that maps white balanced camera colors to XYZ D50 colors.
    /// </summary>
    /// <remarks>
    /// Expected type is SRational[n].
    /// </remarks>
    public static readonly Tag ForwardMatrix2 = Create(Root, 0, 0xC715, "ForwardMatrix2", true, [("Exif.Image.ForwardMatrix2", "Image")]);

    /// <summary>
    /// A UTF-8 encoded string containing the name of the application that created the preview stored in the IFD.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag PreviewApplicationName = Create(Root, 0, 0xC716, "PreviewApplicationName", true, [("Exif.Image.PreviewApplicationName", "Image")]);

    /// <summary>
    /// A UTF-8 encoded string containing the version number of the application that created the preview stored in the IFD.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag PreviewApplicationVersion = Create(Root, 0, 0xC717, "PreviewApplicationVersion", true, [("Exif.Image.PreviewApplicationVersion", "Image")]);

    /// <summary>
    /// A UTF-8 encoded string containing the name of the conversion settings (for example, snapshot name) used for the preview stored in the IFD.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag PreviewSettingsName = Create(Root, 0, 0xC718, "PreviewSettingsName", true, [("Exif.Image.PreviewSettingsName", "Image")]);

    /// <summary>
    /// A unique ID of the conversion settings (for example, MD5 digest) used to render the preview stored in the IFD.
    /// </summary>
    /// <remarks>
    /// Expected type is Byte.
    /// </remarks>
    public static readonly Tag PreviewSettingsDigest = Create(Root, 0, 0xC719, "PreviewSettingsDigest", true, [("Exif.Image.PreviewSettingsDigest", "Image")]);

    /// <summary>
    /// This tag specifies the color space in which the rendered preview in this IFD is stored. The default value for this tag is sRGB for color previews and Gray Gamma 2.2 for monochrome previews.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag PreviewColorSpace = Create(Root, 0, 0xC71A, "PreviewColorSpace", true, [("Exif.Image.PreviewColorSpace", "Image")]);

    /// <summary>
    /// This tag is an ASCII string containing the name of the date/time at which the preview stored in the IFD was rendered. The date/time is encoded using ISO 8601 format.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag PreviewDateTime = Create(Root, 0, 0xC71B, "PreviewDateTime", true, [("Exif.Image.PreviewDateTime", "Image")]);

    /// <summary>
    /// This tag is an MD5 digest of the raw image data. All pixels in the image are processed in row-scan order. Each pixel is zero padded to 16 or 32 bits deep (16-bit for data less than or equal to 16 bits deep, 32-bit otherwise). The data for each pixel is processed in little-endian byte order.
    /// </summary>
    /// <remarks>
    /// Expected type is Byte[16].
    /// </remarks>
    public static readonly Tag RawImageDigest = Create(Root, 0, 0xC71C, "RawImageDigest", true, [("Exif.Image.RawImageDigest", "Image")]);

    /// <summary>
    /// This tag is an MD5 digest of the data stored in the OriginalRawFileData tag.
    /// </summary>
    /// <remarks>
    /// Expected type is Byte[16].
    /// </remarks>
    public static readonly Tag OriginalRawFileDigest = Create(Root, 0, 0xC71D, "OriginalRawFileDigest", true, [("Exif.Image.OriginalRawFileDigest", "Image")]);

    /// <summary>
    /// This tag specifies the number of input samples in each dimension of a default "look" table. The data for this table is stored in the ProfileLookTableData tag.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag ProfileLookTableDims = Create(Root, 0, 0xC725, "ProfileLookTableDims", true, [("Exif.Image.ProfileLookTableDims", "Image")]);

    /// <summary>
    /// This tag contains a default "look" table that can be applied while processing the image as a starting point for user adjustment. This table uses the same format as the tables stored in the ProfileHueSatMapData1 and ProfileHueSatMapData2 tags, and is applied in the same color space. However, it should be applied later in the processing pipe, after any exposure compensation and/or fill light stages, but before any tone curve stage. Each entry of the table contains three 32-bit IEEE floating-point values. The first entry is hue shift in degrees, the second entry is a saturation scale factor, and the third entry is a value scale factor. The table entries are stored in the tag in nested loop order, with the value divisions in the outer loop, the hue divisions in the middle loop, and the saturation divisions in the inner loop. All zero input saturation entries are required to have a value scale factor of 1.0.
    /// </summary>
    /// <remarks>
    /// Expected type is Float[n].
    /// </remarks>
    public static readonly Tag ProfileLookTableData = Create(Root, 0, 0xC726, "ProfileLookTableData", true, [("Exif.Image.ProfileLookTableData", "Image")]);

    /// <summary>
    /// The optional TimeCodes tag shall contain an ordered array of time codes. All time codes shall be 8 bytes long and in binary format. The tag may contain from 1 to 10 time codes. When the tag contains more than one time code, the first one shall be the default time code. This specification does not prescribe how to use multiple time codes. Each time code shall be as defined for the 8-byte time code structure in SMPTE 331M-2004, Section 8.3. See also SMPTE 12-1-2008 and SMPTE 309-1999.
    /// </summary>
    /// <remarks>
    /// Expected type is Byte[n].
    /// </remarks>
    public static readonly Tag TimeCodes = Create(Root, 0, 0xC763, "TimeCodes", true, [("Exif.Image.TimeCodes", "Image")]);

    /// <summary>
    /// The optional FrameRate tag shall specify the video frame rate in number of image frames per second, expressed as a signed rational number. The numerator shall be non-negative and the denominator shall be positive. This field value is identical to the sample rate field in SMPTE 377-1-2009.
    /// </summary>
    /// <remarks>
    /// Expected type is SRational.
    /// </remarks>
    public static readonly Tag FrameRate = Create(Root, 0, 0xC764, "FrameRate", true, [("Exif.Image.FrameRate", "Image")]);

    /// <summary>
    /// The optional TStop tag shall specify the T-stop of the actual lens, expressed as an unsigned rational number. T-stop is also known as T-number or the photometric aperture of the lens. (F-number is the geometric aperture of the lens.) When the exact value is known, the T-stop shall be specified using a single number. Alternately, two numbers shall be used to indicate a T-stop range, in which case the first number shall be the minimum T-stop and the second number shall be the maximum T-stop.
    /// </summary>
    /// <remarks>
    /// Expected type is URational[n].
    /// </remarks>
    public static readonly Tag TStop = Create(Root, 0, 0xC772, "TStop", true, [("Exif.Image.TStop", "Image")]);

    /// <summary>
    /// The optional ReelName tag shall specify a name for a sequence of images, where each image in the sequence has a unique image identifier (including but not limited to file name, frame number, date time, time code).
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag ReelName = Create(Root, 0, 0xC789, "ReelName", true, [("Exif.Image.ReelName", "Image")]);

    /// <summary>
    /// If this file is a proxy for a larger original DNG file, this tag specifics the default final size of the larger original file from which this proxy was generated. The default value for this tag is default final size of the current DNG file, which is DefaultCropSize * DefaultScale.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32[2].
    /// </remarks>
    public static readonly Tag OriginalDefaultFinalSize = Create(Root, 0, 0xC791, "OriginalDefaultFinalSize", true, [("Exif.Image.OriginalDefaultFinalSize", "Image")]);

    /// <summary>
    /// If this file is a proxy for a larger original DNG file, this tag specifics the best quality final size of the larger original file from which this proxy was generated. The default value for this tag is the OriginalDefaultFinalSize, if specified. Otherwise the default value for this tag is the best quality size of the current DNG file, which is DefaultCropSize * DefaultScale * BestQualityScale.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32[2].
    /// </remarks>
    public static readonly Tag OriginalBestQualitySize = Create(Root, 0, 0xC792, "OriginalBestQualitySize", true, [("Exif.Image.OriginalBestQualityFinalSize", "Image")]);

    /// <summary>
    /// If this file is a proxy for a larger original DNG file, this tag specifics the DefaultCropSize of the larger original file from which this proxy was generated. The default value for this tag is OriginalDefaultFinalSize, if specified. Otherwise, the default value for this tag is the DefaultCropSize of the current DNG file.
    /// </summary>
    /// <remarks>
    /// Expected type is URational[2].
    /// </remarks>
    public static readonly Tag OriginalDefaultCropSize = Create(Root, 0, 0xC793, "OriginalDefaultCropSize", true, [("Exif.Image.OriginalDefaultCropSize", "Image")]);

    /// <summary>
    /// The optional CameraLabel tag shall specify a text label for how the camera is used or assigned in this clip. This tag is similar to CameraLabel in XMP.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag CameraLabel = Create(Root, 0, 0xC7A1, "CameraLabel", true, [("Exif.Image.CameraLabel", "Image")]);

    /// <summary>
    /// Provides a way for color profiles to specify how indexing into a 3D HueSatMap is performed during raw conversion. This tag is not applicable to 2.5D HueSatMap tables (i.e., where the Value dimension is 1).
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag ProfileHueSatMapEncoding = Create(Root, 0, 0xC7A3, "ProfileHueSatMapEncoding", true, [("Exif.Image.ProfileHueSatMapEncoding", "Image")]);

    /// <summary>
    /// Provides a way for color profiles to specify how indexing into a 3D LookTable is performed during raw conversion. This tag is not applicable to a 2.5D LookTable (i.e., where the Value dimension is 1).
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag ProfileLookTableEncoding = Create(Root, 0, 0xC7A4, "ProfileLookTableEncoding", true, [("Exif.Image.ProfileLookTableEncoding", "Image")]);

    /// <summary>
    /// Provides a way for color profiles to increase or decrease exposure during raw conversion. BaselineExposureOffset specifies the amount (in EV units) to add to the BaselineExposure tag during image rendering. For example, if the BaselineExposure value for a given camera model is +0.3, and the BaselineExposureOffset value for a given camera profile used to render an image for that camera model is -0.7, then the actual default exposure value used during rendering will be +0.3 - 0.7 = -0.4.
    /// </summary>
    /// <remarks>
    /// Expected type is SRational.
    /// </remarks>
    public static readonly Tag BaselineExposureOffset = Create(Root, 0, 0xC7A5, "BaselineExposureOffset", true, [("Exif.Image.BaselineExposureOffset", "Image")]);

    /// <summary>
    /// This optional tag in a color profile provides a hint to the raw converter regarding how to handle the black point (e.g., flare subtraction) during rendering. If set to Auto, the raw converter should perform black subtraction during rendering. If set to None, the raw converter should not perform any black subtraction during rendering.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag DefaultBlackRender = Create(Root, 0, 0xC7A6, "DefaultBlackRender", true, [("Exif.Image.DefaultBlackRender", "Image")]);

    /// <summary>
    /// This tag is a modified MD5 digest of the raw image data. It has been updated from the algorithm used to compute the RawImageDigest tag be more multi-processor friendly, and to support lossy compression algorithms.
    /// </summary>
    /// <remarks>
    /// Expected type is Byte[16].
    /// </remarks>
    public static readonly Tag NewRawImageDigest = Create(Root, 0, 0xC7A7, "NewRawImageDigest", true, [("Exif.Image.NewRawImageDigest", "Image")]);

    /// <summary>
    /// The gain (what number the sample values are multiplied by) between the main raw IFD and the preview IFD containing this tag.
    /// </summary>
    /// <remarks>
    /// Expected type is Double.
    /// </remarks>
    public static readonly Tag RawToPreviewGain = Create(Root, 0, 0xC7A8, "RawToPreviewGain", true, [("Exif.Image.RawToPreviewGain", "Image")]);

    /// <summary>
    /// Specifies the encoding of any depth data in the file. Can be unknown (apart from nearer distances being closer to zero, and farther distances being closer to the maximum value), linear (values vary linearly from zero representing DepthNear to the maximum value representing DepthFar), or inverse (values are stored inverse linearly, with zero representing DepthNear and the maximum value representing DepthFar).
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag DepthFormat = Create(Root, 0, 0xC7E9, "DepthFormat", true, [("Exif.Image.DepthFormat", "Image")]);

    /// <summary>
    /// Specifies distance from the camera represented by the zero value in the depth map. 0/0 means unknown.
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag DepthNear = Create(Root, 0, 0xC7EA, "DepthNear", true, [("Exif.Image.DepthNear", "Image")]);

    /// <summary>
    /// Specifies distance from the camera represented by the maximum value in the depth map. 0/0 means unknown. 1/0 means infinity, which is valid for unknown and inverse depth formats.
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag DepthFar = Create(Root, 0, 0xC7EB, "DepthFar", true, [("Exif.Image.DepthFar", "Image")]);

    /// <summary>
    /// Specifies the measurement units for the DepthNear and DepthFar tags.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag DepthUnits = Create(Root, 0, 0xC7EC, "DepthUnits", true, [("Exif.Image.DepthUnits", "Image")]);

    /// <summary>
    /// Specifies the measurement geometry for the depth map. Can be unknown, measured along the optical axis, or measured along the optical ray passing through each pixel.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag DepthMeasureType = Create(Root, 0, 0xC7ED, "DepthMeasureType", true, [("Exif.Image.DepthMeasureType", "Image")]);

    /// <summary>
    /// A string that documents how the enhanced image data was processed.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag EnhanceParams = Create(Root, 0, 0xC7EE, "EnhanceParams", true, [("Exif.Image.EnhanceParams", "Image")]);

    /// <summary>
    /// The illuminant used for an optional third set of color calibration tags (ColorMatrix3, CameraCalibration3, ReductionMatrix3). The legal values for this tag are the same as the legal values for the LightSource EXIF tag; CalibrationIlluminant1 and CalibrationIlluminant2 must also be present. If set to 255 (Other), then the IFD must also include a IlluminantData3 tag to specify the x-y chromaticity or spectral power distribution function for this illuminant.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag CalibrationIlluminant3 = Create(Root, 0, 0xCD31, "CalibrationIlluminant3", true, [("Exif.Image.CalibrationIlluminant3", "Image")]);

    /// <summary>
    /// CameraCalibration3 defines a calibration matrix that transforms reference camera native space values to individual camera native space values under the third calibration illuminant. The matrix is stored in row scan order. This matrix is stored separately from the matrix specified by the ColorMatrix3 tag to allow raw converters to swap in replacement color matrices based on UniqueCameraModel tag, while still taking advantage of any per-individual camera calibration performed by the camera manufacturer.
    /// </summary>
    /// <remarks>
    /// Expected type is SRational[n].
    /// </remarks>
    public static readonly Tag CameraCalibration3 = Create(Root, 0, 0xCD32, "CameraCalibration3", true, [("Exif.Image.CameraCalibration3", "Image")]);

    /// <summary>
    /// ColorMatrix3 defines a transformation matrix that converts XYZ values to reference camera native color space values, under the third calibration illuminant. The matrix values are stored in row scan order.
    /// </summary>
    /// <remarks>
    /// Expected type is SRational[n].
    /// </remarks>
    public static readonly Tag ColorMatrix3 = Create(Root, 0, 0xCD33, "ColorMatrix3", true, [("Exif.Image.ColorMatrix3", "Image")]);

    /// <summary>
    /// This tag defines a matrix that maps white balanced camera colors to XYZ D50 colors.
    /// </summary>
    /// <remarks>
    /// Expected type is SRational[n].
    /// </remarks>
    public static readonly Tag ForwardMatrix3 = Create(Root, 0, 0xCD34, "ForwardMatrix3", true, [("Exif.Image.ForwardMatrix3", "Image")]);

    /// <summary>
    /// When the CalibrationIlluminant1 tag is set to 255 (Other), then the IlluminantData1 tag is required and specifies the data for the first illuminant. Otherwise, this tag is ignored. The illuminant data may be specified as either a x-y chromaticity coordinate or as a spectral power distribution function.
    /// </summary>
    /// <remarks>
    /// Expected type is Undefined.
    /// </remarks>
    public static readonly Tag IlluminantData1 = Create(Root, 0, 0xCD35, "IlluminantData1", true, [("Exif.Image.IlluminantData1", "Image")]);

    /// <summary>
    /// When the CalibrationIlluminant2 tag is set to 255 (Other), then the IlluminantData2 tag is required and specifies the data for the second illuminant. Otherwise, this tag is ignored. The format of the data is the same as IlluminantData1.
    /// </summary>
    /// <remarks>
    /// Expected type is Undefined.
    /// </remarks>
    public static readonly Tag IlluminantData2 = Create(Root, 0, 0xCD36, "IlluminantData2", true, [("Exif.Image.IlluminantData2", "Image")]);

    /// <summary>
    /// When the CalibrationIlluminant3 tag is set to 255 (Other), then the IlluminantData3 tag is required and specifies the data for the third illuminant. Otherwise, this tag is ignored. The format of the data is the same as IlluminantData1.
    /// </summary>
    /// <remarks>
    /// Expected type is Undefined.
    /// </remarks>
    public static readonly Tag IlluminantData3 = Create(Root, 0, 0xCD37, "IlluminantData3", true, [("Exif.Image.IlluminantData3", "Image")]);

    /// <summary>
    /// This tag contains the data for the third hue/saturation/value mapping table. Each entry of the table contains three 32-bit IEEE floating-point values. The first entry is hue shift in degrees; the second entry is saturation scale factor; and the third entry is a value scale factor. The table entries are stored in the tag in nested loop order, with the value divisions in the outer loop, the hue divisions in the middle loop, and the saturation divisions in the inner loop. All zero input saturation entries are required to have a value scale factor of 1.0.
    /// </summary>
    /// <remarks>
    /// Expected type is Float[n].
    /// </remarks>
    public static readonly Tag ProfileHueSatMapData3 = Create(Root, 0, 0xCD39, "ProfileHueSatMapData3", true, [("Exif.Image.ProfileHueSatMapData3", "Image")]);

    /// <summary>
    /// ReductionMatrix3 defines a dimensionality reduction matrix for use as the first stage in converting color camera native space values to XYZ values, under the third calibration illuminant. This tag may only be used if ColorPlanes is greater than 3. The matrix is stored in row scan order.
    /// </summary>
    /// <remarks>
    /// Expected type is SRational[n].
    /// </remarks>
    public static readonly Tag ReductionMatrix3 = Create(Root, 0, 0xCD3A, "ReductionMatrix3", true, [("Exif.Image.ReductionMatrix3", "Image")]);

    /// <summary>
    /// This tag specifies color transforms that can be applied to masked image regions. Color transforms are specified using RGB-to-RGB color lookup tables. These tables are associated with Semantic Masks to limit the color transform to a sub-region of the image. The overall color transform is a linear combination of the color tables, weighted by their corresponding Semantic Masks.
    /// </summary>
    /// <remarks>
    /// Expected type is Undefined.
    /// </remarks>
    public static readonly Tag RgbTables = Create(Root, 0, 0xCD3F, "RGBTables", true, [("Exif.Image.RGBTables", "Image")]);

    /// <summary>
    /// This tag is an extended version of ProfileGainTableMap.
    /// </summary>
    /// <remarks>
    /// Expected type is Undefined.
    /// </remarks>
    public static readonly Tag ProfileGainTableMap2 = Create(Root, 0, 0xCD40, "ProfileGainTableMap2", true, [("Exif.Image.ProfileGainTableMap2", "Image")]);

    /// <summary>
    /// This is an informative tag that describes how the image file relates to other image files captured in a sequence. Applications include focus stacking, merging multiple frames to reduce noise, time lapses, exposure brackets, stitched images for super resolution, and so on.
    /// </summary>
    /// <remarks>
    /// Expected type is Undefined.
    /// </remarks>
    public static readonly Tag ImageSequenceInfo = Create(Root, 0, 0xCD44, "ImageSequenceInfo", true, [("Exif.Image.ImageSequenceInfo", "Image")]);

    /// <summary>
    /// This is an informative tag that provides basic statistical information about the pixel values of the image in this IFD. Possible applications include normalizing brightness of images when multiple images are displayed together (especially when mixing Standard Dynamic Range and High Dynamic Range images), identifying underexposed or overexposed images, and so on.
    /// </summary>
    /// <remarks>
    /// Expected type is Undefined.
    /// </remarks>
    public static readonly Tag ImageStats = Create(Root, 0, 0xCD46, "ImageStats", true, [("Exif.Image.ImageStats", "Image")]);

    /// <summary>
    /// This tag describes the intended rendering output dynamic range for a given camera profile.
    /// </summary>
    /// <remarks>
    /// Expected type is Undefined.
    /// </remarks>
    public static readonly Tag ProfileDynamicRange = Create(Root, 0, 0xCD47, "ProfileDynamicRange", true, [("Exif.Image.ProfileDynamicRange", "Image")]);

    /// <summary>
    /// A UTF-8 encoded string containing the 'group name' of the camera profile. The purpose of this tag is to associate two or more related camera profiles into a common group.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag ProfileGroupName = Create(Root, 0, 0xCD48, "ProfileGroupName", true, [("Exif.Image.ProfileGroupName", "Image")]);

    /// <summary>
    /// This optional tag specifies the distance parameter used to encode the JPEG XL data in this IFD. A value of 0.0 means lossless compression, while values greater than 0.0 means lossy compression.
    /// </summary>
    /// <remarks>
    /// Expected type is Float.
    /// </remarks>
    public static readonly Tag JxlDistance = Create(Root, 0, 0xCD49, "JXLDistance", true, [("Exif.Image.JXLDistance", "Image")]);

    /// <summary>
    /// This optional tag specifies the effort parameter used to encode the JPEG XL data in this IFD. Values range from 1 (low) to 9 (high).
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag JxlEffort = Create(Root, 0, 0xCD4A, "JXLEffort", true, [("Exif.Image.JXLEffort", "Image")]);

    /// <summary>
    /// This optional tag specifies the decode speed parameter used to encode the JPEG XL data in this IFD. Values range from 1 (slow) to 4 (fast).
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag JxlDecodeSpeed = Create(Root, 0, 0xCD4B, "JXLDecodeSpeed", true, [("Exif.Image.JXLDecodeSpeed", "Image")]);

    /// <summary>
    /// SEAL (0xCEA1)
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag Seal = Create(Root, 0, 0xCEA1, "SEAL");
}
