// HOW-TO: Reduce PDF File Size from PNG Using Flate Compression in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.png";
        string outputPath = @"C:\Images\sample_output.pdf";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PDF options with compression to reduce file size
                var pdfOptions = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        // Use Flate compression (lossless and generally provides good compression)
                        Compression = PdfImageCompressionOptions.Flate
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
 * 1. When you need to convert high‑resolution PNG screenshots to PDF while keeping the resulting file small for email attachments.
 * 2. When generating printable PDFs from product images and want lossless compression to preserve quality without bloating file size.
 * 3. When automating batch processing of PNG assets into PDFs for a web portal that limits upload size.
 * 4. When integrating Aspose.Imaging into a C# application that must store archived PDFs with minimal storage consumption.
 * 5. When creating PDF reports from PNG charts and require Flate compression to meet corporate document size policies.
 */
