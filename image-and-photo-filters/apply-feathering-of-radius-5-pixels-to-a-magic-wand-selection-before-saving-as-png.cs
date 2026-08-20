// HOW-TO: Apply Feathered Magic Wand Selection and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
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
                MagicWandTool
                    .Select(image, new MagicWandSettings(120, 100))
                    .GetFeathered(new FeatheringSettings() { Size = 5 })
                    .Apply();

                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(outputPath)
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
 * 1. When you need to smooth the edges of a region selected with the Magic Wand tool before exporting the image as a transparent PNG in a C# application.
 * 2. When creating thumbnails that require a soft‑bordered cut‑out of an object, using feathered selection to avoid harsh edges.
 * 3. When preparing product photos for e‑commerce sites, applying a 5‑pixel feather to isolate the product and save it with an alpha channel in PNG format.
 * 4. When automating batch processing of scanned graphics, using Aspose.Imaging to select a color range, feather the mask, and output lossless PNG files.
 * 5. When developing a graphics editor that lets users click to select an area and then applies a subtle blur to the selection border before saving the result as a high‑quality PNG.
 */
