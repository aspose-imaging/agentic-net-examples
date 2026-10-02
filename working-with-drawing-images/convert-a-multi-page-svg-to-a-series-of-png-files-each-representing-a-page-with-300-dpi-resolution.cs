// HOW-TO: Convert Multi-Page SVG to High-Resolution PNG Images in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputDir = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                if (image is IMultipageImage multipage)
                {
                    int pageCount = multipage.PageCount;
                    for (int i = 0; i < pageCount; i++)
                    {
                        string outputPath = Path.Combine(outputDir, $"page_{i + 1}.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        PngOptions options = new PngOptions
                        {
                            ResolutionSettings = new ResolutionSetting(300, 300),
                            MultiPageOptions = new MultiPageOptions(new IntRange(i + 1, i + 1))
                        };

                        image.Save(outputPath, options);
                    }
                }
                else
                {
                    string outputPath = Path.Combine(outputDir, "page_1.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    PngOptions options = new PngOptions
                    {
                        ResolutionSettings = new ResolutionSetting(300, 300)
                    };

                    image.Save(outputPath, options);
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
 * 1. When you need to generate printable 300 DPI PNG pages from a multi‑page SVG diagram for a reporting system.
 * 2. When a web service must split a vector‑based SVG brochure into separate high‑resolution PNG files for thumbnail previews.
 * 3. When automating the preparation of assets for a mobile app that requires raster PNG images at a specific DPI from a single SVG source.
 * 4. When converting SVG floor plans into individual PNG layers for integration with GIS or CAD tools that only accept raster formats.
 * 5. When creating a batch job that extracts each page of a multi‑page SVG invoice and saves them as 300 DPI PNG files for archival in a document management system.
 */
