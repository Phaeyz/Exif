# TagIfd0.RawDataUniqueId field

This tag contains a 16-byte unique identifier for the raw image data in the DNG file. DNG readers can use this tag to recognize a particular raw image, even if the file's name or the metadata contained in the file has been changed. If a DNG writer creates such an identifier, it should do so using an algorithm that will ensure that it is very unlikely two different images will end up having the same identifier.

```csharp
public static readonly Tag RawDataUniqueId;
```

## Remarks

Expected type is Byte[16].

## See Also

* class [Tag](../../Phaeyz.Exif/Tag.md)
* class [TagIfd0](../TagIfd0.md)
* namespace [Phaeyz.Exif.Tags](../../Phaeyz.Exif.md)

<!-- DO NOT EDIT: generated by xmldocmd for Phaeyz.Exif.dll -->
