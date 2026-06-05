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
            string inputPath = "Input/sample.djvu";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            PngOptions pngOptions = new PngOptions
            {
                FilterType = PngFilterType.Sub
            };

            using (FileStream stream = File.OpenRead(inputPath))
            {
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    foreach (DjvuPage page in djvuImage.Pages)
                    {
                        string outputPath = Path.Combine("Output", $"page_{page.PageNumber}.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                        page.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to extract each page of a multi‑page DjVu document and save them as high‑quality PNG images with a specific Sub filter for better compression, they can use this code.
 * 2. When building a document‑preview feature that converts DjVu files into web‑friendly PNG thumbnails on the fly in a C# application, this snippet provides the necessary page‑by‑page conversion.
 * 3. When migrating legacy scanned archives stored as DjVu into a PNG‑based digital asset management system, the code enables automated batch processing of all pages with custom PngOptions.
 * 4. When creating an automated workflow that validates DjVu content by rendering each page to PNG for visual inspection or OCR preprocessing, the example shows how to load, iterate, and save pages using Aspose.Imaging for .NET.
 * 5. When developing a cross‑platform .NET service that receives DjVu uploads and returns individual PNG files with a chosen filter type for downstream image analysis, this code demonstrates the required file handling and conversion steps.
 */