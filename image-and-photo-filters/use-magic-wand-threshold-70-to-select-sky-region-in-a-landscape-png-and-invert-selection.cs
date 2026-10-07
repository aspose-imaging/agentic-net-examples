// HOW-TO: Select Sky Region in PNG with Magic Wand and Invert Selection in C# (Aspose.Imaging for .NET)
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
                MagicWandTool.Select(image, new MagicWandSettings(100, 50) { Threshold = 70 })
                    .Invert()
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
 * 1. When you need to isolate the sky in a landscape PNG to replace it with a different background using Aspose.Imaging in C#.
 * 2. When you want to create a mask of the sky area for applying color grading or lighting effects without affecting the rest of the image.
 * 3. When you are preparing images for a composite where the sky must be removed and later blended with another sky layer programmatically.
 * 4. When you need to generate a sky selection mask to feed into machine‑learning models that require separate sky and ground annotations.
 * 5. When you want to invert the sky selection to edit everything except the sky, such as adding foreground elements while preserving the original sky.
 */
