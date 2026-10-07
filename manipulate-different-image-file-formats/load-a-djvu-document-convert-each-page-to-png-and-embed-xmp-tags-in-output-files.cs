// HOW-TO: Convert DjVu Document Pages to PNG Images in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/document.djvu";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDirectory = "Output";
            Directory.CreateDirectory(outputDirectory);

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                for (int i = 0; i < djvu.Pages.Length; i++)
                {
                    string outputPath = Path.Combine(outputDirectory, $"page_{i}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    PngOptions options = new PngOptions();
                    djvu.Pages[i].Save(outputPath, options);
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
 * 1. When you need to extract each page of a DjVu file and save them as separate PNG files for web preview or further image processing.
 * 2. When a document management system must batch‑convert archived DjVu scans into high‑quality PNG thumbnails for indexing.
 * 3. When an e‑learning platform wants to display DjVu lecture notes as PNG slides on devices that do not support DjVu.
 * 4. When a digital archiving workflow requires converting multi‑page DjVu manuscripts into PNG images for OCR analysis.
 * 5. When a desktop application needs to programmatically read a DjVu file and generate PNG assets for printing or reporting.
 */
