using Phaeyz.Collections;

namespace Phaeyz.Exif;

/// <summary>
/// An image file directory which is an ordered set of entries indexed by tags.
/// </summary>
public class ImageFileDirectory : KeyedCollection<Tag, Entry>
{
    /// <summary>
    /// Initializes a new empty image file directory.
    /// </summary>
    public ImageFileDirectory() : base() { }

    /// <summary>
    /// Initializes a new empty image file directory, having the specified initial capacity.
    /// </summary>
    /// <param name="capacity">
    /// The initial number of elements that the image file directory may contain without needing to grow internal buffers.
    /// </param>
    public ImageFileDirectory(int capacity) : base(capacity) { }

    /// <summary>
    /// Initializes a new image file directory that contains the items copied from the specified dictionary.
    /// </summary>
    /// <param name="collection">
    /// The enumerable whose items are copied to the new image file directory.
    /// </param>
    public ImageFileDirectory(IDictionary<Tag, Entry> dictionary) : base(dictionary) { }

    /// <summary>
    /// Initializes a new image file directory that contains the items copied from the specified enumerable.
    /// </summary>
    /// <param name="collection">
    /// The enumerable whose items are copied to the new image file directory.
    /// </param>
    public ImageFileDirectory(IEnumerable<KeyValuePair<Tag, Entry>> collection) : base(collection) { }

    /// <summary>
    /// Initializes a new image file directory that contains the items copied from the specified enumerable.
    /// </summary>
    /// <param name="collection">
    /// The enumerable whose items are copied to the new image file directory.
    /// </param>
    public ImageFileDirectory(params IEnumerable<Entry> collection) :
        base(collection.Select(e => new KeyValuePair<Tag, Entry>(e.Tag, e))) { }

    /// <summary>
    /// Adds or updates an entry in the image file directory.
    /// </summary>
    /// <param name="entry">
    /// The entry to add or update.
    /// </param>
    /// <returns>
    /// The entry added or updated.
    /// </returns>
    public Entry AddOrUpdate(Entry entry)
    {
        return this[entry.Tag] = entry;
    }

    /// <summary>
    /// Adds or updates an entry in the image file directory.
    /// </summary>
    /// <param name="tag">
    /// The tag of the entry to add or update.
    /// </param>
    /// <param name="value">
    /// The value of the entry to add or update.
    /// </param>
    /// <returns>
    /// The entry added or updated.
    /// </returns>
    public Entry AddOrUpdate(Tag tag, object value)
    {
        EntryType type = Entry.GetTypeFromValue(value);
        return this[tag] = new Entry(tag, type, value);
    }

    /// <summary>
    /// Clones a serializable value. Enumerable values are duplicated with a new list.
    /// The exception to this is ImageFileDirectoryCollection and enumerables ImageFileDirectoryCollection where the
    /// original value is returned.
    /// </summary>
    /// <param name="value">
    /// The value to clone.
    /// </param>
    /// <returns>
    /// The cloned value.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when the value is null.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Throws when the value type is not supported.
    /// </exception>
    private static object CloneValue(object value) => value switch
    {
        null => throw new ArgumentNullException(nameof(value)),
        string o => o,
        byte o => o,
        sbyte o => o,
        ushort o => o,
        short o => o,
        uint o => o,
        int o => o,
        float o => o,
        double o => o,
        UnsignedRational o => o,
        SignedRational o => o,
        ImageFileDirectoryCollection o => o,
        IEnumerable<byte> o => new List<byte>(o),
        IEnumerable<ushort> o => new List<ushort>(o),
        IEnumerable<short> o => new List<short>(o),
        IEnumerable<uint> o => new List<uint>(o),
        IEnumerable<int> o => new List<int>(o),
        IEnumerable<float> o => new List<float>(o),
        IEnumerable<double> o => new List<double>(o),
        IEnumerable<UnsignedRational> o => new List<UnsignedRational>(o),
        IEnumerable<SignedRational> o => new List<SignedRational>(o),
        IEnumerable<ImageFileDirectoryCollection> o => o,
        _ => throw new ArgumentException("Unsupported value type.", nameof(value)),
    };

    /// <summary>
    /// Imports all entries from another collection, merging and overwriting all data.
    /// </summary>
    /// <param name="imageFileDirectory">
    /// The image file directory to import into the current collection.
    /// </param>
    /// <remarks>
    /// The import is a deep copy, including all arrays and lists which are duplicated.
    /// </remarks>
    public void Import(ImageFileDirectory imageFileDirectory)
    {
        // Enumerate all entries. All of these entries will be imported into the current instance.
        foreach (KeyValuePair<Tag, Entry> entry in imageFileDirectory)
        {
            // 1. Check if the value being imported is an IFD collection.
            if (entry.Value.Value is ImageFileDirectoryCollection importIfdc)
            {
                // If the target entry already exists, see if it is a compatible IFD collection.
                if (TryGetValue(entry.Key, out Entry? existingEntry))
                {
                    if (existingEntry.Value is not ImageFileDirectoryCollection targetIfdc)
                    {
                        // Convert the target entry to a compatible IFD collection.
                        if (existingEntry.Value is IEnumerable<ImageFileDirectoryCollection> targetIfdcs)
                        {
                            ImageFileDirectoryCollection? testIfdc = targetIfdcs.FirstOrDefault();
                            if (testIfdc is null)
                            {
                                targetIfdc = [];
                                this[entry.Key] = new Entry(entry.Key, entry.Value.Type, targetIfdc);
                            }
                            else
                            {
                                targetIfdc = testIfdc;
                            }
                        }
                        else
                        {
                            targetIfdc = [];
                            Add(entry.Key, new Entry(entry.Key, entry.Value.Type, targetIfdc));
                        }
                    }

                    targetIfdc.Import(importIfdc);
                }
                // If the target entry does not exist, create a new IFD collection and import the data.
                else
                {
                    ImageFileDirectoryCollection targetIfdc = [];
                    Add(entry.Key, new Entry(entry.Key, entry.Value.Type, targetIfdc));
                    targetIfdc.Import(importIfdc);
                }
            }
            // 2. Check if the value being imported is an enumerable of IFD collection.
            else if (entry.Value.Value is IEnumerable<ImageFileDirectoryCollection> importIfdcs)
            {
                // If the target entry already exists, see if it is a compatible IFD collection.
                if (TryGetValue(entry.Key, out Entry? existingEntry))
                {
                    // Convert the target entry to a compatible IFD collection.
                    if (existingEntry.Value is not IEnumerable<ImageFileDirectoryCollection> targetIfdcs)
                    {
                        targetIfdcs = existingEntry.Value is ImageFileDirectoryCollection targetIfdc
                            ? [targetIfdc]
                            : new List<ImageFileDirectoryCollection>();
                        this[entry.Key] = new Entry(entry.Key, entry.Value.Type, targetIfdcs);
                    }
                    else if (targetIfdcs is not List<ImageFileDirectoryCollection>)
                    {
                        targetIfdcs = new List<ImageFileDirectoryCollection>(targetIfdcs);
                        this[entry.Key] = new Entry(entry.Key, entry.Value.Type, targetIfdcs);
                    }

                    // At this point it is known the target is a list.
                    List<ImageFileDirectoryCollection> targetIfdcList = (List<ImageFileDirectoryCollection>)targetIfdcs;

                    // Import each IFD collection into the target list.
                    int index = 0;
                    foreach (ImageFileDirectoryCollection importingIfdc in importIfdcs)
                    {
                        if (index < targetIfdcList.Count)
                        {
                            targetIfdcList[index].Import(importingIfdc);
                        }
                        else
                        {
                            ImageFileDirectoryCollection targetIfdc = [];
                            targetIfdcList.Add(targetIfdc);
                            targetIfdc.Import(importingIfdc);
                        }
                        index++;
                    }
                }
                // If the target entry does not exist, create a new enumerable of IFD collection and import the data.
                else
                {
                    List<ImageFileDirectoryCollection> targetIfdcList = [];
                    Add(entry.Key, new Entry(entry.Key, entry.Value.Type, targetIfdcList));
                    foreach (ImageFileDirectoryCollection importingIfdc in importIfdcs)
                    {
                        ImageFileDirectoryCollection targetIfdc = [];
                        targetIfdcList.Add(targetIfdc);
                        targetIfdc.Import(importingIfdc);
                    }
                }
            }
            // 3. Handle all other value types.
            else
            {
                AddOrUpdate(AddOrUpdate(entry.Key, CloneValue(entry.Value.Value)));
            }
        }
    }
}