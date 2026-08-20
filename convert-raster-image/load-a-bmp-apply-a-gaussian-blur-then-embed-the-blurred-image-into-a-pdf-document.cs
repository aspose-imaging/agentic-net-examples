// HOW-TO: Apply Gaussian Blur to BMP and Save as PDF in C# (Aspose.Imaging for .NET)
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
            // Define relative input and output paths
            string inputPath = Path.Combine("Input", "sample.bmp");
            string outputPath = Path.Combine("Output", "result.pdf");

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Apply Gaussian blur to the raster image
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                // Save the blurred image embedded in a PDF document
                image.Save(outputPath, new PdfOptions());
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
 * 1. When you need to create a PDF report that shows a softened preview of a BMP diagram for visual emphasis.
 * 2. When generating printable PDFs from scanned BMP images and want to reduce sharp edges with a Gaussian blur before embedding.
 * 3. When building a web service that receives BMP uploads, applies a blur filter for privacy, and returns the result as a PDF document.
 * 4. When automating batch conversion of BMP assets into PDF brochures while applying a consistent blur effect for branding.
 * 5. When integrating Aspose.Imaging into a C# application to preprocess BMP graphics with a Gaussian blur and embed them directly into PDF invoices.
 */
