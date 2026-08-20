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
            string inputPath = @"C:\Images\sample.png";
            string outputImagePath = @"C:\Images\sample_blurred.png";
            string outputPdfPath = @"C:\Images\sample_blurred.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputImagePath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Apply Gaussian blur filter to the entire image
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save the filtered image (optional, shows the result as PNG)
                raster.Save(outputImagePath);

                // Convert the filtered image to PDF
                var pdfOptions = new PdfOptions();
                raster.Save(outputPdfPath, pdfOptions);
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
 * 1. When you need to soften a product photo before embedding it in a PDF catalog.
 * 2. When you want to create a blurred background image for a PDF report generated from PNG assets.
 * 3. When you must preprocess scanned documents with a Gaussian blur to reduce noise before converting them to PDF.
 * 4. When you are building an automated workflow that applies a blur effect to user‑uploaded images and stores the result as a PDF invoice attachment.
 * 5. When you need to generate a PDF preview of a blurred image for privacy‑sensitive applications such as anonymizing faces.
 */
