// HOW-TO: Apply Gaussian Blur to PNG and Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Apply Gaussian blur (radius 5, sigma 4.0) to the whole image
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save the blurred image embedded in a PDF page
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
 * 1. When you need to generate a PDF report that includes a softened version of a product photo for a marketing brochure.
 * 2. When you want to preprocess scanned documents by blurring sensitive details before embedding them into a PDF for secure sharing.
 * 3. When creating printable PDFs where background images require a Gaussian blur to reduce visual noise and improve text readability.
 * 4. When automating a workflow that converts PNG assets to PDF while applying a blur effect to meet branding style guidelines.
 * 5. When developing an application that archives images as PDFs and needs to apply a consistent blur filter to all images for aesthetic consistency.
 */
