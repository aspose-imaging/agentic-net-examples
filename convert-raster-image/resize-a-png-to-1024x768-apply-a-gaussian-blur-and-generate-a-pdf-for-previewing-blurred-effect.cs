// HOW-TO: Resize PNG, Apply Gaussian Blur, and Export to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths
            string inputPath = @"C:\Images\input.png";
            string blurredPngPath = @"C:\Images\blurred.png";
            string pdfPath = @"C:\Images\preview.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(blurredPngPath));
            Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Resize to 1024x768
                image.Resize(1024, 768);

                // Apply Gaussian blur to the entire image
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save the blurred PNG
                raster.Save(blurredPngPath);
            }

            // Load the blurred image again for PDF conversion
            using (Image blurredImage = Image.Load(blurredPngPath))
            {
                // Prepare PDF options
                PdfOptions pdfOptions = new PdfOptions();

                // Save as PDF preview
                blurredImage.Save(pdfPath, pdfOptions);
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
 * 1. When you need to create a lower‑resolution preview of a high‑resolution PNG with a soft focus effect for a web gallery.
 * 2. When generating a PDF mock‑up of a blurred background image to show designers how the final layout will appear.
 * 3. When preparing thumbnail images for a document management system that requires both a blurred PNG and a PDF version for quick viewing.
 * 4. When automating a batch process that resizes product photos, adds a Gaussian blur for privacy, and saves them as PDFs for client review.
 * 5. When building a reporting tool that embeds a blurred image preview in a PDF report to illustrate image‑processing results.
 */
