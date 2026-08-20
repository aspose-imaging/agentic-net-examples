// HOW-TO: Convert CDR to PDF with PDF Version 1.7 in C# (Aspose.Imaging for .NET)
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
        string inputPath = "input.cdr";
        string outputPath = "output.pdf";

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

            // Load the CDR image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PDF options; default PDF version is 1.7
                var pdfOptions = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions()
                    // No explicit PdfCompliance setting needed for PDF 1.7
                };

                // Save as PDF
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
 * 1. When you need to generate PDF documents from CorelDRAW files for client reporting while ensuring compatibility with PDF 1.7 readers.
 * 2. When automating a batch process that converts legacy CDR graphics to PDFs for archival in a document management system.
 * 3. When integrating image conversion into a C# web service that delivers printable PDFs from user‑uploaded CDR files.
 * 4. When preparing marketing assets by converting CDR logos to PDF format that complies with PDF 1.7 standards for print shops.
 * 5. When validating that a converted PDF meets the required version for downstream workflows such as digital signatures or PDF/A conversion.
 */
