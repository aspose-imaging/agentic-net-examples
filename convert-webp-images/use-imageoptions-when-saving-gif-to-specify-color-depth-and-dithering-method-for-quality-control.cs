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
            string inputPath = @"C:\temp\input.gif";
            string outputPath = @"C:\temp\output.gif";

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
                // Cast to GifImage to access dithering
                GifImage gifImage = image as GifImage;
                if (gifImage != null)
                {
                    // Apply dithering (e.g., Floyd‑Steinberg with 8‑bit palette)
                    gifImage.Dither(Aspose.Imaging.DitheringMethod.FloydSteinbergDithering, 8, null);
                }

                // Configure GIF saving options
                GifOptions saveOptions = new GifOptions
                {
                    // ColorResolution = bits per primary color minus 1 (e.g., 7 => 8 bits)
                    ColorResolution = 7,
                    // Enable palette correction for better color matching
                    DoPaletteCorrection = true,
                    // Optional: make the GIF interlaced
                    Interlaced = true,
                    // Optional: set MaxDiff for lossy compression (0 = lossless)
                    MaxDiff = 0
                };

                // Save the image as GIF using the configured options
                gifImage?.Save(outputPath, saveOptions);
                // If the source wasn't a GIF, fall back to generic save
                if (gifImage == null)
                {
                    image.Save(outputPath, saveOptions);
                }
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
 * 1. When a web developer needs to generate optimized animated GIFs from user‑uploaded images while controlling color depth and applying Floyd‑Steinberg dithering to preserve visual quality.
 * 2. When a desktop application must convert legacy 8‑bit GIF assets to a consistent palette with palette correction and interlacing for faster progressive loading in browsers.
 * 3. When an e‑learning platform creates GIF screenshots of software tutorials and wants lossless compression (MaxDiff = 0) combined with a specific ColorResolution to meet branding color standards.
 * 4. When a game developer exports sprite animations as GIF files and needs to enforce a fixed 8‑bit palette and dithering to ensure the animation looks the same across different devices.
 * 5. When an automated image‑processing pipeline processes bulk GIF files and requires explicit GifOptions settings (ColorResolution, DoPaletteCorrection, Interlaced) to guarantee predictable file size and color fidelity for downstream analytics.
 */