// HOW-TO: Batch Convert Raster Images to PDF with Date Watermark in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Set up base, input, and output directories
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            // Ensure input directory exists; if not, create it and exit
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (var file in files)
            {
                string inputPath = file;

                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output PDF path
                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(file) + ".pdf");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // Work only with raster images
                    RasterImage raster = image as RasterImage;
                    if (raster == null)
                        continue; // Skip non‑raster files

                    // Create graphics object for drawing
                    Graphics graphics = new Graphics(raster);

                    // Prepare watermark text with current date
                    string watermarkText = DateTime.Now.ToString("yyyy-MM-dd");

                    // Define font and brush
                    Font font = new Font("Arial", 24);
                    SolidBrush brush = new SolidBrush(Color.Yellow);

                    // Position the watermark near the bottom‑left corner
                    PointF location = new PointF(10, raster.Height - 30);

                    // Draw the watermark text onto the image
                    graphics.DrawString(watermarkText, font, brush, location);

                    // Save the result as PDF
                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        image.Save(outputPath, pdfOptions);
                    }
                }
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
 * 1. When a company needs to archive scanned invoices as PDFs and automatically stamp each file with the processing date.
 * 2. When a photographer wants to generate watermarked PDF portfolios from a folder of JPEG or PNG images, adding the current date for copyright tracking.
 * 3. When a legal firm must convert a batch of evidence photos into PDF documents while embedding a date watermark to maintain chain‑of‑custody records.
 * 4. When a marketing team creates PDF catalogs from product images and wants each page to show the generation date for version control.
 * 5. When an automated reporting system converts daily generated charts (PNG, BMP) into PDFs and adds the day's date as a watermark for audit purposes.
 */
