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
        string inputPath = @"C:\temp\sample.bmp";
        string outputPath = @"C:\temp\output.psd";

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
                // Configure PSD save options: ZIP-like RLE compression and RGB color mode
                var psdOptions = new PsdOptions
                {
                    CompressionMethod = CompressionMethod.RLE,
                    ColorMode = ColorModes.Rgb
                };

                // Save as PSD with the specified options
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
 * 1. When a graphics pipeline receives BMP assets from legacy hardware and must convert them to layered PSD files with lossless RLE compression for Photoshop editing.
 * 2. When an e‑commerce platform needs to generate high‑quality PSD mockups from user‑uploaded BMP logos while preserving RGB color fidelity.
 * 3. When a desktop publishing application automates batch conversion of BMP scans into PSD files to enable designers to apply Photoshop filters without changing color mode.
 * 4. When a digital asset management system stores source images as BMP and requires on‑the‑fly conversion to PSD with ZIP‑style RLE compression for efficient storage and quick preview.
 * 5. When a C# service integrates Aspose.Imaging to transform BMP screenshots into PSD files that maintain RGB color space and use PSD’s built‑in RLE compression for archival purposes.
 */