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
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                MagicWandTool.Select(image, new MagicWandSettings(100, 100))
                    .Subtract(new MagicWandSettings(200, 200) { Threshold = 30 })
                    .Subtract(new RectangleMask(50, 50, 100, 100))
                    .GetFeathered(new FeatheringSettings() { Size = 5 })
                    .Apply();

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
 * 1. When a developer needs to remove a background from a product photo with irregular edges and then soften the transition to avoid harsh lines, they can chain Subtract and GetFeathered on a PNG image.
 * 2. When preparing scanned documents that contain stamps or seals with jagged borders, chaining Subtract to cut out the unwanted area and GetFeathered to smooth the mask ensures clean extraction for OCR.
 * 3. When creating a composite image for a marketing brochure, a designer can use Subtract to eliminate overlapping objects and then apply GetFeathered to blend the remaining mask seamlessly with the new background.
 * 4. When automating the removal of watermarks from legacy JPEG assets that have complex contours, chaining Subtract with a custom threshold and GetFeathered produces a refined mask that preserves surrounding details.
 * 5. When developing an image‑editing tool that lets users click to select a region, using Subtract to fine‑tune the selection and GetFeathered to add a soft edge improves the visual quality of the final PNG output.
 */