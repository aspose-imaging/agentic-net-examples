// HOW-TO: Create 150x150 PNG Thumbnail From Large TIFF Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                // Resize to 150x150 using high‑quality Lanczos (bicubic‑like) filter
                image.Resize(150, 150, ResizeType.LanczosResample);

                var pngOptions = new PngOptions();
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
 * 1. When you need to generate small preview images for high‑resolution TIFF scans in a web gallery.
 * 2. When an application must convert medical or satellite TIFF files into lightweight PNG thumbnails for faster loading.
 * 3. When you want to display product catalog images stored as TIFFs as 150 × 150 PNG icons on an e‑commerce site.
 * 4. When a document management system requires consistent PNG thumbnails for TIFF documents to show in search results.
 * 5. When you are building a batch‑processing tool that creates uniform PNG previews from large TIFF files for reporting dashboards.
 */
