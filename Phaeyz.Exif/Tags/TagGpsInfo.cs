namespace Phaeyz.Exif.Tags;

/// <summary>
/// Tags which only appear in the GPS info image file directory.
/// </summary>
public class TagGpsInfo : Tag
{
    /// <summary>
    /// Indicates the version of <GPSInfoIFD>. The version is given as 2.0.0.0. This tag is mandatory when <GPSInfo> tag is present. (Note: The <GPSVersionID> tag is given in bytes, unlike the <ExifVersion> tag. When the version is 2.0.0.0, the tag value is 02000000.H).
    /// </summary>
    /// <remarks>
    /// Expected type is Byte[4].
    /// </remarks>
    public static readonly Tag GpsVersionId = Create(TagIfd0.GpsInfo, null, 0x0000, "GPSVersionID", true, [("Exif.GPSInfo.GPSVersionID", "GPSInfo")]);

    /// <summary>
    /// Indicates whether the latitude is north or south latitude. The ASCII value 'N' indicates north latitude, and 'S' is south latitude.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii[2].
    /// </remarks>
    public static readonly Tag GpsLatitudeRef = Create(TagIfd0.GpsInfo, null, 0x0001, "GPSLatitudeRef", true, [("Exif.GPSInfo.GPSLatitudeRef", "GPSInfo")]);

    /// <summary>
    /// Indicates the latitude. The latitude is expressed as three RATIONAL values giving the degrees, minutes, and seconds, respectively. When degrees, minutes and seconds are expressed, the format is dd/1,mm/1,ss/1. When degrees and minutes are used and, for example, fractions of minutes are given up to two decimal places, the format is dd/1,mmmm/100,0/1.
    /// </summary>
    /// <remarks>
    /// Expected type is URational[3].
    /// </remarks>
    public static readonly Tag GpsLatitude = Create(TagIfd0.GpsInfo, null, 0x0002, "GPSLatitude", true, [("Exif.GPSInfo.GPSLatitude", "GPSInfo")]);

    /// <summary>
    /// Indicates whether the longitude is east or west longitude. ASCII 'E' indicates east longitude, and 'W' is west longitude.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii[2].
    /// </remarks>
    public static readonly Tag GpsLongitudeRef = Create(TagIfd0.GpsInfo, null, 0x0003, "GPSLongitudeRef", true, [("Exif.GPSInfo.GPSLongitudeRef", "GPSInfo")]);

    /// <summary>
    /// Indicates the longitude. The longitude is expressed as three RATIONAL values giving the degrees, minutes, and seconds, respectively. When degrees, minutes and seconds are expressed, the format is ddd/1,mm/1,ss/1. When degrees and minutes are used and, for example, fractions of minutes are given up to two decimal places, the format is ddd/1,mmmm/100,0/1.
    /// </summary>
    /// <remarks>
    /// Expected type is URational[3].
    /// </remarks>
    public static readonly Tag GpsLongitude = Create(TagIfd0.GpsInfo, null, 0x0004, "GPSLongitude", true, [("Exif.GPSInfo.GPSLongitude", "GPSInfo")]);

    /// <summary>
    /// Indicates the altitude used as the reference altitude. If the reference is sea level and the altitude is above sea level, 0 is given. If the altitude is below sea level, a value of 1 is given and the altitude is indicated as an absolute value in the GSPAltitude tag. The reference unit is meters. Note that this tag is BYTE type, unlike other reference tags.
    /// </summary>
    /// <remarks>
    /// Expected type is Byte.
    /// </remarks>
    public static readonly Tag GpsAltitudeRef = Create(TagIfd0.GpsInfo, null, 0x0005, "GPSAltitudeRef", true, [("Exif.GPSInfo.GPSAltitudeRef", "GPSInfo")]);

    /// <summary>
    /// Indicates the altitude based on the reference in GPSAltitudeRef. Altitude is expressed as one RATIONAL value. The reference unit is meters.
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag GpsAltitude = Create(TagIfd0.GpsInfo, null, 0x0006, "GPSAltitude", true, [("Exif.GPSInfo.GPSAltitude", "GPSInfo")]);

    /// <summary>
    /// Indicates the time as UTC (Coordinated Universal Time). <TimeStamp> is expressed as three RATIONAL values giving the hour, minute, and second (atomic clock).
    /// </summary>
    /// <remarks>
    /// Expected type is URational[3].
    /// </remarks>
    public static readonly Tag GpsTimeStamp = Create(TagIfd0.GpsInfo, null, 0x0007, "GPSTimeStamp", true, [("Exif.GPSInfo.GPSTimeStamp", "GPSInfo")]);

    /// <summary>
    /// Indicates the GPS satellites used for measurements. This tag can be used to describe the number of satellites, their ID number, angle of elevation, azimuth, SNR and other information in ASCII notation. The format is not specified. If the GPS receiver is incapable of taking measurements, value of the tag is set to NULL.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag GpsSatellites = Create(TagIfd0.GpsInfo, null, 0x0008, "GPSSatellites", true, [("Exif.GPSInfo.GPSSatellites", "GPSInfo")]);

    /// <summary>
    /// Indicates the status of the GPS receiver when the image is recorded. "A" means measurement is in progress, and "V" means the measurement is Interoperability.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii[2].
    /// </remarks>
    public static readonly Tag GpsStatus = Create(TagIfd0.GpsInfo, null, 0x0009, "GPSStatus", true, [("Exif.GPSInfo.GPSStatus", "GPSInfo")]);

    /// <summary>
    /// Indicates the GPS measurement mode. "2" means two-dimensional measurement and "3" means three-dimensional measurement is in progress.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii[2].
    /// </remarks>
    public static readonly Tag GpsMeasureMode = Create(TagIfd0.GpsInfo, null, 0x000A, "GPSMeasureMode", true, [("Exif.GPSInfo.GPSMeasureMode", "GPSInfo")]);

    /// <summary>
    /// Indicates the GPS DOP (data degree of precision). An HDOP value is written during two-dimensional measurement, and PDOP during three-dimensional measurement.
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag Gpsdop = Create(TagIfd0.GpsInfo, null, 0x000B, "GPSDOP", true, [("Exif.GPSInfo.GPSDOP", "GPSInfo")]);

    /// <summary>
    /// Indicates the unit used to express the GPS receiver speed of movement. "K" "M" and "N" represents kilometers per hour, miles per hour, and knots.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii[2].
    /// </remarks>
    public static readonly Tag GpsSpeedRef = Create(TagIfd0.GpsInfo, null, 0x000C, "GPSSpeedRef", true, [("Exif.GPSInfo.GPSSpeedRef", "GPSInfo")]);

    /// <summary>
    /// Indicates the speed of GPS receiver movement.
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag GpsSpeed = Create(TagIfd0.GpsInfo, null, 0x000D, "GPSSpeed", true, [("Exif.GPSInfo.GPSSpeed", "GPSInfo")]);

    /// <summary>
    /// Indicates the reference for giving the direction of GPS receiver movement. "T" denotes true direction and "M" is magnetic direction.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii[2].
    /// </remarks>
    public static readonly Tag GpsTrackRef = Create(TagIfd0.GpsInfo, null, 0x000E, "GPSTrackRef", true, [("Exif.GPSInfo.GPSTrackRef", "GPSInfo")]);

    /// <summary>
    /// Indicates the direction of GPS receiver movement. The range of values is from 0.00 to 359.99.
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag GpsTrack = Create(TagIfd0.GpsInfo, null, 0x000F, "GPSTrack", true, [("Exif.GPSInfo.GPSTrack", "GPSInfo")]);

    /// <summary>
    /// Indicates the reference for giving the direction of the image when it is captured. "T" denotes true direction and "M" is magnetic direction.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii[2].
    /// </remarks>
    public static readonly Tag GpsImgDirectionRef = Create(TagIfd0.GpsInfo, null, 0x0010, "GPSImgDirectionRef", true, [("Exif.GPSInfo.GPSImgDirectionRef", "GPSInfo")]);

    /// <summary>
    /// Indicates the direction of the image when it was captured. The range of values is from 0.00 to 359.99.
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag GpsImgDirection = Create(TagIfd0.GpsInfo, null, 0x0011, "GPSImgDirection", true, [("Exif.GPSInfo.GPSImgDirection", "GPSInfo")]);

    /// <summary>
    /// Indicates the geodetic survey data used by the GPS receiver. If the survey data is restricted to Japan, the value of this tag is "TOKYO" or "WGS-84".
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag GpsMapDatum = Create(TagIfd0.GpsInfo, null, 0x0012, "GPSMapDatum", true, [("Exif.GPSInfo.GPSMapDatum", "GPSInfo")]);

    /// <summary>
    /// Indicates whether the latitude of the destination point is north or south latitude. The ASCII value "N" indicates north latitude, and "S" is south latitude.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii[2].
    /// </remarks>
    public static readonly Tag GpsDestLatitudeRef = Create(TagIfd0.GpsInfo, null, 0x0013, "GPSDestLatitudeRef", true, [("Exif.GPSInfo.GPSDestLatitudeRef", "GPSInfo")]);

    /// <summary>
    /// Indicates the latitude of the destination point. The latitude is expressed as three RATIONAL values giving the degrees, minutes, and seconds, respectively. If latitude is expressed as degrees, minutes and seconds, a typical format would be dd/1,mm/1,ss/1. When degrees and minutes are used and, for example, fractions of minutes are given up to two decimal places, the format would be dd/1,mmmm/100,0/1.
    /// </summary>
    /// <remarks>
    /// Expected type is URational[3].
    /// </remarks>
    public static readonly Tag GpsDestLatitude = Create(TagIfd0.GpsInfo, null, 0x0014, "GPSDestLatitude", true, [("Exif.GPSInfo.GPSDestLatitude", "GPSInfo")]);

    /// <summary>
    /// Indicates whether the longitude of the destination point is east or west longitude. ASCII "E" indicates east longitude, and "W" is west longitude.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii[2].
    /// </remarks>
    public static readonly Tag GpsDestLongitudeRef = Create(TagIfd0.GpsInfo, null, 0x0015, "GPSDestLongitudeRef", true, [("Exif.GPSInfo.GPSDestLongitudeRef", "GPSInfo")]);

    /// <summary>
    /// Indicates the longitude of the destination point. The longitude is expressed as three RATIONAL values giving the degrees, minutes, and seconds, respectively. If longitude is expressed as degrees, minutes and seconds, a typical format would be ddd/1,mm/1,ss/1. When degrees and minutes are used and, for example, fractions of minutes are given up to two decimal places, the format would be ddd/1,mmmm/100,0/1.
    /// </summary>
    /// <remarks>
    /// Expected type is URational[3].
    /// </remarks>
    public static readonly Tag GpsDestLongitude = Create(TagIfd0.GpsInfo, null, 0x0016, "GPSDestLongitude", true, [("Exif.GPSInfo.GPSDestLongitude", "GPSInfo")]);

    /// <summary>
    /// Indicates the reference used for giving the bearing to the destination point. "T" denotes true direction and "M" is magnetic direction.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii[2].
    /// </remarks>
    public static readonly Tag GpsDestBearingRef = Create(TagIfd0.GpsInfo, null, 0x0017, "GPSDestBearingRef", true, [("Exif.GPSInfo.GPSDestBearingRef", "GPSInfo")]);

    /// <summary>
    /// Indicates the bearing to the destination point. The range of values is from 0.00 to 359.99.
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag GpsDestBearing = Create(TagIfd0.GpsInfo, null, 0x0018, "GPSDestBearing", true, [("Exif.GPSInfo.GPSDestBearing", "GPSInfo")]);

    /// <summary>
    /// Indicates the unit used to express the distance to the destination point. "K", "M" and "N" represent kilometers, miles and nautical miles.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii[2].
    /// </remarks>
    public static readonly Tag GpsDestDistanceRef = Create(TagIfd0.GpsInfo, null, 0x0019, "GPSDestDistanceRef", true, [("Exif.GPSInfo.GPSDestDistanceRef", "GPSInfo")]);

    /// <summary>
    /// Indicates the distance to the destination point.
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag GpsDestDistance = Create(TagIfd0.GpsInfo, null, 0x001A, "GPSDestDistance", true, [("Exif.GPSInfo.GPSDestDistance", "GPSInfo")]);

    /// <summary>
    /// A character string recording the name of the method used for location finding. The string encoding is defined using the same scheme as UserComment.
    /// </summary>
    /// <remarks>
    /// Expected type is Undefined.
    /// </remarks>
    public static readonly Tag GpsProcessingMethod = Create(TagIfd0.GpsInfo, null, 0x001B, "GPSProcessingMethod", true, [("Exif.GPSInfo.GPSProcessingMethod", "GPSInfo")]);

    /// <summary>
    /// A character string recording the name of the GPS area.The string encoding is defined using the same scheme as UserComment.
    /// </summary>
    /// <remarks>
    /// Expected type is Undefined.
    /// </remarks>
    public static readonly Tag GpsAreaInformation = Create(TagIfd0.GpsInfo, null, 0x001C, "GPSAreaInformation", true, [("Exif.GPSInfo.GPSAreaInformation", "GPSInfo")]);

    /// <summary>
    /// A character string recording date and time information relative to UTC (Coordinated Universal Time). The format is "YYYY:MM:DD.".
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii[11].
    /// </remarks>
    public static readonly Tag GpsDateStamp = Create(TagIfd0.GpsInfo, null, 0x001D, "GPSDateStamp", true, [("Exif.GPSInfo.GPSDateStamp", "GPSInfo")]);

    /// <summary>
    /// Indicates whether differential correction is applied to the GPS receiver.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag GpsDifferential = Create(TagIfd0.GpsInfo, null, 0x001E, "GPSDifferential", true, [("Exif.GPSInfo.GPSDifferential", "GPSInfo")]);

    /// <summary>
    /// This tag indicates horizontal positioning errors in meters.
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag GpsHPositioningError = Create(TagIfd0.GpsInfo, null, 0x001F, "GPSHPositioningError", true, [("Exif.GPSInfo.GPSHPositioningError", "GPSInfo")]);
}
