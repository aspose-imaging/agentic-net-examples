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
            string inputPath = @"C:\temp\sample.gif";
            string outputPath = @"C:\temp\sample.dithered.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the GIF image
            using (Image image = Image.Load(inputPath))
            {
                GifImage gifImage = (GifImage)image;

                // Apply dithering (example: Floyd‑Steinberg with a 4‑bit palette)
                gifImage.Dither(DitheringMethod.FloydSteinbergDithering, 4, null);

                // Assess transparency after dithering
                bool hasTransparency = gifImage.HasTransparentColor;
                Console.WriteLine($"Has transparent color after dithering: {hasTransparency}");

                // Save the dithered image without lossy compression (MaxDiff = 0)
                GifOptions saveOptions = new GifOptions
                {
                    MaxDiff = 0,               // lossless
                    DoPaletteCorrection = true,
                    ColorResolution = 7       // typical value
                };

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
 * 1. When a web developer needs to ensure that a GIF used in an animated banner retains its transparent background after applying Floyd‑Steinberg dithering before optimizing the file size.
 * 2. When a mobile app developer wants to verify that a user‑uploaded GIF keeps its transparent color after reducing the palette to 4‑bit for faster rendering on low‑end devices.
 * 3. When a game UI designer must confirm that a sprite sheet saved as a GIF remains transparent after dithering, so the sprites blend correctly with the game background.
 * 4. When an e‑learning content creator needs to check that instructional GIFs preserve transparency after palette correction and before saving with lossless compression to meet accessibility standards.
 * 5. When a digital marketing analyst automates batch processing of promotional GIFs and wants to detect any loss of transparency caused by dithering before applying lossy compression for email campaigns.
 */