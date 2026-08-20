// HOW-TO: Sharpen PNG Image and Save as PDF Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
            string inputPath = @"C:\temp\sample.png";
            string outputPath = @"C:\temp\sample.pdf";

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
                RasterImage rasterImage = (RasterImage)image;

                // Apply sharpening filter to the whole image
                rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

                // Prepare PDF save options
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
 * 1. When you need to enhance the clarity of scanned PNG documents before archiving them as searchable PDF files.
 * 2. When a web application must automatically improve the sharpness of user‑uploaded screenshots and deliver them as PDF reports.
 * 3. When a batch job processes product photos, applies a sharpening filter, and converts them to PDF catalogs for printing.
 * 4. When an e‑learning platform wants to sharpen lecture slide images and embed them in PDF handouts without losing quality.
 * 5. When a desktop utility converts low‑resolution PNG graphics to high‑definition PDF brochures by sharpening them first.
 */
