using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.png";

        // Ensure input file exists
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
                // Cast to SvgImage to access SetPalette
                if (image is SvgImage svgImage)
                {
                    // Create a custom 8‑bit palette (you can replace this with any custom palette)
                    IColorPalette customPalette = ColorPaletteHelper.Create8Bit();

                    // Apply the palette and update colors
                    svgImage.SetPalette(customPalette, true);
                }

                // Prepare PNG options for 8‑bit indexed color
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.IndexedColor,
                    // Use the same palette for the PNG output
                    Palette = ColorPaletteHelper.Create8Bit()
                };

                // Save the image as an 8‑bit PNG
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
 * 1. When a web application must generate low‑size thumbnail PNGs from user‑uploaded SVG icons while preserving brand colors using a custom 8‑bit palette.
 * 2. When a mobile game needs to convert vector assets (SVG) to indexed‑color PNGs for faster loading and reduced memory footprint on low‑end devices.
 * 3. When an e‑commerce platform wants to batch‑process product vector illustrations into web‑optimized 8‑bit PNGs with a specific corporate color scheme.
 * 4. When a reporting tool has to embed SVG charts into PDF documents that only support indexed PNG images, requiring palette mapping via Aspose.Imaging for .NET.
 * 5. When a legacy printing system only accepts 8‑bit PNG files, and developers must translate modern SVG logos into that format while applying a custom palette to match printer color profiles.
 */