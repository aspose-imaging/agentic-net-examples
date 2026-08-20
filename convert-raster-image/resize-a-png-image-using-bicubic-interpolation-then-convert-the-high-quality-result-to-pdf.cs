// HOW-TO: Resize PNG with Bicubic Interpolation and Convert to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output/result.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Desired size (example: double the original size)
                int newWidth = image.Width * 2;
                int newHeight = image.Height * 2;

                // Resize using bicubic interpolation (CubicConvolution)
                image.Resize(newWidth, newHeight, ResizeType.CubicConvolution);

                // Prepare PDF export options
                PdfOptions pdfOptions = new PdfOptions();

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
 * 1. When you need to enlarge a PNG logo for high‑resolution printing while preserving quality and embed it directly into a PDF report.
 * 2. When an e‑commerce site must generate printable product catalogs by scaling product images and packaging them as PDF brochures.
 * 3. When a document automation workflow requires converting user‑uploaded PNG screenshots into PDF pages at double size for archival purposes.
 * 4. When a desktop application creates printable invoices that include resized PNG graphics such as barcodes or QR codes saved as PDF.
 * 5. When a batch processing script must upscale PNG assets for marketing materials and output them as PDF files for easy distribution.
 */
