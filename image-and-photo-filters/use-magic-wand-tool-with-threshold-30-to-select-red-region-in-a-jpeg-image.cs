// HOW-TO: Select Red Region in JPEG Using Magic Wand Tool C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Select the red region using Magic Wand at point (100, 100) with threshold 30
                MagicWandTool
                    .Select(image, new MagicWandSettings(100, 100) { Threshold = 30 })
                    .Apply();

                // Save the modified image as JPEG
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 90
                };
                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to automatically isolate and edit red-colored objects in a JPEG photo for product labeling.
 * 2. When building a C# application that highlights red traffic signs in street‑view images before further analysis.
 * 3. When creating a batch process that extracts red regions from scanned receipts to mask sensitive information.
 * 4. When developing a photo‑editing tool that lets users click a point and select all similar red tones with a configurable threshold.
 * 5. When preparing images for machine‑learning training by segmenting red areas in JPEG files using Aspose.Imaging.
 */
