using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputPath = @"c:\temp\input.gif";
        string ditheredPngPath = @"c:\temp\dithered.png";
        string lossyGifPath = @"c:\temp\dithered_lossy.gif";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the GIF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to GifImage to access GIF‑specific members
                GifImage gifImage = (GifImage)image;

                // Apply Floyd‑Steinberg dithering with a 4‑bit palette
                gifImage.Dither(DitheringMethod.FloydSteinbergDithering, 4, null);

                // Assess transparency after dithering
                bool hasTransparency = gifImage.HasTransparentColor;
                Console.WriteLine($"Has transparent color after dithering: {hasTransparency}");

                // Ensure output directory exists for PNG
                Directory.CreateDirectory(Path.GetDirectoryName(ditheredPngPath));
                // Save the dithered image as PNG (lossless) for inspection
                gifImage.Save(ditheredPngPath, new PngOptions());

                // Prepare GIF options for lossy compression
                GifOptions gifOptions = new GifOptions
                {
                    // Enable palette correction for better color matching
                    DoPaletteCorrection = true,
                    // Set maximum pixel difference to trigger lossy compression
                    MaxDiff = 80
                };

                // Ensure output directory exists for lossy GIF
                Directory.CreateDirectory(Path.GetDirectoryName(lossyGifPath));
                // Save the dithered image as a lossy GIF
                gifImage.Save(lossyGifPath, gifOptions);
                Console.WriteLine("Lossy GIF saved successfully.");
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
 * 1. When a web developer needs to verify that a GIF retains its transparent background after applying Floyd‑Steinberg dithering before converting it to a lossy GIF for faster page loads.
 * 2. When a mobile app programmer wants to ensure that a dithered GIF’s transparency flag is still set before saving a compressed version to reduce bandwidth usage on cellular networks.
 * 3. When a game UI designer must check that a palette‑reduced GIF used for sprite animation keeps its transparent pixels after dithering, so the sprite blends correctly with the game scene.
 * 4. When an e‑learning content creator needs to confirm that a GIF with a 4‑bit palette maintains transparency after dithering before exporting a smaller lossy GIF for LMS compatibility.
 * 5. When a digital marketing analyst automates image‑optimization pipelines and wants to detect loss of transparency after dithering to avoid broken transparent overlays in email newsletters.
 */