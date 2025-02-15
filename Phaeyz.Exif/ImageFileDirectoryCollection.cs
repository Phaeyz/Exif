using System.Diagnostics.CodeAnalysis;
using Phaeyz.Marshalling;

namespace Phaeyz.Exif;

/// <summary>
/// A series of image file directories which when serialized form a chain.
/// </summary>
/// <remarks>
/// When an entry has an offset pointer to an image file directory (IFD) it will be to one of these types.
/// Entry pointers may be an array as well, so the value may be a list of this type.
/// </remarks>
public class ImageFileDirectoryCollection : List<ImageFileDirectory>
{
    /// <summary>
    /// Initializes a new empty image file directory collection.
    /// </summary>
    public ImageFileDirectoryCollection() : base() { }

    /// <summary>
    /// Initializes a new empty image file directory collection, having the specified initial capacity.
    /// </summary>
    /// <param name="capacity">
    /// The initial number of elements that the image file directory collection may contain without needing to grow internal buffers.
    /// </param>
    public ImageFileDirectoryCollection(int capacity) : base(capacity) { }

    /// <summary>
    /// Initializes a new image file directory collection that contains the items copied from the specified dictionary.
    /// </summary>
    /// <param name="collection">
    /// The enumerable whose items are copied to the new image file directory collection.
    /// </param>
    public ImageFileDirectoryCollection(params IEnumerable<ImageFileDirectory> collection) : base(collection) { }

    /// <summary>
    /// Deserializes a buffer as EXIF image file directory collection.
    /// </summary>
    /// <param name="exifBuffer">
    /// The buffer containing the EXIF image file directory collection.
    /// </param>
    /// <param name="startingOffset">
    /// The offset within the EXIF buffer where the image file directory collection begins.
    /// </param>
    /// <param name="byteOrderMode">
    /// The byte order mode of the data serialized in the buffer.
    /// </param>
    /// <param name="tagProvider">
    /// A provider used for sourcing tag details required for deserialization instructions. If null, the default tag provider is used.
    /// </param>
    /// <param name="cannotRoundTripEntries">
    /// On output, this receives a list of entries which, without intervention, may not round trip. This means if the image file directory
    /// collection is reserialized, these entries may not be valid.
    /// </param>
    /// <returns>
    /// Returns the deserialized EXIF image file directory collection.
    /// </returns>
    /// <exception cref="Phaeyz.Exif.ExifException">
    /// A deserialization error occurred indicating the buffer is not valid EXIF.
    /// </exception>
    public static ImageFileDirectoryCollection Deserialize(
        ReadOnlyMemory<byte> exifBuffer,
        int startingOffset,
        ByteOrderMode byteOrderMode,
        TagProvider? tagProvider,
        out List<EntryReference> cannotRoundTripEntries)
    {
        // Use the default tag provider if one was not provided.
        tagProvider ??= TagProvider.Default;

        // Get the byte converter from the byte order mode.
        ByteConverter byteConverter = byteOrderMode == ByteOrderMode.BigEndian
            ? ByteConverter.BigEndian
            : byteOrderMode == ByteOrderMode.LittleEndian
            ? ByteConverter.LittleEndian
            : throw new ExifException("Invalid EXIF byte order mode.");

        // Now deserialize.
        ImageFileDirectoryCollection dest = [];
        ImageFileDirectoryDeserializer.Deserialize(
            dest,
            exifBuffer,
            tagProvider,
            byteConverter,
            startingOffset,
            false,
            out cannotRoundTripEntries);
        return dest;
    }

    /// <summary>
    /// Imports all image file directories from another collection, merging and overwriting all entries.
    /// </summary>
    /// <param name="imageFileDirectoryCollection">
    /// The image file directory collection to import into the current collection.
    /// </param>
    /// <remarks>
    /// The import is a deep copy, including all arrays and lists which are duplicated.
    /// </remarks>
    public void Import(ImageFileDirectoryCollection imageFileDirectoryCollection)
    {
        for (int i = 0; i < imageFileDirectoryCollection.Count; i++)
        {
            ImageFileDirectory targetIfd;
            if (i == Count)
            {
                targetIfd = [];
                Add(targetIfd);
            }
            else
            {
                targetIfd = this[i];
            }

            targetIfd.Import(imageFileDirectoryCollection[i]);
        }
    }

    /// <summary>
    /// Attempts to read an entry given a path of tags.
    /// </summary>
    /// <param name="tagPath">
    /// One or more tags which form a path which may be followed to find an entry.
    /// </param>
    /// <param name="entry">
    /// Receives the entry if the tag path exists, or null otherwise.
    /// </param>
    /// <returns>
    /// Returns true if an entry using the tag path is found, or false otherwise.
    /// </returns>
    public bool TryGetEntry(IEnumerable<Tag> tagPath, [MaybeNullWhen(false)] out Entry? entry)
    {
        ArgumentNullException.ThrowIfNull(tagPath);
        IReadOnlyList<Tag> tagPathList = (tagPath as IReadOnlyList<Tag>) ?? new List<Tag>(tagPath);
        return TryGetEntry([this], tagPathList, 0, out entry);
    }

    /// <summary>
    /// Recursively attempts to read an entry given a path of tags.
    /// </summary>
    /// <param name="ifdPointers">
    /// Image file directory pointers (i.e. deserialized offsets) to search at the current scope.
    /// </param>
    /// <param name="tagPath">
    /// One or more tags which form a path which may be followed to find an entry.
    /// </param>
    /// <param name="tagPathIndex">
    /// The current index in the tag path currently being examined.
    /// </param>
    /// <param name="entry">
    /// Receives the entry if the tag path exists, or null otherwise.
    /// </param>
    /// <returns>
    /// Returns true if an entry using the tag path is found, or false otherwise.
    /// </returns>
    /// <exception cref="Phaeyz.Exif.ExifException">
    /// An entry in the tag path did not have an expected image file directory collection value.
    /// </exception>
    private static bool TryGetEntry(
        IEnumerable<ImageFileDirectoryCollection> ifdPointers,
        IReadOnlyList<Tag> tagPath,
        int tagPathIndex,
        [MaybeNullWhen(false)] out Entry? entry)
    {
        ArgumentNullException.ThrowIfNull(ifdPointers);
        ArgumentNullException.ThrowIfNull(tagPath);
        ArgumentOutOfRangeException.ThrowIfNegative(tagPathIndex);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(tagPathIndex, tagPath.Count);

        // If the search is first starting out, skip over any root tags in the tag path.
        if (tagPathIndex == 0)
        {
            for (; tagPathIndex < tagPath.Count && tagPath[tagPathIndex].IsRoot; tagPathIndex++);
            if (tagPathIndex == tagPath.Count)
            {
                entry = null;
                return false;
            }
        }

        // Get all image file directories which match the current tag criteria.
        Tag tag = tagPath[tagPathIndex];

        foreach (ImageFileDirectory imageFileDirectory in FilterToIndexedDirectories(ifdPointers, tag.Index))
        {
            if (imageFileDirectory.TryGetValue(tag, out entry))
            {
                // An entry for the current tag was found. If this is the last tag in the tag path, return this entry.
                if (tagPathIndex + 1 == tagPath.Count)
                {
                    return true;
                }

                // This is not the last tag in the tag path, so this tag must be an image file directory pointer.
                if (entry.Tag.Behavior != TagBehavior.IfdPointer)
                {
                    entry = null;
                    throw new ExifException("An entry identified in the tag path is not an image file directory.");
                }

                // Read the image file directory collection(s) and move to the next tag in the tag path.
                if (entry.Value is ImageFileDirectoryCollection nextIfdPointer)
                {
                    if (TryGetEntry([nextIfdPointer], tagPath, tagPathIndex + 1, out entry))
                    {
                        return true;
                    }
                }
                else if (entry.Value is IEnumerable<ImageFileDirectoryCollection> nextIfdPointers)
                {
                    if (TryGetEntry(nextIfdPointers, tagPath, tagPathIndex + 1, out entry))
                    {
                        return true;
                    }
                }
                else
                {
                    entry = null;
                    throw new ExifException("An image file directory entry did not have a 'ImageFileDirectoryCollection' value.");
                }
            }
        }

        // A match could not be found.
        entry = null;
        return false;
    }

    /// <summary>
    /// Enumerates all image file directories, or optionally the image file directory at the specified index.
    /// </summary>
    /// <param name="ifdPointers">
    /// Pointers to a collection of image file directories to scan.
    /// </param>
    /// <param name="filterToIndex">
    /// The index of the image file directory to fetch, or null to yield all of them.
    /// </param>
    /// <returns>
    /// An enumerable to all image file directories, or optionally the image file directory at the specified index.
    /// </returns>
    private static IEnumerable<ImageFileDirectory> FilterToIndexedDirectories(
        IEnumerable<ImageFileDirectoryCollection> ifdPointers,
        int? filterToIndex)
    {
        ArgumentNullException.ThrowIfNull(ifdPointers);

        foreach (ImageFileDirectoryCollection imageFileDirectoryCollection in ifdPointers)
        {
            // If no index is provided, just yield all image file directories.
            if (filterToIndex is null)
            {
                foreach (ImageFileDirectory imageFileDirectory in  imageFileDirectoryCollection)
                {
                    yield return imageFileDirectory;
                }
            }
            else
            {
                // Otherwise, scan until an image file directory at exactly the specified index is found.
                if (filterToIndex < imageFileDirectoryCollection.Count)
                {
                    yield return imageFileDirectoryCollection[filterToIndex.Value];
                    yield break;
                }

                filterToIndex -= imageFileDirectoryCollection.Count;
            }
        }
    }
}