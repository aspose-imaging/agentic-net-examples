// HOW-TO: Resize BMP, Sharpen Image, and Convert to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.bmp";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                image.Resize(640, 480);
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));
                var pdfOptions = new PdfOptions();
                image.Save(outputPath, pdfOptions);
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
 * 1. When you need to take a high‑resolution BMP scan, shrink it to a standard 640×480 size, sharpen the details, and embed it in a PDF report for easy sharing.
 * 2. When generating printable PDFs from legacy BMP assets, you can resize the images to fit the page, enhance edges with a sharpening filter, and save the result as a PDF using Aspose.Imaging.
 * 3. When preparing screenshots saved as BMP for documentation, you may want to reduce their dimensions, improve clarity, and convert them to a single PDF file for inclusion in manuals.
 * 4. When creating an e‑commerce catalog, you can automatically resize product BMP images, apply a sharpening filter to highlight features, and export them as PDF pages for offline browsing.
 * 5. When archiving scanned BMP documents, you can compress them by resizing, enhance readability with sharpening, and store the final version as a searchable PDF using C#.
 */
