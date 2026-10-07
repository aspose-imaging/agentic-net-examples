// HOW-TO: Sharpen BMP Image and Save as PDF Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "image.bmp");
            string outputPath = Path.Combine("Output", "filtered.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterCachedImage raster = image as RasterCachedImage;
                if (raster != null)
                {
                    if (!raster.IsCached)
                        raster.CacheData();

                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions());
                }

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
 * 1. When you need to enhance a scanned BMP diagram with a sharpen filter before embedding it in a PDF report.
 * 2. When an application must programmatically convert legacy BMP assets to searchable PDF documents while improving visual clarity.
 * 3. When a batch process has to apply a custom image filter to BMP files and generate PDF invoices for distribution.
 * 4. When a web service receives BMP uploads, applies sharpening to improve readability, and returns the result as a PDF file.
 * 5. When automating the preparation of print‑ready PDFs from BMP graphics, ensuring the images are sharpened for crisp output.
 */
