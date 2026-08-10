// HOW-TO: Apply Custom Color Palette to SVG and Convert to 8‑Bit PNG in C# (Aspose.Imaging for .NET)
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

        // Validate input file existence
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
                SvgImage svgImage = (SvgImage)image;

                // Create a custom 8‑bit palette (you can replace this with any custom palette)
                IColorPalette customPalette = ColorPaletteHelper.Create8Bit();

                // Apply the palette to the SVG; updateColors = true to remap existing colors
                svgImage.SetPalette(customPalette, true);

                // Prepare PNG options for 8‑bit indexed color output
                PngOptions pngOptions = new PngOptions
                {
                    ColorType = PngColorType.IndexedColor,
                    Palette = customPalette,
                    // BitsPerChannel defaults to 8, which is suitable for 8‑bit PNG
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
 * 1. When you need to recolor an SVG with a specific 256‑color palette before delivering it as a lightweight 8‑bit PNG for web or mobile use.
 * 2. When generating thumbnails for a large SVG catalog and want consistent branding colors while keeping file size minimal.
 * 3. When preparing graphics for embedded systems that only support indexed‑color PNGs and require a custom palette to match the device’s display.
 * 4. When automating a batch process that converts SVG assets to PNGs with exact color mapping for print‑ready proofs.
 * 5. When integrating Aspose.Imaging in a C# application to replace default SVG colors with corporate brand colors and export them as indexed PNGs for faster loading.
 */
