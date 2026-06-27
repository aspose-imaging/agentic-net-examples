using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.gif";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the GIF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to GifImage to access GIF‑specific methods
                GifImage gifImage = (GifImage)image;

                // Deskew the image (normalize angle based on detected skew)
                gifImage.NormalizeAngle();

                // Apply Floyd‑Steinberg dithering with a 1‑bit palette
                gifImage.Dither(DitheringMethod.FloydSteinbergDithering, 1, null);

                // Save the processed image as PNG
                gifImage.Save(outputPath, new PngOptions());
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
 * 1. When a web developer needs to clean up scanned animated GIF logos that are slightly rotated and convert them to high‑contrast PNGs for faster page loads.
 * 2. When an e‑commerce platform wants to automatically correct skewed product GIF images, apply 1‑bit Floyd‑Steinberg dithering for a retro look, and store the result as PNG thumbnails.
 * 3. When a digital archivist processes historical GIF documents, normalizes their orientation, reduces colors with Floyd‑Steinberg dithering, and saves them as lossless PNG files for preservation.
 * 4. When a mobile app generates QR‑code style graphics from user‑uploaded GIFs, deskews them, applies dithering to create crisp black‑and‑white PNG assets.
 * 5. When a game developer prepares sprite sheets originally saved as GIFs, removes any skew, applies dithering for a pixel‑art aesthetic, and exports them as PNGs for use in the game engine.
 */