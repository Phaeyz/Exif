# TagGpsInfo class

Tags which only appear in the GPS info image file directory.

```csharp
public class TagGpsInfo : Tag
```

## Public Members

| name | description |
| --- | --- |
| [TagGpsInfo](TagGpsInfo/TagGpsInfo.md)() | The default constructor. |
| static readonly [GpsAltitude](TagGpsInfo/GpsAltitude.md) | Indicates the altitude based on the reference in GPSAltitudeRef. Altitude is expressed as one RATIONAL value. The reference unit is meters. |
| static readonly [GpsAltitudeRef](TagGpsInfo/GpsAltitudeRef.md) | Indicates the altitude used as the reference altitude. If the reference is sea level and the altitude is above sea level, 0 is given. If the altitude is below sea level, a value of 1 is given and the altitude is indicated as an absolute value in the GSPAltitude tag. The reference unit is meters. Note that this tag is BYTE type, unlike other reference tags. |
| static readonly [GpsAreaInformation](TagGpsInfo/GpsAreaInformation.md) | A character string recording the name of the GPS area.The string encoding is defined using the same scheme as UserComment. |
| static readonly [GpsDateStamp](TagGpsInfo/GpsDateStamp.md) | A character string recording date and time information relative to UTC (Coordinated Universal Time). The format is "YYYY:MM:DD.". |
| static readonly [GpsDestBearing](TagGpsInfo/GpsDestBearing.md) | Indicates the bearing to the destination point. The range of values is from 0.00 to 359.99. |
| static readonly [GpsDestBearingRef](TagGpsInfo/GpsDestBearingRef.md) | Indicates the reference used for giving the bearing to the destination point. "T" denotes true direction and "M" is magnetic direction. |
| static readonly [GpsDestDistance](TagGpsInfo/GpsDestDistance.md) | Indicates the distance to the destination point. |
| static readonly [GpsDestDistanceRef](TagGpsInfo/GpsDestDistanceRef.md) | Indicates the unit used to express the distance to the destination point. "K", "M" and "N" represent kilometers, miles and nautical miles. |
| static readonly [GpsDestLatitude](TagGpsInfo/GpsDestLatitude.md) | Indicates the latitude of the destination point. The latitude is expressed as three RATIONAL values giving the degrees, minutes, and seconds, respectively. If latitude is expressed as degrees, minutes and seconds, a typical format would be dd/1,mm/1,ss/1. When degrees and minutes are used and, for example, fractions of minutes are given up to two decimal places, the format would be dd/1,mmmm/100,0/1. |
| static readonly [GpsDestLatitudeRef](TagGpsInfo/GpsDestLatitudeRef.md) | Indicates whether the latitude of the destination point is north or south latitude. The ASCII value "N" indicates north latitude, and "S" is south latitude. |
| static readonly [GpsDestLongitude](TagGpsInfo/GpsDestLongitude.md) | Indicates the longitude of the destination point. The longitude is expressed as three RATIONAL values giving the degrees, minutes, and seconds, respectively. If longitude is expressed as degrees, minutes and seconds, a typical format would be ddd/1,mm/1,ss/1. When degrees and minutes are used and, for example, fractions of minutes are given up to two decimal places, the format would be ddd/1,mmmm/100,0/1. |
| static readonly [GpsDestLongitudeRef](TagGpsInfo/GpsDestLongitudeRef.md) | Indicates whether the longitude of the destination point is east or west longitude. ASCII "E" indicates east longitude, and "W" is west longitude. |
| static readonly [GpsDifferential](TagGpsInfo/GpsDifferential.md) | Indicates whether differential correction is applied to the GPS receiver. |
| static readonly [GpsDop](TagGpsInfo/GpsDop.md) | Indicates the GPS DOP (data degree of precision). An HDOP value is written during two-dimensional measurement, and PDOP during three-dimensional measurement. |
| static readonly [GpsHPositioningError](TagGpsInfo/GpsHPositioningError.md) | This tag indicates horizontal positioning errors in meters. |
| static readonly [GpsImgDirection](TagGpsInfo/GpsImgDirection.md) | Indicates the direction of the image when it was captured. The range of values is from 0.00 to 359.99. |
| static readonly [GpsImgDirectionRef](TagGpsInfo/GpsImgDirectionRef.md) | Indicates the reference for giving the direction of the image when it is captured. "T" denotes true direction and "M" is magnetic direction. |
| static readonly [GpsLatitude](TagGpsInfo/GpsLatitude.md) | Indicates the latitude. The latitude is expressed as three RATIONAL values giving the degrees, minutes, and seconds, respectively. When degrees, minutes and seconds are expressed, the format is dd/1,mm/1,ss/1. When degrees and minutes are used and, for example, fractions of minutes are given up to two decimal places, the format is dd/1,mmmm/100,0/1. |
| static readonly [GpsLatitudeRef](TagGpsInfo/GpsLatitudeRef.md) | Indicates whether the latitude is north or south latitude. The ASCII value 'N' indicates north latitude, and 'S' is south latitude. |
| static readonly [GpsLongitude](TagGpsInfo/GpsLongitude.md) | Indicates the longitude. The longitude is expressed as three RATIONAL values giving the degrees, minutes, and seconds, respectively. When degrees, minutes and seconds are expressed, the format is ddd/1,mm/1,ss/1. When degrees and minutes are used and, for example, fractions of minutes are given up to two decimal places, the format is ddd/1,mmmm/100,0/1. |
| static readonly [GpsLongitudeRef](TagGpsInfo/GpsLongitudeRef.md) | Indicates whether the longitude is east or west longitude. ASCII 'E' indicates east longitude, and 'W' is west longitude. |
| static readonly [GpsMapDatum](TagGpsInfo/GpsMapDatum.md) | Indicates the geodetic survey data used by the GPS receiver. If the survey data is restricted to Japan, the value of this tag is "TOKYO" or "WGS-84". |
| static readonly [GpsMeasureMode](TagGpsInfo/GpsMeasureMode.md) | Indicates the GPS measurement mode. "2" means two-dimensional measurement and "3" means three-dimensional measurement is in progress. |
| static readonly [GpsProcessingMethod](TagGpsInfo/GpsProcessingMethod.md) | A character string recording the name of the method used for location finding. The string encoding is defined using the same scheme as UserComment. |
| static readonly [GpsSatellites](TagGpsInfo/GpsSatellites.md) | Indicates the GPS satellites used for measurements. This tag can be used to describe the number of satellites, their ID number, angle of elevation, azimuth, SNR and other information in ASCII notation. The format is not specified. If the GPS receiver is incapable of taking measurements, value of the tag is set to NULL. |
| static readonly [GpsSpeed](TagGpsInfo/GpsSpeed.md) | Indicates the speed of GPS receiver movement. |
| static readonly [GpsSpeedRef](TagGpsInfo/GpsSpeedRef.md) | Indicates the unit used to express the GPS receiver speed of movement. "K" "M" and "N" represents kilometers per hour, miles per hour, and knots. |
| static readonly [GpsStatus](TagGpsInfo/GpsStatus.md) | Indicates the status of the GPS receiver when the image is recorded. "A" means measurement is in progress, and "V" means the measurement is Interoperability. |
| static readonly [GpsTimeStamp](TagGpsInfo/GpsTimeStamp.md) | Indicates the time as UTC (Coordinated Universal Time). &lt;TimeStamp&gt; is expressed as three RATIONAL values giving the hour, minute, and second (atomic clock). |
| static readonly [GpsTrack](TagGpsInfo/GpsTrack.md) | Indicates the direction of GPS receiver movement. The range of values is from 0.00 to 359.99. |
| static readonly [GpsTrackRef](TagGpsInfo/GpsTrackRef.md) | Indicates the reference for giving the direction of GPS receiver movement. "T" denotes true direction and "M" is magnetic direction. |
| static readonly [GpsVersionId](TagGpsInfo/GpsVersionId.md) | Indicates the version of &lt;GPSInfoIFD&gt;. The version is given as 2.0.0.0. This tag is mandatory when &lt;GPSInfo&gt; tag is present. (Note: The &lt;GPSVersionID&gt; tag is given in bytes, unlike the &lt;ExifVersion&gt; tag. When the version is 2.0.0.0, the tag value is 02000000.H). |

## See Also

* class [Tag](../Phaeyz.Exif/Tag.md)
* namespace [Phaeyz.Exif.Tags](../Phaeyz.Exif.md)
* [TagGpsInfo.cs](https://github.com/Phaeyz/Exif/blob/main/Phaeyz.Exif/Tags/TagGpsInfo.cs)

<!-- DO NOT EDIT: generated by xmldocmd for Phaeyz.Exif.dll -->
