// HOW-TO: Resize PNG to 800x600, Sharpen and Convert to PDF in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\sample.png";
            string outputPath = "Output\\result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                // Resize to 800x600
                image.Resize(800, 600);

                // Apply sharpening filter
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

                // Save as PDF
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
 * 1. When you need to generate a printable PDF from a high‑resolution PNG while ensuring the image fits a standard 800×600 layout and appears sharper.
 * 2. When an e‑commerce platform must create thumbnail‑size PDFs of product photos uploaded as PNGs for catalog PDFs.
 * 3. When a reporting tool requires converting PNG charts to PDF pages with consistent dimensions and enhanced edge clarity.
 * 4. When a document‑automation workflow needs to downscale large PNG assets, apply a sharpening filter, and embed them in PDF invoices.
 * 5. When a mobile app backend processes user‑uploaded PNG screenshots, resizes them, sharpens details, and stores them as PDFs for archival.
 */
