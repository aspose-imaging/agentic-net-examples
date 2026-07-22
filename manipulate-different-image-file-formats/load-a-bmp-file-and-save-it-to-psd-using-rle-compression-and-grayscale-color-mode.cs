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
            // Hardcoded input and output paths
            string inputPath = @"c:\temp\sample.bmp";
            string outputPath = @"c:\temp\output.psd";

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
                // Configure PSD save options
                PsdOptions psdOptions = new PsdOptions
                {
                    CompressionMethod = Aspose.Imaging.FileFormats.Psd.CompressionMethod.RLE,
                    ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Grayscale
                };

                // Save as PSD with the specified options
                image.Save(outputPath, psdOptions);
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
 * 1. When a developer needs to convert legacy BMP assets into Photoshop‑compatible PSD files with lossless RLE compression and a grayscale color mode for print‑ready workflows.
 * 2. When an application must batch‑process scanned black‑and‑white BMP images and save them as compressed PSD layers to reduce file size while preserving image fidelity.
 * 3. When integrating a C# service that receives BMP uploads and stores them as PSD files for downstream editing in Adobe Photoshop with grayscale mode enabled.
 * 4. When creating a migration tool that transforms BMP graphics from an old catalog into PSD format using Aspose.Imaging, applying RLE compression to meet storage constraints.
 * 5. When building a .NET utility that prepares BMP textures for game art pipelines by converting them to PSD with grayscale mode and RLE compression for efficient asset management.
 */