// HOW-TO: Convert PNG to PDF with Transparent Background and Median Filter in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.png";
            string outputPath = "output/output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                raster.BackgroundColor = Aspose.Imaging.Color.Transparent;
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));

                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    raster.Save(outputPath, pdfOptions);
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
 * 1. When you need to embed a cleaned‑up PNG image with a transparent background into a PDF report.
 * 2. When you want to remove noise from scanned PNG graphics before converting them to PDF for archival.
 * 3. When you are generating PDF invoices that require logo images to appear without a solid background.
 * 4. When you need to programmatically prepare marketing assets by applying a median filter and saving them as PDF for print‑ready distribution.
 * 5. When you are building a document conversion service that must ensure PNG images become PDF pages with transparent backgrounds and reduced visual artifacts.
 */
