// HOW-TO: Apply Median Filter to PNG and Save as PDF in C# (Aspose.Imaging for .NET)
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
            string outputPath = @"C:\Images\sample_filtered.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Apply a median filter with size 5 to the entire image
                raster.Filter(raster.Bounds, new MedianFilterOptions(5));

                // Save the filtered image as a PDF page
                var pdfOptions = new PdfOptions();
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
 * 1. When you need to reduce salt‑and‑pepper noise in a scanned PNG before embedding it in a PDF report.
 * 2. When you want to programmatically preprocess product photos with a median filter and generate a single‑page PDF catalog.
 * 3. When an application must convert raster images to PDF while applying a smoothing filter to improve visual quality for printing.
 * 4. When you are building an automated workflow that validates image files, applies noise reduction, and stores the result as a PDF document.
 * 5. When you need to integrate Aspose.Imaging in a C# service to filter medical images and archive them in PDF format for compliance.
 */
