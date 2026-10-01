// HOW-TO: Batch Convert PNG to PDF with Resize and Sharpen in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".pdf");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    if (!image.IsCached) image.CacheData();

                    image.Resize(640, 480);

                    image.Filter(image.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions());

                    PdfOptions pdfOptions = new PdfOptions();

                    image.Save(outputPath, pdfOptions);
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
 * 1. When you need to generate printable PDFs from a folder of PNG screenshots, resizing them to standard slide dimensions and enhancing clarity with a sharpen filter.
 * 2. When automating the preparation of product catalog images, converting high‑resolution PNGs to uniformly sized PDF pages for easy distribution.
 * 3. When creating a batch workflow that reduces PNG file size by resizing and then bundles them as PDFs for archival or email attachment.
 * 4. When processing scanned PNG documents to improve readability before converting them into searchable PDF files.
 * 5. When building a C# service that ingests user‑uploaded PNG graphics, standardizes their dimensions, applies sharpening, and outputs PDF reports for downstream systems.
 */
