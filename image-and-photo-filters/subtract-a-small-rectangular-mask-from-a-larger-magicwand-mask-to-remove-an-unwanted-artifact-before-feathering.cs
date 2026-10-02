// HOW-TO: Subtract Rectangle Mask from Magic Wand Selection and Feather in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.png";
            string outputPath = "output\\result.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                MagicWandTool.Select(image, new MagicWandSettings(50, 50))
                    .Subtract(new RectangleMask(100, 100, 20, 10))
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
 * 1. When you need to remove a small unwanted object from a PNG image using Aspose.Imaging’s Magic Wand tool before applying a soft edge.
 * 2. When you want to clean up a scanned photograph by subtracting a rectangular region from a selection and then feather the remaining mask in C#.
 * 3. When you are preparing product images and must eliminate a logo artifact by masking it out and smoothing the border with feathering.
 * 4. When you are building an automated image‑processing pipeline that trims stray marks from screenshots and saves the result as a PNG.
 * 5. When you need to programmatically refine a Magic Wand selection by cutting out a defined rectangle and applying a 5‑pixel feather for seamless compositing.
 */
