# TagIfd0.ProfileHueSatMapDims field

This tag specifies the number of input samples in each dimension of the hue/saturation/value mapping tables. The data for these tables are stored in ProfileHueSatMapData1, ProfileHueSatMapData2 and ProfileHueSatMapData3 tags. The most common case has ValueDivisions equal to 1, so only hue and saturation are used as inputs to the mapping table.

```csharp
public static readonly Tag ProfileHueSatMapDims;
```

## Remarks

Expected type is UInt32[3].

## See Also

* class [Tag](../../Phaeyz.Exif/Tag.md)
* class [TagIfd0](../TagIfd0.md)
* namespace [Phaeyz.Exif.Tags](../../Phaeyz.Exif.md)

<!-- DO NOT EDIT: generated by xmldocmd for Phaeyz.Exif.dll -->
