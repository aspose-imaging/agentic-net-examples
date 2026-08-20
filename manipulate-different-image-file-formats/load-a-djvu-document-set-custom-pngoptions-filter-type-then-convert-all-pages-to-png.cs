// HOW-TO: Convert DjVu Document Pages to PNG with Sub Filter in C# (Aspose.Imaging for .NET)
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
            string inputPath = "sample.djvu";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = "Output";

            using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
            {
                int pageNumber = 0;
                foreach (DjvuPage page in djvuImage.Pages)
                {
                    pageNumber++;
                    string outputPath = Path.Combine(outputDir, $"page_{pageNumber}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    PngOptions pngOptions = new PngOptions
                    {
                        FilterType = PngFilterType.Sub
                    };

                    page.Save(outputPath, pngOptions);
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
 * 1. When you need to extract each page of a multi‑page DjVu file and save them as high‑quality PNG images for web publishing.
 * 2. When you want to apply a specific PNG filter (e.g., Sub) to reduce file size while preserving visual fidelity during batch conversion.
 * 3. When an application must programmatically process scanned documents stored in DjVu format and generate PNG thumbnails for preview.
 * 4. When integrating Aspose.Imaging into a C# workflow that converts archival DjVu files into PNGs for compatibility with downstream image analysis tools.
 * 5. When automating the migration of legacy DjVu assets to PNG format with custom compression settings in a server‑side .NET service.
 */
