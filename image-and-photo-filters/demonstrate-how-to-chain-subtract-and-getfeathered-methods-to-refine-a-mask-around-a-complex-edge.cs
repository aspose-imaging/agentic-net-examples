// HOW-TO: Chain Subtract and Feather Masks to Refine Complex Edge in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Ensure any runtime exception is reported cleanly
        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir ?? ".");

            // Load the source image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Build a complex mask:
                // 1. Initial selection with Magic Wand at a seed point
                // 2. Subtract another Magic Wand selection with a custom threshold
                // 3. Subtract several rectangular regions to cut away unwanted parts
                // 4. Feather the resulting mask to smooth the edge
                MagicWandTool.Select(image, new MagicWandSettings(845, 128))
                    .Subtract(new MagicWandSettings(1482, 346) { Threshold = 69 })
                    .Subtract(new RectangleMask(0, 0, 800, 150))
                    .Subtract(new RectangleMask(0, 380, 600, 220))
                    .Subtract(new RectangleMask(930, 520, 110, 40))
                    .Subtract(new RectangleMask(1370, 400, 120, 200))
                    .GetFeathered(new FeatheringSettings { Size = 3 })
                    .Apply(); // Apply the refined mask to the image

                // Save the processed image
                image.Save(outputPath);
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
 * 1. When you need to remove unwanted background areas from a PNG photograph by combining multiple Magic Wand selections and rectangular cuts, then smooth the remaining edge with feathering.
 * 2. When you want to create a precise cut‑out of an object with irregular contours for product photography, using subtraction of overlapping selections before applying a soft edge.
 * 3. When you are preparing images for web thumbnails and must eliminate stray pixels around a logo while keeping the edge gently blurred to avoid jagged artifacts.
 * 4. When you are automating batch processing of scanned documents and need to subtract noise regions and then feather the mask to preserve readable text boundaries.
 * 5. When you are developing a C# application that overlays graphics on complex shapes and requires a refined mask to ensure the overlay blends seamlessly with the original image.
 */
