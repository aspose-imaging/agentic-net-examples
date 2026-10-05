// HOW-TO: Convert Multi‑Page PDF to PNG Images with Alpha Channel in C# (Aspose.Imaging for .NET)
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
        string inputPath = "input.pdf";
        string outputDir = "Output";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (Image pdf = Image.Load(inputPath))
            {
                int pageCount = (pdf as IMultipageImage)?.PageCount ?? 1;

                for (int i = 0; i < pageCount; i++)
                {
                    string outputPath = Path.Combine(outputDir, $"page_{i + 1}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    PngOptions options = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        MultiPageOptions = new MultiPageOptions(new IntRange(i, 1))
                    };

                    pdf.Save(outputPath, options);
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
 * 1. When you need to generate transparent PNG thumbnails of each page of a vector‑based PDF for web previews.
 * 2. When you must extract individual pages from a multi‑page PDF and preserve their vector quality as PNGs with an alpha channel for overlay in graphics editors.
 * 3. When a reporting system requires converting PDF charts into PNG assets that retain transparency for inclusion in dashboards.
 * 4. When automating a workflow that creates PNG assets from PDF brochures to be used in mobile apps where PNG with alpha is required.
 * 5. When preparing print‑ready assets by flattening PDF transparency and exporting each page as a high‑resolution PNG for further processing.
 */
