// HOW-TO: Convert WebP Image to A4 PDF in C# Using Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths (relative)
            string inputPath = "Input\\sample.webp";
            string outputPath = "Output\\sample.pdf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WebP image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PDF options with A4 page size (595x842 points)
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.PageSize = new SizeF(595f, 842f);
                    // Save the image as PDF using the configured options
                    image.Save(outputPath, pdfOptions);
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
 * 1. When you need to embed a WebP graphic into a printable PDF report that must follow the standard A4 page dimensions.
 * 2. When generating invoices or receipts from WebP logos and ensuring the output PDF matches corporate A4 formatting requirements.
 * 3. When automating the creation of marketing brochures where source images are in WebP and the final PDF must be sized for A4 printers.
 * 4. When building a document conversion service that receives WebP uploads and returns A4-sized PDFs for archival or email distribution.
 * 5. When developing a batch process that converts multiple WebP files to PDFs with consistent A4 layout for legal or compliance documentation.
 */
