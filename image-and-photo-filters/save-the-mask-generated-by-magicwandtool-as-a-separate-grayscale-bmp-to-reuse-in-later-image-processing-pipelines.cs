// HOW-TO: Export Magic Wand Selection as Grayscale BMP Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
        string outputPath = "mask.bmp";

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
                ImageBitMask mask = MagicWandTool.Select(image, new MagicWandSettings(120, 100));
                mask.Apply();
                image.Save(outputPath, new BmpOptions());
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
 * 1. When you need to isolate a foreground object from a PNG and store the binary mask as a BMP for later compositing.
 * 2. When you want to reuse the same selection across multiple image processing steps without recalculating the Magic Wand region.
 * 3. When a batch pipeline requires a separate grayscale mask file to feed into machine‑learning models for segmentation.
 * 4. When you are preparing assets for a game engine that expects masks in BMP format for alpha‑channel handling.
 * 5. When you need to archive the exact selection used for quality‑control audits in a medical imaging workflow.
 */
