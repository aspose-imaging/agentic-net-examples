// HOW-TO: Create 200x200 Blurred PDF Thumbnail From JPEG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\source.jpg";
        string outputPath = @"C:\Images\Thumbnail\preview.pdf";

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

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for processing
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur (radius 5, sigma 4.0) to the whole image
                var blurOptions = new GaussianBlurFilterOptions(5, 4.0);
                rasterImage.Filter(rasterImage.Bounds, blurOptions);

                // Resize to 200x200 pixels
                rasterImage.Resize(200, 200);

                // Prepare PDF export options
                var pdfOptions = new PdfOptions();

                // Save the processed image as PDF
                rasterImage.Save(outputPath, pdfOptions);
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
 * 1. When you need to generate a small blurred preview PDF of a high‑resolution JPEG for a document management system.
 * 2. When you want to create uniform 200 × 200 thumbnail PDFs from user‑uploaded photos for a web gallery.
 * 3. When you must apply a Gaussian blur to protect sensitive details before embedding the image in a PDF report.
 * 4. When you require automated batch processing that resizes and converts raster images to PDF thumbnails in a C# backend service.
 * 5. When you need to ensure the output folder exists and handle missing source files while creating PDF previews of product images.
 */
