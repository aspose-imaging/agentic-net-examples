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
                // Cast to RasterImage to apply filter
                RasterImage rasterImage = (RasterImage)image;

                // Apply sharpen filter to the entire image
                rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

                // Set up PDF export options
                PdfOptions pdfOptions = new PdfOptions();

                // Save the processed image as PDF
                image.Save(outputPath, pdfOptions);
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
 * 1. When a web application needs to convert user‑uploaded JPEG photos to PDF documents while enhancing edge detail with Aspose.Imaging’s sharpen filter in C#.
 * 2. When an e‑commerce platform automatically improves product image clarity by applying a sharpen filter before generating PDF catalogs using Aspose.Imaging for .NET.
 * 3. When a desktop utility processes scanned JPEG receipts, sharpens them to boost OCR accuracy, and saves the results as searchable PDF files via Aspose.Imaging.
 * 4. When a medical imaging workflow prepares radiology JPEG images for PDF reports, applying a sharpen filter to highlight fine structures with Aspose.Imaging’s raster image processing.
 * 5. When a batch script creates high‑quality PDF portfolios from a directory of JPEG assets, sharpening each raster image before saving with Aspose.Imaging’s PdfOptions.
 */