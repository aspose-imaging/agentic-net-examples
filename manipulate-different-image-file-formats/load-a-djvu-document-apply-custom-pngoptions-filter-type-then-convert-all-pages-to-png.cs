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
            // Hardcoded input path
            string inputPath = "sample.djvu";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Output directory
            string outputDir = "Output";
            Directory.CreateDirectory(outputDir);

            // Load DjVu document
            using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
            {
                // Configure PNG options with a custom filter type
                PngOptions pngOptions = new PngOptions
                {
                    FilterType = PngFilterType.Sub
                };

                // Convert each page to PNG
                for (int i = 0; i < djvuImage.Pages.Length; i++)
                {
                    var page = djvuImage.Pages[i];
                    string outputPath = Path.Combine(outputDir, $"page_{i + 1}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
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
 * 1. When a developer needs to extract every page from a multi‑page DjVu document and save them as PNG files using a custom PNG filter to improve compression and image quality.
 * 2. When an archival system must convert scanned DjVu files into PNG thumbnails for web preview while specifying the PNG filter type for optimal file size.
 * 3. When a digital publishing workflow requires batch conversion of DjVu ebooks into PNG assets because the target e‑reader only supports PNG format.
 * 4. When a document management application programmatically loads a DjVu file, applies a custom PngOptions filter (e.g., Sub) and stores each page as a separate PNG for downstream image analysis.
 * 5. When a C# service automates the conversion of DjVu invoices into PNG images to feed a third‑party OCR engine that expects PNG input with specific filter settings.
 */