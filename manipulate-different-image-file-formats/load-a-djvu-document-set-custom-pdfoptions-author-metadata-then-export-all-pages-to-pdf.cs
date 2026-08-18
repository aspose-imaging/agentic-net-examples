// HOW-TO: Convert DjVu Document to PDF with Custom Author Metadata in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "input.djvu";
            string outputPath = "output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates if null/empty safely)
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            // Load the DjVu document
            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                // Prepare PDF options with custom author metadata
                var pdfOptions = new PdfOptions
                {
                    PdfDocumentInfo = new PdfDocumentInfo { Author = "Custom Author" }
                };

                // Export all pages to PDF (default behavior)
                djvu.Save(outputPath, pdfOptions);
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
 * 1. When you need to archive scanned DjVu files as PDFs while embedding the author’s name for document management.
 * 2. When a publishing workflow requires converting multi‑page DjVu illustrations into a single PDF and setting author metadata for copyright tracking.
 * 3. When integrating Aspose.Imaging into a C# application that processes user‑uploaded DjVu files and outputs PDFs with consistent author information.
 * 4. When automating batch conversion of DjVu manuals to PDFs for distribution, ensuring each PDF contains the correct author tag for compliance reporting.
 * 5. When creating a digital library that stores original DjVu scans but provides PDF versions with author metadata for easier indexing and retrieval.
 */
