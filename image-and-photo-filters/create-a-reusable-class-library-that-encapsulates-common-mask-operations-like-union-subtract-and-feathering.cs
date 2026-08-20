// HOW-TO: Create Combined Feathered Mask on PNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                var mask = MagicWandTool.Select(image, new MagicWandSettings(100, 100))
                    .Union(new MagicWandSettings(200, 200))
                    .Subtract(new RectangleMask(0, 0, 50, 50))
                    .GetFeathered(new FeatheringSettings() { Size = 5 });

                mask.Apply();

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
 * 1. When you need to merge multiple selection areas, subtract a rectangle, and feather the edges before saving a transparent PNG.
 * 2. When you want to programmatically remove a specific region from a complex mask and apply a smooth feathered transition.
 * 3. When you are building a reusable C# library that encapsulates union, subtraction, and feathering operations on image masks.
 * 4. When you require automated mask creation for photo‑editing workflows that demand precise region blending and soft edges.
 * 5. When you aim to automate background removal with custom mask shapes and feathered boundaries in a .NET application.
 */
