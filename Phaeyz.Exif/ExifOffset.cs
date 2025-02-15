using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Phaeyz.Exif;

/// <summary>
/// Supports the serialization and deserialization of EXIF offset values.
/// </summary>
/// <remarks>
/// EXIF offset values are formatted as "+HH:MM" or "-HH:MM" and this is how this class
/// serializes values. However, when deserializing, the class is more lenient and accepts a variety
/// of formats. The class also supports partial offset values.
/// </remarks>
public partial struct ExifOffset : IEquatable<ExifOffset>
{
    [GeneratedRegex(@"\A\s*(?<PlusOrMinus>(\+|-))?\s*(?<Hours>\d{1,2})?\s*[:/-]?\s*(?<Minutes>\d{1,2})?\s*\z",
        RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.Singleline)]
    private static partial Regex OffsetRegex();

    /// <summary>
    /// Initializes a new instance of the <see cref="Phaeyz.Exif.ExifOffset"/> struct
    /// using an EXIF date and time string of the format "+HH:MM" or "-HH:MM".
    /// </summary>
    /// <param name="offsetString">
    /// An EXIF date and time string.
    /// </param>
    public ExifOffset(string offsetString)
    {
        Match match = OffsetRegex().Match(offsetString);
        if (match.Success)
        {
            IsPositive = match.Groups["PlusOrMinus"].Success ? match.Groups["PlusOrMinus"].Value == "+" : null;
            Hours = match.Groups["Hours"].Success ? byte.Parse(match.Groups["Hours"].Value) : null;
            Minutes = match.Groups["Minutes"].Success ? byte.Parse(match.Groups["Minutes"].Value) : null;
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Phaeyz.Exif.ExifOffset"/> struct.
    /// </summary>
    /// <param name="totalMinutes">
    /// The total number of minutes in the offset.
    /// </param>
    public ExifOffset(int totalMinutes)
    {
        IsPositive = totalMinutes >= 0;
        Hours = (byte)(totalMinutes / 60);
        Minutes = (byte)(totalMinutes % 60);
    }

    /// <summary>
    /// Indicates whether or not the offset is a positive or negative value.
    /// </summary>
    public bool? IsPositive { get; set; }

    /// <summary>
    /// The hour value of the offset.
    /// </summary>
    public byte? Hours { get; set; }

    /// <summary>
    /// The minute value of the offset.
    /// </summary>
    public byte? Minutes { get; set; }

    /// <summary>
    /// Determines whether or not the offset has all offset component values.
    /// </summary>
    public readonly bool HasFullOffset => IsPositive is not null && Hours is not null && Minutes is not null;

    /// <summary>
    /// Determines whether or not all offset component values are <c>null</c>.
    /// </summary>
    public readonly bool IsEmpty => IsPositive is null && Hours is null && Minutes is null;

    /// <summary>
    /// Gets the EXIF-serializable offset string.
    /// </summary>
    public readonly string OffsetString => $"{(IsPositive.HasValue ? IsPositive.Value ? "+" : "-" : " ")}{(Hours?.ToString("D2") ?? "  ")}:{(Minutes?.ToString("D2") ?? "  ")}";

    /// <summary>
    /// Gets the offset in total minutes..
    /// </summary>
    public readonly int TotalMinutes => (IsPositive ?? true ? 1 : -1) * ((Hours ?? 0) * 60 + (Minutes ?? 0));

    /// <summary>
    /// Determines whether two object instances are equal.
    /// </summary>
    /// <param name="other">
    /// The object to compare with the current object.
    /// </param>
    /// <returns>
    /// <c>true</c>> if the specified object is equal to the current object; otherwise, <c>false</c>.
    /// </returns>
    public readonly bool Equals(ExifOffset other) => Hours == other.Hours && Minutes == other.Minutes;

    /// <summary>
    /// Determines whether two object instances are equal.
    /// </summary>
    /// <param name="obj">
    /// The object to compare with the current object.
    /// </param>
    /// <returns>
    /// <c>true</c>> if the specified object is equal to the current object; otherwise, <c>false</c>.
    /// </returns>
    public override readonly bool Equals([NotNullWhen(true)] object? obj) => obj is ExifOffset other && Equals(other);

    /// <summary>
    /// Computes a hash code for the current instance.
    /// </summary>
    /// <returns>
    /// A hash code for the current instance.
    /// </returns>
    public override readonly int GetHashCode() => HashCode.Combine(IsPositive, Hours, Minutes);

    /// <summary>
    /// Gets the EXIF-serializable offset string.
    /// </summary>
    /// <returns>
    /// The EXIF-serializable offset string.
    /// </returns>
    public readonly override string ToString() => OffsetString;
}
