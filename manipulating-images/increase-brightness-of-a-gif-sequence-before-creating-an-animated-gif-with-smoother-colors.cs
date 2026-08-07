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
            string inputPath = @"C:\Temp\input.gif";
            string outputPath = @"C:\Temp\output.gif";

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

                // Increase brightness uniformly for all frames (value range: -255 to 255)
                gifImage.AdjustBrightness(50);

                // Prepare GIF save options for smoother colors
                GifOptions saveOptions = new GifOptions
                {
                    // Enable palette correction to generate an optimal palette
                    DoPaletteCorrection = true,
                    // Preserve all frames (full frame mode)
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
 * 1. When a developer wants to brighten a low‑light animated GIF and ensure the resulting file has smooth colors by using Aspose.Imaging’s AdjustBrightness and palette‑correction options in C#.
 * 2. When an e‑commerce site needs to automatically enhance product showcase GIFs that are too dark before publishing them, using C# to load the GIF, increase brightness, and save with an optimal palette.
 * 3. When a social‑media app processes user‑uploaded animated stickers and must make them visually clearer while preserving all frames, leveraging Aspose.Imaging’s GifImage.AdjustBrightness and GifOptions.FullFrame in .NET.
 * 4. When a marketing automation tool generates animated email banners from legacy GIF assets and requires a uniform brightness boost and smoother color transitions via C# and Aspose.Imaging.
 * 5. When a game developer prepares animated UI elements from old GIF sprites, needing to brighten them and apply palette correction to avoid banding, using the provided C# code with Aspose.Imaging.
 */