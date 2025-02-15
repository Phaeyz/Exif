namespace Phaeyz.Exif.Tags;

/// <summary>
/// Tags which may appear in any non-specific image file directory.
/// </summary>
public class TagAny : Tag
{
    /// <summary>
    /// Indicates the identification of the Interoperability rule. Use "R98" for stating ExifR98 Rules. Four bytes used including the termination code (NULL). see the separate volume of Recommended Exif Interoperability Rules (ExifR98) for other tags used for ExifR98.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag StripOffsets = Create(null, null, 0x0111, "StripOffsets", true, [("Exif.Image.StripOffsets", "Image")]);

    /// <summary>
    /// Indicates the identification of the Interoperability rule. Use "R98" for stating ExifR98 Rules. Four bytes used including the termination code (NULL). see the separate volume of Recommended Exif Interoperability Rules (ExifR98) for other tags used for ExifR98.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag StripByteCounts = Create(null, null, 0x0117, "StripByteCounts", true, [("Exif.Image.StripByteCounts", "Image")]);

    /// <summary>
    /// FreeOffsets (0x0120)
    /// </summary>
    public static readonly Tag FreeOffsets = Create(null, null, 0x0120, "FreeOffsets");

    /// <summary>
    /// FreeByteCounts (0x0121)
    /// </summary>
    public static readonly Tag FreeByteCounts = Create(null, null, 0x0121, "FreeByteCounts");

    /// <summary>
    /// For grayscale data, the optical density of each possible pixel value.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag GrayResponseCurve = Create(null, null, 0x0123, "GrayResponseCurve", true, [("Exif.Image.GrayResponseCurve", "Image")]);

    /// <summary>
    /// T.4-encoding options.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag T4Options = Create(null, null, 0x0124, "T4Options", true, [("Exif.Image.T4Options", "Image")]);

    /// <summary>
    /// T.6-encoding options.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag T6Options = Create(null, null, 0x0125, "T6Options", true, [("Exif.Image.T6Options", "Image")]);

    /// <summary>
    /// ColorResponseUnit (0x012C)
    /// </summary>
    public static readonly Tag ColorResponseUnit = Create(null, null, 0x012C, "ColorResponseUnit");

    /// <summary>
    /// A color map for palette color images. This field defines a Red-Green-Blue color map (often called a lookup table) for palette-color images. In a palette-color image, a pixel value is used to index into an RGB lookup table.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag ColorMap = Create(null, null, 0x0140, "ColorMap", true, [("Exif.Image.ColorMap", "Image")]);

    /// <summary>
    /// For each tile, the byte offset of that tile, as compressed and stored on disk. The offset is specified with respect to the beginning of the TIFF file. Note that this implies that each tile has a location independent of the locations of other tiles.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag TileOffsets = Create(null, null, 0x0144, "TileOffsets", true, [("Exif.Image.TileOffsets", "Image")]);

    /// <summary>
    /// For each tile, the number of (compressed) bytes in that tile. See TileOffsets for a description of how the byte counts are ordered.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag TileByteCounts = Create(null, null, 0x0145, "TileByteCounts", true, [("Exif.Image.TileByteCounts", "Image")]);

    /// <summary>
    /// BadFaxLines (0x0146)
    /// </summary>
    public static readonly Tag BadFaxLines = Create(null, null, 0x0146, "BadFaxLines");

    /// <summary>
    /// CleanFaxData (0x0147)
    /// </summary>
    public static readonly Tag CleanFaxData = Create(null, null, 0x0147, "CleanFaxData");

    /// <summary>
    /// ConsecutiveBadFaxLines (0x0148)
    /// </summary>
    public static readonly Tag ConsecutiveBadFaxLines = Create(null, null, 0x0148, "ConsecutiveBadFaxLines");

    /// <summary>
    /// Defined by Adobe Corporation to enable TIFF Trees within a TIFF file.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag SubIfd = CreateIfdPointer(null, null, 0x014A, "SubIFD", true, [("Exif.Image.SubIFDs", "Image")]);

    /// <summary>
    /// The name of each ink used in a separated (PhotometricInterpretation=5) image.
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag InkNames = Create(null, null, 0x014D, "InkNames", true, [("Exif.Image.InkNames", "Image")]);

    /// <summary>
    /// The number of inks. Usually equal to SamplesPerPixel, unless there are extra samples.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag NumberofInks = Create(null, null, 0x014E, "NumberofInks", true, [("Exif.Image.NumberOfInks", "Image")]);

    /// <summary>
    /// The component values that correspond to a 0% dot and 100% dot.
    /// </summary>
    /// <remarks>
    /// Expected type is Byte.
    /// </remarks>
    public static readonly Tag DotRange = Create(null, null, 0x0150, "DotRange", true, [("Exif.Image.DotRange", "Image")]);

    /// <summary>
    /// Specifies that each pixel has m extra components whose interpretation is defined by one of the values listed below.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag ExtraSamples = Create(null, null, 0x0152, "ExtraSamples", true, [("Exif.Image.ExtraSamples", "Image")]);

    /// <summary>
    /// This field specifies the minimum sample value.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag SMinSampleValue = Create(null, null, 0x0154, "SMinSampleValue", true, [("Exif.Image.SMinSampleValue", "Image")]);

    /// <summary>
    /// This field specifies the maximum sample value.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag SMaxSampleValue = Create(null, null, 0x0155, "SMaxSampleValue", true, [("Exif.Image.SMaxSampleValue", "Image")]);

    /// <summary>
    /// Expands the range of the TransferFunction
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag TransferRange = Create(null, null, 0x0156, "TransferRange", true, [("Exif.Image.TransferRange", "Image")]);

    /// <summary>
    /// A TIFF ClipPath is intended to mirror the essentials of PostScript's path creation functionality.
    /// </summary>
    /// <remarks>
    /// Expected type is Byte.
    /// </remarks>
    public static readonly Tag ClipPath = Create(null, null, 0x0157, "ClipPath", true, [("Exif.Image.ClipPath", "Image")]);

    /// <summary>
    /// The number of units that span the width of the image, in terms of integer ClipPath coordinates.
    /// </summary>
    /// <remarks>
    /// Expected type is SInt16.
    /// </remarks>
    public static readonly Tag XClipPathUnits = Create(null, null, 0x0158, "XClipPathUnits", true, [("Exif.Image.XClipPathUnits", "Image")]);

    /// <summary>
    /// The number of units that span the height of the image, in terms of integer ClipPath coordinates.
    /// </summary>
    /// <remarks>
    /// Expected type is SInt16.
    /// </remarks>
    public static readonly Tag YClipPathUnits = Create(null, null, 0x0159, "YClipPathUnits", true, [("Exif.Image.YClipPathUnits", "Image")]);

    /// <summary>
    /// Indexed images are images where the 'pixels' do not represent color values, but rather an index (usually 8-bit) into a separate color table, the ColorMap.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag Indexed = Create(null, null, 0x015A, "Indexed", true, [("Exif.Image.Indexed", "Image")]);

    /// <summary>
    /// This optional tag may be used to encode the JPEG quantization and Huffman tables for subsequent use by the JPEG decompression process.
    /// </summary>
    /// <remarks>
    /// Expected type is Undefined.
    /// </remarks>
    public static readonly Tag JpegTables = Create(null, null, 0x015B, "JPEGTables", true, [("Exif.Image.JPEGTables", "Image")]);

    /// <summary>
    /// OPIProxy gives information concerning whether this image is a low-resolution proxy of a high-resolution image (Adobe OPI).
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag OpiProxy = Create(null, null, 0x015F, "OPIProxy", true, [("Exif.Image.OPIProxy", "Image")]);

    /// <summary>
    /// GlobalParametersIFD (0x0190)
    /// </summary>
    public static readonly Tag GlobalParametersIfd = CreatePreserveDataBlock(null, null, 0x0190, "GlobalParametersIFD");

    /// <summary>
    /// ProfileType (0x0191)
    /// </summary>
    public static readonly Tag ProfileType = Create(null, null, 0x0191, "ProfileType");

    /// <summary>
    /// FaxProfile (0x0192)
    /// </summary>
    public static readonly Tag FaxProfile = Create(null, null, 0x0192, "FaxProfile");

    /// <summary>
    /// CodingMethods (0x0193)
    /// </summary>
    public static readonly Tag CodingMethods = Create(null, null, 0x0193, "CodingMethods");

    /// <summary>
    /// VersionYear (0x0194)
    /// </summary>
    public static readonly Tag VersionYear = Create(null, null, 0x0194, "VersionYear");

    /// <summary>
    /// ModeNumber (0x0195)
    /// </summary>
    public static readonly Tag ModeNumber = Create(null, null, 0x0195, "ModeNumber");

    /// <summary>
    /// Decode (0x01B1)
    /// </summary>
    public static readonly Tag Decode = Create(null, null, 0x01B1, "Decode");

    /// <summary>
    /// DefaultImageColor (0x01B2)
    /// </summary>
    public static readonly Tag DefaultImageColor = Create(null, null, 0x01B2, "DefaultImageColor");

    /// <summary>
    /// T82Options (0x01B3)
    /// </summary>
    public static readonly Tag T82Options = Create(null, null, 0x01B3, "T82Options");

    /// <summary>
    /// This field indicates the process used to produce the compressed data
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag JpegProc = Create(null, null, 0x0200, "JPEGProc", true, [("Exif.Image.JPEGProc", "Image")]);

    /// <summary>
    /// This Field indicates the length of the restart interval used in the compressed image data.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag JpegRestartInterval = Create(null, null, 0x0203, "JPEGRestartInterval", true, [("Exif.Image.JPEGRestartInterval", "Image")]);

    /// <summary>
    /// This Field points to a list of lossless predictor-selection values, one per component.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag JpegLosslessPredictors = Create(null, null, 0x0205, "JPEGLosslessPredictors", true, [("Exif.Image.JPEGLosslessPredictors", "Image")]);

    /// <summary>
    /// This Field points to a list of point transform values, one per component.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag JpegPointTransforms = Create(null, null, 0x0206, "JPEGPointTransforms", true, [("Exif.Image.JPEGPointTransforms", "Image")]);

    /// <summary>
    /// This Field points to a list of offsets to the quantization tables, one per component.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag JpegqTables = Create(null, null, 0x0207, "JPEGQTables", true, [("Exif.Image.JPEGQTables", "Image")]);

    /// <summary>
    /// This Field points to a list of offsets to the DC Huffman tables or the lossless Huffman tables, one per component.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag JpegdcTables = Create(null, null, 0x0208, "JPEGDCTables", true, [("Exif.Image.JPEGDCTables", "Image")]);

    /// <summary>
    /// This Field points to a list of offsets to the Huffman AC tables, one per component.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag JpegacTables = Create(null, null, 0x0209, "JPEGACTables", true, [("Exif.Image.JPEGACTables", "Image")]);

    /// <summary>
    /// StripRowCounts (0x022F)
    /// </summary>
    public static readonly Tag StripRowCounts = Create(null, null, 0x022F, "StripRowCounts");

    /// <summary>
    /// RenderingIntent (0x0303)
    /// </summary>
    public static readonly Tag RenderingIntent = Create(null, null, 0x0303, "RenderingIntent");

    /// <summary>
    /// USPTOMiscellaneous (0x03E7)
    /// </summary>
    public static readonly Tag UsptoMiscellaneous = Create(null, null, 0x03E7, "USPTOMiscellaneous");

    /// <summary>
    /// XP_DIP_XML (0x4747)
    /// </summary>
    public static readonly Tag XpDipXml = Create(null, null, 0x4747, "XP_DIP_XML");

    /// <summary>
    /// StitchInfo (0x4748)
    /// </summary>
    public static readonly Tag StitchInfo = Create(null, null, 0x4748, "StitchInfo");

    /// <summary>
    /// ResolutionXUnit (0x5001)
    /// </summary>
    public static readonly Tag ResolutionXUnit = Create(null, null, 0x5001, "ResolutionXUnit");

    /// <summary>
    /// ResolutionYUnit (0x5002)
    /// </summary>
    public static readonly Tag ResolutionYUnit = Create(null, null, 0x5002, "ResolutionYUnit");

    /// <summary>
    /// ResolutionXLengthUnit (0x5003)
    /// </summary>
    public static readonly Tag ResolutionXLengthUnit = Create(null, null, 0x5003, "ResolutionXLengthUnit");

    /// <summary>
    /// ResolutionYLengthUnit (0x5004)
    /// </summary>
    public static readonly Tag ResolutionYLengthUnit = Create(null, null, 0x5004, "ResolutionYLengthUnit");

    /// <summary>
    /// PrintFlags (0x5005)
    /// </summary>
    public static readonly Tag PrintFlags = Create(null, null, 0x5005, "PrintFlags");

    /// <summary>
    /// PrintFlagsVersion (0x5006)
    /// </summary>
    public static readonly Tag PrintFlagsVersion = Create(null, null, 0x5006, "PrintFlagsVersion");

    /// <summary>
    /// PrintFlagsCrop (0x5007)
    /// </summary>
    public static readonly Tag PrintFlagsCrop = Create(null, null, 0x5007, "PrintFlagsCrop");

    /// <summary>
    /// PrintFlagsBleedWidth (0x5008)
    /// </summary>
    public static readonly Tag PrintFlagsBleedWidth = Create(null, null, 0x5008, "PrintFlagsBleedWidth");

    /// <summary>
    /// PrintFlagsBleedWidthScale (0x5009)
    /// </summary>
    public static readonly Tag PrintFlagsBleedWidthScale = Create(null, null, 0x5009, "PrintFlagsBleedWidthScale");

    /// <summary>
    /// HalftoneLPI (0x500A)
    /// </summary>
    public static readonly Tag HalftoneLpi = Create(null, null, 0x500A, "HalftoneLPI");

    /// <summary>
    /// HalftoneLPIUnit (0x500B)
    /// </summary>
    public static readonly Tag HalftoneLpiUnit = Create(null, null, 0x500B, "HalftoneLPIUnit");

    /// <summary>
    /// HalftoneDegree (0x500C)
    /// </summary>
    public static readonly Tag HalftoneDegree = Create(null, null, 0x500C, "HalftoneDegree");

    /// <summary>
    /// HalftoneShape (0x500D)
    /// </summary>
    public static readonly Tag HalftoneShape = Create(null, null, 0x500D, "HalftoneShape");

    /// <summary>
    /// HalftoneMisc (0x500E)
    /// </summary>
    public static readonly Tag HalftoneMisc = Create(null, null, 0x500E, "HalftoneMisc");

    /// <summary>
    /// HalftoneScreen (0x500F)
    /// </summary>
    public static readonly Tag HalftoneScreen = Create(null, null, 0x500F, "HalftoneScreen");

    /// <summary>
    /// JPEGQuality (0x5010)
    /// </summary>
    public static readonly Tag JpegQuality = Create(null, null, 0x5010, "JPEGQuality");

    /// <summary>
    /// GridSize (0x5011)
    /// </summary>
    public static readonly Tag GridSize = Create(null, null, 0x5011, "GridSize");

    /// <summary>
    /// ThumbnailFormat (0x5012)
    /// </summary>
    public static readonly Tag ThumbnailFormat = Create(null, null, 0x5012, "ThumbnailFormat");

    /// <summary>
    /// ThumbnailWidth (0x5013)
    /// </summary>
    public static readonly Tag ThumbnailWidth = Create(null, null, 0x5013, "ThumbnailWidth");

    /// <summary>
    /// ThumbnailHeight (0x5014)
    /// </summary>
    public static readonly Tag ThumbnailHeight = Create(null, null, 0x5014, "ThumbnailHeight");

    /// <summary>
    /// ThumbnailColorDepth (0x5015)
    /// </summary>
    public static readonly Tag ThumbnailColorDepth = Create(null, null, 0x5015, "ThumbnailColorDepth");

    /// <summary>
    /// ThumbnailPlanes (0x5016)
    /// </summary>
    public static readonly Tag ThumbnailPlanes = Create(null, null, 0x5016, "ThumbnailPlanes");

    /// <summary>
    /// ThumbnailRawBytes (0x5017)
    /// </summary>
    public static readonly Tag ThumbnailRawBytes = Create(null, null, 0x5017, "ThumbnailRawBytes");

    /// <summary>
    /// ThumbnailLength (0x5018)
    /// </summary>
    public static readonly Tag ThumbnailLength = Create(null, null, 0x5018, "ThumbnailLength");

    /// <summary>
    /// ThumbnailCompressedSize (0x5019)
    /// </summary>
    public static readonly Tag ThumbnailCompressedSize = Create(null, null, 0x5019, "ThumbnailCompressedSize");

    /// <summary>
    /// ColorTransferFunction (0x501A)
    /// </summary>
    public static readonly Tag ColorTransferFunction = Create(null, null, 0x501A, "ColorTransferFunction");

    /// <summary>
    /// ThumbnailData (0x501B)
    /// </summary>
    public static readonly Tag ThumbnailData = Create(null, null, 0x501B, "ThumbnailData");

    /// <summary>
    /// ThumbnailImageWidth (0x5020)
    /// </summary>
    public static readonly Tag ThumbnailImageWidth = Create(null, null, 0x5020, "ThumbnailImageWidth");

    /// <summary>
    /// ThumbnailImageHeight (0x5021)
    /// </summary>
    public static readonly Tag ThumbnailImageHeight = Create(null, null, 0x5021, "ThumbnailImageHeight");

    /// <summary>
    /// ThumbnailBitsPerSample (0x5022)
    /// </summary>
    public static readonly Tag ThumbnailBitsPerSample = Create(null, null, 0x5022, "ThumbnailBitsPerSample");

    /// <summary>
    /// ThumbnailCompression (0x5023)
    /// </summary>
    public static readonly Tag ThumbnailCompression = Create(null, null, 0x5023, "ThumbnailCompression");

    /// <summary>
    /// ThumbnailPhotometricInterp (0x5024)
    /// </summary>
    public static readonly Tag ThumbnailPhotometricInterp = Create(null, null, 0x5024, "ThumbnailPhotometricInterp");

    /// <summary>
    /// ThumbnailDescription (0x5025)
    /// </summary>
    public static readonly Tag ThumbnailDescription = Create(null, null, 0x5025, "ThumbnailDescription");

    /// <summary>
    /// ThumbnailEquipMake (0x5026)
    /// </summary>
    public static readonly Tag ThumbnailEquipMake = Create(null, null, 0x5026, "ThumbnailEquipMake");

    /// <summary>
    /// ThumbnailEquipModel (0x5027)
    /// </summary>
    public static readonly Tag ThumbnailEquipModel = Create(null, null, 0x5027, "ThumbnailEquipModel");

    /// <summary>
    /// ThumbnailStripOffsets (0x5028)
    /// </summary>
    public static readonly Tag ThumbnailStripOffsets = Create(null, null, 0x5028, "ThumbnailStripOffsets");

    /// <summary>
    /// ThumbnailOrientation (0x5029)
    /// </summary>
    public static readonly Tag ThumbnailOrientation = Create(null, null, 0x5029, "ThumbnailOrientation");

    /// <summary>
    /// ThumbnailSamplesPerPixel (0x502A)
    /// </summary>
    public static readonly Tag ThumbnailSamplesPerPixel = Create(null, null, 0x502A, "ThumbnailSamplesPerPixel");

    /// <summary>
    /// ThumbnailRowsPerStrip (0x502B)
    /// </summary>
    public static readonly Tag ThumbnailRowsPerStrip = Create(null, null, 0x502B, "ThumbnailRowsPerStrip");

    /// <summary>
    /// ThumbnailStripByteCounts (0x502C)
    /// </summary>
    public static readonly Tag ThumbnailStripByteCounts = Create(null, null, 0x502C, "ThumbnailStripByteCounts");

    /// <summary>
    /// ThumbnailResolutionX (0x502D)
    /// </summary>
    public static readonly Tag ThumbnailResolutionX = Create(null, null, 0x502D, "ThumbnailResolutionX");

    /// <summary>
    /// ThumbnailResolutionY (0x502E)
    /// </summary>
    public static readonly Tag ThumbnailResolutionY = Create(null, null, 0x502E, "ThumbnailResolutionY");

    /// <summary>
    /// ThumbnailPlanarConfig (0x502F)
    /// </summary>
    public static readonly Tag ThumbnailPlanarConfig = Create(null, null, 0x502F, "ThumbnailPlanarConfig");

    /// <summary>
    /// ThumbnailResolutionUnit (0x5030)
    /// </summary>
    public static readonly Tag ThumbnailResolutionUnit = Create(null, null, 0x5030, "ThumbnailResolutionUnit");

    /// <summary>
    /// ThumbnailTransferFunction (0x5031)
    /// </summary>
    public static readonly Tag ThumbnailTransferFunction = Create(null, null, 0x5031, "ThumbnailTransferFunction");

    /// <summary>
    /// ThumbnailSoftware (0x5032)
    /// </summary>
    public static readonly Tag ThumbnailSoftware = Create(null, null, 0x5032, "ThumbnailSoftware");

    /// <summary>
    /// ThumbnailDateTime (0x5033)
    /// </summary>
    public static readonly Tag ThumbnailDateTime = Create(null, null, 0x5033, "ThumbnailDateTime");

    /// <summary>
    /// ThumbnailArtist (0x5034)
    /// </summary>
    public static readonly Tag ThumbnailArtist = Create(null, null, 0x5034, "ThumbnailArtist");

    /// <summary>
    /// ThumbnailWhitePoint (0x5035)
    /// </summary>
    public static readonly Tag ThumbnailWhitePoint = Create(null, null, 0x5035, "ThumbnailWhitePoint");

    /// <summary>
    /// ThumbnailPrimaryChromaticities (0x5036)
    /// </summary>
    public static readonly Tag ThumbnailPrimaryChromaticities = Create(null, null, 0x5036, "ThumbnailPrimaryChromaticities");

    /// <summary>
    /// ThumbnailYCbCrCoefficients (0x5037)
    /// </summary>
    public static readonly Tag ThumbnailYCbCrCoefficients = Create(null, null, 0x5037, "ThumbnailYCbCrCoefficients");

    /// <summary>
    /// ThumbnailYCbCrSubsampling (0x5038)
    /// </summary>
    public static readonly Tag ThumbnailYCbCrSubsampling = Create(null, null, 0x5038, "ThumbnailYCbCrSubsampling");

    /// <summary>
    /// ThumbnailYCbCrPositioning (0x5039)
    /// </summary>
    public static readonly Tag ThumbnailYCbCrPositioning = Create(null, null, 0x5039, "ThumbnailYCbCrPositioning");

    /// <summary>
    /// ThumbnailRefBlackWhite (0x503A)
    /// </summary>
    public static readonly Tag ThumbnailRefBlackWhite = Create(null, null, 0x503A, "ThumbnailRefBlackWhite");

    /// <summary>
    /// ThumbnailCopyright (0x503B)
    /// </summary>
    public static readonly Tag ThumbnailCopyright = Create(null, null, 0x503B, "ThumbnailCopyright");

    /// <summary>
    /// LuminanceTable (0x5090)
    /// </summary>
    public static readonly Tag LuminanceTable = Create(null, null, 0x5090, "LuminanceTable");

    /// <summary>
    /// ChrominanceTable (0x5091)
    /// </summary>
    public static readonly Tag ChrominanceTable = Create(null, null, 0x5091, "ChrominanceTable");

    /// <summary>
    /// FrameDelay (0x5100)
    /// </summary>
    public static readonly Tag FrameDelay = Create(null, null, 0x5100, "FrameDelay");

    /// <summary>
    /// LoopCount (0x5101)
    /// </summary>
    public static readonly Tag LoopCount = Create(null, null, 0x5101, "LoopCount");

    /// <summary>
    /// GlobalPalette (0x5102)
    /// </summary>
    public static readonly Tag GlobalPalette = Create(null, null, 0x5102, "GlobalPalette");

    /// <summary>
    /// IndexBackground (0x5103)
    /// </summary>
    public static readonly Tag IndexBackground = Create(null, null, 0x5103, "IndexBackground");

    /// <summary>
    /// IndexTransparent (0x5104)
    /// </summary>
    public static readonly Tag IndexTransparent = Create(null, null, 0x5104, "IndexTransparent");

    /// <summary>
    /// PixelUnits (0x5110)
    /// </summary>
    public static readonly Tag PixelUnits = Create(null, null, 0x5110, "PixelUnits");

    /// <summary>
    /// PixelsPerUnitX (0x5111)
    /// </summary>
    public static readonly Tag PixelsPerUnitX = Create(null, null, 0x5111, "PixelsPerUnitX");

    /// <summary>
    /// PixelsPerUnitY (0x5112)
    /// </summary>
    public static readonly Tag PixelsPerUnitY = Create(null, null, 0x5112, "PixelsPerUnitY");

    /// <summary>
    /// PaletteHistogram (0x5113)
    /// </summary>
    public static readonly Tag PaletteHistogram = Create(null, null, 0x5113, "PaletteHistogram");

    /// <summary>
    /// SonyRawFileType (0x7000)
    /// </summary>
    public static readonly Tag SonyRawFileType = Create(null, null, 0x7000, "SonyRawFileType");

    /// <summary>
    /// SonyToneCurve (0x7010)
    /// </summary>
    public static readonly Tag SonyToneCurve = Create(null, null, 0x7010, "SonyToneCurve");

    /// <summary>
    /// ImageID is the full pathname of the original, high-resolution image, or any other identifying string that uniquely identifies the original image (Adobe OPI).
    /// </summary>
    /// <remarks>
    /// Expected type is Ascii.
    /// </remarks>
    public static readonly Tag ImageId = Create(null, null, 0x800D, "ImageID", true, [("Exif.Image.ImageID", "Image")]);

    /// <summary>
    /// WangTag1 (0x80A3)
    /// </summary>
    public static readonly Tag WangTag1 = Create(null, null, 0x80A3, "WangTag1");

    /// <summary>
    /// WangAnnotation (0x80A4)
    /// </summary>
    public static readonly Tag WangAnnotation = Create(null, null, 0x80A4, "WangAnnotation");

    /// <summary>
    /// WangTag3 (0x80A5)
    /// </summary>
    public static readonly Tag WangTag3 = Create(null, null, 0x80A5, "WangTag3");

    /// <summary>
    /// WangTag4 (0x80A6)
    /// </summary>
    public static readonly Tag WangTag4 = Create(null, null, 0x80A6, "WangTag4");

    /// <summary>
    /// ImageReferencePoints (0x80B9)
    /// </summary>
    public static readonly Tag ImageReferencePoints = Create(null, null, 0x80B9, "ImageReferencePoints");

    /// <summary>
    /// RegionXformTackPoint (0x80BA)
    /// </summary>
    public static readonly Tag RegionXformTackPoint = Create(null, null, 0x80BA, "RegionXformTackPoint");

    /// <summary>
    /// WarpQuadrilateral (0x80BB)
    /// </summary>
    public static readonly Tag WarpQuadrilateral = Create(null, null, 0x80BB, "WarpQuadrilateral");

    /// <summary>
    /// AffineTransformMat (0x80BC)
    /// </summary>
    public static readonly Tag AffineTransformMat = Create(null, null, 0x80BC, "AffineTransformMat");

    /// <summary>
    /// Matteing (0x80E3)
    /// </summary>
    public static readonly Tag Matteing = Create(null, null, 0x80E3, "Matteing");

    /// <summary>
    /// DataType (0x80E4)
    /// </summary>
    public static readonly Tag DataType = Create(null, null, 0x80E4, "DataType");

    /// <summary>
    /// ImageDepth (0x80E5)
    /// </summary>
    public static readonly Tag ImageDepth = Create(null, null, 0x80E5, "ImageDepth");

    /// <summary>
    /// TileDepth (0x80E6)
    /// </summary>
    public static readonly Tag TileDepth = Create(null, null, 0x80E6, "TileDepth");

    /// <summary>
    /// ImageFullWidth (0x8214)
    /// </summary>
    public static readonly Tag ImageFullWidth = Create(null, null, 0x8214, "ImageFullWidth");

    /// <summary>
    /// ImageFullHeight (0x8215)
    /// </summary>
    public static readonly Tag ImageFullHeight = Create(null, null, 0x8215, "ImageFullHeight");

    /// <summary>
    /// TextureFormat (0x8216)
    /// </summary>
    public static readonly Tag TextureFormat = Create(null, null, 0x8216, "TextureFormat");

    /// <summary>
    /// WrapModes (0x8217)
    /// </summary>
    public static readonly Tag WrapModes = Create(null, null, 0x8217, "WrapModes");

    /// <summary>
    /// FovCot (0x8218)
    /// </summary>
    public static readonly Tag FovCot = Create(null, null, 0x8218, "FovCot");

    /// <summary>
    /// MatrixWorldToScreen (0x8219)
    /// </summary>
    public static readonly Tag MatrixWorldToScreen = Create(null, null, 0x8219, "MatrixWorldToScreen");

    /// <summary>
    /// MatrixWorldToCamera (0x821A)
    /// </summary>
    public static readonly Tag MatrixWorldToCamera = Create(null, null, 0x821A, "MatrixWorldToCamera");

    /// <summary>
    /// Model2 (0x827D)
    /// </summary>
    public static readonly Tag Model2 = Create(null, null, 0x827D, "Model2");

    /// <summary>
    /// Contains a value of the battery level as a fraction or string
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag BatteryLevel = Create(null, null, 0x828F, "BatteryLevel", true, [("Exif.Image.BatteryLevel", "Image")]);

    /// <summary>
    /// KodakIFD (0x8290)
    /// </summary>
    public static readonly Tag KodakIfd = CreatePreserveDataBlock(null, null, 0x8290, "KodakIFD");

    /// <summary>
    /// MDFileTag (0x82A5)
    /// </summary>
    public static readonly Tag MdFileTag = Create(null, null, 0x82A5, "MDFileTag");

    /// <summary>
    /// MDScalePixel (0x82A6)
    /// </summary>
    public static readonly Tag MdScalePixel = Create(null, null, 0x82A6, "MDScalePixel");

    /// <summary>
    /// MDColorTable (0x82A7)
    /// </summary>
    public static readonly Tag MdColorTable = Create(null, null, 0x82A7, "MDColorTable");

    /// <summary>
    /// MDLabName (0x82A8)
    /// </summary>
    public static readonly Tag MdLabName = Create(null, null, 0x82A8, "MDLabName");

    /// <summary>
    /// MDSampleInfo (0x82A9)
    /// </summary>
    public static readonly Tag MdSampleInfo = Create(null, null, 0x82A9, "MDSampleInfo");

    /// <summary>
    /// MDPrepDate (0x82AA)
    /// </summary>
    public static readonly Tag MdPrepDate = Create(null, null, 0x82AA, "MDPrepDate");

    /// <summary>
    /// MDPrepTime (0x82AB)
    /// </summary>
    public static readonly Tag MdPrepTime = Create(null, null, 0x82AB, "MDPrepTime");

    /// <summary>
    /// MDFileUnits (0x82AC)
    /// </summary>
    public static readonly Tag MdFileUnits = Create(null, null, 0x82AC, "MDFileUnits");

    /// <summary>
    /// AdventScale (0x8335)
    /// </summary>
    public static readonly Tag AdventScale = Create(null, null, 0x8335, "AdventScale");

    /// <summary>
    /// AdventRevision (0x8336)
    /// </summary>
    public static readonly Tag AdventRevision = Create(null, null, 0x8336, "AdventRevision");

    /// <summary>
    /// UIC1Tag (0x835C)
    /// </summary>
    public static readonly Tag Uic1Tag = Create(null, null, 0x835C, "UIC1Tag");

    /// <summary>
    /// UIC2Tag (0x835D)
    /// </summary>
    public static readonly Tag Uic2Tag = Create(null, null, 0x835D, "UIC2Tag");

    /// <summary>
    /// UIC3Tag (0x835E)
    /// </summary>
    public static readonly Tag Uic3Tag = Create(null, null, 0x835E, "UIC3Tag");

    /// <summary>
    /// UIC4Tag (0x835F)
    /// </summary>
    public static readonly Tag Uic4Tag = Create(null, null, 0x835F, "UIC4Tag");

    /// <summary>
    /// IntergraphPacketData (0x847E)
    /// </summary>
    public static readonly Tag IntergraphPacketData = Create(null, null, 0x847E, "IntergraphPacketData");

    /// <summary>
    /// IntergraphFlagRegisters (0x847F)
    /// </summary>
    public static readonly Tag IntergraphFlagRegisters = Create(null, null, 0x847F, "IntergraphFlagRegisters");

    /// <summary>
    /// INGRReserved (0x8481)
    /// </summary>
    public static readonly Tag IngrReserved = Create(null, null, 0x8481, "INGRReserved");

    /// <summary>
    /// Site (0x84E0)
    /// </summary>
    public static readonly Tag Site = Create(null, null, 0x84E0, "Site");

    /// <summary>
    /// ColorSequence (0x84E1)
    /// </summary>
    public static readonly Tag ColorSequence = Create(null, null, 0x84E1, "ColorSequence");

    /// <summary>
    /// IT8Header (0x84E2)
    /// </summary>
    public static readonly Tag It8Header = Create(null, null, 0x84E2, "IT8Header");

    /// <summary>
    /// RasterPadding (0x84E3)
    /// </summary>
    public static readonly Tag RasterPadding = Create(null, null, 0x84E3, "RasterPadding");

    /// <summary>
    /// BitsPerRunLength (0x84E4)
    /// </summary>
    public static readonly Tag BitsPerRunLength = Create(null, null, 0x84E4, "BitsPerRunLength");

    /// <summary>
    /// BitsPerExtendedRunLength (0x84E5)
    /// </summary>
    public static readonly Tag BitsPerExtendedRunLength = Create(null, null, 0x84E5, "BitsPerExtendedRunLength");

    /// <summary>
    /// ColorTable (0x84E6)
    /// </summary>
    public static readonly Tag ColorTable = Create(null, null, 0x84E6, "ColorTable");

    /// <summary>
    /// ImageColorIndicator (0x84E7)
    /// </summary>
    public static readonly Tag ImageColorIndicator = Create(null, null, 0x84E7, "ImageColorIndicator");

    /// <summary>
    /// BackgroundColorIndicator (0x84E8)
    /// </summary>
    public static readonly Tag BackgroundColorIndicator = Create(null, null, 0x84E8, "BackgroundColorIndicator");

    /// <summary>
    /// ImageColorValue (0x84E9)
    /// </summary>
    public static readonly Tag ImageColorValue = Create(null, null, 0x84E9, "ImageColorValue");

    /// <summary>
    /// BackgroundColorValue (0x84EA)
    /// </summary>
    public static readonly Tag BackgroundColorValue = Create(null, null, 0x84EA, "BackgroundColorValue");

    /// <summary>
    /// PixelIntensityRange (0x84EB)
    /// </summary>
    public static readonly Tag PixelIntensityRange = Create(null, null, 0x84EB, "PixelIntensityRange");

    /// <summary>
    /// TransparencyIndicator (0x84EC)
    /// </summary>
    public static readonly Tag TransparencyIndicator = Create(null, null, 0x84EC, "TransparencyIndicator");

    /// <summary>
    /// ColorCharacterization (0x84ED)
    /// </summary>
    public static readonly Tag ColorCharacterization = Create(null, null, 0x84ED, "ColorCharacterization");

    /// <summary>
    /// HCUsage (0x84EE)
    /// </summary>
    public static readonly Tag HcUsage = Create(null, null, 0x84EE, "HCUsage");

    /// <summary>
    /// TrapIndicator (0x84EF)
    /// </summary>
    public static readonly Tag TrapIndicator = Create(null, null, 0x84EF, "TrapIndicator");

    /// <summary>
    /// CMYKEquivalent (0x84F0)
    /// </summary>
    public static readonly Tag CmykEquivalent = Create(null, null, 0x84F0, "CMYKEquivalent");

    /// <summary>
    /// AFCP_IPTC (0x8568)
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32->Unknown.
    /// </remarks>
    public static readonly Tag AfcpIptc = CreatePreserveDataBlock(null, null, 0x8568, "AFCP_IPTC");

    /// <summary>
    /// PixelMagicJBIGOptions (0x85B8)
    /// </summary>
    public static readonly Tag PixelMagicJBigOptions = Create(null, null, 0x85B8, "PixelMagicJBIGOptions");

    /// <summary>
    /// JPLCartoIFD (0x85D7)
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32->Unknown.
    /// </remarks>
    public static readonly Tag JplCartoIfd = CreatePreserveDataBlock(null, null, 0x85D7, "JPLCartoIFD");

    /// <summary>
    /// WB_GRGBLevels (0x8602)
    /// </summary>
    public static readonly Tag WbGrgbLevels = Create(null, null, 0x8602, "WB_GRGBLevels");

    /// <summary>
    /// LeafData (0x8606)
    /// </summary>
    public static readonly Tag LeafData = Create(null, null, 0x8606, "LeafData");

    /// <summary>
    /// TIFF_FXExtensions (0x877F)
    /// </summary>
    public static readonly Tag TiffFxExtensions = Create(null, null, 0x877F, "TIFF_FXExtensions");

    /// <summary>
    /// MultiProfiles (0x8780)
    /// </summary>
    public static readonly Tag MultiProfiles = Create(null, null, 0x8780, "MultiProfiles");

    /// <summary>
    /// SharedData (0x8781)
    /// </summary>
    public static readonly Tag SharedData = Create(null, null, 0x8781, "SharedData");

    /// <summary>
    /// T88Options (0x8782)
    /// </summary>
    public static readonly Tag T88Options = Create(null, null, 0x8782, "T88Options");

    /// <summary>
    /// ImageLayer (0x87AC)
    /// </summary>
    public static readonly Tag ImageLayer = Create(null, null, 0x87AC, "ImageLayer");

    /// <summary>
    /// JBIGOptions (0x87BE)
    /// </summary>
    public static readonly Tag JBigOptions = Create(null, null, 0x87BE, "JBIGOptions");

    /// <summary>
    /// Indicates the field number of multifield images.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag Interlace = Create(null, null, 0x8829, "Interlace", true, [("Exif.Image.Interlace", "Image")]);

    /// <summary>
    /// FaxRecvParams (0x885C)
    /// </summary>
    public static readonly Tag FaxRecvParams = Create(null, null, 0x885C, "FaxRecvParams");

    /// <summary>
    /// FaxSubAddress (0x885D)
    /// </summary>
    public static readonly Tag FaxSubAddress = Create(null, null, 0x885D, "FaxSubAddress");

    /// <summary>
    /// FaxRecvTime (0x885E)
    /// </summary>
    public static readonly Tag FaxRecvTime = Create(null, null, 0x885E, "FaxRecvTime");

    /// <summary>
    /// FedexEDR (0x8871)
    /// </summary>
    public static readonly Tag FedexEdr = Create(null, null, 0x8871, "FedexEDR");

    /// <summary>
    /// LeafSubIFD (0x888A)
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32->Unknown.
    /// </remarks>
    public static readonly Tag LeafSubIfd = CreatePreserveDataBlock(null, null, 0x888A, "LeafSubIFD");

    /// <summary>
    /// Amount of flash energy (BCPS).
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag FlashEnergy = Create(null, null, 0x920B, "FlashEnergy", true, [("Exif.Image.FlashEnergy", "Image")]);

    /// <summary>
    /// SFR of the camera.
    /// </summary>
    /// <remarks>
    /// Expected type is Undefined.
    /// </remarks>
    public static readonly Tag SpatialFrequencyResponse = Create(null, null, 0x920C, "SpatialFrequencyResponse", true, [("Exif.Image.SpatialFrequencyResponse", "Image")]);

    /// <summary>
    /// Noise measurement values.
    /// </summary>
    /// <remarks>
    /// Expected type is Undefined.
    /// </remarks>
    public static readonly Tag Noise = Create(null, null, 0x920D, "Noise", true, [("Exif.Image.Noise", "Image")]);

    /// <summary>
    /// Number of pixels per FocalPlaneResolutionUnit (37392) in ImageWidth direction for main image.
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag FocalPlaneXResolution = Create(null, null, 0x920E, "FocalPlaneXResolution", true, [("Exif.Image.FocalPlaneXResolution", "Image")]);

    /// <summary>
    /// Number of pixels per FocalPlaneResolutionUnit (37392) in ImageLength direction for main image.
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag FocalPlaneYResolution = Create(null, null, 0x920F, "FocalPlaneYResolution", true, [("Exif.Image.FocalPlaneYResolution", "Image")]);

    /// <summary>
    /// Unit of measurement for FocalPlaneXResolution(37390) and FocalPlaneYResolution(37391).
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag FocalPlaneResolutionUnit = Create(null, null, 0x9210, "FocalPlaneResolutionUnit", true, [("Exif.Image.FocalPlaneResolutionUnit", "Image")]);

    /// <summary>
    /// Encodes the camera exposure index setting when image was captured.
    /// </summary>
    /// <remarks>
    /// Expected type is URational.
    /// </remarks>
    public static readonly Tag ExposureIndex = Create(null, null, 0x9215, "ExposureIndex", true, [("Exif.Image.ExposureIndex", "Image")]);

    /// <summary>
    /// Contains four ASCII characters representing the TIFF/EP standard version of a TIFF/EP file, eg '1', '0', '0', '0'
    /// </summary>
    /// <remarks>
    /// Expected type is Byte.
    /// </remarks>
    public static readonly Tag TiffEpStandardId = Create(null, null, 0x9216, "TIFF-EPStandardID", true, [("Exif.Image.TIFFEPStandardID", "Image")]);

    /// <summary>
    /// Type of image sensor.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt16.
    /// </remarks>
    public static readonly Tag SensingMethod = Create(null, null, 0x9217, "SensingMethod", true, [("Exif.Image.SensingMethod", "Image")]);

    /// <summary>
    /// CIP3DataFile (0x923A)
    /// </summary>
    public static readonly Tag Cip3DataFile = Create(null, null, 0x923A, "CIP3DataFile");

    /// <summary>
    /// CIP3Sheet (0x923B)
    /// </summary>
    public static readonly Tag Cip3Sheet = Create(null, null, 0x923B, "CIP3Sheet");

    /// <summary>
    /// CIP3Side (0x923C)
    /// </summary>
    public static readonly Tag Cip3Side = Create(null, null, 0x923C, "CIP3Side");

    /// <summary>
    /// StoNits (0x923F)
    /// </summary>
    public static readonly Tag StoNits = Create(null, null, 0x923F, "StoNits");

    /// <summary>
    /// MSDocumentText (0x932F)
    /// </summary>
    public static readonly Tag MsDocumentText = Create(null, null, 0x932F, "MSDocumentText");

    /// <summary>
    /// MSPropertySetStorage (0x9330)
    /// </summary>
    public static readonly Tag MsPropertySetStorage = Create(null, null, 0x9330, "MSPropertySetStorage");

    /// <summary>
    /// MSDocumentTextPosition (0x9331)
    /// </summary>
    public static readonly Tag MsDocumentTextPosition = Create(null, null, 0x9331, "MSDocumentTextPosition");

    /// <summary>
    /// SamsungRawPointersOffset (0xA010)
    /// </summary>
    public static readonly Tag SamsungRawPointersOffset = CreateOffsetAndLengthPair(null, null, 0xA010, "SamsungRawPointersOffset", 0xA011, "SamsungRawPointersLength");

    /// <summary>
    /// SamsungRawByteOrder (0xA101)
    /// </summary>
    public static readonly Tag SamsungRawByteOrder = Create(null, null, 0xA101, "SamsungRawByteOrder");

    /// <summary>
    /// SamsungRawUnknown (0xA102)
    /// </summary>
    public static readonly Tag SamsungRawUnknown = Create(null, null, 0xA102, "SamsungRawUnknown");

    /// <summary>
    /// Noise (0xA20D)
    /// </summary>
    /// <remarks>
    /// Expected type is Undefined.
    /// </remarks>
    public static readonly Tag NoiseAlt = Create(null, null, 0xA20D, "Noise");

    /// <summary>
    /// ImageNumber (0xA211)
    /// </summary>
    public static readonly Tag ImageNumber = Create(null, null, 0xA211, "ImageNumber");

    /// <summary>
    /// SecurityClassification (0xA212)
    /// </summary>
    public static readonly Tag SecurityClassification = Create(null, null, 0xA212, "SecurityClassification");

    /// <summary>
    /// ImageHistory (0xA213)
    /// </summary>
    public static readonly Tag ImageHistory = Create(null, null, 0xA213, "ImageHistory");

    /// <summary>
    /// TIFF-EPStandardID (0xA216)
    /// </summary>
    public static readonly Tag TiffEpStandardIdAlt = Create(null, null, 0xA216, "TIFF-EPStandardID");

    /// <summary>
    /// ExpandSoftware (0xAFC0)
    /// </summary>
    public static readonly Tag ExpandSoftware = Create(null, null, 0xAFC0, "ExpandSoftware");

    /// <summary>
    /// ExpandLens (0xAFC1)
    /// </summary>
    public static readonly Tag ExpandLens = Create(null, null, 0xAFC1, "ExpandLens");

    /// <summary>
    /// ExpandFilm (0xAFC2)
    /// </summary>
    public static readonly Tag ExpandFilm = Create(null, null, 0xAFC2, "ExpandFilm");

    /// <summary>
    /// ExpandFilterLens (0xAFC3)
    /// </summary>
    public static readonly Tag ExpandFilterLens = Create(null, null, 0xAFC3, "ExpandFilterLens");

    /// <summary>
    /// ExpandScanner (0xAFC4)
    /// </summary>
    public static readonly Tag ExpandScanner = Create(null, null, 0xAFC4, "ExpandScanner");

    /// <summary>
    /// ExpandFlashLamp (0xAFC5)
    /// </summary>
    public static readonly Tag ExpandFlashLamp = Create(null, null, 0xAFC5, "ExpandFlashLamp");

    /// <summary>
    /// HasselbladRawImage (0xB4C3)
    /// </summary>
    public static readonly Tag HasselbladRawImage = Create(null, null, 0xB4C3, "HasselbladRawImage");

    /// <summary>
    /// PixelFormat (0xBC01)
    /// </summary>
    public static readonly Tag PixelFormat = Create(null, null, 0xBC01, "PixelFormat");

    /// <summary>
    /// Transformation (0xBC02)
    /// </summary>
    public static readonly Tag Transformation = Create(null, null, 0xBC02, "Transformation");

    /// <summary>
    /// Uncompressed (0xBC03)
    /// </summary>
    public static readonly Tag Uncompressed = Create(null, null, 0xBC03, "Uncompressed");

    /// <summary>
    /// ImageType (0xBC04)
    /// </summary>
    public static readonly Tag ImageType = Create(null, null, 0xBC04, "ImageType");

    /// <summary>
    /// ImageWidth (0xBC80)
    /// </summary>
    public static readonly Tag ImageWidth = Create(null, null, 0xBC80, "ImageWidth");

    /// <summary>
    /// ImageHeight (0xBC81)
    /// </summary>
    public static readonly Tag ImageHeight = Create(null, null, 0xBC81, "ImageHeight");

    /// <summary>
    /// WidthResolution (0xBC82)
    /// </summary>
    public static readonly Tag WidthResolution = Create(null, null, 0xBC82, "WidthResolution");

    /// <summary>
    /// HeightResolution (0xBC83)
    /// </summary>
    public static readonly Tag HeightResolution = Create(null, null, 0xBC83, "HeightResolution");

    /// <summary>
    /// ImageOffset (0xBCC0)
    /// </summary>
    public static readonly Tag ImageOffset = CreateOffsetAndLengthPair(null, null, 0xBCC0, "ImageOffset", 0xBCC1, "ImageByteCount");

    /// <summary>
    /// AlphaOffset (0xBCC2)
    /// </summary>
    public static readonly Tag AlphaOffset = CreateOffsetAndLengthPair(null, null, 0xBCC2, "AlphaOffset", 0xBCC3, "AlphaByteCount");

    /// <summary>
    /// ImageDataDiscard (0xBCC4)
    /// </summary>
    public static readonly Tag ImageDataDiscard = Create(null, null, 0xBCC4, "ImageDataDiscard");

    /// <summary>
    /// AlphaDataDiscard (0xBCC5)
    /// </summary>
    public static readonly Tag AlphaDataDiscard = Create(null, null, 0xBCC5, "AlphaDataDiscard");

    /// <summary>
    /// OceScanjobDesc (0xC427)
    /// </summary>
    public static readonly Tag OceScanjobDesc = Create(null, null, 0xC427, "OceScanjobDesc");

    /// <summary>
    /// OceApplicationSelector (0xC428)
    /// </summary>
    public static readonly Tag OceApplicationSelector = Create(null, null, 0xC428, "OceApplicationSelector");

    /// <summary>
    /// OceIDNumber (0xC429)
    /// </summary>
    public static readonly Tag OceIdNumber = Create(null, null, 0xC429, "OceIDNumber");

    /// <summary>
    /// OceImageLogic (0xC42A)
    /// </summary>
    public static readonly Tag OceImageLogic = Create(null, null, 0xC42A, "OceImageLogic");

    /// <summary>
    /// Annotations (0xC44F)
    /// </summary>
    public static readonly Tag Annotations = Create(null, null, 0xC44F, "Annotations");

    /// <summary>
    /// HasselbladXML (0xC519)
    /// </summary>
    public static readonly Tag HasselbladXml = Create(null, null, 0xC519, "HasselbladXML");

    /// <summary>
    /// HasselbladExif (0xC51B)
    /// </summary>
    public static readonly Tag HasselbladExif = Create(null, null, 0xC51B, "HasselbladExif");

    /// <summary>
    /// OriginalFileName (0xC573)
    /// </summary>
    public static readonly Tag OriginalFileName = Create(null, null, 0xC573, "OriginalFileName");

    /// <summary>
    /// USPTOOriginalContentType (0xC580)
    /// </summary>
    public static readonly Tag UsptoOriginalContentType = Create(null, null, 0xC580, "USPTOOriginalContentType");

    /// <summary>
    /// CR2CFAPattern (0xC5E0)
    /// </summary>
    public static readonly Tag Cr2CfaPattern = Create(null, null, 0xC5E0, "CR2CFAPattern");

    /// <summary>
    /// RawImageSegmentation (0xC640)
    /// </summary>
    public static readonly Tag RawImageSegmentation = Create(null, null, 0xC640, "RawImageSegmentation");

    /// <summary>
    /// AliasLayerMetadata (0xC660)
    /// </summary>
    public static readonly Tag AliasLayerMetadata = Create(null, null, 0xC660, "AliasLayerMetadata");

    /// <summary>
    /// Normally, the pixels within a tile are stored in simple row-scan order. This tag specifies that the pixels within a tile should be grouped first into rectangular blocks of the specified size. These blocks are stored in row-scan order. Within each block, the pixels are stored in row-scan order. The use of a non-default value for this tag requires setting the DNGBackwardVersion tag to at least 1.2.0.0.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag SubTileBlockSize = Create(null, null, 0xC71E, "SubTileBlockSize", true, [("Exif.Image.SubTileBlockSize", "Image")]);

    /// <summary>
    /// This tag specifies that rows of the image are stored in interleaved order. The value of the tag specifies the number of interleaved fields. The use of a non-default value for this tag requires setting the DNGBackwardVersion tag to at least 1.2.0.0.
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32.
    /// </remarks>
    public static readonly Tag RowInterleaveFactor = Create(null, null, 0xC71F, "RowInterleaveFactor", true, [("Exif.Image.RowInterleaveFactor", "Image")]);

    /// <summary>
    /// NikonNEFInfo (0xC7D5)
    /// </summary>
    public static readonly Tag NikonNefInfo = Create(null, null, 0xC7D5, "NikonNEFInfo");

    /// <summary>
    /// JUMBF (0xCD41)
    /// </summary>
    public static readonly Tag Jumbf = Create(null, null, 0xCD41, "JUMBF");

    /// <summary>
    /// Padding (0xEA1C)
    /// </summary>
    /// <remarks>
    /// This is non-standard. The standard tag is references the EXIF IFD as a parent.
    /// But this tag value happens enough outside of an EXIF IFD where it is useful to have a tag for it.
    /// </remarks>
    public static readonly Tag Padding = Create(null, null, 0xEA1C, "Padding");

    /// <summary>
    /// KDC_IFD (0xFE00)
    /// </summary>
    /// <remarks>
    /// Expected type is UInt32->Unknown.
    /// </remarks>
    public static readonly Tag KdcIfd = CreatePreserveDataBlock(null, null, 0xFE00, "KDC_IFD");
}