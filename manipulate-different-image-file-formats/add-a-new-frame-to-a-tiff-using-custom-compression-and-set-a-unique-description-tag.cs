// HOW-TO: Add New LZW Compressed Frame to Existing TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"c:\temp\input.tif";
            string outputPath = @"c:\temp\output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load existing TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Create options for the new frame with custom compression
                TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
                frameOptions.Compression = TiffCompressions.Lzw;
                frameOptions.Photometric = TiffPhotometrics.Rgb;
                frameOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
                frameOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;

                // Create a new frame (same size as existing image)
                TiffFrame newFrame = new TiffFrame(frameOptions, tiffImage.Width, tiffImage.Height);

                // Fill the new frame with a solid color (optional)
                Graphics graphics = new Graphics(newFrame);
                SolidBrush brush = new SolidBrush(Color.LightGray);
                graphics.FillRectangle(brush, newFrame.Bounds);

                // Add the new frame to the TIFF image
                tiffImage.AddFrame(newFrame);

                // Save the modified TIFF to the output path
                tiffImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to append an extra page to a multi‑page TIFF while keeping file size low by using LZW compression.
 * 2. When you must generate a TIFF document programmatically in C# and want each frame to have a consistent RGB color depth and planar configuration.
 * 3. When you are building a batch process that adds a placeholder or watermark page to existing scanned TIFF files.
 * 4. When you require a solid‑color background frame to be inserted before saving the TIFF for archival or printing workflows.
 * 5. When you need to ensure the output TIFF is saved to a specific folder, creating the directory automatically if it does not exist.
 */
