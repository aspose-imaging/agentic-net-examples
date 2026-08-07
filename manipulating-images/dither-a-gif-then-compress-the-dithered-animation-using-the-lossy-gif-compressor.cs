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
        string outputPath = @"C:\temp\output.lossy.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the GIF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to GifImage to access GIF-specific methods
                GifImage gifImage = (GifImage)image;

                // Apply Floyd‑Steinberg dithering with 8‑bit palette
                gifImage.Dither(DitheringMethod.FloydSteinbergDithering, 8, null);

                // Configure lossy GIF compression
                GifOptions saveOptions = new GifOptions
                {
                    MaxDiff = 80 // Recommended value for optimal lossy compression
                };

                // Save the dithered image using lossy compression
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
 * 1. When a developer needs to shrink an animated GIF for faster web page loading while preserving visual fidelity by applying Floyd‑Steinberg dithering and lossy GIF compression in C#.
 * 2. When a mobile app must generate low‑bandwidth GIF stickers from high‑resolution sources, using Aspose.Imaging to dither frames to an 8‑bit palette and then compress them with a MaxDiff setting.
 * 3. When an email marketing system wants to embed animated GIFs that stay under a strict size limit, the code can dither the animation and apply lossy compression to meet the constraint.
 * 4. When a game developer creates sprite animations and needs to export them as optimized GIFs for in‑game cutscenes, this example shows how to dither and compress the GIF in .NET.
 * 5. When a content management platform automatically processes user‑uploaded GIFs to ensure they are web‑friendly, this routine can be used to dither and compress each animation before storage.
 */