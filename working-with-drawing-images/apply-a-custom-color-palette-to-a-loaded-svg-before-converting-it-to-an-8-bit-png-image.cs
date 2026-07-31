using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.png";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Apply a custom palette to the SVG if possible
                if (image is SvgImage svgImage)
                {
                    // Create an 8‑bit palette (you can customize this as needed)
                    var customPalette = ColorPaletteHelper.Create8Bit();

                    // Apply the palette and update existing colors
                    svgImage.SetPalette(customPalette, true);
                }

                // Configure PNG options for 8‑bit indexed color
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.IndexedColor,
                    Palette = ColorPaletteHelper.Create8Bit(), // use the same or another palette
                    CompressionLevel = 9,
                    Progressive = true
                };

                // Save as PNG
                image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to generate web‑optimized 8‑bit PNG thumbnails from brand‑styled SVG icons while enforcing a corporate color palette.
 * 2. When an application must convert user‑uploaded SVG diagrams into low‑size indexed PNGs for email attachments that require a specific palette for consistent rendering across email clients.
 * 3. When a game engine imports vector assets and requires them as 8‑bit PNG sprites with a predefined palette to match the engine’s limited color set.
 * 4. When a reporting tool transforms SVG charts into printable PNG images and must replace the original colors with a printer‑friendly palette to avoid color shifts.
 * 5. When a mobile app pre‑processes SVG assets into 8‑bit PNG resources to reduce memory usage and enforce a custom palette for theme consistency.
 */