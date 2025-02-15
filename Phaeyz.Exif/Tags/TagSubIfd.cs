namespace Phaeyz.Exif.Tags;

/// <summary>
/// Tags which may appear in a "Sub" image file directory.
/// </summary>
public class TagSubIfd : Tag
{
    /// <summary>
    /// This field specifies how to interpret each data sample in a pixel.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag SampleFormat = Create(TagAny.SubIfd, null, 0x0153, "SampleFormat", true, [("Exif.Image.SampleFormat", "Image")]);

    /// <summary>
    /// The offset to the start byte (SOI) of JPEG compressed thumbnail data. This is not used for primary image JPEG data.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag ThumbnailOffset = CreateOffsetAndLengthPair(TagAny.SubIfd, null, 0x0201, "ThumbnailOffset", 0x0202, "ThumbnailLength", [("Exif.Image.JPEGInterchangeFormat", "Image")]);

    /// <summary>
    /// VignettingCorrection (0x7031)
    /// </summary>
    public static readonly Tag VignettingCorrection = Create(TagAny.SubIfd, null, 0x7031, "VignettingCorrection");

    /// <summary>
    /// Sony vignetting correction parameters
    /// </summary>
    /// <remarks>
    /// Expected type is SInt16[17].
    /// </remarks>
    public static readonly Tag VignettingCorrParams = Create(TagAny.SubIfd, null, 0x7032, "VignettingCorrParams", true, [("Exif.Image.VignettingCorrParams", "Image")]);

    /// <summary>
    /// ChromaticAberrationCorrection (0x7034)
    /// </summary>
    public static readonly Tag ChromaticAberrationCorrection = Create(TagAny.SubIfd, null, 0x7034, "ChromaticAberrationCorrection");

    /// <summary>
    /// Sony chromatic aberration correction parameters
    /// </summary>
    /// <remarks>
    /// Expected type is SInt16[33].
    /// </remarks>
    public static readonly Tag ChromaticAberrationCorrParams = Create(TagAny.SubIfd, null, 0x7035, "ChromaticAberrationCorrParams", true, [("Exif.Image.ChromaticAberrationCorrParams", "Image")]);

    /// <summary>
    /// DistortionCorrection (0x7036)
    /// </summary>
    public static readonly Tag DistortionCorrection = Create(TagAny.SubIfd, null, 0x7036, "DistortionCorrection");

    /// <summary>
    /// Sony distortion correction parameters
    /// </summary>
    /// <remarks>
    /// Expected type is SInt16[17].
    /// </remarks>
    public static readonly Tag DistortionCorrParams = Create(TagAny.SubIfd, null, 0x7037, "DistortionCorrParams", true, [("Exif.Image.DistortionCorrParams", "Image")]);

    /// <summary>
    /// SonyRawImageSize (0x7038)
    /// </summary>
    public static readonly Tag SonyRawImageSize = Create(TagAny.SubIfd, null, 0x7038, "SonyRawImageSize");

    /// <summary>
    /// BlackLevel (0x7310)
    /// </summary>
    public static readonly Tag SonyBlackLevel = Create(TagAny.SubIfd, null, 0x7310, "BlackLevel");

    /// <summary>
    /// WB_RGGBLevels (0x7313)
    /// </summary>
    public static readonly Tag WbRggbLevels = Create(TagAny.SubIfd, null, 0x7313, "WB_RGGBLevels");

    /// <summary>
    /// SonyCropTopLeft (0x74C7)
    /// </summary>
    public static readonly Tag SonyCropTopLeft = Create(TagAny.SubIfd, null, 0x74C7, "SonyCropTopLeft");

    /// <summary>
    /// SonyCropSize (0x74C8)
    /// </summary>
    public static readonly Tag SonyCropSize = Create(TagAny.SubIfd, null, 0x74C8, "SonyCropSize");

    /// <summary>
    /// Contains two values representing the minimum rows and columns to define the repeating patterns of the color filter array
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16[2].
    /// </remarks>
    public static readonly Tag CfaRepeatPatternDim = Create(TagAny.SubIfd, null, 0x828D, "CFARepeatPatternDim", true, [("Exif.Image.CFARepeatPatternDim", "Image")]);

    /// <summary>
    /// Indicates the color filter array (CFA) geometric pattern of the image sensor when a one-chip color area sensor is used. It does not apply to all sensing methods
    /// </summary>
    /// <remarks>
    /// Expected type is Byte[n].
    /// </remarks>
    public static readonly Tag CfaPattern2 = Create(TagAny.SubIfd, null, 0x828E, "CFAPattern2", true, [("Exif.Image.CFAPattern", "Image")]);

    /// <summary>
    /// Provides a mapping between the values in the CFAPattern tag and the plane numbers in LinearRaw space. This is a required tag for non-RGB CFA images.
    /// </summary>
    /// <remarks>
    /// Expected type is Byte.
    /// </remarks>
    public static readonly Tag CfaPlaneColor = Create(TagAny.SubIfd, null, 0xC616, "CFAPlaneColor", true, [("Exif.Image.CFAPlaneColor", "Image")]);

    /// <summary>
    /// Describes the spatial layout of the CFA.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag CfaLayout = Create(TagAny.SubIfd, null, 0xC617, "CFALayout", true, [("Exif.Image.CFALayout", "Image")]);

    /// <summary>
    /// Describes a lookup table that maps stored values into linear values. This tag is typically used to increase compression ratios by storing the raw data in a non-linear, more visually uniform space with fewer total encoding levels. If SamplesPerPixel is not equal to one, this single table applies to all the samples for each pixel.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16[n].
    /// </remarks>
    public static readonly Tag LinearizationTable = Create(TagAny.SubIfd, null, 0xC618, "LinearizationTable", true, [("Exif.Image.LinearizationTable", "Image")]);

    /// <summary>
    /// Specifies repeat pattern size for the BlackLevel tag.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16[2].
    /// </remarks>
    public static readonly Tag BlackLevelRepeatDim = Create(TagAny.SubIfd, null, 0xC619, "BlackLevelRepeatDim", true, [("Exif.Image.BlackLevelRepeatDim", "Image")]);

    /// <summary>
    /// Specifies the zero light (a.k.a. thermal black or black current) encoding level, as a repeating pattern. The origin of this pattern is the top-left corner of the ActiveArea rectangle. The values are stored in row-column-sample scan order.
    /// </summary>
    /// <remarks>
    /// Expected type is URational[n].
    /// </remarks>
    public static readonly Tag BlackLevel = Create(TagAny.SubIfd, null, 0xC61A, "BlackLevel", true, [("Exif.Image.BlackLevel", "Image")]);

    /// <summary>
    /// If the zero light encoding level is a function of the image column, BlackLevelDeltaH specifies the difference between the zero light encoding level for each column and the baseline zero light encoding level. If SamplesPerPixel is not equal to one, this single table applies to all the samples for each pixel.
    /// </summary>
    /// <remarks>
    /// Expected type is SRational[n].
    /// </remarks>
    public static readonly Tag BlackLevelDeltaH = Create(TagAny.SubIfd, null, 0xC61B, "BlackLevelDeltaH", true, [("Exif.Image.BlackLevelDeltaH", "Image")]);

    /// <summary>
    /// If the zero light encoding level is a function of the image row, this tag specifies the difference between the zero light encoding level for each row and the baseline zero light encoding level. If SamplesPerPixel is not equal to one, this single table applies to all the samples for each pixel.
    /// </summary>
    /// <remarks>
    /// Expected type is SRational[n].
    /// </remarks>
    public static readonly Tag BlackLevelDeltaV = Create(TagAny.SubIfd, null, 0xC61C, "BlackLevelDeltaV", true, [("Exif.Image.BlackLevelDeltaV", "Image")]);

    /// <summary>
    /// This tag specifies the fully saturated encoding level for the raw sample values. Saturation is caused either by the sensor itself becoming highly non-linear in response, or by the camera's analog to digital converter clipping.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32[n].
    /// </remarks>
    public static readonly Tag WhiteLevel = Create(TagAny.SubIfd, null, 0xC61D, "WhiteLevel", true, [("Exif.Image.WhiteLevel", "Image")]);

    /// <summary>
    /// DefaultScale is required for cameras with non-square pixels. It specifies the default scale factors for each direction to convert the image to square pixels. Typically these factors are selected to approximately preserve total pixel count. For CFA images that use CFALayout equal to 2, 3, 4, or 5, such as the Fujifilm SuperCCD, these two values should usually differ by a factor of 2.0.
    /// </summary>
    /// <remarks>
    /// Expected type is URational[2].
    /// </remarks>
    public static readonly Tag DefaultScale = Create(TagAny.SubIfd, null, 0xC61E, "DefaultScale", true, [("Exif.Image.DefaultScale", "Image")]);

    /// <summary>
    /// Raw images often store extra pixels around the edges of the final image. These extra pixels help prevent interpolation artifacts near the edges of the final image. DefaultCropOrigin specifies the origin of the final image area, in raw image coordinates (i.e., before the DefaultScale has been applied), relative to the top-left corner of the ActiveArea rectangle.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32[2].
    /// </remarks>
    public static readonly Tag DefaultCropOrigin = Create(TagAny.SubIfd, null, 0xC61F, "DefaultCropOrigin", true, [("Exif.Image.DefaultCropOrigin", "Image")]);

    /// <summary>
    /// Raw images often store extra pixels around the edges of the final image. These extra pixels help prevent interpolation artifacts near the edges of the final image. DefaultCropSize specifies the size of the final image area, in raw image coordinates (i.e., before the DefaultScale has been applied).
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32[2].
    /// </remarks>
    public static readonly Tag DefaultCropSize = Create(TagAny.SubIfd, null, 0xC620, "DefaultCropSize", true, [("Exif.Image.DefaultCropSize", "Image")]);

    /// <summary>
    /// Only applies to CFA images using a Bayer pattern filter array. This tag specifies, in arbitrary units, how closely the values of the green pixels in the blue/green rows track the values of the green pixels in the red/green rows. A value of zero means the two kinds of green pixels track closely, while a non-zero value means they sometimes diverge. The useful range for this tag is from 0 (no divergence) to about 5000 (quite large divergence).
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag BayerGreenSplit = Create(TagAny.SubIfd, null, 0xC62D, "BayerGreenSplit", true, [("Exif.Image.BayerGreenSplit", "Image")]);

    /// <summary>
    /// ChromaBlurRadius provides a hint to the DNG reader about how much chroma blur should be applied to the image. If this tag is omitted, the reader will use its default amount of chroma blurring. Normally this tag is only included for non-CFA images, since the amount of chroma blur required for mosaic images is highly dependent on the de-mosaic algorithm, in which case the DNG reader's default value is likely optimized for its particular de-mosaic algorithm.
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag ChromaBlurRadius = Create(TagAny.SubIfd, null, 0xC631, "ChromaBlurRadius", true, [("Exif.Image.ChromaBlurRadius", "Image")]);

    /// <summary>
    /// Provides a hint to the DNG reader about how strong the camera's anti-alias filter is. A value of 0.0 means no anti-alias filter (i.e., the camera is prone to aliasing artifacts with some subjects), while a value of 1.0 means a strong anti-alias filter (i.e., the camera almost never has aliasing artifacts).
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag AntiAliasStrength = Create(TagAny.SubIfd, null, 0xC632, "AntiAliasStrength", true, [("Exif.Image.AntiAliasStrength", "Image")]);

    /// <summary>
    /// For some cameras, the best possible image quality is not achieved by preserving the total pixel count during conversion. For example, Fujifilm SuperCCD images have maximum detail when their total pixel count is doubled. This tag specifies the amount by which the values of the DefaultScale tag need to be multiplied to achieve the best quality image size.
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag BestQualityScale = Create(TagAny.SubIfd, null, 0xC65C, "BestQualityScale", true, [("Exif.Image.BestQualityScale", "Image")]);

    /// <summary>
    /// This rectangle defines the active (non-masked) pixels of the sensor. The order of the rectangle coordinates is: top, left, bottom, right.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32[4].
    /// </remarks>
    public static readonly Tag ActiveArea = Create(TagAny.SubIfd, null, 0xC68D, "ActiveArea", true, [("Exif.Image.ActiveArea", "Image")]);

    /// <summary>
    /// This tag contains a list of non-overlapping rectangle coordinates of fully masked pixels, which can be optionally used by DNG readers to measure the black encoding level. The order of each rectangle's coordinates is: top, left, bottom, right. If the raw image data has already had its black encoding level subtracted, then this tag should not be used, since the masked pixels are no longer useful.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32[n].
    /// </remarks>
    public static readonly Tag MaskedAreas = Create(TagAny.SubIfd, null, 0xC68E, "MaskedAreas", true, [("Exif.Image.MaskedAreas", "Image")]);

    /// <summary>
    /// This tag indicates how much noise reduction has been applied to the raw data on a scale of 0.0 to 1.0. A 0.0 value indicates that no noise reduction has been applied. A 1.0 value indicates that the "ideal" amount of noise reduction has been applied, i.e. that the DNG reader should not apply additional noise reduction by default. A value of 0/0 indicates that this parameter is unknown.
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag NoiseReductionApplied = Create(TagAny.SubIfd, null, 0xC6F7, "NoiseReductionApplied", true, [("Exif.Image.NoiseReductionApplied", "Image")]);

    /// <summary>
    /// Specifies the list of opcodes that should be applied to the raw image, as read directly from the file.
    /// </summary>
    /// <remarks>
    /// Expected type is Undefined.
    /// </remarks>
    public static readonly Tag OpcodeList1 = Create(TagAny.SubIfd, null, 0xC740, "OpcodeList1", true, [("Exif.Image.OpcodeList1", "Image")]);

    /// <summary>
    /// Specifies the list of opcodes that should be applied to the raw image, just after it has been mapped to linear reference values.
    /// </summary>
    /// <remarks>
    /// Expected type is Undefined.
    /// </remarks>
    public static readonly Tag OpcodeList2 = Create(TagAny.SubIfd, null, 0xC741, "OpcodeList2", true, [("Exif.Image.OpcodeList2", "Image")]);

    /// <summary>
    /// Specifies the list of opcodes that should be applied to the raw image, just after it has been demosaiced.
    /// </summary>
    /// <remarks>
    /// Expected type is Undefined.
    /// </remarks>
    public static readonly Tag OpcodeList3 = Create(TagAny.SubIfd, null, 0xC74E, "OpcodeList3", true, [("Exif.Image.OpcodeList3", "Image")]);

    /// <summary>
    /// NoiseProfile describes the amount of noise in a raw image. Specifically, this tag models the amount of signal-dependent photon (shot) noise and signal-independent sensor readout noise, two common sources of noise in raw images. The model assumes that the noise is white and spatially independent, ignoring fixed pattern effects and other sources of noise (e.g., pixel response non-uniformity, spatially-dependent thermal effects, etc.).
    /// </summary>
    /// <remarks>
    /// Expected type is Double[n].
    /// </remarks>
    public static readonly Tag NoiseProfile = Create(TagAny.SubIfd, null, 0xC761, "NoiseProfile", true, [("Exif.Image.NoiseProfile", "Image")]);

    /// <summary>
    /// CacheVersion (0xC7AA)
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag CacheVersion = Create(TagAny.SubIfd, null, 0xC7AA, "CacheVersion");

    /// <summary>
    /// Specifies a default user crop rectangle in relative coordinates. The values must satisfy: 0.0 <= top < bottom <= 1.0, 0.0 <= left < right <= 1.0.The default values of (top = 0, left = 0, bottom = 1, right = 1) correspond exactly to the default crop rectangle (as specified by the DefaultCropOrigin and DefaultCropSize tags).
    /// </summary>
    /// <remarks>
    /// Expected type is URational[4].
    /// </remarks>
    public static readonly Tag DefaultUserCrop = Create(TagAny.SubIfd, null, 0xC7B5, "DefaultUserCrop", true, [("Exif.Image.DefaultUserCrop", "Image")]);

    /// <summary>
    /// Contains spatially varying gain tables that can be applied while processing the image as a starting point for user adjustments.
    /// </summary>
    /// <remarks>
    /// Expected type is Undefined.
    /// </remarks>
    public static readonly Tag ProfileGainTableMap = Create(TagAny.SubIfd, null, 0xCD2D, "ProfileGainTableMap", true, [("Exif.Image.ProfileGainTableMap", "Image")]);

    /// <summary>
    /// A string that identifies the semantic mask.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag SemanticName = Create(TagAny.SubIfd, null, 0xCD2E, "SemanticName", true, [("Exif.Image.SemanticName", "Image")]);

    /// <summary>
    /// A string that identifies a specific instance in a semantic mask.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag SemanticInstanceId = Create(TagAny.SubIfd, null, 0xCD30, "SemanticInstanceID", true, [("Exif.Image.SemanticInstanceID", "Image")]);

    /// <summary>
    /// This tag identifies the crop rectangle of this IFD's mask, relative to the main image.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag MaskSubArea = Create(TagAny.SubIfd, null, 0xCD38, "MaskSubArea", true, [("Exif.Image.MaskSubArea", "Image")]);

    /// <summary>
    /// This tag specifies that columns of the image are stored in interleaved order. The value of the tag specifies the number of interleaved fields. The use of a non-default value for this tag requires setting the DNGBackwardVersion tag to at least 1.7.1.0.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag ColumnInterleaveFactor = Create(TagAny.SubIfd, null, 0xCD43, "ColumnInterleaveFactor", true, [("Exif.Image.ColumnInterleaveFactor", "Image")]);
}
