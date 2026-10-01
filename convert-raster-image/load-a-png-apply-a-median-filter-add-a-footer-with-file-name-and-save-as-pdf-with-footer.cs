// HOW-TO: Add Filename Footer to PNG, Apply Median Filter, Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir ?? ".");

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));

                using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.Black))
                {
                    Font font = new Font("Arial", 12);
                    Graphics graphics = new Graphics(raster);
                    string fileName = Path.GetFileName(inputPath);
                    float x = 10;
                    float y = raster.Height - 20;
                    graphics.DrawString(fileName, font, brush, new Aspose.Imaging.PointF(x, y));
                }

                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.Source = new FileCreateSource(outputPath, false);
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
 * 1. When you need to clean up a scanned PNG image with a median filter before archiving it as a PDF that includes the original file name as a footer.
 * 2. When generating PDF reports from PNG assets and you want each page to display the source image’s filename at the bottom for traceability.
 * 3. When automating batch conversion of product photos from PNG to PDF while reducing noise and adding a branding label with the file name.
 * 4. When creating printable PDFs from PNG screenshots and need to embed the screenshot’s filename as a caption for documentation purposes.
 * 5. When preparing legal‑evidence PDFs from PNG images, applying a median filter to improve clarity and appending the file name as a footer for audit trails.
 */
