// HOW-TO: Select Color Region With Magic Wand Threshold 30 In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.MagicWand;

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
                MagicWandSettings settings = new MagicWandSettings(50, 50) { Threshold = 30 };
                MagicWandTool.Select(image, settings).Apply();
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
 * 1. When you need to automatically select and isolate a solid‑color area in a PNG image for background removal using C#.
 * 2. When you want to create a mask around a specific region of a raster image by defining a seed point and custom tolerance.
 * 3. When you are building a photo‑editing tool that lets users click a point and select all similar pixels with a threshold of 30.
 * 4. When you must extract a colored logo from a scanned image by selecting pixels around a known coordinate in .NET.
 * 5. When you need to batch‑process images to highlight a target color region before applying further filters or effects.
 */
