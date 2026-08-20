// HOW-TO: Convert PNG to PDF with Median Filter and Filename Footer in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.png";
            string outputPath = "Output/sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Apply median filter with kernel size 5
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(5));

                // Add footer with file name
                Graphics graphics = new Graphics(image);
                using (SolidBrush brush = new SolidBrush(Color.Black))
                {
                    Font font = new Font("Arial", 12);
                    string footer = Path.GetFileName(inputPath);
                    float x = 10;
                    float y = image.Height - 20;
                    graphics.DrawString(footer, font, brush, new PointF(x, y));
                }

                // Save as PDF
                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.Source = new FileCreateSource(outputPath, false);
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
 * 1. When you must reduce noise in a PNG screenshot, embed the original file name as a footer, and provide the result as a PDF document for client review.
 * 2. When generating PDF invoices that include product images, you can apply a median filter to improve image quality and automatically add the image filename at the bottom of each page.
 * 3. When creating archival PDFs from a batch of PNG scans, the code cleans the images with a median filter and stamps each page with its source filename for traceability.
 * 4. When building a C# utility that converts user‑uploaded PNG graphics into PDF manuals, the median filter sharpens the visuals while the footer identifies the source file.
 * 5. When preparing documentation PDFs that need consistent branding, you can programmatically add a filename footer to each converted PNG and apply noise reduction before saving as PDF.
 */
