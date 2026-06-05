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
            // Hardcoded input and output paths
            string inputPath = "Input/sample.djvu";
            string outputPath = "Output/output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load DjVu document
            using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
            {
                // Configure PDF options with author metadata and export all pages
                PdfOptions pdfOptions = new PdfOptions
                {
                    PdfDocumentInfo = new PdfDocumentInfo
                    {
                        Author = "Custom Author"
                    },
                    MultiPageOptions = new DjvuMultiPageOptions()
                };

                // Export all pages to PDF
                djvuImage.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to convert a multi‑page DjVu technical manual into a searchable PDF while embedding the author's name for proper document metadata, they can use this code.
 * 2. When an application must automate the archival of scanned legal documents stored as DjVu files by exporting every page to a single PDF with custom author information, this snippet provides the solution.
 * 3. When a web service processes user‑uploaded DjVu ebooks and returns a PDF version that includes the publisher’s author metadata for cataloging, the code demonstrates the required steps.
 * 4. When a batch job runs nightly to transform a folder of DjVu engineering drawings into PDF portfolios, preserving the creator’s name in each file’s metadata, the example shows how to achieve it in C#.
 * 5. When integrating Aspose.Imaging into a document management system that needs to display DjVu content as PDF while setting the author field for compliance reporting, this code can be employed.
 */