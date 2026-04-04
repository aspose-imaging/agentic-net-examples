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
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.png";

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

            // Create a custom 8‑bit grayscale palette (can be replaced with any custom palette)
            IColorPalette customPalette = Aspose.Imaging.ColorPaletteHelper.Create8BitGrayscale(false);

            // Apply the custom palette to the SVG; updateColors = true to adjust existing colors
            svgImage.SetPalette(customPalette, true);

            // Prepare PNG save options for an 8‑bit indexed PNG
            PngOptions pngOptions = new PngOptions
            {
                ColorType = PngColorType.IndexedColor, // Use indexed color type
                Palette = customPalette                 // Assign the same palette used for the SVG
            };

            // Save the rasterized PNG image
            svgImage.Save(outputPath, pngOptions);
        }
    }
}