// HOW-TO: Increase TIFF Brightness, Apply Gaussian Blur, Export to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.tif";
            string outputPath = "Output/result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                raster.AdjustBrightness(50);
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 1.0));

                PdfOptions pdfOptions = new PdfOptions();
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
 * 1. When you need to enhance a scanned TIFF document’s visibility before archiving it as a PDF.
 * 2. When preparing medical imaging TIFF files for presentation by brightening and smoothing them for PDF reports.
 * 3. When converting low‑contrast TIFF photographs to PDF with a subtle blur to reduce noise.
 * 4. When automating batch processing of TIFF receipts to improve readability and store them as PDFs.
 * 5. When creating PDF portfolios from TIFF graphics that require brightness correction and a smoothing filter.
 */
