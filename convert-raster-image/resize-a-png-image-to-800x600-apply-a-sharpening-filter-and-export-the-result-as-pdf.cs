// HOW-TO: Resize PNG to 800x600, Sharpen, and Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/input.png";
            string outputPath = "Output/output.pdf";

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

                raster.Resize(800, 600, ResizeType.NearestNeighbourResample);
                raster.Filter(raster.Bounds, new SharpenFilterOptions());

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
 * 1. When you need to generate a printable PDF from a high‑resolution PNG by scaling it to standard 800×600 dimensions and enhancing details with a sharpening filter.
 * 2. When an e‑commerce platform must create thumbnail‑size PDFs of product images for catalog PDFs while improving image clarity.
 * 3. When a reporting tool requires converting dashboard screenshots (PNG) into compact PDF pages with consistent size and sharper visuals.
 * 4. When a document‑automation workflow needs to batch‑process PNG assets, resize them for uniform layout, apply sharpening, and embed them in PDF invoices.
 * 5. When a mobile app backend must prepare user‑uploaded PNG photos for PDF email attachments, ensuring they fit a specific page size and appear crisp.
 */
