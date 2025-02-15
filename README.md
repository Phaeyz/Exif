# Phaeyz

Phaeyz is a set of libraries created and polished over time for use with other projects, and made available here for convenience.

All Phaeyz libraries may be found [here](https://github.com/Phaeyz).

# Phaeyz.Exif

API documentation for **Phaeyz.Exif** library is [here](https://github.com/Phaeyz/Exif/blob/main/docs/Phaeyz.Exif.md).

This library contains classes which allow for deserializing EXIF file format, editing and adding EXIF entries and IFDs, as well as serializing it back out. The deserializer and serializer was written such that if IFDs are not built-in or supported by Phaeyz.Exif, it can be extended. Additionally, if some blocks are not supported, there is an attempt to preserve the block using known offsets and sizes so the data may be round-tripped as safely as possible.

Note this library does not protect you from creating non-standard EXIF. The order of IFDs and presence of some entries
is important, and requirements may change depending on context. For more information on the raw EXIF file format, see [EXIF on Wikipedia](https://en.wikipedia.org/wiki/Exif), [Sustainability of Digital Formats: Planning for Library of Congress Collections](https://www.loc.gov/preservation/digital/formats/fdd/fdd000146.shtml) and/or [Specifications for EXIF 2.1 and 2.2 from former exif.org site](http://web.archive.org/web/20131230103425/http://exif.org/specifications.html).

Here are some highlights of this library.

## ExifMetadata (deserializing)

```C#
byte[] exifBuffer = new byte[] {}; // The source EXIF buffer
var exif = ExifMetadata.Deserialize(exifBuffer); // Simple deserialization
// Fetch an entry value based on IFD/tag path.
if (exif.TryGetEntry([TagIfd0.ExifOffset, TagExifIfd.CreateDate], out Entry? entry))
{
    Console.WriteLine(entry.Value);
}
// Or manually iterate IFDs and entries.
foreach (ImageFileDirectory ifd in exif)
{
    foreach (KeyValuePair<Tag, Entry> ifdEntry in ifd)
    {
        // ifdEntry.Value may be a ImageFileDirectoryCollection
        // (ExifMetadata derives from ImageFileDirectoryCollection)
    }
}
```

## ExifMetadata (removing values)

```C#
byte[] exifBuffer = new byte[] {}; // The source EXIF buffer
var exif = ExifMetadata.Deserialize(exifBuffer); // Simple deserialization
foreach (ImageFileDirectory ifd in exif)
{
    // ImageFileDirectory implements KeyedCollection<Tag, Entry>
    ifd.Remove(TagIfd0.ExifOffset); // Example removing entries (including entries referencing an IFD collection)
}
// ImageFileDirectoryCollection implements List<ImageFileDirectory>
exif.RemoveAt(1); // Example removing an IFD from an existing collection
```

## ExifMetadata (adding or updating values)

```C#
byte[] exifBuffer = new byte[] {}; // The source EXIF buffer
var exif = ExifMetadata.Deserialize(exifBuffer); // Simple deserialization
// Add or update to change to set an entry value. It can also automatically discern entry type for value.
exif.First().AddOrUpdate(Tags.TagIfd.ImageDescription, "test");
// You can also merge/import a desired layout into existing EXIF, which automatically creates the IFDs and entries.
// See the unit tests for ImageFileDirectoryCollection for more examples.
ImageFileDirectoryCollection ifdcMerge = [
    new(
        (TagIfd.ImageDescription, "test"),
        (TagIfd0.ExifOffset, new ImageFileDirectoryCollection([
            new(
                (TagExifIfd.DateTimeOriginal, "2024:11:03 19:45:47")
            )
        ]))
    ),
    new(
        (TagIfd.Compression, (ushort)6),
        (TagIfd.Orientation, (ushort)1)
    )
];
exif.Import(ifdcMerge);
```

## ExifMetadata (serializing)

```C#
var exif = new ExifMetadata(); // Create new EXIF like this
// Serializing writes out to a new memory stream
MemoryStream memoryStream = exif.Serialize();
```

## TagProvider (custom tags, needing to do this is probably atypical)

```C#
// Define some custom tags including constraints
public class MyTags
{
    // An IFD tag which applies to any IFD at the root.
    public static readonly Tag Foo = Tag.CreateIfdPointer(Tag.Root, null, 0x980, "Foo");
    // A tag which applies to the zero-th IFD under the Foo tag.
    public static readonly Tag Bar = Tag.Create(MyTags.Foo, 0, 0x981, "Bar");
}

TagProvider tagProvider = new(TagProvider.Default); // Create a new tag provider, and import all the default tags
// Import all tags in MyTags. Be sure to use "OrUpdate" version to overwrite defaults if needed
tagProvider.AddOrUpdateFromType<MyTags>();

byte[] exifBuffer = new byte[] {}; // The source EXIF buffer
var exif = ExifMetadata.Deserialize(exifBuffer, tagProvider); // Now deserialize using the tag provider
```

# Licensing

This project is licensed under GNU General Public License v3.0, which means you can use it for personal or educational purposes for free. However, donations are always encouraged to support the ongoing development of adding new features and resolving issues.

If you plan to use this code for commercial purposes or within an organization, we kindly ask for a donation to support the project's development. Any reasonably sized donation amount which reflects the perceived value of using Phaeyz in your product or service is accepted.

## Donation Options

There are several ways to support Phaeyz with a donation. Perhaps the best way is to use Patreon so that recurring small donations continue to support the development of Phaeyz.

- **Patreon**: [https://www.patreon.com/phaeyz](https://www.patreon.com/phaeyz)
- **Bitcoin**: Send funds to address: ```bc1qdzdahz8d7jkje09fg7s7e8xedjsxm6kfhvsgsw```
- **PayPal**: Send funds to ```phaeyz@pm.me``` ([directions](https://www.paypal.com/us/cshelp/article/how-do-i-send-money-help293))

Your support is greatly appreciated and helps me continue to improve and maintain Phaeyz!