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
        // Hard‑coded input and output paths
        string inputPath = "input.png";
        string outputPath = "output/output.svg";

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
            // Cast to RasterImage to access pixel data
            RasterImage raster = (RasterImage)image;

            // Generate a 16‑color palette using the histogram method
            IColorPalette palette = ColorPaletteHelper.GetCloseImagePalette(
                raster,
                16,
                PaletteMiningMethod.Histogram);

            // Save the image as SVG, applying the generated palette
            image.Save(outputPath, new SvgOptions
            {
                Palette = palette
            });
        }
    }
}