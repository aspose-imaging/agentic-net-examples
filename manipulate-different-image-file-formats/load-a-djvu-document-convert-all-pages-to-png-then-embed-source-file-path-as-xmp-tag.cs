// HOW-TO: Convert Multi‑Page DjVu to Separate PNG Files in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.djvu";
            string outputDirectory = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                int pageCount = djvuImage.Pages.Length;
                for (int i = 0; i < pageCount; i++)
                {
                    DjvuPage page = (DjvuPage)djvuImage.Pages[i];
                    using (page)
                    {
                        string outputPath = Path.Combine(outputDirectory, $"page_{page.PageNumber}.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                        page.Save(outputPath, new PngOptions());
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
 * 1. When you need to extract each page of a multi‑page DjVu document as high‑quality PNG images for web preview or further processing.
 * 2. When an archival system stores scanned books in DjVu format and you must generate PNG thumbnails for a searchable catalog.
 * 3. When a document‑management workflow requires converting DjVu pages to PNG to apply OCR or other image‑analysis tools that only support PNG.
 * 4. When a desktop application must batch‑convert a folder of DjVu files into individual PNG pages for printing or editing in graphic software.
 * 5. When integrating Aspose.Imaging in a C# service that receives DjVu uploads and needs to serve each page as a PNG to client browsers.
 */
