// HOW-TO: Apply Gaussian Blur to BMP and Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.pdf";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply filters
                RasterImage raster = (RasterImage)image;

                // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole image
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Prepare PDF save options
                PdfOptions pdfOptions = new PdfOptions();

                // Save the blurred image as PDF
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to soften a scanned BMP document before embedding it into a PDF report.
 * 2. When you want to create a PDF preview of a BMP image with a subtle blur for privacy protection.
 * 3. When generating printable PDFs from BMP graphics while applying a Gaussian blur to reduce visual noise.
 * 4. When converting legacy BMP assets to PDF format in a C# application and need a built-in blur filter for aesthetic effect.
 * 5. When automating batch processing of BMP files to produce blurred PDF versions for web publishing or archival.
 */
