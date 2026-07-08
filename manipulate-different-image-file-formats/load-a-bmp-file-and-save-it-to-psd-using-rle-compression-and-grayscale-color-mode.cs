using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.bmp";
        string outputPath = @"c:\temp\output.psd";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PSD save options: RLE compression and Grayscale color mode
                var psdOptions = new PsdOptions
                {
                    CompressionMethod = CompressionMethod.RLE,
                    ColorMode = ColorModes.Grayscale
                };

                // Save as PSD
                image.Save(outputPath, psdOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert legacy BMP assets to Photoshop‑compatible PSD files with lossless RLE compression for inclusion in a design workflow.
 * 2. When an application must generate grayscale PSD previews from BMP images for printing pipelines that require a specific color mode.
 * 3. When a batch‑processing tool automates the migration of scanned BMP documents to PSD format while preserving file size using RLE compression.
 * 4. When a C# service creates PSD layers from BMP source files for a web‑based image editor that only supports PSD with grayscale mode.
 * 5. When a developer integrates Aspose.Imaging into a .NET project to standardize image formats by converting BMP files to PSD with RLE compression and grayscale color mode for archival purposes.
 */