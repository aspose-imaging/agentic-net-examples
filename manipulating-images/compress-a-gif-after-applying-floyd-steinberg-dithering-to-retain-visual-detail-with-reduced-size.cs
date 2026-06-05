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

                // Apply Floyd‑Steinberg dithering with an 8‑bit palette (high quality)
                gifImage.Dither(DitheringMethod.FloydSteinbergDithering, 8, null);

                // Set lossy compression options
                GifOptions saveOptions = new GifOptions
                {
                    // Recommended value for good quality/size trade‑off
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
 * 1. When a web developer must reduce the bandwidth of animated GIFs for faster page loads while preserving visual fidelity, they can apply Floyd‑Steinberg dithering and set MaxDiff compression using Aspose.Imaging for .NET.
 * 2. When an email‑marketing system needs to attach lightweight GIF banners that still look sharp on low‑resolution screens, the code can dither the image to an 8‑bit palette and compress it with a configurable MaxDiff value.
 * 3. When a mobile app generates GIF previews from user‑uploaded videos and must keep the file size under a network limit, developers can use this C# snippet to dither and compress the GIF before saving.
 * 4. When a content‑management platform automatically optimizes uploaded GIF assets for CDN distribution, the code provides a repeatable way to apply Floyd‑Steinberg dithering and lossy compression with Aspose.Imaging.
 * 5. When a game developer creates sprite animations stored as GIFs and wants to minimize the game's download size without noticeable quality loss, they can employ this example to dither and compress the files in a .NET build pipeline.
 */