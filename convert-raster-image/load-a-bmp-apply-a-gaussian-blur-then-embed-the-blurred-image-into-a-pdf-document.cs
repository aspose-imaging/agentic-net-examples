// HOW-TO: Apply Gaussian Blur to BMP and Save as PDF in C# (Aspose.Imaging for .NET)
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
            string outputPath = Path.Combine("Output", "blurred.pdf");

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
                raster.Save(outputPath, new PdfOptions());
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
 * 1. When you need to create a PDF report that includes a softened version of a BMP diagram for visual emphasis.
 * 2. When generating printable brochures where high‑resolution BMP photos must be blurred to protect sensitive details before embedding in PDF.
 * 3. When automating a workflow that converts scanned BMP images into PDF files with a Gaussian blur to reduce visual noise.
 * 4. When building a document‑generation service that applies a blur effect to user‑uploaded BMP avatars before adding them to PDF certificates.
 * 5. When preparing legal documents that require BMP signatures to be obscured with a Gaussian blur before being incorporated into a PDF file.
 */
