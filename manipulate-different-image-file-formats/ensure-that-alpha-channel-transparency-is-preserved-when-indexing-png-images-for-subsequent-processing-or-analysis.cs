using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output_indexed.png";

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
            // Cast to PngImage to access PNG‑specific properties
            if (image is PngImage pngImage)
            {
                // Report whether the source image has an alpha channel
                Console.WriteLine($"Source PNG has alpha: {pngImage.HasAlpha}");

                // Prepare options for indexed‑color PNG while preserving transparency
                var pngOptions = new PngOptions
                {
                    // Use indexed color type
                    ColorType = PngColorType.IndexedColor,
                    // Enable maximum compression (optional)
                    CompressionLevel = 9,
                    // Generate a palette that includes transparent entries if needed
                    Palette = ColorPaletteHelper.GetCloseImagePalette((RasterImage)pngImage, 256, PaletteMiningMethod.Histogram)
                };

                // Save the image with the specified options
                image.Save(outputPath, pngOptions);
                Console.WriteLine($"Indexed PNG saved to: {outputPath}");
            }
            else
            {
                Console.Error.WriteLine("The loaded image is not a PNG image.");
            }
        }
    }
}