// HOW-TO: Select Color Region with Magic Wand and Custom Threshold in C# (Aspose.Imaging for .NET)
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
                MagicWandTool
                    .Select(image, new MagicWandSettings(50, 50) { Threshold = 30 })
                    .Apply();

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
 * 1. When you need to automatically isolate a specific color area in a PNG image by defining a seed point and adjusting the selection sensitivity with a custom threshold.
 * 2. When creating a C# tool that lets users click on a photo to remove or replace the background based on color similarity using Aspose.Imaging’s MagicWandTool.
 * 3. When generating thumbnails that only include objects of a particular hue, requiring precise region selection with a threshold to avoid capturing neighboring shades.
 * 4. When building a batch process that extracts logo graphics from scanned PNG files by selecting the logo’s color region using a seed coordinate and a 30‑pixel threshold.
 * 5. When implementing an automated quality‑check that highlights areas of a PNG that match a target color within a tolerance, enabling further analysis or reporting.
 */
