using System;
using System.IO;
using Aspose.Imaging;
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
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Build mask: select, union, subtract a rectangle, feather, then apply
                MagicWandTool.Select(image, new MagicWandSettings(100, 100))
                    .Union(new MagicWandSettings(200, 200))
                    .Subtract(new RectangleMask(10, 10, 50, 50))
                    .GetFeathered(new FeatheringSettings() { Size = 5 })
                    .Apply();

                // Save the masked image
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
 * 1. When a developer needs to automatically remove a logo from PNG screenshots by selecting a region, subtracting a rectangle, and feathering the edges before saving the cleaned image.
 * 2. When a developer wants to combine multiple user‑drawn selections on a JPEG photo, apply a soft feathered border, and export the result for web publishing.
 * 3. When a developer must create a mask that excludes a watermark area from a TIFF scan, using union and subtraction operations to preserve the surrounding content.
 * 4. When a developer is building a batch‑processing tool that applies consistent feathered masks to a series of BMP files to prepare them for machine‑learning training.
 * 5. When a developer needs to integrate mask‑based background removal into a C# desktop app, using the reusable library to perform union, subtract, and feathering steps on loaded images before saving as PNG.
 */