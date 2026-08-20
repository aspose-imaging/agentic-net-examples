// HOW-TO: Sharpen PNG Image and Save as PDF Page in C# (Aspose.Imaging for .NET)
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
            // Hard‑coded input and output paths
            string inputPath = @"C:\Images\sample.png";
            string outputPath = @"C:\Images\output\sample_sharpened.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;

                // Apply a sharpen filter to the entire image
                rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

                // Save the sharpened image as a PDF page
                var pdfOptions = new PdfOptions();
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
 * 1. When you need to enhance the detail of a scanned PNG before embedding it into a PDF report.
 * 2. When generating printable PDFs from product photos and want to improve sharpness automatically.
 * 3. When converting screenshots to PDF documents while applying a sharpening filter to counteract compression blur.
 * 4. When creating a PDF portfolio of marketing images and require consistent image clarity across pages.
 * 5. When automating a workflow that processes raster graphics, sharpens them, and stores the results as single‑page PDFs for archival.
 */
