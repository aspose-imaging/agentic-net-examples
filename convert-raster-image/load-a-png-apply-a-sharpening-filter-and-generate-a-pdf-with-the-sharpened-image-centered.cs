// HOW-TO: Sharpen PNG and Export Centered Image to PDF in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/sample.png";
            string outputPath = "Output/sharpened.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));
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
 * 1. When you need to improve the visual clarity of a scanned PNG before embedding it in a PDF report.
 * 2. When you want to programmatically apply a sharpening filter to product photos and generate a printable PDF catalog.
 * 3. When you must convert PNG screenshots into PDF documents while enhancing details for better readability.
 * 4. When an automated workflow requires centering a sharpened PNG inside a PDF for consistent layout across multiple pages.
 * 5. When you are building a C# application that processes user‑uploaded PNGs, sharpens them, and saves the result as a PDF for archival.
 */
