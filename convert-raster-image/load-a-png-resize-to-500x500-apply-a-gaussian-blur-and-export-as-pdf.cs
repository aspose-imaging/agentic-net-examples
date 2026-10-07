// HOW-TO: Resize PNG to 500x500, Apply Gaussian Blur, Save as PDF in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\image.png";
            string outputPath = "Output\\output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                raster.Resize(500, 500);

                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.5));

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
 * 1. When you need to generate a PDF brochure from a high‑resolution PNG and want the image scaled to a fixed 500 × 500 size.
 * 2. When you must soften a PNG logo with a Gaussian blur before embedding it in a PDF report.
 * 3. When an automated workflow requires converting user‑uploaded PNG screenshots into uniformly sized, blurred PDFs for archival.
 * 4. When creating printable PDF invoices that include product images resized and blurred for visual consistency.
 * 5. When building a C# service that prepares marketing assets by resizing PNG banners, applying a blur effect, and outputting them as PDF files.
 */
