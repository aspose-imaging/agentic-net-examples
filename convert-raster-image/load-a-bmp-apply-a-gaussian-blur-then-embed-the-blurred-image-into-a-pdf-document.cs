using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.bmp";
            string outputPath = "output.pdf";

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
                // Cast to RasterImage to access filtering
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole image
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save the blurred image as a PDF document
                rasterImage.Save(outputPath, new PdfOptions());
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
 * 1. When a developer needs to convert a BMP scan of a handwritten form into a PDF while applying a Gaussian blur to obscure sensitive handwriting details.
 * 2. When an application must generate a PDF report that includes a blurred background image from a BMP file to protect copyrighted graphics.
 * 3. When a document management system requires automated preprocessing of BMP logos with Gaussian blur before embedding them into PDF invoices.
 * 4. When a web service creates PDF brochures from BMP product photos and uses Gaussian blur to create a soft focus effect for visual design.
 * 5. When a security tool processes BMP screenshots, applies a Gaussian blur to mask confidential screen content, and saves the result as a PDF for audit logs.
 */