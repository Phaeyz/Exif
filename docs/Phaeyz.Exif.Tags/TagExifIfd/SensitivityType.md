# TagExifIfd.SensitivityType field

The SensitivityType tag indicates which one of the parameters of ISO12232 is the PhotographicSensitivity tag. Although it is an optional tag, it should be recorded when a PhotographicSensitivity tag is recorded. Value = 4, 5, 6, or 7 may be used in case that the values of plural parameters are the same.

```csharp
public static readonly Tag SensitivityType;
```

## Remarks

Expected type is UInt16.

## See Also

* class [Tag](../../Phaeyz.Exif/Tag.md)
* class [TagExifIfd](../TagExifIfd.md)
* namespace [Phaeyz.Exif.Tags](../../Phaeyz.Exif.md)

<!-- DO NOT EDIT: generated by xmldocmd for Phaeyz.Exif.dll -->
