// HOW-TO: Convert DjVu Document to PDF with Author Metadata in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input\\sample.djvu";
        string outputPath = "Output\\output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the DjVu document
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PDF options with author metadata
                var pdfOptions = new PdfOptions
                {
                    PdfDocumentInfo = new PdfDocumentInfo { Author = "Automated" }
                };

                // Save all pages to a single PDF file
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
 * 1. When you need to archive scanned DjVu files as searchable PDFs and automatically tag them with an author name.
 * 2. When a document management system must programmatically convert multi‑page DjVu reports into a single PDF for downstream workflows.
 * 3. When generating PDF invoices from DjVu templates and you want to embed the creator’s name in the PDF metadata.
 * 4. When automating a migration of legacy DjVu manuals to PDF while preserving author information for compliance audits.
 * 5. When building a C# service that receives DjVu uploads, converts them to PDF, and sets consistent metadata for indexing in a content repository.
 */
