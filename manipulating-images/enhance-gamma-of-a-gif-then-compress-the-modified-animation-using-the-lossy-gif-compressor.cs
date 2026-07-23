using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.gif";
            string outputLosslessPath = "output_gamma.gif";
            string outputLossyPath = "output_gamma_lossy.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the GIF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to GifImage to access GIF-specific methods
                GifImage gifImage = (GifImage)image;

                // Adjust gamma (example value 2.2f)
                gifImage.AdjustGamma(2.2f);

                // Prepare lossless save options (default options)
                var losslessOptions = new GifOptions
                {
                    // Optional: enable palette correction for better quality
                    DoPaletteCorrection = true
                };

                // Ensure output directory exists for lossless file
                Directory.CreateDirectory(Path.GetDirectoryName(outputLosslessPath) ?? ".");

                // Save the gamma‑adjusted image losslessly
                gifImage.Save(outputLosslessPath, losslessOptions);
                Console.WriteLine($"Lossless GIF saved: {outputLosslessPath}");

                // Prepare lossy save options
                var lossyOptions = new GifOptions
                {
                    DoPaletteCorrection = true,
                    MaxDiff = 80 // Recommended value for lossy compression
                };

                // Ensure output directory exists for lossy file
                Directory.CreateDirectory(Path.GetDirectoryName(outputLossyPath) ?? ".");

                // Save the same image with lossy compression
                gifImage.Save(outputLossyPath, lossyOptions);
                Console.WriteLine($"Lossy GIF saved: {outputLossyPath}");
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
 * 1. When a web developer wants to improve the visual brightness of an animated GIF for better contrast on high‑contrast displays and then reduce its file size with lossy GIF compression for faster page loads.
 * 2. When a mobile app team needs to preprocess user‑uploaded GIF stickers by applying a gamma correction of 2.2 and then applying Aspose.Imaging’s lossy GIF compressor to stay within bandwidth limits.
 * 3. When an e‑learning platform must enhance the color balance of animated instructional GIFs and simultaneously shrink the files using the MaxDiff setting to meet LMS storage quotas.
 * 4. When a digital marketing agency prepares promotional GIF banners, they can use this code to adjust gamma for brand‑consistent colors and then compress the animation lossily to meet email size restrictions.
 * 5. When a game developer integrates animated GIF assets into a UI, they can use the snippet to correct gamma for consistent lighting across devices and apply lossy compression to keep the game’s download size low.
 */