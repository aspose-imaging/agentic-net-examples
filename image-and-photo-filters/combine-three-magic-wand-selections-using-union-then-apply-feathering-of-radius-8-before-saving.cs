// HOW-TO: Combine Multiple Magic Wand Selections With Feathering In C# (Aspose.Imaging for .NET)
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
                MagicWandTool.Select(image, new MagicWandSettings(10, 10))
                    .Union(new MagicWandSettings(20, 20))
                    .Union(new MagicWandSettings(30, 30))
                    .GetFeathered(new FeatheringSettings() { Size = 8 })
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
 * 1. When you need to merge several non‑contiguous regions selected by the Magic Wand tool and smooth their edges before exporting a PNG in a C# image‑processing pipeline.
 * 2. When creating a composite mask from multiple click points on a raster image, applying an 8‑pixel feather to soften the transition for seamless overlays.
 * 3. When automating preparation of cut‑out graphics for web assets, combining three selection areas and feathering them to avoid harsh borders.
 * 4. When building a batch‑processing utility that selects distinct color clusters, unites them, and saves the result with softened edges for further editing.
 * 5. When implementing a photo‑editing feature that lets users pick several spots, merges those selections, applies a gentle blur edge, and stores the final image as a PNG file.
 */
