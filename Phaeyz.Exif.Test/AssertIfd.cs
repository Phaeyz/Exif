using System.Collections;

namespace Phaeyz.Exif.Test;

internal static class AssertIfd
{
    internal static async Task Equals(ExifMetadata actual, ExifMetadata expected)
    {
        await Assert.That(actual.ByteOrderMode).IsEqualTo(expected.ByteOrderMode);
        await Equals((ImageFileDirectoryCollection)actual, (ImageFileDirectoryCollection)expected);
    }

    internal static async Task Equals(ImageFileDirectoryCollection actual, ImageFileDirectoryCollection expected)
    {
        await Assert.That(actual.Count).IsEqualTo(expected.Count);
        for (int i = 0; i < actual.Count; i++)
        {
            await Equals(actual[i], expected[i]);
        }
    }

    internal static async Task Equals(ImageFileDirectory actual, ImageFileDirectory expected)
    {
        await Assert.That(actual.Count).IsEqualTo(expected.Count);
        for (int i = 0; i < actual.Count; i++)
        {
            KeyValuePair<Tag, Entry> actualEntry = actual.GetAt(i);
            KeyValuePair<Tag, Entry> expectedEntry = expected.GetAt(i);
            await Assert.That(actualEntry.Key.Value).IsEqualTo(expectedEntry.Key.Value);
            await Assert.That(actualEntry.Value.Tag.Value).IsEqualTo(expectedEntry.Value.Tag.Value);
            await Assert.That(actualEntry.Value.Type).IsEqualTo(expectedEntry.Value.Type);
            await Equals(actualEntry.Value.Value, expectedEntry.Value.Value);
        }
    }

    internal static new async Task Equals(object actual, object expected)
    {
        if (actual is ImageFileDirectoryCollection actualIfdc &&
            expected is IEnumerable<ImageFileDirectoryCollection>)
        {
            actual = new ImageFileDirectoryCollection[] { actualIfdc };
        }
        else if (actual is IEnumerable<ImageFileDirectoryCollection> &&
            expected is ImageFileDirectoryCollection expectedIfdc)
        {
            expected = new ImageFileDirectoryCollection[] { expectedIfdc };
        }
        if (actual is ImageFileDirectoryCollection ifdc)
        {
            await Equals(ifdc, (ImageFileDirectoryCollection)expected);
        }
        else if (actual is ImageFileDirectory ifd)
        {
            await Equals(ifd, (ImageFileDirectory)expected);
        }
        else if (actual is IEnumerable actualEnumerable)
        {
            IEnumerable expectedEnumerable = (IEnumerable)expected;
            IEnumerator actualEnumerator = actualEnumerable.GetEnumerator();
            IEnumerator expectedEnumerator = expectedEnumerable.GetEnumerator();
            while (true)
            {
                bool actualMoveNext = actualEnumerator.MoveNext();
                bool expectedMoveNext = expectedEnumerator.MoveNext();
                await Assert.That(actualMoveNext).IsEqualTo(expectedMoveNext);
                if (!actualMoveNext)
                {
                    break;
                }
                await Assert.That(actualEnumerator.Current.GetType()).IsEqualTo(expectedEnumerator.Current.GetType());
                await Equals(actualEnumerator.Current, expectedEnumerator.Current);
            }
        }
        else
        {
            await Assert.That(actual.GetType()).IsEqualTo(expected.GetType());
            await Assert.That(actual).IsEqualTo(expected);
        }
    }
}