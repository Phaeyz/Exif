# TagIfd0.CameraCalibration2 field

CameraCalibration2 defines a calibration matrix that transforms reference camera native space values to individual camera native space values under the second calibration illuminant. The matrix is stored in row scan order. This matrix is stored separately from the matrix specified by the ColorMatrix2 tag to allow raw converters to swap in replacement color matrices based on UniqueCameraModel tag, while still taking advantage of any per-individual camera calibration performed by the camera manufacturer.

```csharp
public static readonly Tag CameraCalibration2;
```

## Remarks

Expected type is SRational[n].

## See Also

* class [Tag](../../Phaeyz.Exif/Tag.md)
* class [TagIfd0](../TagIfd0.md)
* namespace [Phaeyz.Exif.Tags](../../Phaeyz.Exif.md)

<!-- DO NOT EDIT: generated by xmldocmd for Phaeyz.Exif.dll -->
