using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = "input.png";
        string outputPath = "output_compressed.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (unconditional call)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PNG compression options
            var pngOptions = new PngOptions
            {
                // Maximum compression (0‑9)
                CompressionLevel = 9,
                // Enable progressive loading (optional)
                Progressive = true,
                // Use indexed color with an optimal palette for better size reduction
                ColorType = PngColorType.IndexedColor,
                Palette = ColorPaletteHelper.GetCloseImagePalette(
                    (RasterImage)image,
                    256,
                    PaletteMiningMethod.Histogram)
            };

            // Save the image with the specified compression options
            image.Save(outputPath, pngOptions);
        }
    }
}