# TagExifIfd class

Tags which only appear in the Exif image file directory.

```csharp
public class TagExifIfd : Tag
```

## Public Members

| name | description |
| --- | --- |
| [TagExifIfd](TagExifIfd/TagExifIfd.md)() | The default constructor. |
| static readonly [Acceleration](TagExifIfd/Acceleration.md) | Acceleration (a scalar regardless of direction) as the ambient situation at the shot, for example the driving acceleration of the vehicle which the photographer rode on at the shot. The unit is mGal (10e-5 m/s^2). |
| static readonly [AmbientTemperature](TagExifIfd/AmbientTemperature.md) | Temperature as the ambient situation at the shot, for example the room temperature where the photographer was holding the camera. The unit is degrees C. |
| static readonly [ApertureValue](TagExifIfd/ApertureValue.md) | The lens aperture. The unit is the APEX value. |
| static readonly [Brightness](TagExifIfd/Brightness.md) | Brightness (0xFE53) |
| static readonly [BrightnessValue](TagExifIfd/BrightnessValue.md) | The value of brightness. The unit is the APEX value. Ordinarily it is given in the range of -99.99 to 99.99. |
| static readonly [CameraElevationAngle](TagExifIfd/CameraElevationAngle.md) | Elevation/depression. angle of the orientation of the camera(imaging optical axis) as the ambient situation at the shot. The unit is degrees. |
| static readonly [CameraFirmware](TagExifIfd/CameraFirmware.md) | This tag records the name and version of the software or firmware of the camera used to generate the image. |
| static readonly [CfaPattern](TagExifIfd/CfaPattern.md) | Indicates the color filter array (CFA) geometric pattern of the image sensor when a one-chip color area sensor is used. It does not apply to all sensing methods. |
| static readonly [ColorSpace](TagExifIfd/ColorSpace.md) | The color space information tag is always recorded as the color space specifier. Normally sRGB is used to define the color space based on the PC monitor conditions and environment. If a color space other than sRGB is used, Uncalibrated is set. Image data recorded as Uncalibrated can be treated as sRGB when it is converted to FlashPix. |
| static readonly [ComponentsConfiguration](TagExifIfd/ComponentsConfiguration.md) |  |
| static readonly [CompositeImage](TagExifIfd/CompositeImage.md) | Indicates whether the recorded image is a composite image or not. |
| static readonly [CompositeImageCount](TagExifIfd/CompositeImageCount.md) | Indicates the number of the source images (tentatively recorded images) captured for a composite Image. |
| static readonly [CompositeImageExposureTimes](TagExifIfd/CompositeImageExposureTimes.md) | For a composite image, records the parameters relating exposure time of the exposures for generating the said composite image, such as respective exposure times of captured source images (tentatively recorded images). |
| static readonly [CompressedBitsPerPixel](TagExifIfd/CompressedBitsPerPixel.md) | Information specific to compressed data. The compression mode used for a compressed image is indicated in unit bits per pixel. |
| static readonly [Contrast](TagExifIfd/Contrast.md) | This tag indicates the direction of contrast processing applied by the camera when the image was shot. |
| static readonly [ContrastAlt](TagExifIfd/ContrastAlt.md) | Contrast (0xFE54) |
| static readonly [Converter](TagExifIfd/Converter.md) | Converter (0xFE4D) |
| static readonly [CreateDate](TagExifIfd/CreateDate.md) | The date and time when the image was stored as digital data. |
| static readonly [CustomRendered](TagExifIfd/CustomRendered.md) | This tag indicates the use of special processing on image data, such as rendering geared to output. When special processing is performed, the reader is expected to disable or minimize any further processing. |
| static readonly [DateTimeOriginal](TagExifIfd/DateTimeOriginal.md) | The date and time when the original image data was generated. For a digital still camera the date and time the picture was taken are recorded. |
| static readonly [DeviceSettingDescription](TagExifIfd/DeviceSettingDescription.md) | This tag indicates information on the picture-taking conditions of a particular camera model. The tag is used only to indicate the picture-taking conditions in the reader. |
| static readonly [DigitalZoomRatio](TagExifIfd/DigitalZoomRatio.md) | This tag indicates the digital zoom ratio when the image was shot. If the numerator of the recorded value is 0, this indicates that digital zoom was not used. |
| static readonly [ExifImageHeight](TagExifIfd/ExifImageHeight.md) | Information specific to compressed data. When a compressed file is recorded, the valid height of the meaningful image must be recorded in this tag, whether or not there is padding data or a restart marker. This tag should not exist in an uncompressed file. Since data padding is unnecessary in the vertical direction, the number of lines recorded in this valid image height tag will in fact be the same as that recorded in the SOF. |
| static readonly [ExifImageWidth](TagExifIfd/ExifImageWidth.md) | Information specific to compressed data. When a compressed file is recorded, the valid width of the meaningful image must be recorded in this tag, whether or not there is padding data or a restart marker. This tag should not exist in an uncompressed file. |
| static readonly [ExifVersion](TagExifIfd/ExifVersion.md) | The version of this standard supported. Nonexistence of this field is taken to mean nonconformance to the standard. |
| static readonly [Exposure](TagExifIfd/Exposure.md) | Exposure (0xFE51) |
| static readonly [ExposureCompensation](TagExifIfd/ExposureCompensation.md) | The exposure bias. The units is the APEX value. Ordinarily it is given in the range of -99.99 to 99.99. |
| static readonly [ExposureIndex](TagExifIfd/ExposureIndex.md) | Indicates the exposure index selected on the camera or input device at the time the image is captured. |
| static readonly [ExposureMode](TagExifIfd/ExposureMode.md) | This tag indicates the exposure mode set when the image was shot. In auto-bracketing mode, the camera shoots a series of frames of the same scene at different exposure settings. |
| static readonly [ExposureProgram](TagExifIfd/ExposureProgram.md) | The class of the program used by the camera to set exposure when the picture is taken. |
| static readonly [ExposureTime](TagExifIfd/ExposureTime.md) | Exposure time, given in seconds. |
| static readonly [FileSource](TagExifIfd/FileSource.md) | Indicates the image source. If a DSC recorded the image, this tag value of this tag always be set to 3, indicating that the image was recorded on a DSC. |
| static readonly [Flash](TagExifIfd/Flash.md) | This tag is recorded when an image is taken using a strobe light (flash). |
| static readonly [FlashEnergy](TagExifIfd/FlashEnergy.md) | Indicates the strobe energy at the time the image is captured, as measured in Beam Candle Power Seconds (BCPS). |
| static readonly [FlashpixVersion](TagExifIfd/FlashpixVersion.md) | The FlashPix format version supported by a FPXR file. |
| static readonly [FNumber](TagExifIfd/FNumber.md) | The F number. |
| static readonly [FocalLength](TagExifIfd/FocalLength.md) | The actual focal length of the lens, in mm. Conversion is not made to the focal length of a 35 mm film camera. |
| static readonly [FocalLengthIn35MmFormat](TagExifIfd/FocalLengthIn35MmFormat.md) |  |
| static readonly [FocalPlaneResolutionUnit](TagExifIfd/FocalPlaneResolutionUnit.md) |  |
| static readonly [FocalPlaneXResolution](TagExifIfd/FocalPlaneXResolution.md) |  |
| static readonly [FocalPlaneYResolution](TagExifIfd/FocalPlaneYResolution.md) |  |
| static readonly [GainControl](TagExifIfd/GainControl.md) | This tag indicates the degree of overall image gain adjustment. |
| static readonly [Gamma](TagExifIfd/Gamma.md) | Indicates the value of coefficient gamma. The formula of transfer function used for image reproduction is expressed as follows: (reproduced value) = (input value)^gamma. Both reproduced value and input value indicate normalized value, whose minimum value is 0 and maximum value is 1. |
| static readonly [GooglePlusUploadCode](TagExifIfd/GooglePlusUploadCode.md) | GooglePlusUploadCode (0x9009) |
| static readonly [Humidity](TagExifIfd/Humidity.md) | Humidity as the ambient situation at the shot, for example the room humidity where the photographer was holding the camera. The unit is %. |
| static readonly [ImageEditingSoftware](TagExifIfd/ImageEditingSoftware.md) | This tag records the name and version of the main software used for processing and editing the image. Preferably, a single software is written, but multiple main software may be entered. |
| static readonly [ImageEditor](TagExifIfd/ImageEditor.md) | This tag records the name of the main person who edited the image. Preferably, a single name is written (individual name, group/organization name, etc.), but multiple main editors may be entered. |
| static readonly [ImageHistory](TagExifIfd/ImageHistory.md) | Record of what has been done to the image. |
| static readonly [ImageNumber](TagExifIfd/ImageNumber.md) | Number assigned to an image, e.g., in a chained image burst. |
| static readonly [ImageTitle](TagExifIfd/ImageTitle.md) | This tag records the title of the image. |
| static readonly [ImageUniqueId](TagExifIfd/ImageUniqueId.md) | This tag indicates an identifier assigned uniquely to each image. It is recorded as an ASCII string equivalent to hexadecimal notation and 128-bit fixed length. |
| static readonly [InteroperabilityIfd](TagExifIfd/InteroperabilityIfd.md) | Interoperability IFD is composed of tags which stores the information to ensure the Interoperability and pointed by the following tag located in Exif IFD. The Interoperability structure of Interoperability IFD is the same as TIFF defined IFD structure but does not contain the image data characteristically compared with normal TIFF IFD. |
| static readonly [Iso](TagExifIfd/Iso.md) | Indicates the ISO Speed and ISO Latitude of the camera or input device as specified in ISO 12232. |
| static readonly [IsoSpeed](TagExifIfd/IsoSpeed.md) | This tag indicates the ISO speed value of a camera or input device that is defined in ISO 12232. When recording this tag, the PhotographicSensitivity and SensitivityType tags shall also be recorded. |
| static readonly [IsoSpeedLatitudeYyy](TagExifIfd/IsoSpeedLatitudeYyy.md) | This tag indicates the ISO speed latitude yyy value of a camera or input device that is defined in ISO 12232. However, this tag shall not be recorded without ISOSpeed and ISOSpeedLatitudezzz. |
| static readonly [IsoSpeedLatitudeZzz](TagExifIfd/IsoSpeedLatitudeZzz.md) | This tag indicates the ISO speed latitude zzz value of a camera or input device that is defined in ISO 12232. However, this tag shall not be recorded without ISOSpeed and ISOSpeedLatitudeyyy. |
| static readonly [Lens](TagExifIfd/Lens.md) | Lens (0xFDEA) |
| static readonly [LensInfo](TagExifIfd/LensInfo.md) | This tag notes minimum focal length, maximum focal length, minimum F number in the minimum focal length, and minimum F number in the maximum focal length, which are specification information for the lens that was used in photography. When the minimum F number is unknown, the notation is 0/0 |
| static readonly [LensMake](TagExifIfd/LensMake.md) | This tag records the lens manufactor as an ASCII string. |
| static readonly [LensModel](TagExifIfd/LensModel.md) | This tag records the lens's model name and model number as an ASCII string. |
| static readonly [LensSerialNumber](TagExifIfd/LensSerialNumber.md) | This tag records the serial number of the interchangeable lens that was used in photography as an ASCII string. |
| static readonly [LightSource](TagExifIfd/LightSource.md) | The kind of light source. |
| static readonly [MakerNote](TagExifIfd/MakerNote.md) | A tag for manufacturers of Exif writers to record any desired information. The contents are up to the manufacturer. Note that 10-20% of MakerNote implementations cannot roundtrip during deserialization and serialization due to using absolute byte offsets in the data. |
| static readonly [MaxApertureValue](TagExifIfd/MaxApertureValue.md) | The smallest F number of the lens. The unit is the APEX value. Ordinarily it is given in the range of 00.00 to 99.99, but it is not limited to this range. |
| static readonly [MetadataEditingSoftware](TagExifIfd/MetadataEditingSoftware.md) | This tag records the name and version of one software used to edit the metadata of the image without processing or editing of the image data itself. |
| static readonly [MeteringMode](TagExifIfd/MeteringMode.md) | The metering mode. |
| static readonly [MoireFilter](TagExifIfd/MoireFilter.md) | MoireFilter (0xFE58) |
| static readonly [OffsetSchema](TagExifIfd/OffsetSchema.md) | OffsetSchema (0xEA1D) |
| static readonly [OffsetTime](TagExifIfd/OffsetTime.md) | Time difference from Universal Time Coordinated including daylight saving time of DateTime tag. |
| static readonly [OffsetTimeDigitized](TagExifIfd/OffsetTimeDigitized.md) | Time difference from Universal Time Coordinated including daylight saving time of DateTimeDigitized tag. |
| static readonly [OffsetTimeOriginal](TagExifIfd/OffsetTimeOriginal.md) | Time difference from Universal Time Coordinated including daylight saving time of DateTimeOriginal tag. |
| static readonly [OptoElectricConvFactor](TagExifIfd/OptoElectricConvFactor.md) |  |
| static readonly [OwnerName](TagExifIfd/OwnerName.md) | This tag records the owner of a camera used in photography as an ASCII string. |
| static readonly [Padding](TagExifIfd/Padding.md) | Padding (0xEA1C) |
| static readonly [Photographer](TagExifIfd/Photographer.md) | This tag records the name of the photographer. |
| static readonly [PhotoshopOwnerName](TagExifIfd/PhotoshopOwnerName.md) | OwnerName (0xFDE8) |
| static readonly [Pressure](TagExifIfd/Pressure.md) | Pressure as the ambient situation at the shot, for example the room atmosphere where the photographer was holding the camera or the water pressure under the sea. The unit is hPa. |
| static readonly [RawDevelopingSoftware](TagExifIfd/RawDevelopingSoftware.md) | This tag records the name and version of the software used to develop the RAW image. |
| static readonly [RawFile](TagExifIfd/RawFile.md) | RawFile (0xFE4C) |
| static readonly [RecommendedExposureIndex](TagExifIfd/RecommendedExposureIndex.md) | This tag indicates the recommended exposure index value of a camera or input device defined in ISO 12232. When recording this tag, the PhotographicSensitivity and SensitivityType tags shall also be recorded. |
| static readonly [RelatedSoundFile](TagExifIfd/RelatedSoundFile.md) | This tag is used to record the name of an audio file related to the image data. The only relational information recorded here is the Exif audio file name and extension (an ASCII string consisting of 8 characters + '.' + 3 characters). The path is not recorded. |
| static readonly [Saturation](TagExifIfd/Saturation.md) | This tag indicates the direction of saturation processing applied by the camera when the image was shot. |
| static readonly [SaturationAlt](TagExifIfd/SaturationAlt.md) | Saturation (0xFE55) |
| static readonly [SceneCaptureType](TagExifIfd/SceneCaptureType.md) |  |
| static readonly [SceneType](TagExifIfd/SceneType.md) | Indicates the type of scene. If a DSC recorded the image, this tag value must always be set to 1, indicating that the image was directly photographed. |
| static readonly [SecurityClassification](TagExifIfd/SecurityClassification.md) | Security classification assigned to the image. |
| static readonly [SelfTimerMode](TagExifIfd/SelfTimerMode.md) | Number of seconds image capture was delayed from button press. |
| static readonly [SensingMethod](TagExifIfd/SensingMethod.md) | Indicates the image sensor type on the camera or input device. |
| static readonly [SensitivityType](TagExifIfd/SensitivityType.md) | The SensitivityType tag indicates which one of the parameters of ISO12232 is the PhotographicSensitivity tag. Although it is an optional tag, it should be recorded when a PhotographicSensitivity tag is recorded. Value = 4, 5, 6, or 7 may be used in case that the values of plural parameters are the same. |
| static readonly [SerialNumber](TagExifIfd/SerialNumber.md) | This tag records the serial number of the body of the camera that was used in photography as an ASCII string. |
| static readonly [SerialNumberAlt](TagExifIfd/SerialNumberAlt.md) | SerialNumber (0xFDE9) |
| static readonly [Shadows](TagExifIfd/Shadows.md) | Shadows (0xFE52) |
| static readonly [Sharpness](TagExifIfd/Sharpness.md) | This tag indicates the direction of sharpness processing applied by the camera when the image was shot. |
| static readonly [SharpnessAlt](TagExifIfd/SharpnessAlt.md) | Sharpness (0xFE56) |
| static readonly [ShutterSpeedValue](TagExifIfd/ShutterSpeedValue.md) | Shutter speed. The unit is the APEX (Additive System of Photographic Exposure) setting. |
| static readonly [Smoothness](TagExifIfd/Smoothness.md) | Smoothness (0xFE57) |
| static readonly [SpatialFrequencyResponse](TagExifIfd/SpatialFrequencyResponse.md) | This tag records the camera or input device spatial frequency table and SFR values in the direction of image width, image height, and diagonal direction, as specified in ISO 12233. |
| static readonly [SpectralSensitivity](TagExifIfd/SpectralSensitivity.md) | Indicates the spectral sensitivity of each channel of the camera used. The tag value is an ASCII string compatible with the standard developed by the ASTM Technical Committee. |
| static readonly [StandardOutputSensitivity](TagExifIfd/StandardOutputSensitivity.md) | This tag indicates the standard output sensitivity value of a camera or input device defined in ISO 12232. When recording this tag, the PhotographicSensitivity and SensitivityType tags shall also be recorded. |
| static readonly [SubjectArea](TagExifIfd/SubjectArea.md) | This tag indicates the location and area of the main subject in the overall scene. |
| static readonly [SubjectDistance](TagExifIfd/SubjectDistance.md) | The distance to the subject, given in meters. |
| static readonly [SubjectDistanceRange](TagExifIfd/SubjectDistanceRange.md) | This tag indicates the distance to the subject. |
| static readonly [SubjectLocation](TagExifIfd/SubjectLocation.md) |  |
| static readonly [SubSecTime](TagExifIfd/SubSecTime.md) |  |
| static readonly [SubSecTimeDigitized](TagExifIfd/SubSecTimeDigitized.md) |  |
| static readonly [SubSecTimeOriginal](TagExifIfd/SubSecTimeOriginal.md) |  |
| static readonly [TimeZoneOffset](TagExifIfd/TimeZoneOffset.md) | This optional tag encodes the time zone of the camera clock (relative to Greenwich Mean Time) used to create the DataTimeOriginal tag-value when the picture was taken. It may also contain the time zone offset of the clock used to create the DateTime tag-value when the image was modified. |
| static readonly [UserComment](TagExifIfd/UserComment.md) |  |
| static readonly [WaterDepth](TagExifIfd/WaterDepth.md) | Water depth as the ambient situation at the shot, for example the water depth of the camera at underwater photography. The unit is m. |
| static readonly [WhiteBalance](TagExifIfd/WhiteBalance.md) | This tag indicates the white balance mode set when the image was shot. |
| static readonly [WhiteBalanceAlt](TagExifIfd/WhiteBalanceAlt.md) | WhiteBalance (0xFE4E) |
| static readonly [XiaomiModel](TagExifIfd/XiaomiModel.md) | XiaomiModel (0x9A00) |
| static readonly [XiaomiSettings](TagExifIfd/XiaomiSettings.md) | XiaomiSettings (0x9999) |

## See Also

* class [Tag](../Phaeyz.Exif/Tag.md)
* namespace [Phaeyz.Exif.Tags](../Phaeyz.Exif.md)
* [TagExifIfd.cs](https://github.com/Phaeyz/Exif/blob/main/Phaeyz.Exif/Tags/TagExifIfd.cs)

<!-- DO NOT EDIT: generated by xmldocmd for Phaeyz.Exif.dll -->
