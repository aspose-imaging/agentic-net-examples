using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string[] inputPaths = { "c:\\temp\\source1.tif", "c:\\temp\\source2.tif" };
            string outputPath = "c:\\temp\\combined.tif";

            // Verify each input file exists
            foreach (var inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // List to hold frames with distinct compression settings
            List<TiffFrame> frames = new List<TiffFrame>();

            // First source - LZW compression
            TiffOptions options1 = new TiffOptions(TiffExpectedFormat.Default)
            {
                BitsPerSample = new ushort[] { 8, 8, 8 },
                Compression = TiffCompressions.Lzw,
                Photometric = TiffPhotometrics.Rgb,
                PlanarConfiguration = TiffPlanarConfigs.Contiguous,
                ByteOrder = TiffByteOrder.BigEndian
            };
            using (TiffImage src1 = (TiffImage)Image.Load(inputPaths[0]))
            {
                TiffFrame frame1 = new TiffFrame(src1.ActiveFrame, options1);
                frames.Add(frame1);
            }

            // Second source - CCITT Group 3 Fax compression (B/W)
            TiffOptions options2 = new TiffOptions(TiffExpectedFormat.Default)
            {
                BitsPerSample = new ushort[] { 1 },
                Compression = TiffCompressions.CcittFax3,
                Photometric = TiffPhotometrics.MinIsBlack,
                PlanarConfiguration = TiffPlanarConfigs.Contiguous,
                ByteOrder = TiffByteOrder.LittleEndian
            };
            using (TiffImage src2 = (TiffImage)Image.Load(inputPaths[1]))
            {
                TiffFrame frame2 = new TiffFrame(src2.ActiveFrame, options2);
                frames.Add(frame2);
            }

            // Create combined TIFF image from the frames
            using (TiffImage combined = new TiffImage(frames.ToArray()))
            {
                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the combined image
                combined.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}