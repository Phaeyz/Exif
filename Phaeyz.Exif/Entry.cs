using System.Collections;

namespace Phaeyz.Exif;

/// <summary>
/// An entry within an image file directory.
/// </summary>
public class Entry
{
    /// <summary>
    /// Creates and initializes an instance of an image file directory entry.
    /// </summary>
    /// <param name="tag">
    /// The tag of the entry.
    /// </param>
    /// <param name="type">
    /// The type of the entry.
    /// </param>
    /// <param name="value">
    /// The value of the entry.
    /// </param>
    public Entry(Tag tag, EntryType type, object value)
    {
        ArgumentNullException.ThrowIfNull(tag);
        ArgumentNullException.ThrowIfNull(value);

        Tag = tag;
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Creates and initializes an instance of an image file directory entry.
    /// </summary>
    /// <param name="tag">
    /// The tag of the entry.
    /// </param>
    /// <param name="value">
    /// The value of the entry. The entry type is inferred from the value.
    /// </param>
    public Entry(Tag tag, object value)
    {
        ArgumentNullException.ThrowIfNull(tag);
        ArgumentNullException.ThrowIfNull(value);

        Tag = tag;
        Type = GetTypeFromValue(value);
        Value = value;
    }

    /// <summary>
    /// Gets an entry type from a value.
    /// </summary>
    /// <param name="value">
    /// The value to get the entry type from.
    /// </param>
    /// <returns>
    /// The entry type.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when the value is null.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Throws when the value type is not supported.
    /// </exception>
    public static EntryType GetTypeFromValue(object value) => value switch
    {
        null => throw new ArgumentNullException(nameof(value)),
        string _ => EntryType.Ascii,
        IEnumerable<byte> _ => EntryType.ByteSequence,
        byte _ => EntryType.Byte,
        sbyte _ => EntryType.SByte,
        ushort _ or IEnumerable<ushort> _ => EntryType.UInt16,
        short _ or IEnumerable<short> _ => EntryType.Int16,
        uint _ or IEnumerable<uint> _ => EntryType.UInt32,
        int _ or IEnumerable<int> _ => EntryType.Int32,
        float _ or IEnumerable<float> _ => EntryType.Single,
        double _ or IEnumerable<double> _ => EntryType.Double,
        UnsignedRational or IEnumerable<UnsignedRational> _ => EntryType.UnsignedRational,
        SignedRational or IEnumerable<SignedRational> _ => EntryType.SignedRational,
        ImageFileDirectoryCollection _ or IEnumerable<ImageFileDirectoryCollection> _ => EntryType.UInt32,
        _ => throw new ArgumentException("Unsupported value type.", nameof(value)),
    };

    /// <summary>
    /// Gets the entry tag.
    /// </summary>
    public Tag Tag { get; }

    /// <summary>
    /// Gets the entry type.
    /// </summary>
    public EntryType Type { get; }

    /// <summary>
    /// Gets the entry value.
    /// </summary>
    public object Value { get; }

    /// <summary>
    /// Gets a friendly string of the image file directory entry.
    /// </summary>
    /// <returns>
    /// A friendly string of the image file directory entry.
    /// </returns>
    public override string ToString()
    {
        object value = Value;
        if (value is ImageFileDirectoryCollection imageFileDirectoryCollection)
        {
            return $"Tag={Tag}, Type={Type}, IfdPointers=1";
        }
        if (value is IEnumerable<ImageFileDirectoryCollection> imageFileDirectoryPointers)
        {
            return $"Tag={Tag}, Type={Type}, IfdPointers={imageFileDirectoryPointers.Count()}";
        }
        if (value is IEnumerable<byte> byteSequence)
        {
            return $"Tag={Tag}, Type={Type}, ByteCount={byteSequence.Count()}";
        }
        string valueString = value is not string && value is IEnumerable enumerable
            ? $"[{string.Join(',', enumerable.Cast<object>().Select(obj => obj.ToString()))}]"
            : value?.ToString() ?? "<null>";
        return $"Tag={Tag}, Type={Type}, Value={valueString}";
    }

    /// <summary>
    /// Implicitly converts a tuple to an entry.
    /// </summary>
    /// <param name="entry">
    /// The tuple to convert to an entry.
    /// </param>
    public static implicit operator Entry((Tag tag, object value) entry) => new(entry.tag, entry.value);
}