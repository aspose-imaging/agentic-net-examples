// HOW-TO: Save GIF With Custom Color Depth And Floyd Steinberg Dithering In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.gif";
            string outputPath = @"C:\Images\Result\output.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // If the image is a GIF, apply dithering for quality control
                if (image is GifImage gifImage)
                {
                    // Apply Floyd‑Steinberg dithering with a 4‑bit palette
                    gifImage.Dither(DitheringMethod.FloydSteinbergDithering, 4, null);
                }

                // Configure GIF saving options
                GifOptions saveOptions = new GifOptions
                {
                    // Set color depth (bits per primary color minus 1). 7 => 8 bits per channel.
                    ColorResolution = 7,
                    // Enable palette correction for better color matching
                    DoPaletteCorrection = true,
                    // Save as interlaced GIF (optional)
                    Interlaced = true,
                    // Use lossy compression with a moderate max difference
                    MaxDiff = 80
                };

                // Save the image as GIF using the configured options
                image.Save(outputPath, saveOptions);
            }

            Console.WriteLine("GIF saved successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to reduce the file size of an animated GIF while preserving visual quality by controlling the palette and applying dithering.
 * 2. When you want to ensure consistent colors across different browsers by correcting the GIF palette during export.
 * 3. When you need to create interlaced GIFs that load progressively on slow connections.
 * 4. When you are generating GIFs with a specific bits‑per‑channel setting (e.g., 8‑bit per channel) for compatibility with legacy systems.
 * 5. When you must apply lossy compression with a defined maximum color difference to balance quality and compression for web delivery.
 */
