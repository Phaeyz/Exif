# TagExifIfd.ComponentsConfiguration field

Information specific to compressed data. The channels of each component are arranged in order from the 1st component to the 4th. For uncompressed data the data arrangement is given in the &lt;PhotometricInterpretation&gt; tag. However, since &lt;PhotometricInterpretation&gt; can only express the order of Y, Cb and Cr, this tag is provided for cases when compressed data uses components other than Y, Cb, and Cr and to enable support of other sequences.

```csharp
public static readonly Tag ComponentsConfiguration;
```

## Remarks

Expected type is Undefined[4].

## See Also

* class [Tag](../../Phaeyz.Exif/Tag.md)
* class [TagExifIfd](../TagExifIfd.md)
* namespace [Phaeyz.Exif.Tags](../../Phaeyz.Exif.md)

<!-- DO NOT EDIT: generated by xmldocmd for Phaeyz.Exif.dll -->
