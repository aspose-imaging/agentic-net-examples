using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath1 = @"c:\temp\source1.tif";
        string inputPath2 = @"c:\temp\source2.tif";
        string outputPath = @"c:\temp\combined.tif";

        // Verify first input file exists
        if (!File.Exists(inputPath1))
        {
            Console.Error.WriteLine($"File not found: {inputPath1}");
            return;
        }

        // Verify second input file exists
        if (!File.Exists(inputPath2))
        {
            Console.Error.WriteLine($"File not found: {inputPath2}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create TiffOptions for the first frame (LZW compression)
        TiffOptions options1 = new TiffOptions(TiffExpectedFormat.Default)
        {
            BitsPerSample = new ushort[] { 8, 8, 8 },
            ByteOrder = TiffByteOrder.BigEndian,
            Compression = TiffCompressions.Lzw,
            Photometric = TiffPhotometrics.Rgb,
            PlanarConfiguration = TiffPlanarConfigs.Contiguous
        };

        // Create TiffOptions for the second frame (CCITT Group 3 Fax compression, 1-bit B/W)
        TiffOptions options2 = new TiffOptions(TiffExpectedFormat.Default)
        {
            BitsPerSample = new ushort[] { 1 },
            ByteOrder = TiffByteOrder.LittleEndian,
            Compression = TiffCompressions.CcittFax3,
            Photometric = TiffPhotometrics.MinIsBlack,
            PlanarConfiguration = TiffPlanarConfigs.Contiguous
        };

        // Load frames from the source files with the specified options
        TiffFrame frame1 = new TiffFrame(inputPath1, options1);
        TiffFrame frame2 = new TiffFrame(inputPath2, options2);

        // Create a multi-frame TIFF image and add the frames
        using (TiffImage tiffImage = new TiffImage(frame1))
        {
            tiffImage.AddFrame(frame2);
            tiffImage.Save(outputPath);
        }
    }
}