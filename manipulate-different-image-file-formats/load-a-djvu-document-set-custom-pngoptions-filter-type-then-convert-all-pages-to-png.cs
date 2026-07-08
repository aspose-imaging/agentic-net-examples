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
            // Input DjVu file
            string inputPath = "sample.djvu";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Output directory for PNG pages
            string outputDir = "Output";
            Directory.CreateDirectory(outputDir);

            // PNG options with custom filter type
            PngOptions pngOptions = new PngOptions
            {
                FilterType = PngFilterType.Sub
            };

            // Load DjVu document
            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Convert each page to PNG
                foreach (Image pageImage in djvuImage.Pages)
                {
                    DjvuPage page = (DjvuPage)pageImage;
                    string outputPath = Path.Combine(outputDir, $"page_{page.PageNumber}.png");
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
 * 1. When a developer needs to extract each page of a multi‑page DjVu document and save them as high‑quality PNG images with a specific filter (e.g., Sub) for web publishing.
 * 2. When an archival system must convert scanned DjVu files into PNG thumbnails while preserving image fidelity using Aspose.Imaging’s PngOptions in a C# batch process.
 * 3. When a document‑management application requires programmatic conversion of DjVu pages to PNG format for downstream OCR processing, and wants to control PNG compression via the FilterType setting.
 * 4. When a desktop utility needs to read a DjVu file from a stream, iterate over its pages, and output individual PNG files to a designated folder for user‑friendly viewing on devices that do not support DjVu.
 * 5. When a migration script must automate the transformation of legacy DjVu assets into PNG assets with custom filter settings to ensure consistent visual results across different platforms.
 */