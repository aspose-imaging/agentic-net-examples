// HOW-TO: Apply Gaussian Blur to PNG and Save as PDF in C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "image.png");
            string outputPath = Path.Combine("Output", "result.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0));

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
 * 1. When you need to generate a PDF report that includes a softened version of a product photo to reduce visual noise.
 * 2. When creating printable marketing brochures where PNG logos must be blurred for watermark effects before embedding in PDF pages.
 * 3. When automating document workflows that require converting scanned PNG images into PDF while applying a Gaussian blur to hide sensitive details.
 * 4. When developing a C# application that prepares PDF invoices and wants to blur background images to keep the focus on text.
 * 5. When building a batch processing tool that processes PNG screenshots, applies a blur filter, and stores the results as PDF files for archival.
 */
