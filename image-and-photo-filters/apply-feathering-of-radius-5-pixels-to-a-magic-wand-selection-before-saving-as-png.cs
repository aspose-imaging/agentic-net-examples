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
            // Hardcoded input and output file paths
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

            // Load the image as a raster image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Create a magic wand selection at point (120,100), feather it with radius 5, and apply to the image
                MagicWandTool
                    .Select(image, new MagicWandSettings(120, 100))
                    .GetFeathered(new FeatheringSettings { Size = 5 })
                    .Apply();

                // Save the resulting image as PNG with alpha channel support
                image.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
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
 * 1. When a developer needs to isolate a foreground object in a PNG photograph and smooth the selection edges with a 5‑pixel feather to avoid harsh borders before exporting the image.
 * 2. When building a C# image‑editing tool that lets users click a point, uses Aspose.Imaging’s Magic Wand to select similar colors, and applies a 5‑pixel feather to create a soft transition for overlay graphics saved as a TruecolorWithAlpha PNG.
 * 3. When preparing product‑shot images for an e‑commerce site, a programmer can use the Magic Wand selection with a 5‑pixel feather to gently blend the background removal and then save the result as a PNG with transparency.
 * 4. When automating batch processing of scanned documents, a developer may apply a 5‑pixel feather to the Magic Wand selection to smooth out jagged edges around highlighted regions before saving the cleaned‑up pages as PNG files.
 * 5. When creating a C# workflow that extracts a logo from a larger PNG banner, the Magic Wand tool with a 5‑pixel feather can be used to capture the logo with softened edges and preserve the alpha channel on export.
 */