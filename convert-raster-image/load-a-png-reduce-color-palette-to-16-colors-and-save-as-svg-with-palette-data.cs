using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = "input.png";
            string outputPath = "output.svg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to work with palettes
                RasterImage raster = (RasterImage)image;

                // Create a 16‑color palette using the histogram mining method
                IColorPalette palette = ColorPaletteHelper.GetCloseImagePalette(
                    raster,
                    16,
                    PaletteMiningMethod.Histogram);

                // Prepare SVG save options and assign the palette
                var svgOptions = new SvgOptions
                {
                    Palette = palette
                };

                // Save the image as SVG with the reduced palette
                image.Save(outputPath, svgOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}