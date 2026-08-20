// HOW-TO: Compress GIF With Floyd Steinberg Dithering And Lossy Palette In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.gif";
        string outputPath = @"C:\temp\output.gif";

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

            // Load the GIF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to GifImage to access GIF‑specific methods
                GifImage gifImage = (GifImage)image;

                // Apply Floyd‑Steinberg dithering with an 8‑bit palette (full color depth)
                gifImage.Dither(DitheringMethod.FloydSteinbergDithering, 8, null);

                // Configure GIF saving options for lossy compression
                GifOptions saveOptions = new GifOptions
                {
                    // Enable palette correction for better color matching
                    DoPaletteCorrection = true,
                    // Set maximum pixel difference to trigger lossy compression (recommended 80)
                    MaxDiff = 80
                };

                // Save the processed image using the configured options
                gifImage.Save(outputPath, saveOptions);
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
 * 1. When you need to reduce the file size of animated GIFs for faster web page loading while preserving visual quality through Floyd‑Steinberg dithering.
 * 2. When you want to generate optimized GIFs for email newsletters that must stay under attachment size limits without noticeable color banding.
 * 3. When you are building a C# batch‑processing tool that automatically compresses user‑uploaded GIFs before storing them in a cloud bucket.
 * 4. When you need to apply palette correction and lossy compression to GIFs created from high‑resolution screenshots to meet mobile app bandwidth constraints.
 * 5. When you are converting a series of GIF frames into a smaller animated file for social‑media sharing, using Aspose.Imaging’s Dither and MaxDiff settings.
 */
