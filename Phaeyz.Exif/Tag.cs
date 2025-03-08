using System.Text;

namespace Phaeyz.Exif;

/// <summary>
/// Represents an EXIF tag which identifies an entry value within an image file directory.
/// </summary>
public class Tag : IEquatable<Tag>
{
    /// <summary>
    /// Caches the hash code for the current tag so it only needs to be computed once.
    /// </summary>
    private int? _hashCode = null;

    /// <summary>
    /// Gets the root tag. This tag is never serialized or deserialized, but is used to indicate a pointer to
    /// the outer-most set of directories.
    /// </summary>
    public static readonly Tag Root = new(true);

    /// <summary>
    /// Gets whether or not the tag is the root tag.
    /// </summary>
    public bool IsRoot => Behavior == TagBehavior.Root;

    /// <summary>
    /// Aliases for the tag. The key a namespace name such as "Exif.Image.ImageWidth", and the value is the category such as "Image".
    /// </summary>
    public IReadOnlyDictionary<string, string> Aliases { get; private set; }

    /// <summary>
    /// Special behavior of the tag used for serializing and deserializing.
    /// </summary>
    public TagBehavior Behavior { get; private set; }

    /// <summary>
    /// Gets the index of parent directory set which this tag must exist within. If <c>null</c> this tag
    /// may appear in any of the array of parent directories.
    /// </summary>
    public int? Index { get; private set; }

    /// <summary>
    /// Gets a friendly name for the tag. Only used for debugging.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Gets the parent directory tag the current tag must exist under.
    /// </summary>
    public Tag? Parent { get; private set; }

    /// <summary>
    /// Gets a tag related to the current tag. This is currently only used with the <c>OffsetAndLengthPair</c> behavior.
    /// </summary>
    public Tag? Related { get; private set; }

    /// <summary>
    /// Gets the UINT16 value of the tag which is serialized to the EXIF.
    /// </summary>
    public ushort Value { get; private set; }

    /// <summary>
    /// Do not call.
    /// </summary>
    /// <exception cref="Phaeyz.Exif.ExifException">
    /// Use one of the Create methods to create a tag.
    /// </exception>
    protected Tag() => throw new ExifException("Use one of the Create methods to create a tag.");

    /// <summary>
    /// Creates a root tag.
    /// </summary>
    private Tag(bool _)
    {
        Parent = this;
        Index = null;
        Value = 0;
        Name = "Root";
        Behavior = TagBehavior.Root;
        Related = null;
        Aliases = new Dictionary<string, string>().AsReadOnly();
    }

    /// <summary>
    /// Creates a tag.
    /// </summary>
    /// <param name="parent">
    /// The parent directory tag the current tag must exist under. If <c>null</c> this tag may appear in every parent directory.
    /// </param>
    /// <param name="index">
    /// The index of parent directory set which this tag must exist within. If <c>null</c> this tag may appear in any
    /// of the array of parent directories.
    /// </param>
    /// <param name="value">
    /// The UINT16 value of the tag which is serialized to the EXIF.
    /// </param>
    /// <param name="name">
    /// A friendly name for the tag. Only used for debugging.
    /// </param>
    /// <param name="behavior">
    /// Special behavior of the tag used for serializing and deserializing.
    /// </param>
    /// <param name="related">
    /// A tag related to the current tag. This is currently only used with the <c>OffsetAndLengthPair</c> behavior.
    /// </param>
    /// <param name="aliases">
    /// Aliases for the tag. The key a namespace name such as "Exif.Image.ImageWidth", and the value is the category such as "Image".
    /// </param>
    /// <exception cref="System.ArgumentException">
    /// Either the parent tag is not root or a directory pointer, or the behavior is <c>Root</c>.
    /// </exception>
    /// <exception cref="System.ArgumentOutOfRangeException">
    /// The index is negative or the behavior value is not defined.
    /// </exception>
    private Tag(
        Tag? parent,
        int? index,
        ushort value,
        string? name,
        TagBehavior behavior,
        Tag? related = null,
        IEnumerable<KeyValuePair<string, string>>? aliases = null)
    {
        switch (parent?.Behavior)
        {
            case null:
            case TagBehavior.Root:
            case TagBehavior.IfdPointer:
            case TagBehavior.ScopedIfdPointer:
                break;
            default:
                throw new ArgumentException("A parent tag must be a directory pointer or the root.", nameof(parent));
        }

        if (index < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        if (behavior == TagBehavior.Root)
        {
            throw new ArgumentException("Cannot create a root tag.", nameof(behavior));
        }

        if (!Enum.IsDefined(typeof(TagBehavior), behavior))
        {
            throw new ArgumentOutOfRangeException(nameof(behavior));
        }

        if (string.IsNullOrEmpty(name))
        {
            name = $"Tag: {value:X4}";
        }

        Parent = parent;
        Index = index;
        Value = value;
        Name = name;
        Behavior = behavior;
        Related = related;
        Aliases = aliases is null ? Root.Aliases : new Dictionary<string, string>(aliases).AsReadOnly();
    }

    /// <summary>
    /// Creates a standard value tag.
    /// </summary>
    /// <param name="parent">
    /// The parent directory tag the current tag must exist under. If <c>null</c> this tag may appear in every parent directory.
    /// </param>
    /// <param name="index">
    /// The index of parent directory set which this tag must exist within. If <c>null</c> this tag may appear in any
    /// of the array of parent directories.
    /// </param>
    /// <param name="value">
    /// The UINT16 value of the tag which is serialized to the EXIF.
    /// </param>
    /// <param name="name">
    /// A friendly name for the tag. Only used for debugging.
    /// </param>
    /// <param name="canRoundTrip">
    /// If <c>false</c>, the tag will be marked as cannot round trip. Deserialized tags which cannot round
    /// trip will be surfaced in a resulting list allowing the caller to optionally take action.
    /// The default tag provider does not have any tags which are marked as "cannot round trip".
    /// Defaults to <c>true</c>.
    /// </param>
    /// <param name="aliases">
    /// Aliases for the tag. The key a namespace name such as "Exif.Image.ImageWidth", and the value is the category such as "Image".
    /// </param>
    /// <returns>
    /// The new standard value tag.
    /// </returns>
    public static Tag Create(
        Tag? parent,
        int? index,
        ushort value,
        string? name,
        bool canRoundTrip = true,
        IEnumerable<KeyValuePair<string, string>>? aliases = null) =>
        new(parent, index, value, name, canRoundTrip ? TagBehavior.StandardValue : TagBehavior.CannotRoundTrip, null, aliases);

    /// <summary>
    /// Creates a standard value tag.
    /// </summary>
    /// <param name="parent">
    /// The parent directory tag the current tag must exist under. If <c>null</c> this tag may appear in every parent directory.
    /// </param>
    /// <param name="index">
    /// The index of parent directory set which this tag must exist within. If <c>null</c> this tag may appear in any
    /// of the array of parent directories.
    /// </param>
    /// <param name="value">
    /// The UINT16 value of the tag which is serialized to the EXIF.
    /// </param>
    /// <param name="name">
    /// A friendly name for the tag. Only used for debugging.
    /// </param>
    /// <param name="canRoundTrip">
    /// If <c>false</c>, the tag will be marked as cannot round trip. Deserialized tags which cannot round
    /// trip will be surfaced in a resulting list allowing the caller to optionally take action.
    /// The default tag provider does not have any tags which are marked as "cannot round trip".
    /// Defaults to <c>true</c>.
    /// </param>
    /// <param name="aliases">
    /// Aliases for the tag. The key a namespace name such as "Exif.Image.ImageWidth", and the value is the category such as "Image".
    /// </param>
    /// <returns>
    /// The new standard value tag.
    /// </returns>
    public static Tag Create(
        Tag? parent,
        int? index,
        ushort value,
        string? name,
        bool canRoundTrip,
        IEnumerable<(string key, string category)>? aliases) => Create(
            parent,
            index,
            value,
            name,
            canRoundTrip,
            aliases?.Select(o => new KeyValuePair<string, string>(o.key, o.category)));

    /// <summary>
    /// Creates a tag where the value is an offset to a block of data of unknown size, and best effort is attempted
    /// to preserve the data block during deserialization.
    /// </summary>
    /// <param name="parent">
    /// The parent directory tag the current tag must exist under. If <c>null</c> this tag may appear in every parent directory.
    /// </param>
    /// <param name="index">
    /// The index of parent directory set which this tag must exist within. If <c>null</c> this tag may appear in any
    /// of the array of parent directories.
    /// </param>
    /// <param name="value">
    /// The UINT16 value of the tag which is serialized to the EXIF.
    /// </param>
    /// <param name="name">
    /// A friendly name for the tag. Only used for debugging.
    /// </param>
    /// <param name="aliases">
    /// Aliases for the tag. The key a namespace name such as "Exif.Image.ImageWidth", and the value is the category such as "Image".
    /// </param>
    /// <returns>
    /// The new standard value tag.
    /// </returns>
    public static Tag CreatePreserveDataBlock(
        Tag? parent,
        int? index,
        ushort value,
        string? name,
        IEnumerable<KeyValuePair<string, string>>? aliases = null) =>
        new(parent, index, value, name, TagBehavior.PreserveDataBlock, null, aliases);

    /// <summary>
    /// Creates a tag where the value is an offset to a block of data of unknown size, and best effort is attempted
    /// to preserve the data block during deserialization.
    /// </summary>
    /// <param name="parent">
    /// The parent directory tag the current tag must exist under. If <c>null</c> this tag may appear in every parent directory.
    /// </param>
    /// <param name="index">
    /// The index of parent directory set which this tag must exist within. If <c>null</c> this tag may appear in any
    /// of the array of parent directories.
    /// </param>
    /// <param name="value">
    /// The UINT16 value of the tag which is serialized to the EXIF.
    /// </param>
    /// <param name="name">
    /// A friendly name for the tag. Only used for debugging.
    /// </param>
    /// <param name="aliases">
    /// Aliases for the tag. The key a namespace name such as "Exif.Image.ImageWidth", and the value is the category such as "Image".
    /// </param>
    /// <returns>
    /// The new standard value tag.
    /// </returns>
    public static Tag CreatePreserveDataBlock(
        Tag? parent,
        int? index,
        ushort value,
        string? name,
        IEnumerable<(string key, string category)>? aliases) => CreatePreserveDataBlock(
            parent,
            index,
            value,
            name,
            aliases?.Select(o => new KeyValuePair<string, string>(o.key, o.category)));

    /// <summary>
    /// Creates a directory pointer tag.
    /// </summary>
    /// <param name="parent">
    /// The parent directory tag the current tag must exist under.
    /// </param>
    /// <param name="index">
    /// The index of parent directory set which this tag must exist within. If <c>null</c> this tag may appear in any
    /// of the array of parent directories.
    /// </param>
    /// <param name="value">
    /// The UINT16 value of the tag which is serialized to the EXIF.
    /// </param>
    /// <param name="name">
    /// A friendly name for the tag. Only used for debugging.
    /// </param>
    /// <param name="scopeByteOffset">
    /// If true, all offsets within the serialized image file directory are relative to the first byte of the image file
    /// directory. If false, all offsets are relative to the start of the EXIF buffer (this is the normal case).
    /// </param>
    /// <param name="aliases">
    /// Aliases for the tag. The key a namespace name such as "Exif.Image.ImageWidth", and the value is the category such as "Image".
    /// </param>
    /// <returns>
    /// The new directory pointer tag.
    /// </returns>
    public static Tag CreateIfdPointer(
        Tag? parent,
        int? index,
        ushort value,
        string? name,
        bool scopeByteOffset = false,
        IEnumerable<KeyValuePair<string, string>>? aliases = null) =>
        new(parent, index, value, name, scopeByteOffset ? TagBehavior.ScopedIfdPointer : TagBehavior.IfdPointer, null, aliases);

    /// <summary>
    /// Creates a directory pointer tag.
    /// </summary>
    /// <param name="parent">
    /// The parent directory tag the current tag must exist under.
    /// </param>
    /// <param name="index">
    /// The index of parent directory set which this tag must exist within. If <c>null</c> this tag may appear in any
    /// of the array of parent directories.
    /// </param>
    /// <param name="value">
    /// The UINT16 value of the tag which is serialized to the EXIF.
    /// </param>
    /// <param name="name">
    /// A friendly name for the tag. Only used for debugging.
    /// </param>
    /// <param name="scopeByteOffset">
    /// If true, all offsets within the serialized image file directory are relative to the first byte of the image file
    /// directory. If false, all offsets are relative to the start of the EXIF buffer (this is the normal case).
    /// </param>
    /// <param name="aliases">
    /// Aliases for the tag. The key a namespace name such as "Exif.Image.ImageWidth", and the value is the category such as "Image".
    /// </param>
    /// <returns>
    /// The new directory pointer tag.
    /// </returns>
    public static Tag CreateIfdPointer(
        Tag? parent,
        int? index,
        ushort value,
        string? name,
        bool scopeByteOffset,
        IEnumerable<(string key, string category)>? aliases) => CreateIfdPointer(
            parent,
            index,
            value,
            name,
            scopeByteOffset,
            aliases?.Select(o => new KeyValuePair<string, string>(o.key, o.category)));

    /// <summary>
    /// Creates an offset and length pair tag.
    /// </summary>
    /// <param name="parent">
    /// The parent directory tag the current tag must exist under. If <c>null</c> this tag may appear in every parent directory.
    /// </param>
    /// <param name="index">
    /// The index of parent directory set which this tag must exist within. If <c>null</c> this tag may appear in any
    /// of the array of parent directories.
    /// </param>
    /// <param name="offsetValue">
    /// The UINT16 value of the tag for the data offset.
    /// </param>
    /// <param name="offsetName">
    /// A friendly name for the offset tag. Only used for debugging.
    /// </param>
    /// <param name="lengthValue">
    /// The UINT16 value of the tag for the data length.
    /// </param>
    /// <param name="lengthName">
    /// A friendly name for the length tag. Only used for debugging.
    /// </param>
    /// <param name="aliases">
    /// Aliases for the tag. The key a namespace name such as "Exif.Image.ImageWidth", and the value is the category such as "Image".
    /// </param>
    /// <returns>
    /// The new directory pointer tag.
    /// </returns>
    public static Tag CreateOffsetAndLengthPair(
        Tag? parent,
        int? index,
        ushort offsetValue,
        string? offsetName,
        ushort lengthValue,
        string? lengthName,
        IEnumerable<KeyValuePair<string, string>>? aliases = null)
    {
        Tag valueTag = new(
            parent,
            index,
            lengthValue,
            string.IsNullOrEmpty(offsetName) ? lengthName : string.IsNullOrEmpty(lengthName) ? null : offsetName + " (Length)",
            TagBehavior.StandardValue);

        return new(parent, index, offsetValue, offsetName, TagBehavior.OffsetAndLengthPair, valueTag, aliases);
    }

    /// <summary>
    /// Creates an offset and length pair tag.
    /// </summary>
    /// <param name="parent">
    /// The parent directory tag the current tag must exist under. If <c>null</c> this tag may appear in every parent directory.
    /// </param>
    /// <param name="index">
    /// The index of parent directory set which this tag must exist within. If <c>null</c> this tag may appear in any
    /// of the array of parent directories.
    /// </param>
    /// <param name="offsetValue">
    /// The UINT16 value of the tag for the data offset.
    /// </param>
    /// <param name="offsetName">
    /// A friendly name for the offset tag. Only used for debugging.
    /// </param>
    /// <param name="lengthValue">
    /// The UINT16 value of the tag for the data length.
    /// </param>
    /// <param name="lengthName">
    /// A friendly name for the length tag. Only used for debugging.
    /// </param>
    /// <param name="aliases">
    /// Aliases for the tag. The key a namespace name such as "Exif.Image.ImageWidth", and the value is the category such as "Image".
    /// </param>
    /// <returns>
    /// The new directory pointer tag.
    /// </returns>
    public static Tag CreateOffsetAndLengthPair(
        Tag? parent,
        int? index,
        ushort offsetValue,
        string? offsetName,
        ushort lengthValue,
        string? lengthName,
        IEnumerable<(string key, string category)>? aliases) => CreateOffsetAndLengthPair(
            parent,
            index,
            offsetValue,
            offsetName,
            lengthValue,
            lengthName,
            aliases?.Select(o => new KeyValuePair<string, string>(o.key, o.category)));

    /// <summary>
    /// Determines if the specified tag is logically equal to the current tag. Names, aliases, and behaviors are ignored.
    /// </summary>
    /// <param name="obj">
    /// The tag which must match the current match.
    /// </param>
    /// <returns>
    /// Returns true if the tag data is logically equal to the current tag, otherwise false.
    /// </returns>
    public override bool Equals(object? obj) => Equals(obj as Tag);

    /// <summary>
    /// Determines if the specified tag is logically equal to the current tag. Names, aliases, and behaviors are ignored.
    /// </summary>
    /// <param name="tag">
    /// The tag which must match the current match.
    /// </param>
    /// <returns>
    /// Returns true if the tag data is logically equal to the current tag, otherwise false.
    /// </returns>
    public bool Equals(Tag? tag) =>
        tag is not null &&
        Value == tag.Value &&
        Index == tag.Index &&
        Parent is null == tag.Parent is null &&
        Parent?.IsRoot == tag.Parent?.IsRoot &&
        (Parent is null || Parent.IsRoot || Parent.Equals(tag.Parent!));

    /// <summary>
    /// Determines if the specified tag data is logically equal to the current tag. Names, aliases, and behaviors are ignored.
    /// </summary>
    /// <param name="value">
    /// The value to match in the current tag.
    /// </param>
    /// <param name="parent">
    /// The parent to match in the current tag.
    /// </param>
    /// <param name="index">
    /// The index to match in the current tag.
    /// </param>
    /// <returns>
    /// Returns true if the tag data is logically equal to the current tag, otherwise false.
    /// </returns>
    public bool Equals(ushort value, Tag? parent, int? index) =>
        Value != value &&
        Index != index &&
        Parent is null != parent is null &&
        Parent?.IsRoot == parent?.IsRoot &&
        (Parent is null || Parent.IsRoot || Parent.Equals(parent));

    /// <summary>
    /// Computes a hash code for the current tag. Names, aliases, and behaviors are ignored.
    /// </summary>
    /// <returns>
    /// A hash code for the current tag.
    /// </returns>
    public override int GetHashCode()
    {
        if (_hashCode is null)
        {
            HashCode hashCode = new();
            hashCode.Add(Value);
            hashCode.Add(Index);
            if (!IsRoot)
            {
                hashCode.Add(Parent?.GetHashCode());
            }
            _hashCode = hashCode.ToHashCode();
        }
        return _hashCode.Value;
    }

    /// <summary>
    /// Computes a score to how closely the tag logically matches the current tag. Names, aliases, and behaviors are ignored.
    /// </summary>
    /// <param name="tag">
    /// The tag which must match the current match.
    /// </param>
    /// <returns>
    /// Returns a score to how closely the tag logically matches the current tag. The lowest value is 0 which means the tag
    /// is incompatible, and the highest value is 3 which means the value, index, and parent all match.
    /// </returns>
    public int Match(Tag? tag)
    {
        if (tag is null || Value != tag.Value)
        {
            return 0;
        }

        int score = 1;

        if (Index is not null && tag.Index is not null)
        {
            if (Index != tag.Index)
            {
                return 0;
            }
            score++;
        }

        if (Parent is not null && tag.Parent is not null)
        {
            if (Parent.IsRoot != tag.Parent.IsRoot ||
                !Parent.IsRoot && Parent.Match(tag.Parent) == 0)
            {
                return 0;
            }
            score++;
        }

        return score;
    }

    /// <summary>
    /// Computes a score to how closely the tag data logically matches the current tag. Names, aliases, and behaviors are ignored.
    /// </summary>
    /// <param name="value">
    /// The value to match in the current tag.
    /// </param>
    /// <param name="parent">
    /// The parent to match in the current tag. This may not be <c>null</c>, and if the tag's parent is
    /// <c>null</c> it will match any value provided here.
    /// </param>
    /// <param name="index">
    /// The index to match in the current tag.
    /// </param>
    /// <returns>
    /// Returns a score to how closely the tag data logically matches the current tag. The lowest value is 0 which means the tag
    /// data is incompatible, and the highest value is 3 which means the value, index, and parent all match.
    /// </returns>
    public int Match(ushort value, Tag parent, int index)
    {
        if (parent is null || Value != value)
        {
            return 0;
        }

        int score = 1;

        if (Index is not null)
        {
            if (Index != index)
            {
                return 0;
            }
            score++;
        }

        if (Parent is not null)
        {
            if (Parent.IsRoot != parent.IsRoot ||
                !Parent.IsRoot && Parent.Match(parent) == 0)
            {
                return 0;
            }
            score++;
        }

        return score;
    }

    /// <summary>
    /// Creates a friendly string representing the current tag.
    /// </summary>
    /// <returns>
    /// A friendly string representing the current tag.
    /// </returns>
    public override string ToString()
    {
        string stringBase = string.IsNullOrWhiteSpace(Name) ? $"0x{Value:X4}" : $"{Name} (0x{Value:X4})";
        if (Aliases.Count == 0)
        {
            return stringBase;
        }
        StringBuilder sb = new(stringBase);
        sb.Append(" [");
        foreach (var aliasToken in Aliases.Keys.Select((a, i) => i > 0 ? $", {a}" : a))
        {
            sb.Append(aliasToken);
        }
        sb.Append(']');
        return sb.ToString();
    }
}