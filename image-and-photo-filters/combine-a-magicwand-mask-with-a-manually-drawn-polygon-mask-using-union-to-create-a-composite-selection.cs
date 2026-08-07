// HOW-TO: Combine Magic Wand and Polygon Masks Using Union in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                MagicWandTool
                    .Select(image, new MagicWandSettings(120, 80))
                    .Union(new RectangleMask(200, 150, 300, 200))
                    .Apply();

                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(outputPath, false)
                };
                image.Save(outputPath, pngOptions);
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
 * 1. When you need to automatically select a region based on color similarity and then add a manually defined rectangular area to the selection for precise cropping of a PNG image in C#.
 * 2. When you want to create a composite mask that combines a Magic Wand selection with a custom polygon (or rectangle) mask to isolate complex objects before applying further image edits.
 * 3. When you are building a photo‑editing tool that lets users refine an auto‑selected area by drawing additional shapes and then save the result with transparency using Aspose.Imaging.
 * 4. When you must generate a selection that includes both a tolerance‑based region and a specific rectangular region to export a cut‑out of a PNG with alpha channel preserved.
 * 5. When you are processing batch images and need to programmatically merge auto‑detected and user‑drawn masks into a single selection before saving the output as a true‑color PNG in .NET.
 */
