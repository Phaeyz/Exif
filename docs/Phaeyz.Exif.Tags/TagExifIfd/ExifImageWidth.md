# TagExifIfd.ExifImageWidth field

Information specific to compressed data. When a compressed file is recorded, the valid width of the meaningful image must be recorded in this tag, whether or not there is padding data or a restart marker. This tag should not exist in an uncompressed file.

```csharp
public static readonly Tag ExifImageWidth;
```

## Remarks

Expected type is UInt32.

## See Also

* class [Tag](../../Phaeyz.Exif/Tag.md)
* class [TagExifIfd](../TagExifIfd.md)
* namespace [Phaeyz.Exif.Tags](../../Phaeyz.Exif.md)

<!-- DO NOT EDIT: generated by xmldocmd for Phaeyz.Exif.dll -->
