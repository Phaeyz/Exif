using System.Collections;
using System.Reflection;
using Phaeyz.Exif.Tags;

namespace Phaeyz.Exif;

/// <summary>
/// A container which is used during deserialization to determine tab behaviors.
/// </summary>
public class TagProvider : IEnumerable<Tag>
{
    private bool _readOnly = false;
    private Dictionary<ushort, HashSet<Tag>> _tagsFromValue = [];

    /// <summary>
    /// Built-in tags which allows for for round-trip of serialization and deserialization in most cases.
    /// </summary>
    public static readonly TagProvider Default;

    /// <summary>
    /// Creates a default provider containing the built-in tags.
    /// </summary>
    static TagProvider()
    {
        TagProvider tagProvider = [];
        tagProvider.AddFromType<TagIfd>();
        tagProvider.AddFromType<TagIfd0>();
        tagProvider.AddFromType<TagExifIfd>();
        tagProvider.AddFromType<TagGpsInfo>();
        tagProvider.AddFromType<TagInteroperabilityIfd>();
        tagProvider.AddFromType<TagSubIfd>();
        tagProvider.AddFromType<TagAny>();
        Default = tagProvider.AsReadOnly();
    }

    /// <summary>
    /// Creates and initializes a new tag provider along with an optional set of initial tags.
    /// </summary>
    /// <param name="tags"></param>
    public TagProvider(IEnumerable<Tag>? tags = null)
    {
        if (tags is not null)
        {
            AddRange(tags);
        }
    }

    /// <summary>
    /// Determines if the current provider is read-only. If the provider is read-only, add and remove methods will throw an exception. 
    /// </summary>
    public bool IsReadOnly => _readOnly;

    /// <summary>
    /// Adds a new tag to the provider. The tag's related and parents, if available, will also be added.
    /// </summary>
    /// <param name="tag">
    /// The tag to add to the provider.
    /// </param>
    /// <returns>
    /// Returns true if the tag was added to the provider, or false if an equivalent tag has already been added.
    /// </returns>
    /// <exception cref="System.ArgumentException">
    /// The tag is a root tag.
    /// </exception>
    /// <exception cref="System.InvalidOperationException">
    /// The provider is read-only.
    /// </exception>
    public bool Add(Tag tag)
    {
        ArgumentNullException.ThrowIfNull(tag);

        if (tag.IsRoot)
        {
            throw new ArgumentException("May not add the root tag to a provider.", nameof(tag));
        }

        if (_readOnly)
        {
            throw new InvalidOperationException("The tag provider is read-only.");
        }

        if (tag.Parent is not null && !tag.Parent.IsRoot)
        {
            Add(tag.Parent);
        }

        if (tag.Related is not null && !tag.Related.IsRoot)
        {
            Add(tag.Related);
        }

        if (_tagsFromValue.TryGetValue(tag.Value, out HashSet<Tag>? tags))
        {
            return tags.Add(tag);
        }

        _tagsFromValue.Add(tag.Value, new HashSet<Tag>([tag]));
        return true;
    }

    /// <summary>
    /// Adds all static tags found as fields or properties on a type to the provider.
    /// Each tag's related and parents, if available, will also be added.
    /// </summary>
    /// <typeparam name="T">
    /// The type containing static fields and properties with tag values.
    /// </typeparam>
    public void AddFromType<T>() => AddFromType(typeof(T));

    /// <summary>
    /// Adds all static tags found as fields or properties on a type to the provider.
    /// Each tag's related and parents, if available, will also be added.
    /// </summary>
    /// <param name="type">
    /// The type containing static fields and properties with tag values.
    /// </param>
    public void AddFromType(Type type)
    {
        foreach (var memberInfo in type.GetMembers(
            BindingFlags.Public | BindingFlags.Static | BindingFlags.GetField | BindingFlags.GetProperty | BindingFlags.FlattenHierarchy))
        {
            Tag? tag = null;
            if (memberInfo is FieldInfo fieldInfo && fieldInfo.FieldType == typeof(Tag))
            {
                tag = (Tag?)fieldInfo.GetValue(null);
            }
            else if (memberInfo is PropertyInfo propertyInfo && propertyInfo.PropertyType == typeof(Tag))
            {
                tag = (Tag?)propertyInfo.GetValue(null);
            }
            if (tag is not null && !tag.IsRoot)
            {
                Add(tag);
            }
        }
    }

    /// <summary>
    /// Adds or updates all static tags found as fields or properties on a type to the provider.
    /// Each tag's related and parents, if available, will also be added or updated.
    /// </summary>
    /// <typeparam name="T">
    /// The type containing static fields and properties with tag values.
    /// </typeparam>
    public void AddOrUpdateFromType<T>() => AddOrUpdateFromType(typeof(T));

    /// <summary>
    /// Adds or updates all static tags found as fields or properties on a type to the provider.
    /// Each tag's related and parents, if available, will also be added or updated.
    /// </summary>
    /// <param name="type">
    /// The type containing static fields and properties with tag values.
    /// </param>
    public void AddOrUpdateFromType(Type type)
    {
        foreach (var memberInfo in type.GetMembers(
            BindingFlags.Public | BindingFlags.Static | BindingFlags.GetField | BindingFlags.GetProperty | BindingFlags.FlattenHierarchy))
        {
            Tag? tag = null;
            if (memberInfo is FieldInfo fieldInfo && fieldInfo.FieldType == typeof(Tag))
            {
                tag = (Tag?)fieldInfo.GetValue(null);
            }
            else if (memberInfo is PropertyInfo propertyInfo && propertyInfo.PropertyType == typeof(Tag))
            {
                tag = (Tag?)propertyInfo.GetValue(null);
            }
            if (tag is not null && !tag.IsRoot)
            {
                AddOrUpdate(tag);
            }
        }
    }

    /// <summary>
    /// Adds a set of tags to the provider. Each tag's related and parents, if available, will also be added.
    /// </summary>
    /// <param name="tags">
    /// The set of tags to add to the provider.
    /// </param>
    public void AddRange(IEnumerable<Tag> tags)
    {
        ArgumentNullException.ThrowIfNull(tags);

        foreach (Tag tag in tags)
        {
            Add(tag);
        }
    }

    /// <summary>
    /// Adds a new tag to the provider. If an equivalent tag already exists, it will be replaced.
    /// The tag's related and parents, if available, will also be added or updated.
    /// </summary>
    /// <param name="tag">
    /// The tag to add to the provider.
    /// </param>
    /// <returns>
    /// Returns true if the tag previously did not exist and now it exists in the provider, or false otherwise.
    /// </returns>
    /// <exception cref="System.ArgumentException">
    /// The tag is a root tag.
    /// </exception>
    /// <exception cref="System.InvalidOperationException">
    /// The provider is read-only.
    /// </exception>
    public bool AddOrUpdate(Tag tag)
    {
        ArgumentNullException.ThrowIfNull(tag);

        if (tag.IsRoot)
        {
            throw new ArgumentException("May not add the root tag to a provider.", nameof(tag));
        }

        if (_readOnly)
        {
            throw new InvalidOperationException("The tag provider is read-only.");
        }

        if (tag.Parent is not null && !tag.Parent.IsRoot)
        {
            AddOrUpdate(tag.Parent);
        }

        if (tag.Related is not null && !tag.Related.IsRoot)
        {
            AddOrUpdate(tag.Related);
        }

        if (_tagsFromValue.TryGetValue(tag.Value, out HashSet<Tag>? tags))
        {
            bool added = !tags.Remove(tag);
            tags.Add(tag);
            return added;
        }

        _tagsFromValue.Add(tag.Value, new HashSet<Tag>([tag]));
        return true;
    }

    /// <summary>
    /// Adds or updates a set of tags to the provider. If an equivalent tag already exists, it will be replaced.
    /// Any tag's related and parents, if available, will also be added or updated.
    /// </summary>
    /// <param name="tags">
    /// The set of tags to add or update in the provider.
    /// </param>
    public void AddOrUpdateRange(IEnumerable<Tag> tags)
    {
        ArgumentNullException.ThrowIfNull(tags);

        foreach (Tag tag in tags)
        {
            AddOrUpdate(tag);
        }
    }

    /// <summary>
    /// Creates a version of the provider which is read-only. If the current version of the provider is not
    /// read-only, further modifications will be reflected in the read-only version.
    /// </summary>
    /// <returns>
    /// A read-only version of the current tag provider.
    /// </returns>
    public TagProvider AsReadOnly()
    {
        return IsReadOnly ? this : new TagProvider
        {
            _readOnly = true,
            _tagsFromValue = _tagsFromValue,
        };
    }

    /// <summary>
    /// Gets whether or not an equivalent tag exists in the provider.
    /// </summary>
    /// <param name="tag">
    /// The tag to determine whether or not an equivalent exists in the provider.
    /// </param>
    /// <returns>
    /// Returns true if an equivalent tag exists in the provider, or false otherwise.
    /// </returns>
    public bool Contains(Tag tag)
    {
        if (tag is null || tag.IsRoot)
        {
            return false;
        }

        return _tagsFromValue.TryGetValue(tag.Value, out HashSet<Tag>? tags) && tags.Contains(tag);
    }

    /// <summary>
    /// Iterates tags in the current tag provider.
    /// </summary>
    /// <param name="tagValue">
    /// Optionally filters to only tags with the specified tag value.
    /// </param>
    /// <returns>
    /// An iterator which enumerates tags in the provider.
    /// </returns>
    public IEnumerable<Tag> EnumerateTags(ushort? tagValue = null)
    {
        if (tagValue is not null)
        {
            if (_tagsFromValue.TryGetValue(tagValue.Value, out HashSet<Tag>? tags))
            {
                foreach (Tag tag in tags)
                {
                    yield return tag;
                }
            }
        }
        else
        {
            foreach (Tag tag in _tagsFromValue.Values.SelectMany(tag => tag))
            {
                yield return tag;
            }
        }
    }

    /// <summary>
    /// Gets an enumerator to enumerate all tags in the tag provider.
    /// </summary>
    /// <returns>
    /// An enumerator to enumerate all tags in the tag provider.
    /// </returns>
    public IEnumerator<Tag> GetEnumerator() => EnumerateTags().GetEnumerator();

    /// <summary>
    /// Gets an enumerator to enumerate all tags in the tag provider.
    /// </summary>
    /// <returns>
    /// An enumerator to enumerate all tags in the tag provider.
    /// </returns>
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    /// <summary>
    /// Matches the specified tag data to a tag in the tag provider.
    /// </summary>
    /// <param name="value">
    /// The tag value.
    /// </param>
    /// <param name="parent">
    /// The tag parent. This may not be <c>null</c>, and if the tag's parent is
    /// <c>null</c> it will match any value provided here.
    /// </param>
    /// <param name="index">
    /// The index of the parent where the value exists.
    /// </param>
    /// <returns>
    /// A new tag object if a matching tag could be found, or null otherwise.
    /// </returns>
    public Tag? Match(ushort value, Tag parent, int index)
    {
        if (_tagsFromValue.TryGetValue(value, out HashSet<Tag>? tags))
        {
            const int bestPossibleScore = 3;

            int bestScore = 0;
            Tag? bestTag = null;

            foreach (Tag tag in tags)
            {
                int score = tag.Match(value, parent, index);
                if (score > bestScore)
                {
                    bestScore = score;
                    bestTag = tag;
                }

                if (bestScore == bestPossibleScore)
                {
                    break;
                }
            }

            return bestTag;
        }

        return null;
    }

    /// <summary>
    /// Removes a tag from the provider.
    /// </summary>
    /// <param name="tag">
    /// The tag to remove from the provider.
    /// </param>
    /// <returns>
    /// Returns true if the tag was removed, or false otherwise.
    /// </returns>
    /// <exception cref="System.ArgumentException">
    /// The tag is a root tag.
    /// </exception>
    /// <exception cref="System.InvalidOperationException">
    /// The provider is read-only.
    /// </exception>
    public bool Remove(Tag tag)
    {
        ArgumentNullException.ThrowIfNull(tag);

        if (tag.IsRoot)
        {
            throw new ArgumentException("May not add the root tag to a provider.", nameof(tag));
        }

        if (_readOnly)
        {
            throw new InvalidOperationException("The tag provider is read-only.");
        }

        if (_tagsFromValue.TryGetValue(tag.Value, out HashSet<Tag>? tags))
        {
            if (tags.Remove(tag))
            {
                if (tags.Count == 0)
                {
                    _tagsFromValue.Remove(tag.Value);
                }
                return true;
            }
        }

        return false;
    }
}