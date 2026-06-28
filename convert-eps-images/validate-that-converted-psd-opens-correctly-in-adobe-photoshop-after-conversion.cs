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

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PSD save options
                PsdOptions psdOptions = new PsdOptions
                {
                    CompressionMethod = CompressionMethod.RLE,
                    ColorMode = ColorModes.Rgb,
                    ChannelBitsCount = 8,
                    ChannelsCount = 4,
                    Version = 6
                };

                // Save as PSD
                image.Save(outputPath, psdOptions);
            }

            // Attempt to load the saved PSD to validate it opens correctly
            using (Image psdImage = Image.Load(outputPath))
            {
                Console.WriteLine("PSD file loaded successfully and is valid.");
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
 * 1. When a developer needs to convert legacy BMP assets to Photoshop‑compatible PSD files with RLE compression and verify the resulting file can be opened in Adobe Photoshop.
 * 2. When an automated image‑processing pipeline must generate PSD files from various source formats and ensure the output is valid before passing it to a design team.
 * 3. When a C# application has to batch‑process user‑uploaded bitmap images, save them as layered PSDs with specific color mode and channel settings, and confirm the files are readable.
 * 4. When a software integration test requires loading a saved PSD to detect any corruption after using Aspose.Imaging’s PsdOptions configuration.
 * 5. When a digital asset management system needs to store high‑quality PSD versions of BMP images and must programmatically validate that Photoshop can open the converted files.
 */