using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Phaeyz.Exif;

/// <summary>
/// Supports the serialization and deserialization of EXIF date and time values.
/// </summary>
/// <remarks>
/// EXIF date and time values are formatted as "YYYY:MM:DD HH:MM:SS" and this is how this class
/// serializes values. However, when deserializing, the class is more lenient and accepts a variety
/// of formats. The class also supports partial date and time values.
/// </remarks>
public partial struct ExifDateTime : IEquatable<ExifDateTime>
{
    [GeneratedRegex(@"\A\s*(?<Year>\d{4})?\s*[:/-]?\s*((?<Month>\d{2})?\s*[:/-]?\s*((?<Day>\d{2})?\s*[T@]?\s*((?<Hour>\d{2})?\s*[:/-]?\s*((?<Minute>\d{2})?\s*[:/-]?\s*((?<Second>\d{2})?)?)?)?)?)?\s*\z",
        RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.Singleline)]
    private static partial Regex DateTimeRegex();

    /// <summary>
    /// Initializes a new instance of the <see cref="Phaeyz.Exif.ExifDateTime"/> struct
    /// using an EXIF date and time string of the format "YYYY:MM:DD HH:MM:SS".
    /// </summary>
    /// <param name="dateTimeString">
    /// An EXIF date and time string.
    /// </param>
    public ExifDateTime(string dateTimeString)
    {
        Match match = DateTimeRegex().Match(dateTimeString);
        if (match.Success)
        {
            Year = match.Groups["Year"].Success ? ushort.Parse(match.Groups["Year"].Value) : null;
            Month = match.Groups["Month"].Success ? byte.Parse(match.Groups["Month"].Value) : null;
            Day = match.Groups["Day"].Success ? byte.Parse(match.Groups["Day"].Value) : null;
            Hour = match.Groups["Hour"].Success ? byte.Parse(match.Groups["Hour"].Value) : null;
            Minute = match.Groups["Minute"].Success ? byte.Parse(match.Groups["Minute"].Value) : null;
            Second = match.Groups["Second"].Success ? byte.Parse(match.Groups["Second"].Value) : null;
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Phaeyz.Exif.ExifDateTime"/> struct.
    /// </summary>
    /// <param name="dateOnly">
    /// A date-only value.
    /// </param>
    public ExifDateTime(DateOnly dateOnly)
    {
        Year = (ushort)dateOnly.Year;
        Month = (byte)dateOnly.Month;
        Day = (byte)dateOnly.Day;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Phaeyz.Exif.ExifDateTime"/> struct.
    /// </summary>
    /// <param name="timeOnly">
    /// A time-only value.
    /// </param>
    public ExifDateTime(TimeOnly timeOnly)
    {
        Hour = (byte)timeOnly.Hour;
        Minute = (byte)timeOnly.Minute;
        Second = (byte)timeOnly.Second;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Phaeyz.Exif.ExifDateTime"/> struct.
    /// </summary>
    /// <param name="dateTime">
    /// A date and time value.
    /// </param>
    public ExifDateTime(DateTime dateTime)
    {
        Year = (ushort)dateTime.Year;
        Month = (byte)dateTime.Month;
        Day = (byte)dateTime.Day;
        Hour = (byte)dateTime.Hour;
        Minute = (byte)dateTime.Minute;
        Second = (byte)dateTime.Second;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Phaeyz.Exif.ExifDateTime"/> struct.
    /// </summary>
    /// <param name="dateTimeOffset">
    /// A date and time offset value.
    /// </param>
    public ExifDateTime(DateTimeOffset dateTimeOffset) : this(dateTimeOffset.DateTime) { }

    /// <summary>
    /// The year value of the date and time.
    /// </summary>
    public ushort? Year { get; set; }

    /// <summary>
    /// The month value of the date and time.
    /// </summary>
    public byte? Month { get; set; }

    /// <summary>
    /// The day value of the date and time.
    /// </summary>
    public byte? Day { get; set; }

    /// <summary>
    /// The hour value of the date and time.
    /// </summary>
    public byte? Hour { get; set; }

    /// <summary>
    /// The minute value of the date and time.
    /// </summary>
    public byte? Minute { get; set; }

    /// <summary>
    /// The second value of the date and time.
    /// </summary>
    public byte? Second { get; set; }

    /// <summary>
    /// Determines whether or not the date and time has all date component values.
    /// </summary>
    public readonly bool HasFullDate => Year is not null && Month is not null && Day is not null;

    /// <summary>
    /// Determines whether or not the date and time has all time component values.
    /// </summary>
    public readonly bool HasFullTime => Hour is not null && Minute is not null && Second is not null;

    /// <summary>
    /// Determines whether or not the date and time has all date and time component values.
    /// </summary>
    public readonly bool HasFullDateTime => HasFullDate && HasFullTime;

    /// <summary>
    /// Determines whether or not all date component values are <c>null</c>.
    /// </summary>
    public readonly bool IsDateEmpty => Year is null && Month is null && Day is null;

    /// <summary>
    /// Determines whether or not all time component values are <c>null</c>.
    /// </summary>
    public readonly bool IsTimeEmpty => Hour is null && Minute is null && Second is null;

    /// <summary>
    /// Determines whether or not all date and time component values are <c>null</c>.
    /// </summary>
    public readonly bool IsEmpty => IsDateEmpty && IsTimeEmpty;

    /// <summary>
    /// Gets the date-only value of the date and time, or <c>null</c> if any date values are <c>null</c>.
    /// </summary>
    public readonly DateOnly? DateOnly => HasFullDate ? new DateOnly(Year!.Value, Month!.Value, Day!.Value) : null;

    /// <summary>
    /// Gets the time-only value of the date and time, or <c>null</c> if any time values are <c>null</c>.
    /// </summary>
    public readonly TimeOnly? TimeOnly => HasFullTime ? new TimeOnly(Hour!.Value, Minute!.Value, Second!.Value) : null;

    /// <summary>
    /// Gets the full date and time value, or <c>null</c> if any date or time values are <c>null</c>.
    /// </summary>
    public readonly DateTime? DateTime => HasFullDateTime ? new DateTime(Year!.Value, Month!.Value, Day!.Value, Hour!.Value, Minute!.Value, Second!.Value) : null;

    /// <summary>
    /// Gets the EXIF-serializable date and time string.
    /// </summary>
    public readonly string DateAndTimeString => $"{DateString} {TimeString}";

    /// <summary>
    /// Gets the EXIF-serializable date string.
    /// </summary>
    public readonly string DateString => $"{(Year?.ToString("D4") ?? "    ")}:{(Month?.ToString("D2") ?? "  ")}:{(Day?.ToString("D2") ?? "  ")}";

    /// <summary>
    /// Gets the EXIF-serializable time string.
    /// </summary>
    public readonly string TimeString => $"{(Hour?.ToString("D2") ?? "  ")}:{(Minute?.ToString("D2") ?? "  ")}:{(Second?.ToString("D2") ?? "  ")}";

    /// <summary>
    /// Determines whether two object instances are equal.
    /// </summary>
    /// <param name="other">
    /// The object to compare with the current object.
    /// </param>
    /// <returns>
    /// <c>true</c>> if the specified object is equal to the current object; otherwise, <c>false</c>.
    /// </returns>
    public readonly bool Equals(ExifDateTime other) =>
        Year == other.Year && Month == other.Month && Day == other.Day &&
        Hour == other.Hour && Minute == other.Minute && Second == other.Second;

    /// <summary>
    /// Determines whether two object instances are equal.
    /// </summary>
    /// <param name="obj">
    /// The object to compare with the current object.
    /// </param>
    /// <returns>
    /// <c>true</c>> if the specified object is equal to the current object; otherwise, <c>false</c>.
    /// </returns>
    public override readonly bool Equals([NotNullWhen(true)] object? obj) => obj is ExifDateTime other && Equals(other);

    /// <summary>
    /// Computes a hash code for the current instance.
    /// </summary>
    /// <returns>
    /// A hash code for the current instance.
    /// </returns>
    public override readonly int GetHashCode() => HashCode.Combine(Year, Month, Day, Hour, Minute, Second);

    /// <summary>
    /// Gets the EXIF-serializable date and time string.
    /// </summary>
    /// <returns>
    /// The EXIF-serializable date and time string.
    /// </returns>
    public readonly override string ToString() => DateAndTimeString;
}
