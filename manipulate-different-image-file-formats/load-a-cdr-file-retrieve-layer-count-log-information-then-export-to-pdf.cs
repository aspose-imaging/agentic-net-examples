using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Data\sample.cdr";
            string outputPath = @"C:\Data\sample.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (CdrImage image = (CdrImage)Image.Load(inputPath))
            {
                // Retrieve and log the number of pages (layers) in the document
                int layerCount = image.PageCount;
                Console.WriteLine($"Layer (page) count: {layerCount}");

                // Export the first page to PDF
                int pageNumber = 0;
                CdrImagePage page = (CdrImagePage)image.Pages[pageNumber];

                PdfOptions pdfOptions = new PdfOptions();
                CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    PageWidth = page.Width,
                    PageHeight = page.Height
                };
                pdfOptions.VectorRasterizationOptions = rasterOptions;

                page.Save(outputPath, pdfOptions);
                Console.WriteLine($"Exported page {pageNumber} to PDF: {outputPath}");
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
 * 1. When a graphic designer needs to batch‑convert CorelDRAW (.cdr) files to PDF for client review, they can use this code to load each CDR, log the number of layers, and export the first page as a PDF.
 * 2. When an automated document processing pipeline must verify that a CorelDRAW file contains the expected number of pages before publishing, the snippet reads the CDR, retrieves the page count, and records it in logs.
 * 3. When a .NET application has to generate PDF previews of multi‑page CDR drawings for a web portal, this example shows how to rasterize the first page with specific rendering options and save it as a PDF.
 * 4. When a legacy CAD system exports designs as CDR files and a downstream system only accepts PDF, developers can employ this code to safely convert the source file while ensuring the output dimensions match the original page size.
 * 5. When building a file‑validation tool that checks for missing CDR assets and creates PDF backups, the program demonstrates file existence checks, directory creation, layer counting, and PDF export in a single workflow.
 */