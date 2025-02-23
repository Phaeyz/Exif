# TagProvider.Match method

Matches the specified tag data to a tag in the tag provider.

```csharp
public Tag? Match(ushort value, Tag parent, int index)
```

| parameter | description |
| --- | --- |
| value | The tag value. |
| parent | The tag parent. This may not be `null`, and if the tag's parent is `null` it will match any value provided here. |
| index | The index of the parent where the value exists. |

## Return Value

A new tag object if a matching tag could be found, or null otherwise.

## See Also

* class [Tag](../Tag.md)
* class [TagProvider](../TagProvider.md)
* namespace [Phaeyz.Exif](../../Phaeyz.Exif.md)

<!-- DO NOT EDIT: generated by xmldocmd for Phaeyz.Exif.dll -->
