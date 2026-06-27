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
            string inputPath = @"C:\Images\input.gif";
            string outputPath = @"C:\Images\output_contrast.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the GIF image (may contain multiple frames)
            using (Image image = Image.Load(inputPath))
            {
                // Cast to GifImage to access GIF-specific methods
                GifImage gifImage = (GifImage)image;

                // Increase contrast (value in range [-100, 100])
                gifImage.AdjustContrast(50f);

                // Save the modified GIF preserving animation
                gifImage.Save(outputPath, new GifOptions
                {
                    // Enable palette correction for better color quality
                    DoPaletteCorrection = true,
                    // Preserve all frames
                    FullFrame = true
                });
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
 * 1. When a developer wants to use Aspose.Imaging for .NET to boost the contrast of an animated GIF before embedding it in a marketing email.
 * 2. When a developer needs to preprocess user‑uploaded GIF files with Aspose.Imaging to make overlaid text more readable by increasing contrast while keeping the animation intact.
 * 3. When a developer is generating product demo slideshows and uses Aspose.Imaging to enhance each frame’s tones by adjusting contrast in the GIF sequence.
 * 4. When a developer prepares GIF assets for a mobile game and applies Aspose.Imaging’s AdjustContrast method to achieve richer colors without losing frame timing.
 * 5. When a developer automates batch processing of GIFs for a social‑media scheduler, using Aspose.Imaging to increase contrast and enable palette correction in C#.
 */