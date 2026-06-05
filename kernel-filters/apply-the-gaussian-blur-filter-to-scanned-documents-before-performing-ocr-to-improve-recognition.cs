using System;
using System.IO;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\scanned_document.png";
            string outputPath = @"C:\Images\Processed\scanned_document_blurred.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur with kernel size 5 and sigma 4.0 to the whole image
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new GaussianBlurFilterOptions(5, 4.0));

                // Save the processed image
                rasterImage.Save(outputPath);
            }

            // TODO: Perform OCR on the blurred image using your OCR library of choice
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a .NET service receives scanned PNG receipts and needs to apply a Gaussian blur filter to reduce scanner noise before running OCR for expense reporting.
 * 2. When converting JPEG images of old contracts into raster images and using GaussianBlurFilterOptions to smooth grainy edges, improving OCR accuracy for legal document analysis.
 * 3. When processing handwritten form scans saved as PNG files, applying a Gaussian blur via RasterImage.Filter to eliminate speckles and enhance character recognition in an OCR pipeline.
 * 4. When batch‑processing archival TIFF scans in a C# application, using a Gaussian blur with kernel size 5 and sigma 4.0 to normalize background texture before extracting searchable text with OCR.
 * 5. When generating searchable PDFs from scanned PNG pages, applying the Gaussian blur filter to each page’s raster image to improve OCR results in a document management system.
 */