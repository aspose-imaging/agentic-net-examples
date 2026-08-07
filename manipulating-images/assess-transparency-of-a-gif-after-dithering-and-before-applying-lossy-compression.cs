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
            // Hardcoded input and output paths
            string inputPath = @"c:\temp\sample.gif";
            string ditheredOutputPath = @"c:\temp\sample.dithered.png";
            string lossyGifOutputPath = @"c:\temp\sample.lossy.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(ditheredOutputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(lossyGifOutputPath));

            // Load the GIF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to GifImage to access GIF‑specific members
                GifImage gifImage = (GifImage)image;

                // Apply dithering (Floyd‑Steinberg, 4‑bit palette, no custom palette)
                gifImage.Dither(DitheringMethod.FloydSteinbergDithering, 4, null);

                // Assess transparency after dithering
                bool hasTransparency = gifImage.HasTransparentColor;
                Console.WriteLine($"Has transparent color after dithering: {hasTransparency}");

                // Save the dithered image as PNG (lossless)
                PngOptions pngOptions = new PngOptions();
                gifImage.Save(ditheredOutputPath, pngOptions);

                // Prepare GIF options for lossy compression
                GifOptions gifOptions = new GifOptions
                {
                    // Enable palette correction for better color matching
                    DoPaletteCorrection = true,
                    // Set maximum pixel difference to trigger lossy compression
                    MaxDiff = 80
                };

                // Save the same image as a lossy GIF
                gifImage.Save(lossyGifOutputPath, gifOptions);
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
 * 1. When a developer needs to verify whether a GIF retains any transparent pixels after applying Floyd‑Steinberg dithering before converting it to a lossy GIF for web delivery.
 * 2. When an image‑processing pipeline must ensure that a dithered animation’s transparency flag is preserved before saving a lossless PNG preview for quality control.
 * 3. When optimizing animated graphics for email newsletters, a programmer uses this code to check transparency after palette reduction so that the subsequent lossy GIF compression does not unintentionally remove transparent areas.
 * 4. When building a content‑management system that automatically generates thumbnails, the code helps confirm that a dithered GIF still has a transparent background before creating a PNG thumbnail and a compressed GIF version.
 * 5. When troubleshooting color‑banding issues in a GIF conversion tool, a developer runs this snippet to detect transparent colors after dithering, ensuring that the lossy compression step respects the original image’s alpha channel.
 */