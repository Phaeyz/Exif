# TagBehavior enumeration

Special behavior used during tag serialization and deserialization.

```csharp
public enum TagBehavior
```

## Values

| name | value | description |
| --- | --- | --- |
| Root | `0` | Only the root tag will have this behavior. |
| CannotRoundTrip | `1` | Indicates an entry which cannot be serialized and deserialized round-tripped if there are modifications to either the EXIF or the image. |
| PreserveDataBlock | `2` | The tag is a UINT32 value which is an offset to data within the buffer, but the length is not not known. |
| StandardValue | `3` | Indicates no special behavior used when serializing or deserializing. |
| IfdPointer | `4` | The tag is an array of UINT32 values which point to offsets starting a directory series. |
| ScopedIfdPointer | `5` | The tag is an array of UINT32 values which point to offsets starting a directory series. When parsing IFDs referenced by this pointer, the byte offset is reset to the byte offset. |
| OffsetAndLengthPair | `6` | That tag is a UINT32 which points to an unknown byte sequence, and is related to another tag in the same directory which is a UINT32 which is the length of the byte sequence. |

## See Also

* namespace [Phaeyz.Exif](../Phaeyz.Exif.md)
* [TagBehavior.cs](https://github.com/Phaeyz/Exif/blob/main/Phaeyz.Exif/TagBehavior.cs)

<!-- DO NOT EDIT: generated by xmldocmd for Phaeyz.Exif.dll -->
