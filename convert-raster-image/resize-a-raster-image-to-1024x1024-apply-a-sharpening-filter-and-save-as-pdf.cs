// HOW-TO: Resize Image to 1024x1024, Sharpen, and Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (string.IsNullOrEmpty(outputDir))
                outputDir = ".";
            Directory.CreateDirectory(outputDir);

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached)
                    image.CacheData();

                image.Resize(1024, 1024);
                image.Filter(image.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions());

                using (PdfOptions pdfOptions = new PdfOptions())
                {
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
 * 1. When you need to generate a high‑resolution PDF thumbnail from a PNG by resizing it to a fixed 1024 × 1024 size and applying sharpening for clearer details.
 * 2. When an e‑commerce platform must convert product photos into uniformly sized, sharpened PDFs for printable catalogs.
 * 3. When a document‑management system requires batch processing of scanned images to standard dimensions and enhanced sharpness before archiving them as PDFs.
 * 4. When a mobile app backend prepares user‑uploaded screenshots for PDF reports, ensuring they are resized and sharpened to maintain readability.
 * 5. When a marketing automation workflow transforms large raster graphics into optimized PDF assets with consistent dimensions and improved visual quality.
 */
