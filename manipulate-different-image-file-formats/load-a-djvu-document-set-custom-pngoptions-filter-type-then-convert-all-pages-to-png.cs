// HOW-TO: Convert DjVu Document to PNG with Sub Filter Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\sample.djvu";
            string outputDirectory = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image image = Image.Load(inputPath))
            {
                DjvuImage djvu = (DjvuImage)image;
                using (PngOptions pngOptions = new PngOptions())
                {
                    pngOptions.FilterType = PngFilterType.Sub;

                    for (int i = 0; i < djvu.Pages.Length; i++)
                    {
                        string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        using (RasterImage page = (RasterImage)djvu.Pages[i])
                        {
                            page.Save(outputPath, pngOptions);
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
 * 1. When you need to extract each page of a multi‑page DjVu file as separate PNG images for web preview.
 * 2. When you want to apply a specific PNG filter (Sub) to reduce file size while preserving quality during conversion.
 * 3. When automating a batch process that converts scanned DjVu archives into PNGs for OCR preprocessing.
 * 4. When integrating Aspose.Imaging into a C# application to programmatically render DjVu pages as raster images.
 * 5. When preparing DjVu content for platforms that only support PNG, requiring per‑page conversion with custom options.
 */
