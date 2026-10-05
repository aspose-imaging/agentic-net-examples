// HOW-TO: Select Red Area In JPEG With Magic Wand Threshold 30 C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output\\result.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                MagicWandTool.Select(image, new MagicWandSettings(50, 50) { Threshold = 30 })
                    .Apply();

                PngOptions pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
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
 * 1. When you need to isolate and extract a red-colored object from a JPEG photo for further editing or compositing.
 * 2. When you want to create a transparent PNG that contains only the selected red region while discarding the rest of the image.
 * 3. When you are building an automated pipeline that identifies red markers in scanned documents and saves them as separate PNG assets.
 * 4. When you need to apply a color‑based selection with a specific tolerance (threshold 30) to handle variations in red shades in batch image processing.
 * 5. When you are developing a C# application that converts JPEG images to PNG with an alpha channel after selecting a specific color region using Aspose.Imaging’s Magic Wand tool.
 */
