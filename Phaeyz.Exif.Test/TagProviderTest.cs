using Phaeyz.Exif.Tags;

namespace Phaeyz.Exif.Test;

internal class TagProviderTest
{
    [Test]
    public async Task Match_NoFallbackParent_ReturnsNull()
    {
        var tagProvider = new TagProvider(TagMatches.TagProvider);
        tagProvider.Remove(TagMatches.NoParentNoIndexTag);
        tagProvider.Remove(TagMatches.NoParentWithIndex1Tag);
        Tag? matchedTag = tagProvider.Match(TagMatches.TagValue, TagIfd0.ExifOffset, 1);
        await Assert.That(matchedTag).IsNull();
    }

    [Test]
    public async Task Match_NoMatchingParentWhenIndexMatches_ReturnsCorrectMatch()
    {
        Tag? matchedTag = TagMatches.TagProvider.Match(TagMatches.TagValue, TagIfd0.ExifOffset, 1);
        await Assert.That(matchedTag).IsEqualTo(TagMatches.NoParentWithIndex1Tag);
    }

    [Test]
    public async Task Match_NoMatchingParentWhenNoIndexMatches_ReturnsCorrectMatch()
    {
        Tag? matchedTag = TagMatches.TagProvider.Match(TagMatches.TagValue, TagIfd0.ExifOffset, 2);
        await Assert.That(matchedTag).IsEqualTo(TagMatches.NoParentNoIndexTag);
    }

    [Test]
    public async Task Match_NoValueMatch_ReturnsNull()
    {
        Tag? matchedTag = TagProvider.Default.Match(TagMatches.TagValue, Tag.Root, 0);
        await Assert.That(matchedTag).IsNull();
    }

    [Test]
    public async Task Match_WithParentWhenIndexMatches_ReturnsCorrectMatch()
    {
        Tag? matchedTag = TagMatches.TagProvider.Match(TagMatches.TagValue, Tag.Root, 1);
        await Assert.That(matchedTag).IsEqualTo(TagMatches.RootParentWithIndex1Tag);
    }

    [Test]
    public async Task Match_WithParentWhenNoIndexMatches_ReturnsCorrectMatch()
    {
        Tag? matchedTag = TagMatches.TagProvider.Match(TagMatches.TagValue, Tag.Root, 2);
        await Assert.That(matchedTag).IsEqualTo(TagMatches.RootParentNoIndexTag);
    }
}

file static class TagMatches
{
    public static readonly ushort TagValue = 0x1234;
    public static readonly TagProvider TagProvider;
    public static readonly Tag NoParentNoIndexTag = Tag.Create(null, null, TagValue, "NoParentNoIndexTag");
    public static readonly Tag NoParentWithIndex1Tag = Tag.Create(null, 1, TagValue, "NoParentWithIndex1Tag");
    public static readonly Tag RootParentNoIndexTag = Tag.Create(Tag.Root, null, TagValue, "RootParentNoIndexTag");
    public static readonly Tag RootParentWithIndex1Tag = Tag.Create(Tag.Root, 1, TagValue, "RootParentWithIndex1Tag");

    static TagMatches()
    {
        TagProvider = new(TagProvider.Default);
        TagProvider.AddRange([
            NoParentNoIndexTag,
            NoParentWithIndex1Tag,
            RootParentNoIndexTag,
            RootParentWithIndex1Tag
        ]);
    }
}
