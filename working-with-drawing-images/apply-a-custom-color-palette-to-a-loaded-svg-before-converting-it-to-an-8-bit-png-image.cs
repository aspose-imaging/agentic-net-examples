using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to SvgImage to access vector-specific methods
            SvgImage svgImage = (SvgImage)image;

            // Create a custom 8‑bit grayscale palette (can be replaced with any IColorPalette)
            IColorPalette customPalette = Aspose.Imaging.ColorPaletteHelper.Create8BitGrayscale(false);

            // Apply the palette to the SVG; updateColors = true to remap existing colors
            svgImage.SetPalette(customPalette, true);

            // Prepare PNG save options for an 8‑bit indexed PNG
            PngOptions pngOptions = new PngOptions
            {
                // Use indexed color type
                ColorType = Aspose.Imaging.FileFormats.Png.PngColorType.IndexedColor,
                // Assign the same palette used for the SVG
                Palette = customPalette,
                // Optional: set compression level (0‑9)
                CompressionLevel = 9
            };

            // Save the rasterized PNG
            svgImage.Save(outputPath, pngOptions);
        }
    }
}