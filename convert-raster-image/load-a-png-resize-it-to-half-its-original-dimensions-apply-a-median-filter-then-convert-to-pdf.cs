// HOW-TO: Resize PNG, Apply Median Filter, and Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.png";
            string outputPath = "Output/output.pdf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load PNG, resize, apply median filter, and save as PDF
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                // Resize to half the original dimensions
                raster.Resize(raster.Width / 2, raster.Height / 2);

                // Apply median filter with size 5
                raster.Filter(raster.Bounds, new MedianFilterOptions(5));

                // Save the result as PDF
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
 * 1. When you need to reduce the file size of a high‑resolution PNG for faster web loading while preserving visual quality, you can resize it to half its dimensions and apply a median filter before converting it to a PDF report.
 * 2. When generating printable documents from screenshots, you may want to smooth noise with a median filter and embed the cleaned image into a PDF.
 * 3. When automating batch processing of scanned PNG images, resizing them and applying a median filter can improve OCR accuracy before saving them as PDFs.
 * 4. When creating thumbnails for a PDF catalog, you can halve the PNG size, denoise it, and store the result directly as a PDF page.
 * 5. When integrating image preprocessing into a C# workflow that outputs PDFs for archival, this code resizes, denoises, and converts PNGs in a single step.
 */
