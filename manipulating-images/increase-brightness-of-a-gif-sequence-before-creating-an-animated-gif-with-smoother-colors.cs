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
        string inputPath = "input.gif";
        string outputPath = "output.gif";

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

                // Increase brightness of all frames (value range: -255 to 255)
                gifImage.AdjustBrightness(50);

                // Prepare save options with palette correction for smoother colors
                GifOptions saveOptions = new GifOptions
                {
                    DoPaletteCorrection = true,
                    // Preserve all frames (full animation)
                    FullFrame = true
                };

                // Save the adjusted animated GIF
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
 * 1. When a developer needs to brighten a low‑light animated GIF (e.g., a surveillance camera clip) before publishing it online, they can use this code to adjust the brightness of every frame and save the result with palette correction for smoother colors.
 * 2. When creating promotional social‑media content that includes an animated GIF with faded colors, a developer can increase the brightness of the entire sequence and generate a smoother‑gradient GIF using Aspose.Imaging for .NET.
 * 3. When converting a series of scanned handwritten notes into an animated GIF, a developer may need to boost the brightness to improve legibility and ensure the final GIF displays consistent colors across browsers.
 * 4. When building a web‑based meme generator that lets users upload GIFs, a developer can apply this code to automatically brighten dark frames and apply palette correction so the animated output looks vibrant on all devices.
 * 5. When processing GIF frames extracted from a video for an e‑learning module, a developer can use this snippet to uniformly raise brightness and produce an animated GIF with smoother color transitions for better visual clarity.
 */