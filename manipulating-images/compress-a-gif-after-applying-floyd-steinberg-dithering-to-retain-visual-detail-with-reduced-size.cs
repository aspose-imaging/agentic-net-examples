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
        string outputPath = @"C:\temp\output_compressed.gif";

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

                // Apply Floyd‑Steinberg dithering with an 8‑bit palette (256 colors)
                gifImage.Dither(DitheringMethod.FloydSteinbergDithering, 8, null);

                // Configure GIF saving options for lossy compression
                var saveOptions = new GifOptions
                {
                    // Enable palette correction for better visual quality
                    DoPaletteCorrection = true,
                    // Set maximum pixel difference to trigger lossy compression (recommended 80)
                    MaxDiff = 80
                };

                // Save the processed image with compression
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
 * 1. When a developer needs to reduce the file size of an animated GIF for faster web page loading while preserving visual detail, they can apply Floyd‑Steinberg dithering and lossy compression using Aspose.Imaging in C#.
 * 2. When preparing GIF assets for email newsletters where attachment size limits apply, this code lets you shrink the GIF by dithering to an 8‑bit palette and setting a MaxDiff threshold.
 * 3. When optimizing GIFs for mobile apps to minimize bandwidth consumption, a developer can use the example to apply palette correction and lossy compression before saving the image.
 * 4. When converting high‑resolution GIFs from a design tool into lightweight versions for social media sharing, the code demonstrates how to load, dither, and compress the GIF in a .NET environment.
 * 5. When building an automated image‑processing pipeline that archives GIFs with reduced storage cost, this snippet shows how to programmatically apply Floyd‑Steinberg dithering and configure GifOptions for efficient C# processing.
 */