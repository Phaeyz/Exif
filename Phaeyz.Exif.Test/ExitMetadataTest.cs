using Phaeyz.Exif.Tags;

namespace Phaeyz.Exif.Test;

internal class ExifMetadataTest
{
    [Test]
    public async Task Deserialize_CannotRoundTrip_EntryReferencesCreated()
    {
        TagProvider tagProvider = new(TagProvider.Default);
        Tag tagCannotRoundTrip1 = Tag.Create(null, null, 0x1234, "CannotRoundTrip1", false);
        Tag tagCannotRoundTrip2 = Tag.Create(null, null, 0x1235, "CannotRoundTrip2", false);
        tagProvider.Add(tagCannotRoundTrip1);
        tagProvider.Add(tagCannotRoundTrip2);
        byte[] bytes =
        [
            0x4D, 0x4D,             // Byte order
            0x00, 0x2A,             // Magic number
            0x00, 0x00, 0x00, 0x08, // IFD0 offset
            0x00, 0x02,             // Entry count
            0x12, 0x34,             // Tag (CannotRoundTrip1)
            0x00, 0x04,             // Type (UInt32)
            0x00, 0x00, 0x00, 0x01, // Count
            0x00, 0x00, 0x00, 0x11, // Value
            0x12, 0x35,             // Tag (CannotRoundTrip2)
            0x00, 0x04,             // Type (UInt32)
            0x00, 0x00, 0x00, 0x01, // Count
            0x00, 0x00, 0x00, 0x22, // Value
            0x00, 0x00, 0x00, 0x00, // No more IFDs
        ];
        ExifMetadata exif = ExifMetadata.Deserialize(bytes, tagProvider, out List<EntryReference> cannotRoundTripReferences);
        ExifMetadata expectedExif = [
            new(
                (tagCannotRoundTrip1, (uint)0x11),
                (tagCannotRoundTrip2, (uint)0x22)
            )
        ];
        List<EntryReference> expectedEntryReferences = [
            new(exif.First(), tagCannotRoundTrip1),
            new(exif.First(), tagCannotRoundTrip2)
        ];
        await AssertIfd.Equals(exif, expectedExif);
        await Assert.That(cannotRoundTripReferences).IsEquivalentTo(expectedEntryReferences);
    }

    [Test]
    public async Task Deserialize_LittleEndian_DeserializesCorrectly()
    {
        byte[] bytes =
        [
            0x49, 0x49,             // Byte order
            0x2A, 0x00,             // Magic number
            0x08, 0x00, 0x00, 0x00, // IFD0 offset
            0x02, 0x00,             // Entry count
            0x28, 0x01,             // Tag (ResolutionUnit)
            0x03, 0x00,             // Type (UInt16)
            0x01, 0x00, 0x00, 0x00, // Count
            0x02, 0x00, 0x00, 0x00, // Value (0x0002)
            0x1A, 0x01,             // Tag (XResolution)
            0x05, 0x00,             // Type (UnsignedRational)
            0x01, 0x00, 0x00, 0x00, // Count
            0x26, 0x00, 0x00, 0x00, // Value (Offset)
            0x00, 0x00, 0x00, 0x00, // No more IFDs
            0xC0, 0xC6, 0x2D, 0x00, // XResolution Numerator
            0x10, 0x27, 0x00, 0x00, // XResolution Denominator
        ];
        ExifMetadata exif = ExifMetadata.Deserialize(bytes);
        ExifMetadata expectedExif = [
            new(
                (TagIfd.ResolutionUnit, (ushort)2),
                (TagIfd.XResolution, new UnsignedRational(3000000, 10000))
            )
        ];
        expectedExif.ByteOrderMode = ByteOrderMode.LittleEndian;
        await AssertIfd.Equals(exif, expectedExif);
    }

    [Test]
    public async Task Deserialize_MultipleIfdsIncludingMultiplePointerPattern_DeserializesCorrectly()
    {
        byte[] bytes =
        [
            0x4D, 0x4D,             // Byte order
            0x00, 0x2A,             // Magic number
            0x00, 0x00, 0x00, 0x08, // IFD0 offset

            0x00, 0x05,             // IFD0 entry count
            0x01, 0x1A,             // Tag (XResolution)
            0x00, 0x05,             // Type (UnsignedRational)
            0x00, 0x00, 0x00, 0x01, // Count
            0x00, 0x00, 0x00, 0x4A, // Value (Offset)
            0x01, 0x1B,             // Tag (YResolution)
            0x00, 0x05,             // Type (UnsignedRational)
            0x00, 0x00, 0x00, 0x01, // Count
            0x00, 0x00, 0x00, 0x52, // Value (Offset)
            0x01, 0x28,             // Tag (ResolutionUnit)
            0x00, 0x03,             // Type (UInt16)
            0x00, 0x00, 0x00, 0x01, // Count
            0x00, 0x02, 0x00, 0x00, // Value (0x0002)
            0x87, 0x69,             // Tag (ExifOffset)
            0x00, 0x04,             // Type (UInt32)
            0x00, 0x00, 0x00, 0x01, // Count
            0x00, 0x00, 0x00, 0x5A, // Value (Offset)
            0x88, 0x25,             // Tag (GpsInfo)
            0x00, 0x04,             // Type (UInt32)
            0x00, 0x00, 0x00, 0x01, // Count
            0x00, 0x00, 0x00, 0xA0, // Value (Offset)
            0x00, 0x00, 0x00, 0xC9, // Next IFD Offset
            0x00, 0x2D, 0xC6, 0xC0, // XResolution Numerator
            0x00, 0x00, 0x27, 0x10, // XResolution Denominator
            0x00, 0x2D, 0xC6, 0xC0, // YResolution Numerator
            0x00, 0x00, 0x27, 0x10, // YResolution Denominator

            0x00, 0x03,             // Exif IFD entry count
            0x90, 0x00,             // Tag (ExifVersion)
            0x00, 0x07,             // Type (ByteSequence)
            0x00, 0x00, 0x00, 0x04, // Count
            0x30, 0x32, 0x33, 0x32, // Value
            0x90, 0x03,             // Tag (DateTimeOriginal)
            0x00, 0x02,             // Type (Ascii)
            0x00, 0x00, 0x00, 0x14, // Count
            0x00, 0x00, 0x00, 0x84, // Value (Offset)
            0xA0, 0x05,             // Tag (InteroperabilityIfd)
            0x00, 0x04,             // Type (UInt32)
            0x00, 0x00, 0x00, 0x02, // Count
            0x00, 0x00, 0x00, 0x98, // Value (Offset to Offsets)
            0x00, 0x00, 0x00, 0x00, // No more IFDs
            0x32, 0x30, 0x32, 0x34, 0x3A, 0x31, 0x31, 0x3A, 0x30, 0x33, // ASCII part 1 of "2024:11:03 19:45:47"
            0x20, 0x31, 0x39, 0x3A, 0x34, 0x35, 0x3A, 0x34, 0x37, 0x00, // ASCII part 2 of "2024:11:03 19:45:47"
            0x00, 0x00, 0x00, 0xE7, // InteroperabilityIfd Offset 0
            0x00, 0x00, 0x01, 0x0D, // InteroperabilityIfd Offset 1

            0x00, 0x02,             // GpsInfo IFD entry count
            0x00, 0x00,             // Tag (GpsVersionId)
            0x00, 0x07,             // Type (ByteSequence)
            0x00, 0x00, 0x00, 0x04, // Count
            0x02, 0x02, 0x00, 0x00, // Value
            0x00, 0x1D,             // Tag (GpsDateStamp)
            0x00, 0x02,             // Type (Ascii)
            0x00, 0x00, 0x00, 0x0B, // Count
            0x00, 0x00, 0x00, 0xBE, // Value (Offset)
            0x00, 0x00, 0x00, 0x00, // No more IFDs
            0x32, 0x30, 0x32, 0x34, 0x3A, 0x31, 0x31, 0x3A, 0x30, 0x34, 0x00, // "2024:11:04"

            0x00, 0x02,             // IFD1 entry count
            0x01, 0x03,             // Tag (Compression)
            0x00, 0x03,             // Type (UInt16)
            0x00, 0x00, 0x00, 0x01, // Count
            0x00, 0x06, 0x00, 0x00, // Value (0x0006)
            0x01, 0x12,             // Tag (Orientation)
            0x00, 0x03,             // Type (UInt16)
            0x00, 0x00, 0x00, 0x01, // Count
            0x00, 0x01, 0x00, 0x00, // Value (0x0001)
            0x00, 0x00, 0x00, 0x00, // No more IFDs

            0x00, 0x01,             // InteroperabilityIfd[0] entry count
            0x90, 0x03,             // Tag (DateTimeOriginal)
            0x00, 0x02,             // Type (Ascii)
            0x00, 0x00, 0x00, 0x14, // Count
            0x00, 0x00, 0x00, 0xF9, // Value (Offset)
            0x00, 0x00, 0x00, 0x00, // No more IFDs
            0x32, 0x30, 0x32, 0x34, 0x3A, 0x31, 0x31, 0x3A, 0x30, 0x33, // ASCII part 1 of "2024:11:03 19:45:47"
            0x20, 0x31, 0x39, 0x3A, 0x34, 0x35, 0x3A, 0x34, 0x37, 0x00, // ASCII part 2 of "2024:11:03 19:45:47"

            0x00, 0x01,             // InteroperabilityIfd[1] entry count
            0x90, 0x03,             // Tag (DateTimeOriginal)
            0x00, 0x02,             // Type (Ascii)
            0x00, 0x00, 0x00, 0x14, // Count
            0x00, 0x00, 0x01, 0x1F, // Value (Offset)
            0x00, 0x00, 0x00, 0x00, // No more IFDs
            0x32, 0x30, 0x32, 0x34, 0x3A, 0x31, 0x31, 0x3A, 0x30, 0x33, // ASCII part 1 of "2024:11:03 19:45:48"
            0x20, 0x31, 0x39, 0x3A, 0x34, 0x35, 0x3A, 0x34, 0x38, 0x00  // ASCII part 2 of "2024:11:03 19:45:48"
        ];
        ExifMetadata exif = ExifMetadata.Deserialize(bytes);
        ExifMetadata expectedExif = [
            new(
                (TagIfd.XResolution, new UnsignedRational(3000000, 10000)),
                (TagIfd.YResolution, new UnsignedRational(3000000, 10000)),
                (TagIfd.ResolutionUnit, (ushort)2),
                (TagIfd0.ExifOffset, new ImageFileDirectoryCollection([
                    new(
                        (TagExifIfd.ExifVersion, new byte[] { 0x30, 0x32, 0x33, 0x32 }),
                        (TagExifIfd.DateTimeOriginal, "2024:11:03 19:45:47"),
                        (TagExifIfd.InteroperabilityIfd,
                            new ImageFileDirectoryCollection[] { // Test multi-pointer pattern
                                new([
                                    new(
                                        (TagExifIfd.DateTimeOriginal, "2024:11:03 19:45:47")
                                    )
                                ]),
                                new([
                                    new(
                                        (TagExifIfd.DateTimeOriginal, "2024:11:03 19:45:48")
                                    )
                                ])
                            }
                         )
                    )
                ])),
                new(TagIfd0.GpsInfo, new ImageFileDirectoryCollection([
                    new(
                        (TagGpsInfo.GpsVersionId, new byte[] { 0x02, 0x02, 0x00, 0x00 }),
                        (TagGpsInfo.GpsDateStamp, "2024:11:04")
                    )
                ]))
            ),
            new(
                (TagIfd.Compression, (ushort)6),
                (TagIfd.Orientation, (ushort)1)
            )
        ];
        await AssertIfd.Equals(exif, expectedExif);
    }

    [Test]
    public async Task Deserialize_OffsetAndLength_DeserializesCorrectly()
    {
        byte[] bytes =
        [
            0x4D, 0x4D,             // Byte order
            0x00, 0x2A,             // Magic number
            0x00, 0x00, 0x00, 0x08, // IFD0 offset
            0x00, 0x02,             // Entry count
            0xA0, 0x10,             // Tag (SamsungRawPointersOffset)
            0x00, 0x04,             // Type (UInt32)
            0x00, 0x00, 0x00, 0x01, // Count
            0x00, 0x00, 0x00, 0x26, // Value (Offset)
            0xA0, 0x11,             // Tag (SamsungRawPointerLength)
            0x00, 0x04,             // Type (UInt32)
            0x00, 0x00, 0x00, 0x01, // Count
            0x00, 0x00, 0x00, 0x05, // Value (Length)
            0x00, 0x00, 0x00, 0x00, // No more IFDs
            0x01, 0x02, 0x03, 0x04, 0x05, // SamsungRawPointersOffset value
        ];
        ExifMetadata exif = ExifMetadata.Deserialize(bytes);
        ExifMetadata expectedExif = [
            new(
                (TagAny.SamsungRawPointersOffset, new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05 })
            )
        ];
        await AssertIfd.Equals(exif, expectedExif);
    }

    [Test]
    public async Task Deserialize_PreserveDataBlock_DeserializesCorrectly()
    {
        byte[] bytes =
        [
            0x4D, 0x4D,             // Byte order
            0x00, 0x2A,             // Magic number
            0x00, 0x00, 0x00, 0x08, // IFD0 offset
            0x00, 0x04,             // Entry count
            0x82, 0x90,             // Tag (KodakIfd)
            0x00, 0x04,             // Type (UInt32)
            0x00, 0x00, 0x00, 0x01, // Count
            0x00, 0x00, 0x00, 0x3E, // Value (Offset)
            0xFE, 0x00,             // Tag (KdcIfd)
            0x00, 0x04,             // Type (UInt32)
            0x00, 0x00, 0x00, 0x01, // Count
            0x00, 0x00, 0x00, 0x43, // Value (Offset)
            0x01, 0x28,             // Tag (ResolutionUnit)
            0x00, 0x03,             // Type (UInt16)
            0x00, 0x00, 0x00, 0x01, // Count
            0x00, 0x02, 0x00, 0x00, // Value (0x0002)
            0x01, 0x1A,             // Tag (XResolution)
            0x00, 0x05,             // Type (UnsignedRational)
            0x00, 0x00, 0x00, 0x01, // Count
            0x00, 0x00, 0x00, 0x48, // Value (Offset)
            0x00, 0x00, 0x00, 0x00, // No more IFDs
            0x01, 0x01, 0x01, 0x01, 0x01, // KodakIfd preserved bytes
            0x02, 0x02, 0x02, 0x02, 0x02, // KdcIfd preserved bytes
            0x00, 0x2D, 0xC6, 0xC0, // XResolution Numerator
            0x00, 0x00, 0x27, 0x10, // XResolution Denominator
        ];
        ExifMetadata exif = ExifMetadata.Deserialize(bytes);
        ExifMetadata expectedExif = [
            new(
                (TagAny.KodakIfd, new byte[] { 0x01, 0x01, 0x01, 0x01, 0x01 }),
                (TagAny.KdcIfd, new byte[] { 0x02, 0x02, 0x02, 0x02, 0x02 }),
                (TagIfd.ResolutionUnit, (ushort)2),
                (TagIfd.XResolution, new UnsignedRational(3000000, 10000))
            )
        ];
        await AssertIfd.Equals(exif, expectedExif);
    }

    [Test]
    public async Task Deserialize_SingleIfd_DeserializesCorrectly()
    {
        byte[] bytes =
        [
            0x4D, 0x4D,             // Byte order
            0x00, 0x2A,             // Magic number
            0x00, 0x00, 0x00, 0x08, // IFD0 offset
            0x00, 0x03,             // Entry count
            0x01, 0x1A,             // Tag (XResolution)
            0x00, 0x05,             // Type (UnsignedRational)
            0x00, 0x00, 0x00, 0x01, // Count
            0x00, 0x00, 0x00, 0x32, // Value (Offset)
            0x01, 0x1B,             // Tag (YResolution)
            0x00, 0x05,             // Type (UnsignedRational)
            0x00, 0x00, 0x00, 0x01, // Count
            0x00, 0x00, 0x00, 0x3A, // Value (Offset)
            0x01, 0x28,             // Tag (ResolutionUnit)
            0x00, 0x03,             // Type (UInt16)
            0x00, 0x00, 0x00, 0x01, // Count
            0x00, 0x02, 0x00, 0x00, // Value
            0x00, 0x00, 0x00, 0x00, // No more IFDs
            0x00, 0x2D, 0xC6, 0xC0, // XResolution Numerator
            0x00, 0x00, 0x27, 0x10, // XResolution Denominator
            0x00, 0x2D, 0xC6, 0xC0, // YResolution Numerator
            0x00, 0x00, 0x27, 0x10  // YResolution Denominator
        ];
        ExifMetadata exif = ExifMetadata.Deserialize(bytes);
        ExifMetadata expectedExif = [
            new(
                (TagIfd.XResolution, new UnsignedRational(3000000, 10000)),
                (TagIfd.YResolution, new UnsignedRational(3000000, 10000)),
                (TagIfd.ResolutionUnit, (ushort)2)
            )
        ];
        await AssertIfd.Equals(exif, expectedExif);
    }

    [Test]
    public async Task Serialize_LittleEndian_SerializesCorrectly()
    {
        ExifMetadata exif = [
            new(
                (TagIfd.ResolutionUnit, (ushort)2),
                (TagIfd.XResolution, new UnsignedRational(3000000, 10000))
            )
        ];
        exif.ByteOrderMode = ByteOrderMode.LittleEndian;
        using MemoryStream memoryStream = exif.Serialize();
        byte[] bytes = memoryStream.ToArray();
        byte[] expectedBytes =
        [
            0x49, 0x49,             // Byte order
            0x2A, 0x00,             // Magic number
            0x08, 0x00, 0x00, 0x00, // IFD0 offset
            0x02, 0x00,             // Entry count
            0x28, 0x01,             // Tag (ResolutionUnit)
            0x03, 0x00,             // Type (UInt16)
            0x01, 0x00, 0x00, 0x00, // Count
            0x02, 0x00, 0x00, 0x00, // Value (0x0002)
            0x1A, 0x01,             // Tag (XResolution)
            0x05, 0x00,             // Type (UnsignedRational)
            0x01, 0x00, 0x00, 0x00, // Count
            0x26, 0x00, 0x00, 0x00, // Value (Offset)
            0x00, 0x00, 0x00, 0x00, // No more IFDs
            0xC0, 0xC6, 0x2D, 0x00, // XResolution Numerator
            0x10, 0x27, 0x00, 0x00, // XResolution Denominator
        ];
        await Assert.That(bytes).IsEquivalentTo(expectedBytes);
    }

    [Test]
    public async Task Serialize_MultipleIfdsIncludingMultiplePointerPattern_SerializesCorrectly()
    {
        ExifMetadata exif = [
            new(
                (TagIfd.XResolution, new UnsignedRational(3000000, 10000)),
                (TagIfd.YResolution, new UnsignedRational(3000000, 10000)),
                (TagIfd.ResolutionUnit, (ushort)2),
                (TagIfd0.ExifOffset, new ImageFileDirectoryCollection([
                    new(
                        (TagExifIfd.ExifVersion, new byte[] { 0x30, 0x32, 0x33, 0x32 }),
                        (TagExifIfd.DateTimeOriginal, "2024:11:03 19:45:47"),
                        (TagExifIfd.InteroperabilityIfd,
                            new ImageFileDirectoryCollection[] { // Test multi-pointer pattern
                                new([
                                    new(
                                        (TagExifIfd.DateTimeOriginal, "2024:11:03 19:45:47")
                                    )
                                ]),
                                new([
                                    new(
                                        (TagExifIfd.DateTimeOriginal, "2024:11:03 19:45:48")
                                    )
                                ])
                            }
                         )
                    )
                ])),
                new(TagIfd0.GpsInfo, new ImageFileDirectoryCollection([
                    new(
                        (TagGpsInfo.GpsVersionId, new byte[] { 0x02, 0x02, 0x00, 0x00 }),
                        (TagGpsInfo.GpsDateStamp, "2024:11:04")
                    )
                ]))
            ),
            new(
                (TagIfd.Compression, (ushort)6),
                (TagIfd.Orientation, (ushort)1)
            )
        ];

        using MemoryStream memoryStream = exif.Serialize();
        byte[] bytes = memoryStream.ToArray();
        byte[] expectedBytes =
        [
            0x4D, 0x4D,             // Byte order
            0x00, 0x2A,             // Magic number
            0x00, 0x00, 0x00, 0x08, // IFD0 offset

            0x00, 0x05,             // IFD0 entry count
            0x01, 0x1A,             // Tag (XResolution)
            0x00, 0x05,             // Type (UnsignedRational)
            0x00, 0x00, 0x00, 0x01, // Count
            0x00, 0x00, 0x00, 0x4A, // Value (Offset)
            0x01, 0x1B,             // Tag (YResolution)
            0x00, 0x05,             // Type (UnsignedRational)
            0x00, 0x00, 0x00, 0x01, // Count
            0x00, 0x00, 0x00, 0x52, // Value (Offset)
            0x01, 0x28,             // Tag (ResolutionUnit)
            0x00, 0x03,             // Type (UInt16)
            0x00, 0x00, 0x00, 0x01, // Count
            0x00, 0x02, 0x00, 0x00, // Value (0x0002)
            0x87, 0x69,             // Tag (ExifOffset)
            0x00, 0x04,             // Type (UInt32)
            0x00, 0x00, 0x00, 0x01, // Count
            0x00, 0x00, 0x00, 0x5A, // Value (Offset)
            0x88, 0x25,             // Tag (GpsInfo)
            0x00, 0x04,             // Type (UInt32)
            0x00, 0x00, 0x00, 0x01, // Count
            0x00, 0x00, 0x00, 0xA0, // Value (Offset)
            0x00, 0x00, 0x00, 0xC9, // Next IFD Offset
            0x00, 0x2D, 0xC6, 0xC0, // XResolution Numerator
            0x00, 0x00, 0x27, 0x10, // XResolution Denominator
            0x00, 0x2D, 0xC6, 0xC0, // YResolution Numerator
            0x00, 0x00, 0x27, 0x10, // YResolution Denominator

            0x00, 0x03,             // Exif IFD entry count
            0x90, 0x00,             // Tag (ExifVersion)
            0x00, 0x07,             // Type (ByteSequence)
            0x00, 0x00, 0x00, 0x04, // Count
            0x30, 0x32, 0x33, 0x32, // Value
            0x90, 0x03,             // Tag (DateTimeOriginal)
            0x00, 0x02,             // Type (Ascii)
            0x00, 0x00, 0x00, 0x14, // Count
            0x00, 0x00, 0x00, 0x84, // Value (Offset)
            0xA0, 0x05,             // Tag (InteroperabilityIfd)
            0x00, 0x04,             // Type (UInt32)
            0x00, 0x00, 0x00, 0x02, // Count
            0x00, 0x00, 0x00, 0x98, // Value (Offset to Offsets)
            0x00, 0x00, 0x00, 0x00, // No more IFDs
            0x32, 0x30, 0x32, 0x34, 0x3A, 0x31, 0x31, 0x3A, 0x30, 0x33, // ASCII part 1 of "2024:11:03 19:45:47"
            0x20, 0x31, 0x39, 0x3A, 0x34, 0x35, 0x3A, 0x34, 0x37, 0x00, // ASCII part 2 of "2024:11:03 19:45:47"
            0x00, 0x00, 0x00, 0xE7, // InteroperabilityIfd Offset 0
            0x00, 0x00, 0x01, 0x0D, // InteroperabilityIfd Offset 1

            0x00, 0x02,             // GpsInfo IFD entry count
            0x00, 0x00,             // Tag (GpsVersionId)
            0x00, 0x07,             // Type (ByteSequence)
            0x00, 0x00, 0x00, 0x04, // Count
            0x02, 0x02, 0x00, 0x00, // Value
            0x00, 0x1D,             // Tag (GpsDateStamp)
            0x00, 0x02,             // Type (Ascii)
            0x00, 0x00, 0x00, 0x0B, // Count
            0x00, 0x00, 0x00, 0xBE, // Value (Offset)
            0x00, 0x00, 0x00, 0x00, // No more IFDs
            0x32, 0x30, 0x32, 0x34, 0x3A, 0x31, 0x31, 0x3A, 0x30, 0x34, 0x00, // "2024:11:04"

            0x00, 0x02,             // IFD1 entry count
            0x01, 0x03,             // Tag (Compression)
            0x00, 0x03,             // Type (UInt16)
            0x00, 0x00, 0x00, 0x01, // Count
            0x00, 0x06, 0x00, 0x00, // Value (0x0006)
            0x01, 0x12,             // Tag (Orientation)
            0x00, 0x03,             // Type (UInt16)
            0x00, 0x00, 0x00, 0x01, // Count
            0x00, 0x01, 0x00, 0x00, // Value (0x0001)
            0x00, 0x00, 0x00, 0x00, // No more IFDs

            0x00, 0x01,             // InteroperabilityIfd[0] entry count
            0x90, 0x03,             // Tag (DateTimeOriginal)
            0x00, 0x02,             // Type (Ascii)
            0x00, 0x00, 0x00, 0x14, // Count
            0x00, 0x00, 0x00, 0xF9, // Value (Offset)
            0x00, 0x00, 0x00, 0x00, // No more IFDs
            0x32, 0x30, 0x32, 0x34, 0x3A, 0x31, 0x31, 0x3A, 0x30, 0x33, // ASCII part 1 of "2024:11:03 19:45:47"
            0x20, 0x31, 0x39, 0x3A, 0x34, 0x35, 0x3A, 0x34, 0x37, 0x00, // ASCII part 2 of "2024:11:03 19:45:47"

            0x00, 0x01,             // InteroperabilityIfd[1] entry count
            0x90, 0x03,             // Tag (DateTimeOriginal)
            0x00, 0x02,             // Type (Ascii)
            0x00, 0x00, 0x00, 0x14, // Count
            0x00, 0x00, 0x01, 0x1F, // Value (Offset)
            0x00, 0x00, 0x00, 0x00, // No more IFDs
            0x32, 0x30, 0x32, 0x34, 0x3A, 0x31, 0x31, 0x3A, 0x30, 0x33, // ASCII part 1 of "2024:11:03 19:45:48"
            0x20, 0x31, 0x39, 0x3A, 0x34, 0x35, 0x3A, 0x34, 0x38, 0x00  // ASCII part 2 of "2024:11:03 19:45:48"
        ];
        await Assert.That(bytes).IsEquivalentTo(expectedBytes);
    }

    [Test]
    public async Task Serialize_OffsetAndLength_SerializesCorrectly()
    {
        ExifMetadata exif = [
            new(
                (TagAny.SamsungRawPointersOffset, new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05 })
            )
        ];
        using MemoryStream memoryStream = exif.Serialize();
        byte[] bytes = memoryStream.ToArray();
        byte[] expectedBytes =
        [
            0x4D, 0x4D,             // Byte order
            0x00, 0x2A,             // Magic number
            0x00, 0x00, 0x00, 0x08, // IFD0 offset
            0x00, 0x02,             // Entry count
            0xA0, 0x10,             // Tag (SamsungRawPointersOffset)
            0x00, 0x04,             // Type (UInt32)
            0x00, 0x00, 0x00, 0x01, // Count
            0x00, 0x00, 0x00, 0x26, // Value (Offset)
            0xA0, 0x11,             // Tag (SamsungRawPointerLength)
            0x00, 0x04,             // Type (UInt32)
            0x00, 0x00, 0x00, 0x01, // Count
            0x00, 0x00, 0x00, 0x05, // Value (Length)
            0x00, 0x00, 0x00, 0x00, // No more IFDs
            0x01, 0x02, 0x03, 0x04, 0x05, // SamsungRawPointersOffset value
        ];
        await Assert.That(bytes).IsEquivalentTo(expectedBytes);
    }

    [Test]
    public async Task Serialize_PreserveDataBlock_SerializesCorrectly()
    {
        ExifMetadata exif = [
            new(
                (TagAny.KodakIfd, new byte[] { 0x01, 0x01, 0x01, 0x01, 0x01 }),
                (TagAny.KdcIfd, new byte[] { 0x02, 0x02, 0x02, 0x02, 0x02 }),
                (TagIfd.ResolutionUnit, (ushort)2),
                (TagIfd.XResolution, new UnsignedRational(3000000, 10000))
            )
        ];
        using MemoryStream memoryStream = exif.Serialize();
        byte[] bytes = memoryStream.ToArray();
        byte[] expectedBytes =
        [
            0x4D, 0x4D,             // Byte order
            0x00, 0x2A,             // Magic number
            0x00, 0x00, 0x00, 0x08, // IFD0 offset
            0x00, 0x04,             // Entry count
            0x82, 0x90,             // Tag (KodakIfd)
            0x00, 0x04,             // Type (UInt32)
            0x00, 0x00, 0x00, 0x01, // Count
            0x00, 0x00, 0x00, 0x3E, // Value (Offset)
            0xFE, 0x00,             // Tag (KdcIfd)
            0x00, 0x04,             // Type (UInt32)
            0x00, 0x00, 0x00, 0x01, // Count
            0x00, 0x00, 0x00, 0x43, // Value (Offset)
            0x01, 0x28,             // Tag (ResolutionUnit)
            0x00, 0x03,             // Type (UInt16)
            0x00, 0x00, 0x00, 0x01, // Count
            0x00, 0x02, 0x00, 0x00, // Value (0x0002)
            0x01, 0x1A,             // Tag (XResolution)
            0x00, 0x05,             // Type (UnsignedRational)
            0x00, 0x00, 0x00, 0x01, // Count
            0x00, 0x00, 0x00, 0x48, // Value (Offset)
            0x00, 0x00, 0x00, 0x00, // No more IFDs
            0x01, 0x01, 0x01, 0x01, 0x01, // KodakIfd preserved bytes
            0x02, 0x02, 0x02, 0x02, 0x02, // KdcIfd preserved bytes
            0x00, 0x2D, 0xC6, 0xC0, // XResolution Numerator
            0x00, 0x00, 0x27, 0x10, // XResolution Denominator
        ];
        await Assert.That(bytes).IsEquivalentTo(expectedBytes);
    }

    [Test]
    public async Task Serialize_SingleIfd_SerializesCorrectly()
    {
        ExifMetadata exif = [];
        ImageFileDirectory ifd = [];
        ifd.AddOrUpdate(TagIfd.XResolution, new UnsignedRational(3000000, 10000));
        ifd.AddOrUpdate(TagIfd.YResolution, new UnsignedRational(3000000, 10000));
        ifd.AddOrUpdate(TagIfd.ResolutionUnit, (ushort)2);
        exif.Add(ifd);
        using MemoryStream memoryStream = exif.Serialize();
        byte[] bytes = memoryStream.ToArray();
        byte[] expectedBytes =
        [
            0x4D, 0x4D,             // Byte order
            0x00, 0x2A,             // Magic number
            0x00, 0x00, 0x00, 0x08, // IFD0 offset
            0x00, 0x03,             // Entry count
            0x01, 0x1A,             // Tag (XResolution)
            0x00, 0x05,             // Type (UnsignedRational)
            0x00, 0x00, 0x00, 0x01, // Count
            0x00, 0x00, 0x00, 0x32, // Value (Offset)
            0x01, 0x1B,             // Tag (YResolution)
            0x00, 0x05,             // Type (UnsignedRational)
            0x00, 0x00, 0x00, 0x01, // Count
            0x00, 0x00, 0x00, 0x3A, // Value (Offset)
            0x01, 0x28,             // Tag (ResolutionUnit)
            0x00, 0x03,             // Type (UInt16)
            0x00, 0x00, 0x00, 0x01, // Count
            0x00, 0x02, 0x00, 0x00, // Value
            0x00, 0x00, 0x00, 0x00, // No more IFDs
            0x00, 0x2D, 0xC6, 0xC0, // XResolution Numerator
            0x00, 0x00, 0x27, 0x10, // XResolution Denominator
            0x00, 0x2D, 0xC6, 0xC0, // YResolution Numerator
            0x00, 0x00, 0x27, 0x10  // YResolution Denominator
        ];
        await Assert.That(bytes).IsEquivalentTo(expectedBytes);
    }
}