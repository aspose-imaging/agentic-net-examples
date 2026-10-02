// HOW-TO: Convert DjVu Pages 10 to 15 to PNG Images in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
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
                int startPage = 10;
                int endPage = 15;

                int pageCount = djvu.Pages.Length;
                if (startPage < 1) startPage = 1;
                if (endPage > pageCount) endPage = pageCount;

                for (int i = startPage; i <= endPage; i++)
                {
                    var page = djvu.Pages[i - 1];
                    string outputPath = Path.Combine(outputDir, $"page_{i}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (PngOptions options = new PngOptions())
                    {
                        options.Source = new FileCreateSource(outputPath, false);
                        page.Save(outputPath, options);
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
 * 1. When you need to extract a specific range of pages from a multi‑page DjVu document and save each page as a high‑quality PNG for web preview.
 * 2. When you want to automate batch conversion of selected DjVu pages to PNG files in a .NET application without manual editing.
 * 3. When you are building a document‑processing pipeline that requires converting only pages 10‑15 of a scanned DjVu archive into PNG thumbnails.
 * 4. When you must generate separate PNG images for a subset of DjVu pages to feed into OCR or image‑analysis tools.
 * 5. When you need to programmatically create PNG assets from a DjVu file for inclusion in a mobile app’s asset bundle, limiting the conversion to a defined page range.
 */
