// HOW-TO: Apply Gaussian Blur and Brightness to TIFF and Save as PDF in C# (Aspose.Imaging for .NET)
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

                // Apply Gaussian blur
                tiffImage.Filter(tiffImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Adjust brightness (range -255 to 255)
                tiffImage.AdjustBrightness(50);

                // Save the result as PDF
                PdfOptions pdfOptions = new PdfOptions();
                tiffImage.Save(outputPath, pdfOptions);
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
 * 1. When you need to preprocess scanned documents by softening noise and enhancing visibility before converting them to a searchable PDF.
 * 2. When generating printable PDFs from high‑resolution TIFF maps where a subtle blur and brightness boost improve readability.
 * 3. When automating archival of medical imaging files, applying Gaussian blur to protect patient details and adjusting brightness for consistent viewing.
 * 4. When creating marketing brochures from TIFF artwork, using blur to create a background effect and brightening the image before exporting to PDF.
 * 5. When developing a batch conversion tool that standardizes TIFF photographs by applying blur and brightness corrections and saves the results as PDFs for easy distribution.
 */
