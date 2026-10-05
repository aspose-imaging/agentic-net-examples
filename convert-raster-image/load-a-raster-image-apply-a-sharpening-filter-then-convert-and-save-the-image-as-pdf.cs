// HOW-TO: Sharpen PNG Image and Save as PDF Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = Path.Combine("Input", "input.png");
                string outputPath = Path.Combine("Output", "output.pdf");

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = image as RasterImage;
                    if (raster == null)
                    {
                        Console.Error.WriteLine("Loaded image is not a raster image.");
                        return;
                    }

                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions());

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
}

/*
 * Real-World Use Cases:
 * 1. When you need to improve the clarity of scanned PNG documents before archiving them as searchable PDF files.
 * 2. When a web application must automatically enhance user‑uploaded PNG photos and deliver them as PDF reports.
 * 3. When generating printable PDFs from product screenshots that require a sharpening step to highlight details.
 * 4. When converting PNG assets from a legacy system into PDF while applying a filter to meet branding quality standards.
 * 5. When batch‑processing a folder of PNG images to create sharpened PDFs for compliance documentation.
 */
