// HOW-TO: Resize JPEG to 800x600 with Lanczos and Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.jpg";
            string outputPath = @"C:\Images\output.pdf";

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
                // Desired dimensions (example: 800x600)
                int newWidth = 800;
                int newHeight = 600;

                // Resize using Lanczos resampling
                image.Resize(newWidth, newHeight, ResizeType.LanczosResample);

                // Prepare PDF export options
                var pdfOptions = new PdfOptions();

                // Save the resized image as PDF
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
 * 1. When you need to generate a high‑quality PDF thumbnail from a large photo for an e‑commerce product catalog.
 * 2. When you must downscale scanned documents to a standard size before embedding them in a PDF report.
 * 3. When creating printable PDFs from user‑uploaded images while preserving detail using Lanczos resampling.
 * 4. When automating batch conversion of JPEG images to PDF with consistent dimensions for archival purposes.
 * 5. When integrating image resizing and PDF export into a C# web service that returns PDFs to client applications.
 */
