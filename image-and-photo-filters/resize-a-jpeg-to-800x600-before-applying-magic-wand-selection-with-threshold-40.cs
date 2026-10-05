// HOW-TO: Resize JPEG to 800x600 and Apply Magic Wand Selection in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                image.Resize(800, 600, ResizeType.NearestNeighbourResample);
                MagicWandTool.Select(image, new MagicWandSettings(0, 0) { Threshold = 40 })
                    .Apply();
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
 * 1. When you need to downscale a high‑resolution JPEG to a web‑friendly 800×600 size before extracting a region with a Magic Wand tool in a C# application.
 * 2. When preparing product photos for an e‑commerce site, you can resize them and automatically select background areas using a threshold‑based Magic Wand to simplify background removal.
 * 3. When processing scanned documents, you may want to shrink the image and isolate similar‑colored sections for OCR preprocessing using Aspose.Imaging’s Magic Wand with a threshold of 40.
 * 4. When building a batch image‑editing script, you can ensure consistent dimensions and then apply a Magic Wand selection to batch‑crop or mask areas across multiple JPEG files.
 * 5. When creating thumbnails that require both size reduction and selective region detection, this code resizes the JPEG and selects pixels within the specified tolerance for further editing.
 */
