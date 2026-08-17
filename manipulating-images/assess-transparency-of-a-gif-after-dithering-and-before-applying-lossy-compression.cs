// HOW-TO: Check GIF Transparency After Dithering Before Lossy Compression in C# (Aspose.Imaging for .NET)
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
            string inputGifPath = @"c:\temp\input.gif";
            string ditheredPngPath = @"c:\temp\dithered.png";
            string lossyGifPath = @"c:\temp\output.lossy.gif";

            // Verify input file exists
            if (!File.Exists(inputGifPath))
            {
                Console.Error.WriteLine($"File not found: {inputGifPath}");
                return;
            }

            // Load the GIF image
            using (Image image = Image.Load(inputGifPath))
            {
                // Cast to GifImage to access GIF‑specific members
                GifImage gifImage = (GifImage)image;

                // Apply Floyd‑Steinberg dithering with a 1‑bit palette
                gifImage.Dither(DitheringMethod.FloydSteinbergDithering, 1, null);

                // Assess transparency after dithering
                bool hasTransparency = gifImage.HasTransparentColor;
                Console.WriteLine($"Has transparent color after dithering: {hasTransparency}");

                // Ensure output directory exists before saving PNG
                Directory.CreateDirectory(Path.GetDirectoryName(ditheredPngPath));
                // Save the dithered image as PNG (lossless)
                gifImage.Save(ditheredPngPath, new PngOptions());

                // Prepare GIF options for lossy compression
                GifOptions gifOptions = new GifOptions
                {
                    // Enable palette correction for better color matching
                    DoPaletteCorrection = true,
                    // Set a moderate loss level (recommended 80)
                    MaxDiff = 80
                };

                // Ensure output directory exists before saving lossy GIF
                Directory.CreateDirectory(Path.GetDirectoryName(lossyGifPath));
                // Save the image as a lossy GIF
                gifImage.Save(lossyGifPath, gifOptions);
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
 * 1. When you need to verify whether a GIF retains any transparent pixels after applying Floyd‑Steinberg dithering before further compression.
 * 2. When you want to generate a lossless PNG preview of a dithered GIF to compare visual quality before creating a smaller lossy GIF.
 * 3. When you are building an automated pipeline that must decide if palette correction is required based on the presence of transparency after dithering.
 * 4. When you need to apply moderate lossy compression to a GIF while preserving transparency information detected earlier in the workflow.
 * 5. When you are troubleshooting image‑processing bugs and need to log the transparency state of a GIF at a specific stage of the conversion process.
 */
