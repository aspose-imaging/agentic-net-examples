using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output/output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image as a raster image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Apply MagicWandTool with a high threshold to expand mask coverage
                MagicWandTool
                    .Select(image, new MagicWandSettings(0, 0) { Threshold = 200 })
                    .Apply();

                // Save the modified image with truecolor with alpha
                image.Save(outputPath, new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
                });
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
 * 1. When a developer needs to automatically select and mask smooth color gradients in a PNG photograph for background removal, they can raise the MagicWandTool Threshold to a high value to expand the mask coverage.
 * 2. When creating a batch process that isolates semi‑transparent UI elements in PNG assets for a game UI, a high threshold ensures the MagicWand selection captures subtle opacity variations.
 * 3. When preparing scanned artwork with gradual shading for vector tracing, increasing the MagicWand threshold helps include the entire gradient region in the mask before exporting to a truecolor PNG with alpha.
 * 4. When building an image‑editing feature that lets users click on a region of a PNG logo and automatically select the surrounding gradient for recoloring, a high MagicWand threshold expands the selection to cover the full color transition.
 * 5. When developing a server‑side service that extracts logo symbols from PNG files with soft edges for watermark detection, setting a high MagicWand threshold expands the mask to include the fuzzy gradient border.
 */