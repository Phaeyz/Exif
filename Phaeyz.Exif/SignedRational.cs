namespace Phaeyz.Exif;

/// <summary>
/// Two signed 32-bit values (a numerator and a denominator) forming a rational value.
/// </summary>
/// <param name="numerator">
/// The numberator.
/// </param>
/// <param name="denominator">
/// The denominator.
/// </param>
public readonly struct SignedRational(int numerator, int denominator)
{
    /// <summary>
    /// The numerator.
    /// </summary>
    public int Numerator { get; } = numerator;

    /// <summary>
    /// The denominator.
    /// </summary>
    public int Denominator { get; } = denominator;

    /// <summary>
    /// A computed value by dividing the numerator by the denominator.
    /// </summary>
    public readonly double Value => Denominator == 0 ? double.NaN : Numerator / (double)Denominator;

    /// <summary>
    /// Gets a friendly string for the rational number.
    /// </summary>
    /// <returns>
    /// A friendly string for the rational number.
    /// </returns>
    public override readonly string ToString() => $"{Numerator} / {Denominator} ({Value})";
}