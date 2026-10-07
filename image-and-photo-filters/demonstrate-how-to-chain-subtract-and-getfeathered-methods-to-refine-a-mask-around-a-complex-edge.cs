// HOW-TO: How To Refine A Mask With Subtract And Feather In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
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
                    .Subtract(new MagicWandSettings(120, 120) { Threshold = 10 })
                    .Subtract(new RectangleMask(150, 150, 30, 30))
                    .GetFeathered(new FeatheringSettings() { Size = 5 })
                    .Apply();

                image.Save(outputPath, new PngOptions());
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
 * 1. When you need to remove unwanted background regions from a PNG photo while preserving fine details by subtracting multiple selections and feathering the edge.
 * 2. When you want to create a precise cut‑out of an object with complex contours by combining magic wand selections and a rectangular mask before applying a soft feather.
 * 3. When you must generate a clean mask for compositing two images in a .NET application, using successive Subtract calls to eliminate noise and then feather the boundary.
 * 4. When you are building an automated batch process that cleans up scanned documents, removing stray marks with Subtract and smoothing the mask edges for better OCR results.
 * 5. When you are developing a photo‑editing tool that lets users fine‑tune selections, allowing them to subtract overlapping areas and apply a feathered transition to achieve a natural blend.
 */
