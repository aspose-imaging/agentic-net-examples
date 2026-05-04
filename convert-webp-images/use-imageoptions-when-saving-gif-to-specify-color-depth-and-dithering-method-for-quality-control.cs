using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.gif";
            string outputPath = @"C:\temp\output.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Attempt to cast to GifImage to apply dithering
                GifImage gifImage = image as GifImage;
                if (gifImage != null)
                {
                    // Apply Floyd‑Steinberg dithering with a 4‑bit palette
                    gifImage.Dither(DitheringMethod.FloydSteinbergDithering, 4, null);
                }

                // Configure GIF saving options (color depth, palette correction, interlacing)
                GifOptions saveOptions = new GifOptions
                {
                    ColorResolution = 7,          // 8 bits per primary color (7 + 1)
                    DoPaletteCorrection = true,   // Build optimal palette
                    Interlaced = true             // Progressive display
                };

                // Save using the appropriate object
                if (gifImage != null)
                {
                    gifImage.Save(outputPath, saveOptions);
                }
                else
                {
                    image.Save(outputPath, saveOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}