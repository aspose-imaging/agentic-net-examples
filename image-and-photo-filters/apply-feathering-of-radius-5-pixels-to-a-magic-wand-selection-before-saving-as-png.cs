// HOW-TO: Apply Feathered Magic Wand Selection and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

public class Program
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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                MagicWandTool.Select(raster, new MagicWandSettings(0, 0))
                    .GetFeathered(new FeatheringSettings() { Size = 5 })
                    .Apply();

                raster.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
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
 * 1. When you need to smooth the edges of a region selected with the Magic Wand tool before exporting a PNG with transparency.
 * 2. When creating web graphics that require a soft‑transition around cut‑out objects to avoid jagged borders.
 * 3. When processing scanned photos and want to isolate a subject with a 5‑pixel feathered mask for further compositing.
 * 4. When generating thumbnails where the selected area must blend seamlessly with the background after saving as a true‑color PNG.
 * 5. When automating batch image cleanup in a C# application and need to apply consistent feathering to selections across multiple PNG files.
 */
