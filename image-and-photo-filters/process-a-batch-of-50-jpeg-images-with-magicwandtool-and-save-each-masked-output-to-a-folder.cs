// HOW-TO: Batch Apply Magic Wand Mask to JPEG Images in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "Input";
            string outputFolder = "Output";

            string[] files = Directory.GetFiles(inputFolder, "*.jpg");
            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + "_masked.jpg");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    MagicWandTool.Select(image, new MagicWandSettings(0, 0))
                        .Apply();
                    image.Save(outputPath);
                }
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
 * 1. When you need to automatically remove backgrounds from a folder of product photos stored as JPEGs before uploading them to an e‑commerce site.
 * 2. When you want to generate masked versions of scanned documents in JPEG format for archival or OCR preprocessing.
 * 3. When a photo‑editing application must apply a quick selection mask to dozens of user‑uploaded JPEG images on the server side.
 * 4. When you are preparing thumbnail previews that only show the foreground of JPEG pictures by using the Magic Wand selection in a .NET batch job.
 * 5. When you need to integrate Aspose.Imaging’s MagicWandTool into a C# workflow to batch‑process JPEG assets for a machine‑learning dataset.
 */
