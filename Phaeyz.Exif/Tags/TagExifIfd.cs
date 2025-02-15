namespace Phaeyz.Exif.Tags;

/// <summary>
/// Tags which only appear in the Exif image file directory.
/// </summary>
public class TagExifIfd : Tag
{
    /// <summary>
    /// Exposure time, given in seconds.
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag ExposureTime = Create(TagIfd0.ExifOffset, null, 0x829A, "ExposureTime", true, [("Exif.Image.ExposureTime", "Image"), ("Exif.Photo.ExposureTime", "Photo")]);

    /// <summary>
    /// The F number.
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag FNumber = Create(TagIfd0.ExifOffset, null, 0x829D, "FNumber", true, [("Exif.Image.FNumber", "Image"), ("Exif.Photo.FNumber", "Photo")]);

    /// <summary>
    /// The class of the program used by the camera to set exposure when the picture is taken.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag ExposureProgram = Create(TagIfd0.ExifOffset, null, 0x8822, "ExposureProgram", true, [("Exif.Image.ExposureProgram", "Image"), ("Exif.Photo.ExposureProgram", "Photo")]);

    /// <summary>
    /// Indicates the spectral sensitivity of each channel of the camera used. The tag value is an ASCII string compatible with the standard developed by the ASTM Technical Committee.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag SpectralSensitivity = Create(TagIfd0.ExifOffset, null, 0x8824, "SpectralSensitivity", true, [("Exif.Image.SpectralSensitivity", "Image"), ("Exif.Photo.SpectralSensitivity", "Photo")]);

    /// <summary>
    /// Indicates the ISO Speed and ISO Latitude of the camera or input device as specified in ISO 12232.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16[n].
    /// </remarks>
    public static readonly Tag Iso = Create(TagIfd0.ExifOffset, null, 0x8827, "ISO", true, [("Exif.Image.ISOSpeedRatings", "Image"), ("Exif.Photo.ISOSpeedRatings", "Photo")]);

    /// <summary>
    /// Indicates the Opto-Electoric Conversion Function (OECF) specified in ISO 14524. <OECF> is the relationship between the camera optical input and the image values.
    /// </summary>
    /// <remarks>
    /// Expected type is Undefined.
    /// </remarks>
    public static readonly Tag OptoElectricConvFactor = Create(TagIfd0.ExifOffset, null, 0x8828, "Opto-ElectricConvFactor", true, [("Exif.Image.OECF", "Image"), ("Exif.Photo.OECF", "Photo")]);

    /// <summary>
    /// This optional tag encodes the time zone of the camera clock (relative to Greenwich Mean Time) used to create the DataTimeOriginal tag-value when the picture was taken. It may also contain the time zone offset of the clock used to create the DateTime tag-value when the image was modified.
    /// </summary>
    /// <remarks>
    /// Expected type is SInt16[n].
    /// </remarks>
    public static readonly Tag TimeZoneOffset = Create(TagIfd0.ExifOffset, null, 0x882A, "TimeZoneOffset", true, [("Exif.Image.TimeZoneOffset", "Image")]);

    /// <summary>
    /// Number of seconds image capture was delayed from button press.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag SelfTimerMode = Create(TagIfd0.ExifOffset, null, 0x882B, "SelfTimerMode", true, [("Exif.Image.SelfTimerMode", "Image")]);

    /// <summary>
    /// The SensitivityType tag indicates which one of the parameters of ISO12232 is the PhotographicSensitivity tag. Although it is an optional tag, it should be recorded when a PhotographicSensitivity tag is recorded. Value = 4, 5, 6, or 7 may be used in case that the values of plural parameters are the same.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag SensitivityType = Create(TagIfd0.ExifOffset, null, 0x8830, "SensitivityType", true, [("Exif.Photo.SensitivityType", "Photo")]);

    /// <summary>
    /// This tag indicates the standard output sensitivity value of a camera or input device defined in ISO 12232. When recording this tag, the PhotographicSensitivity and SensitivityType tags shall also be recorded.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag StandardOutputSensitivity = Create(TagIfd0.ExifOffset, null, 0x8831, "StandardOutputSensitivity", true, [("Exif.Photo.StandardOutputSensitivity", "Photo")]);

    /// <summary>
    /// This tag indicates the recommended exposure index value of a camera or input device defined in ISO 12232. When recording this tag, the PhotographicSensitivity and SensitivityType tags shall also be recorded.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag RecommendedExposureIndex = Create(TagIfd0.ExifOffset, null, 0x8832, "RecommendedExposureIndex", true, [("Exif.Photo.RecommendedExposureIndex", "Photo")]);

    /// <summary>
    /// This tag indicates the ISO speed value of a camera or input device that is defined in ISO 12232. When recording this tag, the PhotographicSensitivity and SensitivityType tags shall also be recorded.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag IsoSpeed = Create(TagIfd0.ExifOffset, null, 0x8833, "ISOSpeed", true, [("Exif.Photo.ISOSpeed", "Photo")]);

    /// <summary>
    /// This tag indicates the ISO speed latitude yyy value of a camera or input device that is defined in ISO 12232. However, this tag shall not be recorded without ISOSpeed and ISOSpeedLatitudezzz.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag IsoSpeedLatitudeYyy = Create(TagIfd0.ExifOffset, null, 0x8834, "ISOSpeedLatitudeyyy", true, [("Exif.Photo.ISOSpeedLatitudeyyy", "Photo")]);

    /// <summary>
    /// This tag indicates the ISO speed latitude zzz value of a camera or input device that is defined in ISO 12232. However, this tag shall not be recorded without ISOSpeed and ISOSpeedLatitudeyyy.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag IsoSpeedLatitudeZzz = Create(TagIfd0.ExifOffset, null, 0x8835, "ISOSpeedLatitudezzz", true, [("Exif.Photo.ISOSpeedLatitudezzz", "Photo")]);

    /// <summary>
    /// The version of this standard supported. Nonexistence of this field is taken to mean nonconformance to the standard.
    /// </summary>
    /// <remarks>
    /// Expected type is Undefined.
    /// </remarks>
    public static readonly Tag ExifVersion = Create(TagIfd0.ExifOffset, null, 0x9000, "ExifVersion", true, [("Exif.Photo.ExifVersion", "Photo")]);

    /// <summary>
    /// The date and time when the original image data was generated. For a digital still camera the date and time the picture was taken are recorded.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag DateTimeOriginal = Create(TagIfd0.ExifOffset, null, 0x9003, "DateTimeOriginal", true, [("Exif.Image.DateTimeOriginal", "Image"), ("Exif.Photo.DateTimeOriginal", "Photo")]);

    /// <summary>
    /// The date and time when the image was stored as digital data.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag CreateDate = Create(TagIfd0.ExifOffset, null, 0x9004, "CreateDate", true, [("Exif.Photo.DateTimeDigitized", "Photo")]);

    /// <summary>
    /// GooglePlusUploadCode (0x9009)
    /// </summary>
    /// <remarks>
    /// Expected type is Undefined.
    /// </remarks>
    public static readonly Tag GooglePlusUploadCode = Create(TagIfd0.ExifOffset, null, 0x9009, "GooglePlusUploadCode");

    /// <summary>
    /// Time difference from Universal Time Coordinated including daylight saving time of DateTime tag.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag OffsetTime = Create(TagIfd0.ExifOffset, null, 0x9010, "OffsetTime", true, [("Exif.Photo.OffsetTime", "Photo")]);

    /// <summary>
    /// Time difference from Universal Time Coordinated including daylight saving time of DateTimeOriginal tag.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag OffsetTimeOriginal = Create(TagIfd0.ExifOffset, null, 0x9011, "OffsetTimeOriginal", true, [("Exif.Photo.OffsetTimeOriginal", "Photo")]);

    /// <summary>
    /// Time difference from Universal Time Coordinated including daylight saving time of DateTimeDigitized tag.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag OffsetTimeDigitized = Create(TagIfd0.ExifOffset, null, 0x9012, "OffsetTimeDigitized", true, [("Exif.Photo.OffsetTimeDigitized", "Photo")]);

    /// <summary>
    /// Information specific to compressed data. The channels of each component are arranged in order from the 1st component to the 4th. For uncompressed data the data arrangement is given in the <PhotometricInterpretation> tag. However, since <PhotometricInterpretation> can only express the order of Y, Cb and Cr, this tag is provided for cases when compressed data uses components other than Y, Cb, and Cr and to enable support of other sequences.
    /// </summary>
    /// <remarks>
    /// Expected type is Undefined[4].
    /// </remarks>
    public static readonly Tag ComponentsConfiguration = Create(TagIfd0.ExifOffset, null, 0x9101, "ComponentsConfiguration", true, [("Exif.Photo.ComponentsConfiguration", "Photo")]);

    /// <summary>
    /// Information specific to compressed data. The compression mode used for a compressed image is indicated in unit bits per pixel.
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag CompressedBitsPerPixel = Create(TagIfd0.ExifOffset, null, 0x9102, "CompressedBitsPerPixel", true, [("Exif.Image.CompressedBitsPerPixel", "Image"), ("Exif.Photo.CompressedBitsPerPixel", "Photo")]);

    /// <summary>
    /// Shutter speed. The unit is the APEX (Additive System of Photographic Exposure) setting.
    /// </summary>
    /// <remarks>
    /// Expected type is SRational.
    /// </remarks>
    public static readonly Tag ShutterSpeedValue = Create(TagIfd0.ExifOffset, null, 0x9201, "ShutterSpeedValue", true, [("Exif.Image.ShutterSpeedValue", "Image"), ("Exif.Photo.ShutterSpeedValue", "Photo")]);

    /// <summary>
    /// The lens aperture. The unit is the APEX value.
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag ApertureValue = Create(TagIfd0.ExifOffset, null, 0x9202, "ApertureValue", true, [("Exif.Image.ApertureValue", "Image"), ("Exif.Photo.ApertureValue", "Photo")]);

    /// <summary>
    /// The value of brightness. The unit is the APEX value. Ordinarily it is given in the range of -99.99 to 99.99.
    /// </summary>
    /// <remarks>
    /// Expected type is SRational.
    /// </remarks>
    public static readonly Tag BrightnessValue = Create(TagIfd0.ExifOffset, null, 0x9203, "BrightnessValue", true, [("Exif.Image.BrightnessValue", "Image"), ("Exif.Photo.BrightnessValue", "Photo")]);

    /// <summary>
    /// The exposure bias. The units is the APEX value. Ordinarily it is given in the range of -99.99 to 99.99.
    /// </summary>
    /// <remarks>
    /// Expected type is SRational.
    /// </remarks>
    public static readonly Tag ExposureCompensation = Create(TagIfd0.ExifOffset, null, 0x9204, "ExposureCompensation", true, [("Exif.Image.ExposureBiasValue", "Image"), ("Exif.Photo.ExposureBiasValue", "Photo")]);

    /// <summary>
    /// The smallest F number of the lens. The unit is the APEX value. Ordinarily it is given in the range of 00.00 to 99.99, but it is not limited to this range.
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag MaxApertureValue = Create(TagIfd0.ExifOffset, null, 0x9205, "MaxApertureValue", true, [("Exif.Image.MaxApertureValue", "Image"), ("Exif.Photo.MaxApertureValue", "Photo")]);

    /// <summary>
    /// The distance to the subject, given in meters.
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag SubjectDistance = Create(TagIfd0.ExifOffset, null, 0x9206, "SubjectDistance", true, [("Exif.Image.SubjectDistance", "Image"), ("Exif.Photo.SubjectDistance", "Photo")]);

    /// <summary>
    /// The metering mode.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag MeteringMode = Create(TagIfd0.ExifOffset, null, 0x9207, "MeteringMode", true, [("Exif.Image.MeteringMode", "Image"), ("Exif.Photo.MeteringMode", "Photo")]);

    /// <summary>
    /// The kind of light source.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag LightSource = Create(TagIfd0.ExifOffset, null, 0x9208, "LightSource", true, [("Exif.Image.LightSource", "Image"), ("Exif.Photo.LightSource", "Photo")]);

    /// <summary>
    /// This tag is recorded when an image is taken using a strobe light (flash).
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag Flash = Create(TagIfd0.ExifOffset, null, 0x9209, "Flash", true, [("Exif.Image.Flash", "Image"), ("Exif.Photo.Flash", "Photo")]);

    /// <summary>
    /// The actual focal length of the lens, in mm. Conversion is not made to the focal length of a 35 mm film camera.
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag FocalLength = Create(TagIfd0.ExifOffset, null, 0x920A, "FocalLength", true, [("Exif.Image.FocalLength", "Image"), ("Exif.Photo.FocalLength", "Photo")]);

    /// <summary>
    /// Number assigned to an image, e.g., in a chained image burst.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag ImageNumber = Create(TagIfd0.ExifOffset, null, 0x9211, "ImageNumber", true, [("Exif.Image.ImageNumber", "Image")]);

    /// <summary>
    /// Security classification assigned to the image.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag SecurityClassification = Create(TagIfd0.ExifOffset, null, 0x9212, "SecurityClassification", true, [("Exif.Image.SecurityClassification", "Image")]);

    /// <summary>
    /// Record of what has been done to the image.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag ImageHistory = Create(TagIfd0.ExifOffset, null, 0x9213, "ImageHistory", true, [("Exif.Image.ImageHistory", "Image")]);

    /// <summary>
    /// This tag indicates the location and area of the main subject in the overall scene.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16[n].
    /// </remarks>
    public static readonly Tag SubjectArea = Create(TagIfd0.ExifOffset, null, 0x9214, "SubjectArea", true, [("Exif.Image.SubjectLocation", "Image"), ("Exif.Photo.SubjectArea", "Photo")]);

    /// <summary>
    /// A tag for manufacturers of Exif writers to record any desired information. The contents are up to the manufacturer. Note that 10-20% of MakerNote implementations cannot roundtrip during deserialization and serialization due to using absolute byte offsets in the data.
    /// </summary>
    /// <remarks>
    /// Expected type is Unknown.
    /// </remarks>
    public static readonly Tag MakerNote = Create(TagIfd0.ExifOffset, null, 0x927C, "MakerNote", true, [("Exif.Photo.MakerNote", "Photo")]);

    /// <summary>
    /// A tag for Exif users to write keywords or comments on the image besides those in <ImageDescription>, and without the character code limitations of the <ImageDescription> tag.
    /// </summary>
    /// <remarks>
    /// Expected type is Undefined.
    /// </remarks>
    public static readonly Tag UserComment = Create(TagIfd0.ExifOffset, null, 0x9286, "UserComment", true, [("Exif.Photo.UserComment", "Photo")]);

    /// <summary>
    /// A tag used to record fractions of seconds for the <DateTime> tag.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag SubSecTime = Create(TagIfd0.ExifOffset, null, 0x9290, "SubSecTime", true, [("Exif.Photo.SubSecTime", "Photo")]);

    /// <summary>
    /// A tag used to record fractions of seconds for the <DateTimeOriginal> tag.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag SubSecTimeOriginal = Create(TagIfd0.ExifOffset, null, 0x9291, "SubSecTimeOriginal", true, [("Exif.Photo.SubSecTimeOriginal", "Photo")]);

    /// <summary>
    /// A tag used to record fractions of seconds for the <DateTimeDigitized> tag.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag SubSecTimeDigitized = Create(TagIfd0.ExifOffset, null, 0x9292, "SubSecTimeDigitized", true, [("Exif.Photo.SubSecTimeDigitized", "Photo")]);

    /// <summary>
    /// Temperature as the ambient situation at the shot, for example the room temperature where the photographer was holding the camera. The unit is degrees C.
    /// </summary>
    /// <remarks>
    /// Expected type is SRational.
    /// </remarks>
    public static readonly Tag AmbientTemperature = Create(TagIfd0.ExifOffset, null, 0x9400, "AmbientTemperature", true, [("Exif.Photo.Temperature", "Photo")]);

    /// <summary>
    /// Humidity as the ambient situation at the shot, for example the room humidity where the photographer was holding the camera. The unit is %.
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag Humidity = Create(TagIfd0.ExifOffset, null, 0x9401, "Humidity", true, [("Exif.Photo.Humidity", "Photo")]);

    /// <summary>
    /// Pressure as the ambient situation at the shot, for example the room atmosphere where the photographer was holding the camera or the water pressure under the sea. The unit is hPa.
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag Pressure = Create(TagIfd0.ExifOffset, null, 0x9402, "Pressure", true, [("Exif.Photo.Pressure", "Photo")]);

    /// <summary>
    /// Water depth as the ambient situation at the shot, for example the water depth of the camera at underwater photography. The unit is m.
    /// </summary>
    /// <remarks>
    /// Expected type is SRational.
    /// </remarks>
    public static readonly Tag WaterDepth = Create(TagIfd0.ExifOffset, null, 0x9403, "WaterDepth", true, [("Exif.Photo.WaterDepth", "Photo")]);

    /// <summary>
    /// Acceleration (a scalar regardless of direction) as the ambient situation at the shot, for example the driving acceleration of the vehicle which the photographer rode on at the shot. The unit is mGal (10e-5 m/s^2).
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag Acceleration = Create(TagIfd0.ExifOffset, null, 0x9404, "Acceleration", true, [("Exif.Photo.Acceleration", "Photo")]);

    /// <summary>
    /// Elevation/depression. angle of the orientation of the camera(imaging optical axis) as the ambient situation at the shot. The unit is degrees.
    /// </summary>
    /// <remarks>
    /// Expected type is SRational.
    /// </remarks>
    public static readonly Tag CameraElevationAngle = Create(TagIfd0.ExifOffset, null, 0x9405, "CameraElevationAngle", true, [("Exif.Photo.CameraElevationAngle", "Photo")]);

    /// <summary>
    /// XiaomiSettings (0x9999)
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag XiaomiSettings = Create(TagIfd0.ExifOffset, null, 0x9999, "XiaomiSettings");

    /// <summary>
    /// XiaomiModel (0x9A00)
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag XiaomiModel = Create(TagIfd0.ExifOffset, null, 0x9A00, "XiaomiModel");

    /// <summary>
    /// The FlashPix format version supported by a FPXR file.
    /// </summary>
    /// <remarks>
    /// Expected type is Undefined.
    /// </remarks>
    public static readonly Tag FlashpixVersion = Create(TagIfd0.ExifOffset, null, 0xA000, "FlashpixVersion", true, [("Exif.Photo.FlashpixVersion", "Photo")]);

    /// <summary>
    /// The color space information tag is always recorded as the color space specifier. Normally sRGB is used to define the color space based on the PC monitor conditions and environment. If a color space other than sRGB is used, Uncalibrated is set. Image data recorded as Uncalibrated can be treated as sRGB when it is converted to FlashPix.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag ColorSpace = Create(TagIfd0.ExifOffset, null, 0xA001, "ColorSpace", true, [("Exif.Photo.ColorSpace", "Photo")]);

    /// <summary>
    /// Information specific to compressed data. When a compressed file is recorded, the valid width of the meaningful image must be recorded in this tag, whether or not there is padding data or a restart marker. This tag should not exist in an uncompressed file.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag ExifImageWidth = Create(TagIfd0.ExifOffset, null, 0xA002, "ExifImageWidth", true, [("Exif.Photo.PixelXDimension", "Photo")]);

    /// <summary>
    /// Information specific to compressed data. When a compressed file is recorded, the valid height of the meaningful image must be recorded in this tag, whether or not there is padding data or a restart marker. This tag should not exist in an uncompressed file. Since data padding is unnecessary in the vertical direction, the number of lines recorded in this valid image height tag will in fact be the same as that recorded in the SOF.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag ExifImageHeight = Create(TagIfd0.ExifOffset, null, 0xA003, "ExifImageHeight", true, [("Exif.Photo.PixelYDimension", "Photo")]);

    /// <summary>
    /// This tag is used to record the name of an audio file related to the image data. The only relational information recorded here is the Exif audio file name and extension (an ASCII string consisting of 8 characters + '.' + 3 characters). The path is not recorded.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag RelatedSoundFile = Create(TagIfd0.ExifOffset, null, 0xA004, "RelatedSoundFile", true, [("Exif.Photo.RelatedSoundFile", "Photo")]);

    /// <summary>
    /// Interoperability IFD is composed of tags which stores the information to ensure the Interoperability and pointed by the following tag located in Exif IFD. The Interoperability structure of Interoperability IFD is the same as TIFF defined IFD structure but does not contain the image data characteristically compared with normal TIFF IFD.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag InteroperabilityIfd = CreateIfdPointer(TagIfd0.ExifOffset, null, 0xA005, "InteroperabilityIFD", false, [("Exif.Photo.InteroperabilityTag", "Photo")]);

    /// <summary>
    /// Indicates the strobe energy at the time the image is captured, as measured in Beam Candle Power Seconds (BCPS).
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag FlashEnergy = Create(TagIfd0.ExifOffset, null, 0xA20B, "FlashEnergy", true, [("Exif.Photo.FlashEnergy", "Photo")]);

    /// <summary>
    /// This tag records the camera or input device spatial frequency table and SFR values in the direction of image width, image height, and diagonal direction, as specified in ISO 12233.
    /// </summary>
    /// <remarks>
    /// Expected type is Undefined.
    /// </remarks>
    public static readonly Tag SpatialFrequencyResponse = Create(TagIfd0.ExifOffset, null, 0xA20C, "SpatialFrequencyResponse", true, [("Exif.Photo.SpatialFrequencyResponse", "Photo")]);

    /// <summary>
    /// Indicates the number of pixels in the image width (X) direction per <FocalPlaneResolutionUnit> on the camera focal plane.
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag FocalPlaneXResolution = Create(TagIfd0.ExifOffset, null, 0xA20E, "FocalPlaneXResolution", true, [("Exif.Photo.FocalPlaneXResolution", "Photo")]);

    /// <summary>
    /// Indicates the number of pixels in the image height (V) direction per <FocalPlaneResolutionUnit> on the camera focal plane.
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag FocalPlaneYResolution = Create(TagIfd0.ExifOffset, null, 0xA20F, "FocalPlaneYResolution", true, [("Exif.Photo.FocalPlaneYResolution", "Photo")]);

    /// <summary>
    /// Indicates the unit for measuring <FocalPlaneXResolution> and <FocalPlaneYResolution>. This value is the same as the <ResolutionUnit>.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag FocalPlaneResolutionUnit = Create(TagIfd0.ExifOffset, null, 0xA210, "FocalPlaneResolutionUnit", true, [("Exif.Photo.FocalPlaneResolutionUnit", "Photo")]);

    /// <summary>
    /// Indicates the location of the main subject in the scene. The value of this tag represents the pixel at the center of the main subject relative to the left edge, prior to rotation processing as per the <Rotation> tag. The first value indicates the X column number and second indicates the Y row number.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16[2].
    /// </remarks>
    public static readonly Tag SubjectLocation = Create(TagIfd0.ExifOffset, null, 0xA214, "SubjectLocation", true, [("Exif.Photo.SubjectLocation", "Photo")]);

    /// <summary>
    /// Indicates the exposure index selected on the camera or input device at the time the image is captured.
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag ExposureIndex = Create(TagIfd0.ExifOffset, null, 0xA215, "ExposureIndex", true, [("Exif.Photo.ExposureIndex", "Photo")]);

    /// <summary>
    /// Indicates the image sensor type on the camera or input device.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag SensingMethod = Create(TagIfd0.ExifOffset, null, 0xA217, "SensingMethod", true, [("Exif.Photo.SensingMethod", "Photo")]);

    /// <summary>
    /// Indicates the image source. If a DSC recorded the image, this tag value of this tag always be set to 3, indicating that the image was recorded on a DSC.
    /// </summary>
    /// <remarks>
    /// Expected type is Undefined.
    /// </remarks>
    public static readonly Tag FileSource = Create(TagIfd0.ExifOffset, null, 0xA300, "FileSource", true, [("Exif.Photo.FileSource", "Photo")]);

    /// <summary>
    /// Indicates the type of scene. If a DSC recorded the image, this tag value must always be set to 1, indicating that the image was directly photographed.
    /// </summary>
    /// <remarks>
    /// Expected type is Undefined.
    /// </remarks>
    public static readonly Tag SceneType = Create(TagIfd0.ExifOffset, null, 0xA301, "SceneType", true, [("Exif.Photo.SceneType", "Photo")]);

    /// <summary>
    /// Indicates the color filter array (CFA) geometric pattern of the image sensor when a one-chip color area sensor is used. It does not apply to all sensing methods.
    /// </summary>
    /// <remarks>
    /// Expected type is Undefined.
    /// </remarks>
    public static readonly Tag CfaPattern = Create(TagIfd0.ExifOffset, null, 0xA302, "CFAPattern", true, [("Exif.Photo.CFAPattern", "Photo")]);

    /// <summary>
    /// This tag indicates the use of special processing on image data, such as rendering geared to output. When special processing is performed, the reader is expected to disable or minimize any further processing.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag CustomRendered = Create(TagIfd0.ExifOffset, null, 0xA401, "CustomRendered", true, [("Exif.Photo.CustomRendered", "Photo")]);

    /// <summary>
    /// This tag indicates the exposure mode set when the image was shot. In auto-bracketing mode, the camera shoots a series of frames of the same scene at different exposure settings.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag ExposureMode = Create(TagIfd0.ExifOffset, null, 0xA402, "ExposureMode", true, [("Exif.Photo.ExposureMode", "Photo")]);

    /// <summary>
    /// This tag indicates the white balance mode set when the image was shot.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag WhiteBalance = Create(TagIfd0.ExifOffset, null, 0xA403, "WhiteBalance", true, [("Exif.Photo.WhiteBalance", "Photo")]);

    /// <summary>
    /// This tag indicates the digital zoom ratio when the image was shot. If the numerator of the recorded value is 0, this indicates that digital zoom was not used.
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag DigitalZoomRatio = Create(TagIfd0.ExifOffset, null, 0xA404, "DigitalZoomRatio", true, [("Exif.Photo.DigitalZoomRatio", "Photo")]);

    /// <summary>
    /// This tag indicates the equivalent focal length assuming a 35mm film camera, in mm. A value of 0 means the focal length is unknown. Note that this tag differs from the <FocalLength> tag.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag FocalLengthIn35MmFormat = Create(TagIfd0.ExifOffset, null, 0xA405, "FocalLengthIn35mmFormat", true, [("Exif.Photo.FocalLengthIn35mmFilm", "Photo")]);

    /// <summary>
    /// This tag indicates the type of scene that was shot. It can also be used to record the mode in which the image was shot. Note that this differs from the <SceneType> tag.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag SceneCaptureType = Create(TagIfd0.ExifOffset, null, 0xA406, "SceneCaptureType", true, [("Exif.Photo.SceneCaptureType", "Photo")]);

    /// <summary>
    /// This tag indicates the degree of overall image gain adjustment.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag GainControl = Create(TagIfd0.ExifOffset, null, 0xA407, "GainControl", true, [("Exif.Photo.GainControl", "Photo")]);

    /// <summary>
    /// This tag indicates the direction of contrast processing applied by the camera when the image was shot.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag Contrast = Create(TagIfd0.ExifOffset, null, 0xA408, "Contrast", true, [("Exif.Photo.Contrast", "Photo")]);

    /// <summary>
    /// This tag indicates the direction of saturation processing applied by the camera when the image was shot.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag Saturation = Create(TagIfd0.ExifOffset, null, 0xA409, "Saturation", true, [("Exif.Photo.Saturation", "Photo")]);

    /// <summary>
    /// This tag indicates the direction of sharpness processing applied by the camera when the image was shot.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag Sharpness = Create(TagIfd0.ExifOffset, null, 0xA40A, "Sharpness", true, [("Exif.Photo.Sharpness", "Photo")]);

    /// <summary>
    /// This tag indicates information on the picture-taking conditions of a particular camera model. The tag is used only to indicate the picture-taking conditions in the reader.
    /// </summary>
    /// <remarks>
    /// Expected type is Undefined.
    /// </remarks>
    public static readonly Tag DeviceSettingDescription = Create(TagIfd0.ExifOffset, null, 0xA40B, "DeviceSettingDescription", true, [("Exif.Photo.DeviceSettingDescription", "Photo")]);

    /// <summary>
    /// This tag indicates the distance to the subject.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag SubjectDistanceRange = Create(TagIfd0.ExifOffset, null, 0xA40C, "SubjectDistanceRange", true, [("Exif.Photo.SubjectDistanceRange", "Photo")]);

    /// <summary>
    /// This tag indicates an identifier assigned uniquely to each image. It is recorded as an ASCII string equivalent to hexadecimal notation and 128-bit fixed length.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag ImageUniqueId = Create(TagIfd0.ExifOffset, null, 0xA420, "ImageUniqueID", true, [("Exif.Photo.ImageUniqueID", "Photo")]);

    /// <summary>
    /// This tag records the owner of a camera used in photography as an ASCII string.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag OwnerName = Create(TagIfd0.ExifOffset, null, 0xA430, "OwnerName", true, [("Exif.Photo.CameraOwnerName", "Photo")]);

    /// <summary>
    /// This tag records the serial number of the body of the camera that was used in photography as an ASCII string.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag SerialNumber = Create(TagIfd0.ExifOffset, null, 0xA431, "SerialNumber", true, [("Exif.Photo.BodySerialNumber", "Photo")]);

    /// <summary>
    /// This tag notes minimum focal length, maximum focal length, minimum F number in the minimum focal length, and minimum F number in the maximum focal length, which are specification information for the lens that was used in photography. When the minimum F number is unknown, the notation is 0/0
    /// </summary>
    /// <remarks>
    /// Expected type is URational[4].
    /// </remarks>
    public static readonly Tag LensInfo = Create(TagIfd0.ExifOffset, null, 0xA432, "LensInfo", true, [("Exif.Photo.LensSpecification", "Photo")]);

    /// <summary>
    /// This tag records the lens manufactor as an ASCII string.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag LensMake = Create(TagIfd0.ExifOffset, null, 0xA433, "LensMake", true, [("Exif.Photo.LensMake", "Photo")]);

    /// <summary>
    /// This tag records the lens's model name and model number as an ASCII string.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag LensModel = Create(TagIfd0.ExifOffset, null, 0xA434, "LensModel", true, [("Exif.Photo.LensModel", "Photo")]);

    /// <summary>
    /// This tag records the serial number of the interchangeable lens that was used in photography as an ASCII string.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag LensSerialNumber = Create(TagIfd0.ExifOffset, null, 0xA435, "LensSerialNumber", true, [("Exif.Photo.LensSerialNumber", "Photo")]);

    /// <summary>
    /// This tag records the title of the image.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag ImageTitle = Create(TagIfd0.ExifOffset, null, 0xA436, "ImageTitle", true, [("Exif.Photo.ImageTitle", "Photo")]);

    /// <summary>
    /// This tag records the name of the photographer.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag Photographer = Create(TagIfd0.ExifOffset, null, 0xA437, "Photographer", true, [("Exif.Photo.Photographer", "Photo")]);

    /// <summary>
    /// This tag records the name of the main person who edited the image. Preferably, a single name is written (individual name, group/organization name, etc.), but multiple main editors may be entered.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag ImageEditor = Create(TagIfd0.ExifOffset, null, 0xA438, "ImageEditor", true, [("Exif.Photo.ImageEditor", "Photo")]);

    /// <summary>
    /// This tag records the name and version of the software or firmware of the camera used to generate the image.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag CameraFirmware = Create(TagIfd0.ExifOffset, null, 0xA439, "CameraFirmware", true, [("Exif.Photo.CameraFirmware", "Photo")]);

    /// <summary>
    /// This tag records the name and version of the software used to develop the RAW image.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag RawDevelopingSoftware = Create(TagIfd0.ExifOffset, null, 0xA43A, "RAWDevelopingSoftware", true, [("Exif.Photo.RAWDevelopingSoftware", "Photo")]);

    /// <summary>
    /// This tag records the name and version of the main software used for processing and editing the image. Preferably, a single software is written, but multiple main software may be entered.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag ImageEditingSoftware = Create(TagIfd0.ExifOffset, null, 0xA43B, "ImageEditingSoftware", true, [("Exif.Photo.ImageEditingSoftware", "Photo")]);

    /// <summary>
    /// This tag records the name and version of one software used to edit the metadata of the image without processing or editing of the image data itself.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag MetadataEditingSoftware = Create(TagIfd0.ExifOffset, null, 0xA43C, "MetadataEditingSoftware", true, [("Exif.Photo.MetadataEditingSoftware", "Photo")]);

    /// <summary>
    /// Indicates whether the recorded image is a composite image or not.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag CompositeImage = Create(TagIfd0.ExifOffset, null, 0xA460, "CompositeImage", true, [("Exif.Photo.CompositeImage", "Photo")]);

    /// <summary>
    /// Indicates the number of the source images (tentatively recorded images) captured for a composite Image.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16[2].
    /// </remarks>
    public static readonly Tag CompositeImageCount = Create(TagIfd0.ExifOffset, null, 0xA461, "CompositeImageCount", true, [("Exif.Photo.SourceImageNumberOfCompositeImage", "Photo")]);

    /// <summary>
    /// For a composite image, records the parameters relating exposure time of the exposures for generating the said composite image, such as respective exposure times of captured source images (tentatively recorded images).
    /// </summary>
    /// <remarks>
    /// Expected type is Undefined.
    /// </remarks>
    public static readonly Tag CompositeImageExposureTimes = Create(TagIfd0.ExifOffset, null, 0xA462, "CompositeImageExposureTimes", true, [("Exif.Photo.SourceExposureTimesOfCompositeImage", "Photo")]);

    /// <summary>
    /// Indicates the value of coefficient gamma. The formula of transfer function used for image reproduction is expressed as follows: (reproduced value) = (input value)^gamma. Both reproduced value and input value indicate normalized value, whose minimum value is 0 and maximum value is 1.
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag Gamma = Create(TagIfd0.ExifOffset, null, 0xA500, "Gamma", true, [("Exif.Photo.Gamma", "Photo")]);

    /// <summary>
    /// Padding (0xEA1C)
    /// </summary>
    /// <remarks>
    /// Expected type is Undefined.
    /// </remarks>
    public static readonly Tag Padding = Create(TagIfd0.ExifOffset, null, 0xEA1C, "Padding");

    /// <summary>
    /// OffsetSchema (0xEA1D)
    /// </summary>
    /// <remarks>
    /// Expected type is SInt32.
    /// </remarks>
    public static readonly Tag OffsetSchema = Create(TagIfd0.ExifOffset, null, 0xEA1D, "OffsetSchema");

    /// <summary>
    /// OwnerName (0xFDE8)
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag PhotoshopOwnerName = Create(TagIfd0.ExifOffset, null, 0xFDE8, "OwnerName");

    /// <summary>
    /// SerialNumber (0xFDE9)
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag SerialNumberAlt = Create(TagIfd0.ExifOffset, null, 0xFDE9, "SerialNumber");

    /// <summary>
    /// Lens (0xFDEA)
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag Lens = Create(TagIfd0.ExifOffset, null, 0xFDEA, "Lens");

    /// <summary>
    /// RawFile (0xFE4C)
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag RawFile = Create(TagIfd0.ExifOffset, null, 0xFE4C, "RawFile");

    /// <summary>
    /// Converter (0xFE4D)
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag Converter = Create(TagIfd0.ExifOffset, null, 0xFE4D, "Converter");

    /// <summary>
    /// WhiteBalance (0xFE4E)
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag WhiteBalanceAlt = Create(TagIfd0.ExifOffset, null, 0xFE4E, "WhiteBalance");

    /// <summary>
    /// Exposure (0xFE51)
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag Exposure = Create(TagIfd0.ExifOffset, null, 0xFE51, "Exposure");

    /// <summary>
    /// Shadows (0xFE52)
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag Shadows = Create(TagIfd0.ExifOffset, null, 0xFE52, "Shadows");

    /// <summary>
    /// Brightness (0xFE53)
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag Brightness = Create(TagIfd0.ExifOffset, null, 0xFE53, "Brightness");

    /// <summary>
    /// Contrast (0xFE54)
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag ContrastAlt = Create(TagIfd0.ExifOffset, null, 0xFE54, "Contrast");

    /// <summary>
    /// Saturation (0xFE55)
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag SaturationAlt = Create(TagIfd0.ExifOffset, null, 0xFE55, "Saturation");

    /// <summary>
    /// Sharpness (0xFE56)
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag SharpnessAlt = Create(TagIfd0.ExifOffset, null, 0xFE56, "Sharpness");

    /// <summary>
    /// Smoothness (0xFE57)
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag Smoothness = Create(TagIfd0.ExifOffset, null, 0xFE57, "Smoothness");

    /// <summary>
    /// MoireFilter (0xFE58)
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag MoireFilter = Create(TagIfd0.ExifOffset, null, 0xFE58, "MoireFilter");
}
