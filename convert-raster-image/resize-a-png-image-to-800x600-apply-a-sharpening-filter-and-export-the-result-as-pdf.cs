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
            string inputPath = "Input/sample.png";
            string outputPath = "Output/result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Apply sharpening filter
                raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

                // Resize to 800x600
                raster.Resize(800, 600);

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
 * 1. When a developer needs to convert high‑resolution PNG screenshots into compact 800×600 PDF reports with enhanced edge clarity for inclusion in automated documentation pipelines.
 * 2. When an e‑commerce platform must generate product catalog pages by resizing product PNG images, applying a sharpening filter to improve visual detail, and exporting them as PDF flyers.
 * 3. When a medical imaging system requires batch processing of PNG scans to a standard 800×600 size, sharpen them for better diagnostic visibility, and bundle the results into PDF files for electronic health records.
 * 4. When a marketing automation tool creates personalized PDF brochures by taking user‑uploaded PNG logos, resizing them, sharpening for crispness, and embedding them into PDF templates using C# and Aspose.Imaging.
 * 5. When a legal firm automates the conversion of scanned PNG evidence files into uniformly sized, sharpened PDF documents for easier review and archival in case management software.
 */