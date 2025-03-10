# Tag.Create method (1 of 2)

Creates a standard value tag.

```csharp
public static Tag Create(Tag? parent, int? index, ushort value, string? name, bool canRoundTrip, 
    IEnumerable<(string key, string category)>? aliases)
```

| parameter | description |
| --- | --- |
| parent | The parent directory tag the current tag must exist under. If `null` this tag may appear in every parent directory. |
| index | The index of parent directory set which this tag must exist within. If `null` this tag may appear in any of the array of parent directories. |
| value | The UINT16 value of the tag which is serialized to the EXIF. |
| name | A friendly name for the tag. Only used for debugging. |
| canRoundTrip | If `false`, the tag will be marked as cannot round trip. Deserialized tags which cannot round trip will be surfaced in a resulting list allowing the caller to optionally take action. The default tag provider does not have any tags which are marked as "cannot round trip". Defaults to `true`. |
| aliases | Aliases for the tag. The key a namespace name such as "Exif.Image.ImageWidth", and the value is the category such as "Image". |

## Return Value

The new standard value tag.

## See Also

* class [Tag](../Tag.md)
* namespace [Phaeyz.Exif](../../Phaeyz.Exif.md)

---

# Tag.Create method (2 of 2)

Creates a standard value tag.

```csharp
public static Tag Create(Tag? parent, int? index, ushort value, string? name, 
    bool canRoundTrip = true, IEnumerable<KeyValuePair<string, string>>? aliases = null)
```

| parameter | description |
| --- | --- |
| parent | The parent directory tag the current tag must exist under. If `null` this tag may appear in every parent directory. |
| index | The index of parent directory set which this tag must exist within. If `null` this tag may appear in any of the array of parent directories. |
| value | The UINT16 value of the tag which is serialized to the EXIF. |
| name | A friendly name for the tag. Only used for debugging. |
| canRoundTrip | If `false`, the tag will be marked as cannot round trip. Deserialized tags which cannot round trip will be surfaced in a resulting list allowing the caller to optionally take action. The default tag provider does not have any tags which are marked as "cannot round trip". Defaults to `true`. |
| aliases | Aliases for the tag. The key a namespace name such as "Exif.Image.ImageWidth", and the value is the category such as "Image". |

## Return Value

The new standard value tag.

## See Also

* class [Tag](../Tag.md)
* namespace [Phaeyz.Exif](../../Phaeyz.Exif.md)

<!-- DO NOT EDIT: generated by xmldocmd for Phaeyz.Exif.dll -->
