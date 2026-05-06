using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath1 = @"c:\temp\source1.tif";
            string inputPath2 = @"c:\temp\source2.tif";
            string outputPath = @"c:\temp\combined.tif";

            // Verify input files exist
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }

            // Prepare a list to hold the frames
            List<TiffFrame> frames = new List<TiffFrame>();

            // ----- First frame with LZW compression -----
            using (RasterImage img1 = (RasterImage)Image.Load(inputPath1))
            {
                TiffOptions options1 = new TiffOptions(TiffExpectedFormat.Default)
                {
                    BitsPerSample = new ushort[] { 8, 8, 8 },
                    ByteOrder = TiffByteOrder.BigEndian,
                    Compression = TiffCompressions.Lzw,
                    Photometric = TiffPhotometrics.Rgb,
                    PlanarConfiguration = TiffPlanarConfigs.Contiguous
                };
                TiffFrame frame1 = new TiffFrame(img1, options1);
                frames.Add(frame1);
            }

            // ----- Second frame with CCITT Group 3 Fax compression -----
            using (RasterImage img2 = (RasterImage)Image.Load(inputPath2))
            {
                TiffOptions options2 = new TiffOptions(TiffExpectedFormat.Default)
                {
                    BitsPerSample = new ushort[] { 1 },
                    ByteOrder = TiffByteOrder.LittleEndian,
                    Compression = TiffCompressions.CcittFax3,
                    Photometric = TiffPhotometrics.MinIsBlack,
                    PlanarConfiguration = TiffPlanarConfigs.Contiguous
                };
                TiffFrame frame2 = new TiffFrame(img2, options2);
                frames.Add(frame2);
            }

            // Create a multi-frame TIFF image from the collected frames
            using (TiffImage tiffImage = new TiffImage(frames.ToArray()))
            {
                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the combined TIFF
                tiffImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}