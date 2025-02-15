using Phaeyz.Exif.Tags;

namespace Phaeyz.Exif.Test;

internal class ImageFileDirectoryCollectionTest
{
    [Test]
    public async Task Import_ChangeType_TypeChanged()
    {
        ImageFileDirectoryCollection ifdcTarget = [
            new(
                (TagIfd.XResolution, new UnsignedRational(3000000, 10000))
            )
        ];
        ImageFileDirectoryCollection ifdcImportAndExpected = [
            new(
                (TagIfd.XResolution, (uint)10)
            )
        ];
        ifdcTarget.Import(ifdcImportAndExpected);
        await AssertIfd.Equals(ifdcTarget, ifdcImportAndExpected);
    }

    [Test]
    public async Task Import_ComplexGraph_ImportedCorrectly()
    {
        ImageFileDirectoryCollection ifdcTarget = [
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
                ]))
            ),
            new(
                (TagIfd.Compression, (ushort)6),
                (TagIfd.Orientation, (ushort)1)
            )
        ];
        ImageFileDirectoryCollection ifdcImport = [
            new(
                (TagIfd0.ExifOffset, new ImageFileDirectoryCollection([
                    new(
                        (TagExifIfd.InteroperabilityIfd,
                            new ImageFileDirectoryCollection[] { // Test multi-pointer pattern
                                new(),
                                new([
                                    new(
                                        (TagExifIfd.CameraFirmware, "Camera Firmware")
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
            )
        ];
        ImageFileDirectoryCollection ifdcExpected = [
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
                                        (TagExifIfd.DateTimeOriginal, "2024:11:03 19:45:48"),
                                        (TagExifIfd.CameraFirmware, "Camera Firmware")
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
        ifdcTarget.Import(ifdcImport);
        await AssertIfd.Equals(ifdcTarget, ifdcExpected);
    }

    [Test]
    public async Task Import_EmptyTargetImportsComplexGraph_ImportedCorrectly()
    {
        ImageFileDirectoryCollection ifdcTarget = [];
        ImageFileDirectoryCollection ifdcImportAndExpected = [
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
                                        (TagExifIfd.DateTimeOriginal, "2024:11:03 19:45:48"),
                                        (TagExifIfd.CameraFirmware, "Camera Firmware")
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
        ifdcTarget.Import(ifdcImportAndExpected);
        await AssertIfd.Equals(ifdcTarget, ifdcImportAndExpected);
    }

    [Test]
    public async Task Import_SingleIfdLeaveOnlyOneEntryUntouched_OnlyOneEntryUntouched()
    {
        ImageFileDirectoryCollection ifdcTarget = [
            new(
                (TagAny.KodakIfd, new byte[] { 0x01, 0x01, 0x01, 0x01, 0x01 }),
                (TagAny.KdcIfd, new byte[] { 0x02, 0x02, 0x02, 0x02, 0x02 }),
                (TagIfd.ResolutionUnit, (ushort)2),
                (TagIfd.XResolution, new UnsignedRational(3000000, 10000))
            )
        ];
        ImageFileDirectoryCollection ifdcImport = [
            new(
                (TagAny.KodakIfd, new byte[] { 0x11, 0x11, 0x11, 0x11, 0x11 }),
                (TagIfd.ResolutionUnit, (ushort)3),
                (TagIfd.XResolution, new UnsignedRational(400000, 1000))
            )
        ];
        ImageFileDirectoryCollection ifdcExpected = [
            new(
                (TagAny.KodakIfd, new byte[] { 0x11, 0x11, 0x11, 0x11, 0x11 }),
                (TagAny.KdcIfd, new byte[] { 0x02, 0x02, 0x02, 0x02, 0x02 }),
                (TagIfd.ResolutionUnit, (ushort)3),
                (TagIfd.XResolution, new UnsignedRational(400000, 1000))
            )
        ];
        ifdcTarget.Import(ifdcImport);
        await AssertIfd.Equals(ifdcTarget, ifdcExpected);
    }
}
