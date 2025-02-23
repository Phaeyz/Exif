# TagProvider class

A container which is used during deserialization to determine tab behaviors.

```csharp
public class TagProvider : IEnumerable<Tag>
```

## Public Members

| name | description |
| --- | --- |
| [TagProvider](TagProvider/TagProvider.md)(…) | Creates and initializes a new tag provider along with an optional set of initial tags. |
| static readonly [Default](TagProvider/Default.md) | Built-in tags which allows for for round-trip of serialization and deserialization in most cases. |
| [IsReadOnly](TagProvider/IsReadOnly.md) { get; } | Determines if the current provider is read-only. If the provider is read-only, add and remove methods will throw an exception. |
| [Add](TagProvider/Add.md)(…) | Adds a new tag to the provider. The tag's related and parents, if available, will also be added. |
| [AddFromType](TagProvider/AddFromType.md)(…) | Adds all static tags found as fields or properties on a type to the provider. Each tag's related and parents, if available, will also be added. |
| [AddFromType&lt;T&gt;](TagProvider/AddFromType.md)() | Adds all static tags found as fields or properties on a type to the provider. Each tag's related and parents, if available, will also be added. |
| [AddOrUpdate](TagProvider/AddOrUpdate.md)(…) | Adds a new tag to the provider. If an equivalent tag already exists, it will be replaced. The tag's related and parents, if available, will also be added or updated. |
| [AddOrUpdateFromType](TagProvider/AddOrUpdateFromType.md)(…) | Adds or updates all static tags found as fields or properties on a type to the provider. Each tag's related and parents, if available, will also be added or updated. |
| [AddOrUpdateFromType&lt;T&gt;](TagProvider/AddOrUpdateFromType.md)() | Adds or updates all static tags found as fields or properties on a type to the provider. Each tag's related and parents, if available, will also be added or updated. |
| [AddOrUpdateRange](TagProvider/AddOrUpdateRange.md)(…) | Adds or updates a set of tags to the provider. If an equivalent tag already exists, it will be replaced. Any tag's related and parents, if available, will also be added or updated. |
| [AddRange](TagProvider/AddRange.md)(…) | Adds a set of tags to the provider. Each tag's related and parents, if available, will also be added. |
| [AsReadOnly](TagProvider/AsReadOnly.md)() | Creates a version of the provider which is read-only. If the current version of the provider is not read-only, further modifications will be reflected in the read-only version. |
| [Contains](TagProvider/Contains.md)(…) | Gets whether or not an equivalent tag exists in the provider. |
| [EnumerateTags](TagProvider/EnumerateTags.md)(…) | Iterates tags in the current tag provider. |
| [GetEnumerator](TagProvider/GetEnumerator.md)() | Gets an enumerator to enumerate all tags in the tag provider. |
| [Match](TagProvider/Match.md)(…) | Matches the specified tag data to a tag in the tag provider. |
| [Remove](TagProvider/Remove.md)(…) | Removes a tag from the provider. |

## See Also

* class [Tag](./Tag.md)
* namespace [Phaeyz.Exif](../Phaeyz.Exif.md)
* [TagProvider.cs](https://github.com/Phaeyz/Exif/blob/main/Phaeyz.Exif/TagProvider.cs)

<!-- DO NOT EDIT: generated by xmldocmd for Phaeyz.Exif.dll -->
