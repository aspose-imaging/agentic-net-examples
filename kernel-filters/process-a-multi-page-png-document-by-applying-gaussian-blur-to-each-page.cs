using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                PngOptions options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                image.Save(outputPath, options);
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
 * 1. When a developer needs to automatically blur sensitive information across all pages of a multi‑page PNG invoice before sharing it with external partners.
 * 2. When a C# application must prepare multi‑page PNG maps for a web portal by applying a Gaussian blur to each page to create a low‑resolution preview.
 * 3. When a document management system requires batch processing of scanned multi‑page PNG forms, using Aspose.Imaging for .NET to add Gaussian blur for privacy compliance.
 * 4. When an image‑processing pipeline in a .NET service needs to generate stylized thumbnails of each page in a multi‑page PNG brochure by applying a Gaussian blur filter.
 * 5. When a developer wants to integrate Aspose.Imaging into a Windows desktop tool that sanitizes multi‑page PNG blueprints by blurring proprietary details on every page before export.
 */