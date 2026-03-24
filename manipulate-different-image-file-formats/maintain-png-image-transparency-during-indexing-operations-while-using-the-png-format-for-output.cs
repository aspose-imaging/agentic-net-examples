using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare PNG save options with indexed color and maximum compression
            PngOptions pngOptions = new PngOptions
            {
                Progressive = true,
                ColorType = PngColorType.IndexedColor,
                CompressionLevel = 9,
                // Generate a palette that best fits the source image (preserves transparency where possible)
                Palette = ColorPaletteHelper.GetCloseImagePalette(
                    (RasterImage)image,
                    256,
                    PaletteMiningMethod.Histogram)
            };

            // Save the image using the specified options
            image.Save(outputPath, pngOptions);
        }
    }
}