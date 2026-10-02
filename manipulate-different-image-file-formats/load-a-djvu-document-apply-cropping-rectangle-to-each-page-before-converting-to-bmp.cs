// HOW-TO: Convert Each Page Of DjVu To BMP Images In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

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
                for (int i = 0; i < pageCount; i++)
                {
                    string outputPath = Path.Combine(outputDir, $"page_{i}.bmp");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    BmpOptions bmpOptions = new BmpOptions();
                    djvu.Pages[i].Save(outputPath, bmpOptions);
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
 * 1. When you need to extract every page from a multi‑page DjVu file and save them as separate BMP files for legacy Windows applications.
 * 2. When a document workflow requires converting scanned DjVu archives into BMP format to preserve lossless bitmap data before further processing.
 * 3. When you want to automate batch conversion of DjVu pages to BMP in a C# service that integrates with Aspose.Imaging.
 * 4. When you must generate BMP thumbnails of each DjVu page for use in a catalog or preview gallery.
 * 5. When a legacy system only accepts BMP images, and you need to programmatically transform DjVu documents page‑by‑page in .NET.
 */
