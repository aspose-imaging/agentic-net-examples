using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded file paths
            string inputPath = @"C:\temp\input.gif";
            string ditheredPath = @"C:\temp\output_dithered.gif";
            string lossyPath = @"C:\temp\output_lossy.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the original GIF and apply dithering
            using (Image image = Image.Load(inputPath))
            {
                GifImage gif = (GifImage)image;

                // Apply Floyd‑Steinberg dithering with an 8‑bit palette
                gif.Dither(DitheringMethod.FloydSteinbergDithering, 8, null);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(ditheredPath));

                // Save the dithered GIF (lossless)
                gif.Save(ditheredPath);
            }

            // Load the dithered GIF for lossy compression
            using (Image ditheredImage = Image.Load(ditheredPath))
            {
                // Configure lossy GIF options
                GifOptions options = new GifOptions
                {
                    MaxDiff = 80 // Recommended value for good lossy compression
                };

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(lossyPath));

                // Save the GIF using lossy compression
                ditheredImage.Save(lossyPath, options);
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
 * 1. When a developer needs to shrink an animated GIF for faster web loading by first applying Floyd‑Steinberg dithering and then using Aspose.Imaging’s lossy GIF compressor in C#.
 * 2. When an e‑commerce site wants to generate lightweight product animation thumbnails that stay under email size limits, the code dither‑processes the GIF and compresses it lossily.
 * 3. When a mobile app must cache animated stickers locally and minimize storage usage, the routine dithers the original GIF and saves it with a MaxDiff setting for lossy compression.
 * 4. When a digital marketing agency prepares GIF banners for a high‑traffic landing page and needs to balance color fidelity with bandwidth savings, they can dither the animation and apply lossy compression using Aspose.Imaging for .NET.
 * 5. When a game developer creates sprite animations in GIF format and wants to embed them in a Unity project with a reduced memory footprint, this C# code provides a simple way to dither and then compress the GIF lossily.
 */