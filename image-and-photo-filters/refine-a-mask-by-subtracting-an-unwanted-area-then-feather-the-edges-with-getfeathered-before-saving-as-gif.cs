// HOW-TO: How To Subtract Area From Magic Wand Mask And Feather Edges In C# (Aspose.Imaging for .NET)
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
        string outputPath = "output/output.gif";

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
                    .Subtract(new RectangleMask(20, 20, 50, 50))
                    .GetFeathered(new FeatheringSettings() { Size = 5 })
                    .Apply();

                image.Save(outputPath, new GifOptions());
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
 * 1. When you need to remove a specific rectangular region from a selected area in a PNG and smooth the transition before exporting it as an animated or static GIF.
 * 2. When creating web‑ready graphics that require a clean cut‑out around an object, using Magic Wand selection with a subtraction mask to eliminate background artifacts.
 * 3. When preparing image assets for UI icons where the edge of the cut‑out must be feathered to avoid harsh borders in the final GIF file.
 * 4. When automating batch processing of screenshots, you can programmatically subtract unwanted UI elements and apply feathering to maintain visual consistency.
 * 5. When converting high‑resolution PNGs to smaller GIFs while preserving a refined mask that excludes a defined area and softens its edges for smoother visual output.
 */
