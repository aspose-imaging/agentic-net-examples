// HOW-TO: Extract All Pages From DjVu And Save As PNG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.djvu";
            string outputDir = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                int pageCount = djvu.Pages.Length;
                Console.WriteLine($"Number of pages: {pageCount}");

                for (int i = 0; i < pageCount; i++)
                {
                    string outputPath = Path.Combine(outputDir, $"page_{i + 1}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (RasterImage page = (RasterImage)djvu.Pages[i])
                    {
                        PngOptions pngOptions = new PngOptions();
                        page.Save(outputPath, pngOptions);
                    }
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
 * 1. When you need to batch‑convert a multi‑page DjVu document into individual PNG images for web preview or further processing.
 * 2. When you must determine how many pages a DjVu file contains before performing page‑specific operations.
 * 3. When an application requires extracting each page of a scanned DjVu archive to feed into OCR or image analysis tools.
 * 4. When you want to generate thumbnail PNGs for each page of a DjVu e‑book to display in a catalog or library UI.
 * 5. When a migration script has to move legacy DjVu assets into a PNG‑based workflow without losing page separation.
 */
