using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "C:\\temp\\input.webp";
            string outputPath = "C:\\temp\\output.pdf";

            // Verify input file exists
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
                // Configure PDF options with JPEG compression at 80% quality
                var pdfOptions = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        Compression = PdfImageCompressionOptions.Jpeg,
                        JpegQuality = 80
                    }
                };

                // Save the image as PDF using the configured options
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
 * 1. When a developer needs to embed high‑resolution WebP graphics into a PDF report while keeping the file size low by applying JPEG compression at 80 % quality.
 * 2. When an e‑commerce platform must convert product images stored as WebP into printable PDF catalogs and wants to balance image clarity with reduced download size.
 * 3. When a document management system automates the archival of WebP screenshots as PDFs and requires consistent JPEG compression to meet storage quotas.
 * 4. When a web application generates PDF invoices that include WebP logos and wants to ensure the PDFs are optimized for email attachment limits using Aspose.Imaging’s PdfCoreOptions.
 * 5. When a batch‑processing script converts a folder of WebP assets to PDF for legal compliance and needs to set JPEG compression to 80 % to satisfy both quality and size constraints.
 */