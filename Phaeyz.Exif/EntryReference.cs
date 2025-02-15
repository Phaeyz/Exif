namespace Phaeyz.Exif;

/// <summary>
/// A reference to an entry value within an image file directory.
/// </summary>
/// <param name="ImageFileDirectory">
/// The image file directory containing the entry.
/// </param>
/// <param name="Tag">
/// The tag for the entry within the image file directory.
/// </param>
public record EntryReference(ImageFileDirectory ImageFileDirectory, Tag Tag);