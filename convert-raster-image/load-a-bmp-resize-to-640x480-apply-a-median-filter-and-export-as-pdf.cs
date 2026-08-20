// HOW-TO: Resize BMP to 640x480, Apply Median Filter, Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input\\sample.bmp";
        string outputPath = "Output\\result.pdf";

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

            // Load BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for processing
                RasterImage raster = (RasterImage)image;

                // Resize to 640x480
                raster.Resize(640, 480);

                // Apply median filter with size 5
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(5));

                // Save as PDF
                PdfOptions pdfOptions = new PdfOptions();
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
 * 1. When you need to convert a high‑resolution BMP scan into a smaller PDF for faster email sharing while reducing noise.
 * 2. When generating printable PDF reports from legacy BMP graphics that must be resized to standard 640×480 dimensions.
 * 3. When preprocessing scanned documents by applying a median filter to remove speckles before embedding them in a PDF portfolio.
 * 4. When automating batch conversion of BMP assets to PDF in a C# application, ensuring consistent size and basic noise reduction.
 * 5. When integrating Aspose.Imaging into a .NET workflow to transform BMP images into PDF files with built‑in resizing and filtering for web‑ready previews.
 */
