# TagSubIfd.DefaultCropOrigin field

Raw images often store extra pixels around the edges of the final image. These extra pixels help prevent interpolation artifacts near the edges of the final image. DefaultCropOrigin specifies the origin of the final image area, in raw image coordinates (i.e., before the DefaultScale has been applied), relative to the top-left corner of the ActiveArea rectangle.

```csharp
public static readonly Tag DefaultCropOrigin;
```

## Remarks

Expected type is UInt32[2].

## See Also

* class [Tag](../../Phaeyz.Exif/Tag.md)
* class [TagSubIfd](../TagSubIfd.md)
* namespace [Phaeyz.Exif.Tags](../../Phaeyz.Exif.md)

<!-- DO NOT EDIT: generated by xmldocmd for Phaeyz.Exif.dll -->
