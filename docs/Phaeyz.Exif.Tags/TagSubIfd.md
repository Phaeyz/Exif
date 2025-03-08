# TagSubIfd class

Tags which may appear in a "Sub" image file directory.

```csharp
public class TagSubIfd : Tag
```

## Public Members

| name | description |
| --- | --- |
| [TagSubIfd](TagSubIfd/TagSubIfd.md)() | The default constructor. |
| static readonly [ActiveArea](TagSubIfd/ActiveArea.md) | This rectangle defines the active (non-masked) pixels of the sensor. The order of the rectangle coordinates is: top, left, bottom, right. |
| static readonly [AntiAliasStrength](TagSubIfd/AntiAliasStrength.md) | Provides a hint to the DNG reader about how strong the camera's anti-alias filter is. A value of 0.0 means no anti-alias filter (i.e., the camera is prone to aliasing artifacts with some subjects), while a value of 1.0 means a strong anti-alias filter (i.e., the camera almost never has aliasing artifacts). |
| static readonly [BayerGreenSplit](TagSubIfd/BayerGreenSplit.md) | Only applies to CFA images using a Bayer pattern filter array. This tag specifies, in arbitrary units, how closely the values of the green pixels in the blue/green rows track the values of the green pixels in the red/green rows. A value of zero means the two kinds of green pixels track closely, while a non-zero value means they sometimes diverge. The useful range for this tag is from 0 (no divergence) to about 5000 (quite large divergence). |
| static readonly [BestQualityScale](TagSubIfd/BestQualityScale.md) | For some cameras, the best possible image quality is not achieved by preserving the total pixel count during conversion. For example, Fujifilm SuperCCD images have maximum detail when their total pixel count is doubled. This tag specifies the amount by which the values of the DefaultScale tag need to be multiplied to achieve the best quality image size. |
| static readonly [BlackLevel](TagSubIfd/BlackLevel.md) | Specifies the zero light (a.k.a. thermal black or black current) encoding level, as a repeating pattern. The origin of this pattern is the top-left corner of the ActiveArea rectangle. The values are stored in row-column-sample scan order. |
| static readonly [BlackLevelDeltaH](TagSubIfd/BlackLevelDeltaH.md) | If the zero light encoding level is a function of the image column, BlackLevelDeltaH specifies the difference between the zero light encoding level for each column and the baseline zero light encoding level. If SamplesPerPixel is not equal to one, this single table applies to all the samples for each pixel. |
| static readonly [BlackLevelDeltaV](TagSubIfd/BlackLevelDeltaV.md) | If the zero light encoding level is a function of the image row, this tag specifies the difference between the zero light encoding level for each row and the baseline zero light encoding level. If SamplesPerPixel is not equal to one, this single table applies to all the samples for each pixel. |
| static readonly [BlackLevelRepeatDim](TagSubIfd/BlackLevelRepeatDim.md) | Specifies repeat pattern size for the BlackLevel tag. |
| static readonly [CacheVersion](TagSubIfd/CacheVersion.md) | CacheVersion (0xC7AA) |
| static readonly [CfaLayout](TagSubIfd/CfaLayout.md) | Describes the spatial layout of the CFA. |
| static readonly [CfaPattern2](TagSubIfd/CfaPattern2.md) | Indicates the color filter array (CFA) geometric pattern of the image sensor when a one-chip color area sensor is used. It does not apply to all sensing methods |
| static readonly [CfaPlaneColor](TagSubIfd/CfaPlaneColor.md) | Provides a mapping between the values in the CFAPattern tag and the plane numbers in LinearRaw space. This is a required tag for non-RGB CFA images. |
| static readonly [CfaRepeatPatternDim](TagSubIfd/CfaRepeatPatternDim.md) | Contains two values representing the minimum rows and columns to define the repeating patterns of the color filter array |
| static readonly [ChromaBlurRadius](TagSubIfd/ChromaBlurRadius.md) | ChromaBlurRadius provides a hint to the DNG reader about how much chroma blur should be applied to the image. If this tag is omitted, the reader will use its default amount of chroma blurring. Normally this tag is only included for non-CFA images, since the amount of chroma blur required for mosaic images is highly dependent on the de-mosaic algorithm, in which case the DNG reader's default value is likely optimized for its particular de-mosaic algorithm. |
| static readonly [ChromaticAberrationCorrection](TagSubIfd/ChromaticAberrationCorrection.md) | ChromaticAberrationCorrection (0x7034) |
| static readonly [ChromaticAberrationCorrParams](TagSubIfd/ChromaticAberrationCorrParams.md) | Sony chromatic aberration correction parameters |
| static readonly [ColumnInterleaveFactor](TagSubIfd/ColumnInterleaveFactor.md) | This tag specifies that columns of the image are stored in interleaved order. The value of the tag specifies the number of interleaved fields. The use of a non-default value for this tag requires setting the DNGBackwardVersion tag to at least 1.7.1.0. |
| static readonly [DefaultCropOrigin](TagSubIfd/DefaultCropOrigin.md) | Raw images often store extra pixels around the edges of the final image. These extra pixels help prevent interpolation artifacts near the edges of the final image. DefaultCropOrigin specifies the origin of the final image area, in raw image coordinates (i.e., before the DefaultScale has been applied), relative to the top-left corner of the ActiveArea rectangle. |
| static readonly [DefaultCropSize](TagSubIfd/DefaultCropSize.md) | Raw images often store extra pixels around the edges of the final image. These extra pixels help prevent interpolation artifacts near the edges of the final image. DefaultCropSize specifies the size of the final image area, in raw image coordinates (i.e., before the DefaultScale has been applied). |
| static readonly [DefaultScale](TagSubIfd/DefaultScale.md) | DefaultScale is required for cameras with non-square pixels. It specifies the default scale factors for each direction to convert the image to square pixels. Typically these factors are selected to approximately preserve total pixel count. For CFA images that use CFALayout equal to 2, 3, 4, or 5, such as the Fujifilm SuperCCD, these two values should usually differ by a factor of 2.0. |
| static readonly [DefaultUserCrop](TagSubIfd/DefaultUserCrop.md) | Specifies a default user crop rectangle in relative coordinates. The values must satisfy: 0.0 &lt;= top &lt; bottom &lt;= 1.0, 0.0 &lt;= left &lt; right &lt;= 1.0.The default values of (top = 0, left = 0, bottom = 1, right = 1) correspond exactly to the default crop rectangle (as specified by the DefaultCropOrigin and DefaultCropSize tags). |
| static readonly [DistortionCorrection](TagSubIfd/DistortionCorrection.md) | DistortionCorrection (0x7036) |
| static readonly [DistortionCorrParams](TagSubIfd/DistortionCorrParams.md) | Sony distortion correction parameters |
| static readonly [LinearizationTable](TagSubIfd/LinearizationTable.md) | Describes a lookup table that maps stored values into linear values. This tag is typically used to increase compression ratios by storing the raw data in a non-linear, more visually uniform space with fewer total encoding levels. If SamplesPerPixel is not equal to one, this single table applies to all the samples for each pixel. |
| static readonly [MaskedAreas](TagSubIfd/MaskedAreas.md) | This tag contains a list of non-overlapping rectangle coordinates of fully masked pixels, which can be optionally used by DNG readers to measure the black encoding level. The order of each rectangle's coordinates is: top, left, bottom, right. If the raw image data has already had its black encoding level subtracted, then this tag should not be used, since the masked pixels are no longer useful. |
| static readonly [MaskSubArea](TagSubIfd/MaskSubArea.md) | This tag identifies the crop rectangle of this IFD's mask, relative to the main image. |
| static readonly [NoiseProfile](TagSubIfd/NoiseProfile.md) | NoiseProfile describes the amount of noise in a raw image. Specifically, this tag models the amount of signal-dependent photon (shot) noise and signal-independent sensor readout noise, two common sources of noise in raw images. The model assumes that the noise is white and spatially independent, ignoring fixed pattern effects and other sources of noise (e.g., pixel response non-uniformity, spatially-dependent thermal effects, etc.). |
| static readonly [NoiseReductionApplied](TagSubIfd/NoiseReductionApplied.md) | This tag indicates how much noise reduction has been applied to the raw data on a scale of 0.0 to 1.0. A 0.0 value indicates that no noise reduction has been applied. A 1.0 value indicates that the "ideal" amount of noise reduction has been applied, i.e. that the DNG reader should not apply additional noise reduction by default. A value of 0/0 indicates that this parameter is unknown. |
| static readonly [OpcodeList1](TagSubIfd/OpcodeList1.md) | Specifies the list of opcodes that should be applied to the raw image, as read directly from the file. |
| static readonly [OpcodeList2](TagSubIfd/OpcodeList2.md) | Specifies the list of opcodes that should be applied to the raw image, just after it has been mapped to linear reference values. |
| static readonly [OpcodeList3](TagSubIfd/OpcodeList3.md) | Specifies the list of opcodes that should be applied to the raw image, just after it has been demosaiced. |
| static readonly [ProfileGainTableMap](TagSubIfd/ProfileGainTableMap.md) | Contains spatially varying gain tables that can be applied while processing the image as a starting point for user adjustments. |
| static readonly [SampleFormat](TagSubIfd/SampleFormat.md) | This field specifies how to interpret each data sample in a pixel. |
| static readonly [SemanticInstanceId](TagSubIfd/SemanticInstanceId.md) | A string that identifies a specific instance in a semantic mask. |
| static readonly [SemanticName](TagSubIfd/SemanticName.md) | A string that identifies the semantic mask. |
| static readonly [SonyBlackLevel](TagSubIfd/SonyBlackLevel.md) | BlackLevel (0x7310) |
| static readonly [SonyCropSize](TagSubIfd/SonyCropSize.md) | SonyCropSize (0x74C8) |
| static readonly [SonyCropTopLeft](TagSubIfd/SonyCropTopLeft.md) | SonyCropTopLeft (0x74C7) |
| static readonly [SonyRawImageSize](TagSubIfd/SonyRawImageSize.md) | SonyRawImageSize (0x7038) |
| static readonly [ThumbnailOffset](TagSubIfd/ThumbnailOffset.md) | The offset to the start byte (SOI) of JPEG compressed thumbnail data. This is not used for primary image JPEG data. |
| static readonly [VignettingCorrection](TagSubIfd/VignettingCorrection.md) | VignettingCorrection (0x7031) |
| static readonly [VignettingCorrParams](TagSubIfd/VignettingCorrParams.md) | Sony vignetting correction parameters |
| static readonly [WbRggbLevels](TagSubIfd/WbRggbLevels.md) | WB_RGGBLevels (0x7313) |
| static readonly [WhiteLevel](TagSubIfd/WhiteLevel.md) | This tag specifies the fully saturated encoding level for the raw sample values. Saturation is caused either by the sensor itself becoming highly non-linear in response, or by the camera's analog to digital converter clipping. |

## See Also

* class [Tag](../Phaeyz.Exif/Tag.md)
* namespace [Phaeyz.Exif.Tags](../Phaeyz.Exif.md)
* [TagSubIfd.cs](https://github.com/Phaeyz/Exif/blob/main/Phaeyz.Exif/Tags/TagSubIfd.cs)

<!-- DO NOT EDIT: generated by xmldocmd for Phaeyz.Exif.dll -->
