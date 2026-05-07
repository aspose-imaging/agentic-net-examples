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
        // Hardcoded input and output file paths
        string inputPath = "input.svg";
        string outputPath = "output.png";

        try
        {
            // Verify that the input SVG file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to SvgImage to access SetPalette
                var svgImage = image as SvgImage;
                if (svgImage == null)
                {
                    Console.Error.WriteLine("Loaded image is not an SVG.");
                    return;
                }

                // Create an 8‑bit palette (256 colors)
                var palette = Aspose.Imaging.ColorPaletteHelper.Create8Bit();

                // Apply the custom palette to the SVG; updateColors = true
                svgImage.SetPalette(palette, true);

                // Prepare PNG options for 8‑bit indexed color output
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.IndexedColor,
                    Palette = palette,
                    // Optional: set compression level (0‑9)
                    CompressionLevel = 9
                };

                // Save the rasterized image as an 8‑bit PNG
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}