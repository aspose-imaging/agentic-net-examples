// HOW-TO: Apply Gamma Correction and Gaussian Blur to TIFF and Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.tif";
            string outputPath = "Output/result.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                TiffImage tiffImage = (TiffImage)image;
                RasterImage raster = (RasterImage)tiffImage.ActiveFrame;

                // Apply gamma correction
                raster.AdjustGamma(2.0f);

                // Apply Gaussian blur (radius 5, sigma 1.0)
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 1.0));

                // Save the processed image as PDF
                raster.Save(outputPath, new PdfOptions());
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
 * 1. When you need to enhance the brightness and contrast of a scanned TIFF document, apply gamma correction before converting it to a searchable PDF.
 * 2. When preparing high‑resolution TIFF photographs for web preview, you can soften details with a Gaussian blur and output the result as a lightweight PDF.
 * 3. When automating archival of medical imaging files, you may adjust gamma to improve visibility and blur noise, then store the processed image in PDF for compliance.
 * 4. When generating printable PDFs from TIFF blueprints, applying gamma correction and a blur filter ensures consistent tonal balance across different printers.
 * 5. When building a batch‑processing pipeline that normalizes TIFF scans and consolidates them into PDF reports, this code handles the image adjustments and format conversion in C#.
 */
