// HOW-TO: Convert BMP to Grayscale PSD with RLE Compression and Verify in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\temp\sample.bmp";
            string outputPath = @"C:\temp\output.psd";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PSD saving options
                PsdOptions psdOptions = new PsdOptions
                {
                    CompressionMethod = Aspose.Imaging.FileFormats.Psd.CompressionMethod.RLE,
                    ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Grayscale
                };

                // Save as PSD
                image.Save(outputPath, psdOptions);
            }

            // Attempt to load the saved PSD to verify it can be opened
            using (Image psdImage = Image.Load(outputPath))
            {
                // Simple validation: output dimensions
                Console.WriteLine($"PSD loaded successfully. Size: {psdImage.Width}x{psdImage.Height}");
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
 * 1. When you need to transform legacy BMP assets into Photoshop‑compatible PSD files while preserving grayscale data and using lossless RLE compression.
 * 2. When an automated pipeline must generate PSD files from source images and confirm they can be opened by Photoshop before further processing.
 * 3. When you are building a batch conversion tool that standardizes image color mode to grayscale for consistent editing in Adobe Photoshop.
 * 4. When you want to ensure that converted PSD files meet size and dimension expectations by loading them immediately after saving.
 * 5. When integrating Aspose.Imaging into a C# application to replace manual Photoshop imports with programmatic PSD creation and validation.
 */
