// HOW-TO: Crop PNG to 300x300, Apply Median Filter, Save as PDF in C# (Aspose.Imaging for .NET)
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
            string outputPath = "Output\\result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                if (!raster.IsCached) raster.CacheData();

                Aspose.Imaging.Rectangle cropRect = new Aspose.Imaging.Rectangle(0, 0, 300, 300);
                raster.Crop(cropRect);

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
 * 1. When you need to extract a 300 × 300 thumbnail from a PNG, reduce noise with a median filter, and embed it in a PDF report using C#.
 * 2. When generating printable PDFs from scanned PNG images where you must crop a specific region and smooth the image before saving.
 * 3. When creating PDF invoices that include a cleaned‑up logo extracted from a larger PNG file by cropping and applying noise reduction.
 * 4. When preprocessing PNG screenshots for documentation, cropping the area of interest, applying a median filter to remove artifacts, and converting the result to PDF.
 * 5. When automating batch conversion of PNG graphics to PDF pages while ensuring each page contains a centered, noise‑filtered 300 × 300 image.
 */
