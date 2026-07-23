using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.gif";
            string outputPath = "output/animated.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load GIF, adjust gamma, and save as animated GIF
            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                // Adjust gamma for balanced luminance (example value)
                gif.AdjustGamma(2.2f);

                // Save with default GIF options
                GifOptions options = new GifOptions();
                gif.Save(outputPath, options);
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
 * 1. When a developer needs to correct the brightness of a series of frames from a low‑light camera before exporting them as an animated GIF for a web slideshow, they can use this code to adjust gamma and ensure consistent luminance.
 * 2. When an e‑learning platform wants to generate animated GIF tutorials from screen‑capture sequences that appear too dark on mobile devices, the gamma adjustment step balances the colors before saving the GIF.
 * 3. When a marketing team requires a product showcase GIF where each frame must have uniform brightness across different browsers, a C# routine that loads the GIF, applies AdjustGamma, and saves with GifOptions fulfills the need.
 * 4. When a game developer creates sprite animations from legacy GIF assets that suffer from washed‑out colors, applying a gamma correction of 2.2 before re‑encoding the animation prevents visual degradation.
 * 5. When an automated image‑processing pipeline processes user‑uploaded GIFs and needs to standardize luminance to meet accessibility guidelines, the provided Aspose.Imaging code adjusts gamma and outputs a compliant animated GIF.
 */