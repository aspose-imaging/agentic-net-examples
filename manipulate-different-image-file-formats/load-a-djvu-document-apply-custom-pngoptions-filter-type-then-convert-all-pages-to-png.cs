// HOW-TO: Convert DjVu Document Pages to PNG with Sub Filter in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\document.djvu";
            string outputDirectory = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            using (PngOptions pngOptions = new PngOptions())
            {
                pngOptions.FilterType = PngFilterType.Sub;

                for (int i = 0; i < djvu.Pages.Length; i++)
                {
                    string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    djvu.Pages[i].Save(outputPath, pngOptions);
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
 * 1. When you need to extract each page of a multi‑page DjVu file and save them as high‑quality PNG images for web preview.
 * 2. When you want to apply a specific PNG filter (Sub) to reduce file size while preserving detail during DjVu‑to‑PNG conversion in a .NET application.
 * 3. When an archival system requires converting scanned DjVu documents into separate PNG files for compatibility with image‑processing pipelines.
 * 4. When building a document viewer that loads DjVu files and renders each page as PNG thumbnails using Aspose.Imaging for C#.
 * 5. When automating batch processing of DjVu reports to generate PNG assets for inclusion in PDFs or email attachments.
 */
