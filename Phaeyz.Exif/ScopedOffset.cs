namespace Phaeyz.Exif;

/// <summary>
/// Tracks offsets when both an absolute and relative offset are involved.
/// </summary>
internal readonly struct ScopedOffset
{
    /// <summary>
    /// Creates and initializes a new ScopedOffset instance.
    /// </summary>
    /// <param name="absoluteOffset">
    /// An absolute offset value.
    /// </param>
    /// <param name="relativeOffset">
    /// An offset which is relative to the absolute offset.
    /// </param>
    public ScopedOffset(int absoluteOffset, int relativeOffset)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(absoluteOffset);
        ArgumentOutOfRangeException.ThrowIfNegative(relativeOffset);
        AbsoluteOffset = absoluteOffset;
        RelativeOffset = relativeOffset;
    }

    /// <summary>
    /// Gets the absolute offset value.
    /// </summary>
    public int AbsoluteOffset { get; }

    /// <summary>
    /// Gets the offset which is relative to the absolute offset.
    /// </summary>
    public int RelativeOffset { get; }

    /// <summary>
    /// Gets the computed offset taking into account both the absolute and relative offset.
    /// </summary>
    public int Value => AbsoluteOffset + RelativeOffset;

    /// <summary>
    /// Creates a new ScopedOffset which is scoped to the computed offset value of the current instance.
    /// </summary>
    /// <returns>
    /// A new ScopedOffset which is scoped to the computed offset value of the current instance.
    /// </returns>
    public ScopedOffset Scope() => new(AbsoluteOffset + RelativeOffset, 0);

    /// <summary>
    /// Creates a new ScopedOffset by computing a new relative offset and maintaining the existing absolute offset.
    /// </summary>
    /// <param name="scopingOffset">
    /// The existing scoping offset.
    /// </param>
    /// <param name="add">
    /// The value to add against the relative offset.
    /// </param>
    /// <returns>
    /// A new ScopedOffset by computing a new relative offset and maintaining the existing absolute offset.
    /// </returns>
    public static ScopedOffset operator +(ScopedOffset scopingOffset, int add) =>
        new(scopingOffset.AbsoluteOffset, scopingOffset.RelativeOffset + add);

    /// <summary>
    /// Implicitly converts the existing scoping offset to an int by yielding the computed offset value.
    /// </summary>
    /// <param name="scopingOffset">
    /// The existing scoping offset.
    /// </param>
    public static implicit operator int(ScopedOffset scopingOffset) => scopingOffset.Value;

    /// <summary>
    /// Gets a friendly string for the scoping offset.
    /// </summary>
    /// <returns>
    /// A friendly string for the scoping offset.
    /// </returns>
    public override readonly string ToString() => $"{Value} (Absolute={AbsoluteOffset}, Relative={RelativeOffset})";
}