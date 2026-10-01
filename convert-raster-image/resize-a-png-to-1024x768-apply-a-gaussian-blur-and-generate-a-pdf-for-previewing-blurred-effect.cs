// HOW-TO: Resize PNG, Apply Gaussian Blur, and Export to PDF in C# (Aspose.Imaging for .NET)
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

            string inputPath = Path.Combine(inputDirectory, "image.png");
            string outputPath = Path.Combine(outputDirectory, "preview.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                if (!raster.IsCached)
                    raster.CacheData();

                raster.Resize(1024, 768, ResizeType.NearestNeighbourResample);

                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions();
                raster.Filter(raster.Bounds, blurOptions);

                var pdfOptions = new PdfOptions();
                raster.Save(outputPath, pdfOptions);
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
 * 1. When you need to generate a low‑resolution PDF preview of a high‑detail PNG with a softened look for design mock‑ups.
 * 2. When an e‑commerce platform must create blurred thumbnail PDFs of product images to protect copyright while still showing size.
 * 3. When a reporting tool requires converting resized PNG charts into PDF pages with a Gaussian blur to emphasize background elements.
 * 4. When a document workflow needs to automatically downscale uploaded PNGs, apply a blur for privacy, and bundle them as PDFs for review.
 * 5. When a desktop application wants to quickly produce a printable PDF preview of a PNG after resizing and applying a blur effect without using external image editors.
 */
