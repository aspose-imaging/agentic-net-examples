// HOW-TO: Combine Union Subtract and Feather Masks on PNG with Aspose.Imaging C# (Aspose.Imaging for .NET)
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
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                MagicWandTool.Select(image, new MagicWandSettings(10, 10))
                    .Union(new MagicWandSettings(20, 20))
                    .Subtract(new RectangleMask(30, 30, 50, 50))
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
 * 1. When you need to programmatically merge multiple selected areas and remove a specific region from a PNG before saving it in a .NET application.
 * 2. When you want to create soft‑edged selections by feathering mask boundaries to produce smooth transitions in image composites.
 * 3. When you are building a reusable library that performs complex mask operations such as union and subtraction for automated photo editing workflows.
 * 4. When you must apply a rectangular cut‑out to an existing selection and then blend the result with the original image using Aspose.Imaging in C#.
 * 5. When you require error‑handled loading and saving of raster images while performing advanced magic wand selections and mask manipulations.
 */
