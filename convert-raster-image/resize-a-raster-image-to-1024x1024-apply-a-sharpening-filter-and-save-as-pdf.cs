// HOW-TO: Resize Image to 1024x1024, Sharpen, and Save as PDF in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string inputPath = "C:\\Images\\input.jpg";
            string outputPath = "C:\\Images\\output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for raster operations
                RasterImage rasterImage = (RasterImage)image;

                // Resize to 1024x1024
                rasterImage.Resize(1024, 1024);

                // Apply sharpening filter
                rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

                // Prepare PDF save options
                var pdfOptions = new PdfOptions();

                // Save as PDF
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
 * 1. When you need to generate a high‑resolution PDF thumbnail from a JPEG for a web preview.
 * 2. When preparing product catalog pages that require all images to be uniformly 1024×1024 pixels and sharpened before embedding in a PDF.
 * 3. When converting scanned photos to PDF while enhancing detail and enforcing a fixed size for consistent printing.
 * 4. When automating a batch process that resizes user‑uploaded pictures, applies a sharpening filter, and stores them as PDF documents for archival.
 * 5. When creating PDF reports that include sharpened, square images to meet layout specifications in a C# application.
 */
