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
        try
        {
            // Hardcoded paths
            string inputPath = @"c:\temp\source.tif";   // placeholder input
            string outputPath = @"c:\temp\scanned_output.tif";

            // Input validation
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure options for a CCITT Group 4 compressed B/W frame
            TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
            frameOptions.Compression = TiffCompressions.CcittFax4;          // Group 4
            frameOptions.Photometric = TiffPhotometrics.MinIsBlack;        // 0 = black, 1 = white
            frameOptions.BitsPerSample = new ushort[] { 1 };               // 1‑bit per pixel
            frameOptions.ByteOrder = TiffByteOrder.LittleEndian;           // typical for fax

            // Create a frame with custom dimensions
            int frameWidth = 1024;   // custom width
            int frameHeight = 768;   // custom height
            TiffFrame frame = new TiffFrame(frameOptions, frameWidth, frameHeight);

            // Set DPI values for scanning quality
            frame.HorizontalResolution = 300; // 300 DPI horizontal
            frame.VerticalResolution = 300;   // 300 DPI vertical

            // Assemble the TIFF image and save
            using (TiffImage tiffImage = new TiffImage(frame))
            {
                tiffImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}