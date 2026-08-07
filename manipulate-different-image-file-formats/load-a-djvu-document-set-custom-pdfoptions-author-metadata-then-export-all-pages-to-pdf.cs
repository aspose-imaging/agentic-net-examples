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

            // Validate input file existence
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
            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                // Configure PDF options with custom author metadata
                PdfOptions pdfOptions = new PdfOptions
                {
                    PdfDocumentInfo = new PdfDocumentInfo
                    {
                        Author = "Custom Author"
                    },
                    // Export all pages
                    MultiPageOptions = new DjvuMultiPageOptions()
                };

                // Save all pages to a single PDF file
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
 * 1. When a developer uses Aspose.Imaging for .NET to convert scanned archival DjVu files into a single PDF while embedding a custom author name for compliance.
 * 2. When an application built with C# and Aspose.Imaging must batch‑process multi‑page DjVu documents and generate a PDF with author metadata for digital publishing workflows.
 * 3. When a legal‑tech solution employing Aspose.Imaging needs to preserve page order from a DjVu case file and add author information before storing the PDF in a document management system.
 * 4. When a C# service leverages Aspose.Imaging to transform DjVu e‑books into PDF format with author attribution for e‑reader compatibility.
 * 5. When a desktop utility uses Aspose.Imaging to load a DjVu image, set PDF document info, and export all pages to one PDF for easy sharing and printing.
 */