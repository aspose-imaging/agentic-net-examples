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
        string inputPath = @"c:\temp\input.gif";
        string outputPath = @"c:\temp\output.gif";

        // Ensure any runtime exception is reported without crashing
        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the GIF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to GifImage to access GIF‑specific methods
                GifImage gifImage = (GifImage)image;

                // Apply Floyd‑Steinberg dithering with a 4‑bit palette (16 colors)
                gifImage.Dither(DitheringMethod.FloydSteinbergDithering, 4, null);

                // Prepare GIF save options with lossy compression
                GifOptions saveOptions = new GifOptions
                {
                    // Enable palette correction for better visual quality
                    DoPaletteCorrection = true,
                    // Recommended lossy compression level
                    MaxDiff = 80
                };

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the processed GIF using the specified options
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
 * 1. When a web developer wants to reduce the bandwidth of animated GIFs on a website while preserving visual detail, they can apply Floyd‑Steinberg dithering and lossy GIF compression using Aspose.Imaging for .NET.
 * 2. When a mobile app needs to bundle animated icons that must stay under a strict file‑size limit, the code can shrink the GIF by dithering to a 4‑bit palette and setting MaxDiff for controlled quality loss.
 * 3. When an e‑learning platform generates slide‑show animations from high‑resolution source GIFs, this routine ensures the output GIFs load faster by compressing them without noticeable color banding.
 * 4. When a digital marketing tool creates personalized GIF banners from user‑uploaded images, the developer can use the sample to automatically optimize each GIF for email delivery.
 * 5. When a game developer packages animated UI elements in a Unity project and wants to keep the asset bundle size low, they can run this code to dither and compress the GIFs before importing them.
 */