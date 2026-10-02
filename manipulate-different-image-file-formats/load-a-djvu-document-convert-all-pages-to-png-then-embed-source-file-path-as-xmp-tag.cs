// HOW-TO: Convert Each DjVu Page to Separate PNG Files in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/sample.djvu";
            string outputDirectory = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                for (int i = 0; i < djvu.Pages.Length; i++)
                {
                    using (RasterImage page = (RasterImage)djvu.Pages[i])
                    {
                        if (!page.IsCached)
                        {
                            page.CacheData();
                        }

                        string outputPath = Path.Combine(outputDirectory, $"page_{i}.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        using (PngOptions options = new PngOptions())
                        {
                            page.Save(outputPath, options);
                        }
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
 * 1. When you need to extract each page of a multi‑page DjVu document as separate PNG images for web publishing.
 * 2. When a document conversion service must generate PNG previews of DjVu files for thumbnail galleries.
 * 3. When an archival workflow converts DjVu scans into PNG files to ensure compatibility with modern image viewers.
 * 4. When an OCR pipeline requires DjVu pages to be saved as PNG before text recognition.
 * 5. When a batch job processes a folder of DjVu files, converting all pages to PNG for downstream processing.
 */
