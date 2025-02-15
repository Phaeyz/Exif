# TagIfd class

Tags which may appear in any root image file directory.

```csharp
public class TagIfd : Tag
```

## Public Members

| name | description |
| --- | --- |
| [TagIfd](TagIfd/TagIfd.md)() | The default constructor. |
| static readonly [Artist](TagIfd/Artist.md) | This tag records the name of the camera owner, photographer or image creator. The detailed format is not specified, but it is recommended that the information be written as in the example below for ease of Interoperability. When the field is left blank, it is treated as unknown. Ex.) "Camera owner, John Smith; Photographer, Michael Brown; Image creator, Ken James" |
| static readonly [BitsPerSample](TagIfd/BitsPerSample.md) | Indicates the identification of the Interoperability rule. Use "R98" for stating ExifR98 Rules. Four bytes used including the termination code (NULL). see the separate volume of Recommended Exif Interoperability Rules (ExifR98) for other tags used for ExifR98. |
| static readonly [Compression](TagIfd/Compression.md) | Indicates the identification of the Interoperability rule. Use "R98" for stating ExifR98 Rules. Four bytes used including the termination code (NULL). see the separate volume of Recommended Exif Interoperability Rules (ExifR98) for other tags used for ExifR98. |
| static readonly [Copyright](TagIfd/Copyright.md) | Copyright information. In this standard the tag is used to indicate both the photographer and editor copyrights. It is the copyright notice of the person or organization claiming rights to the image. The Interoperability copyright statement including date and rights should be written in this field; e.g., "Copyright, John Smith, 19xx. All rights reserved.". In this standard the field records both the photographer and editor copyrights, with each recorded in a separate part of the statement. When there is a clear distinction between the photographer and editor copyrights, these are to be written in the order of photographer followed by editor copyright, separated by NULL (in this case since the statement also ends with a NULL, there are two NULL codes). When only the photographer copyright is given, it is terminated by one NULL code. When only the editor copyright is given, the photographer copyright part consists of one space followed by a terminating NULL code, then the editor copyright is given. When the field is left blank, it is treated as unknown. |
| static readonly [ImageDescription](TagIfd/ImageDescription.md) | Indicates the identification of the Interoperability rule. Use "R98" for stating ExifR98 Rules. Four bytes used including the termination code (NULL). see the separate volume of Recommended Exif Interoperability Rules (ExifR98) for other tags used for ExifR98. |
| static readonly [ImageHeight](TagIfd/ImageHeight.md) | Indicates the identification of the Interoperability rule. Use "R98" for stating ExifR98 Rules. Four bytes used including the termination code (NULL). see the separate volume of Recommended Exif Interoperability Rules (ExifR98) for other tags used for ExifR98. |
| static readonly [ImageWidth](TagIfd/ImageWidth.md) | Indicates the identification of the Interoperability rule. Use "R98" for stating ExifR98 Rules. Four bytes used including the termination code (NULL). see the separate volume of Recommended Exif Interoperability Rules (ExifR98) for other tags used for ExifR98. |
| static readonly [Make](TagIfd/Make.md) | Indicates the identification of the Interoperability rule. Use "R98" for stating ExifR98 Rules. Four bytes used including the termination code (NULL). see the separate volume of Recommended Exif Interoperability Rules (ExifR98) for other tags used for ExifR98. |
| static readonly [Model](TagIfd/Model.md) | Indicates the identification of the Interoperability rule. Use "R98" for stating ExifR98 Rules. Four bytes used including the termination code (NULL). see the separate volume of Recommended Exif Interoperability Rules (ExifR98) for other tags used for ExifR98. |
| static readonly [ModifyDate](TagIfd/ModifyDate.md) | The date and time of image creation. In Exif standard, it is the date and time the file was changed. |
| static readonly [Orientation](TagIfd/Orientation.md) | Indicates the identification of the Interoperability rule. Use "R98" for stating ExifR98 Rules. Four bytes used including the termination code (NULL). see the separate volume of Recommended Exif Interoperability Rules (ExifR98) for other tags used for ExifR98. |
| static readonly [PhotometricInterpretation](TagIfd/PhotometricInterpretation.md) | Indicates the identification of the Interoperability rule. Use "R98" for stating ExifR98 Rules. Four bytes used including the termination code (NULL). see the separate volume of Recommended Exif Interoperability Rules (ExifR98) for other tags used for ExifR98. |
| static readonly [PlanarConfiguration](TagIfd/PlanarConfiguration.md) | Indicates whether pixel components are recorded in a chunky or planar format. In JPEG compressed files a JPEG marker is used instead of this tag. If this field does not exist, the TIFF default of 1 (chunky) is assumed. |
| static readonly [PrimaryChromaticities](TagIfd/PrimaryChromaticities.md) |  |
| static readonly [ReferenceBlackWhite](TagIfd/ReferenceBlackWhite.md) | The reference black point value and reference white point value. No defaults are given in TIFF, but the values below are given as defaults here. The color space is declared in a color space information tag, with the default being the value that gives the optimal image characteristics Interoperability these conditions. |
| static readonly [ResolutionUnit](TagIfd/ResolutionUnit.md) |  |
| static readonly [RowsPerStrip](TagIfd/RowsPerStrip.md) | Indicates the identification of the Interoperability rule. Use "R98" for stating ExifR98 Rules. Four bytes used including the termination code (NULL). see the separate volume of Recommended Exif Interoperability Rules (ExifR98) for other tags used for ExifR98. |
| static readonly [SamplesPerPixel](TagIfd/SamplesPerPixel.md) | Indicates the identification of the Interoperability rule. Use "R98" for stating ExifR98 Rules. Four bytes used including the termination code (NULL). see the separate volume of Recommended Exif Interoperability Rules (ExifR98) for other tags used for ExifR98. |
| static readonly [Software](TagIfd/Software.md) | This tag records the name and version of the software or firmware of the camera or image input device used to generate the image. The detailed format is not specified, but it is recommended that the example shown below be followed. When the field is left blank, it is treated as unknown. |
| static readonly [ThumbnailOffset](TagIfd/ThumbnailOffset.md) | The offset to the start byte (SOI) of JPEG compressed thumbnail data. This is not used for primary image JPEG data. |
| static readonly [TransferFunction](TagIfd/TransferFunction.md) |  |
| static readonly [WhitePoint](TagIfd/WhitePoint.md) |  |
| static readonly [XResolution](TagIfd/XResolution.md) | Indicates the identification of the Interoperability rule. Use "R98" for stating ExifR98 Rules. Four bytes used including the termination code (NULL). see the separate volume of Recommended Exif Interoperability Rules (ExifR98) for other tags used for ExifR98. |
| static readonly [YCbCrCoefficients](TagIfd/YCbCrCoefficients.md) | The matrix coefficients for transformation from RGB to YCbCr image data. No default is given in TIFF; but here the value given in Appendix E, "Color Space Guidelines", is used as the default. The color space is declared in a color space information tag, with the default being the value that gives the optimal image characteristics Interoperability this condition. |
| static readonly [YCbCrPositioning](TagIfd/YCbCrPositioning.md) |  |
| static readonly [YCbCrSubSampling](TagIfd/YCbCrSubSampling.md) | The sampling ratio of chrominance components in relation to the luminance component. In JPEG compressed data a JPEG marker is used instead of this tag. |
| static readonly [YResolution](TagIfd/YResolution.md) |  |

## See Also

* class [Tag](../Phaeyz.Exif/Tag.md)
* namespace [Phaeyz.Exif.Tags](../Phaeyz.Exif.md)
* [TagIfd.cs](https://github.com/Phaeyz/Exif/blob/main/Phaeyz.Exif/Tags/TagIfd.cs)

<!-- DO NOT EDIT: generated by xmldocmd for Phaeyz.Exif.dll -->
