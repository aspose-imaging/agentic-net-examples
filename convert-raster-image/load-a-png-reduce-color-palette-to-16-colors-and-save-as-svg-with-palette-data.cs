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
        try
        {
            // Hard‑coded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access pixel data
                RasterImage raster = (RasterImage)image;

                // Generate a 16‑color palette using the histogram mining method
                IColorPalette palette = ColorPaletteHelper.GetCloseImagePalette(
                    raster,
                    16,
                    PaletteMiningMethod.Histogram);

                // Prepare SVG save options and attach the palette
                SvgOptions svgOptions = new SvgOptions
                {
                    // The Palette property is available on ImageOptionsBase
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