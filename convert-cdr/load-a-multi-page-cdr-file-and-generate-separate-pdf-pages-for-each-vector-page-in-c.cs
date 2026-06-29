using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input CDR file path
            string inputPath = "input\\sample.cdr";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Output directory for PDF pages
            string outputDir = "output";
            Directory.CreateDirectory(outputDir);

            // Load the multi‑page CDR image
            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                // Cache the whole document to avoid repeated loading
                cdr.CacheData();

                int pageIndex = 0;
                foreach (CdrImagePage page in cdr.Pages)
                {
                    // Ensure the page data is cached
                    page.CacheData();

                    // Build output PDF path for the current page
                    string outputPath = Path.Combine(outputDir, $"page_{pageIndex}.pdf");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Configure PDF options with appropriate rasterization settings
                    PdfOptions pdfOptions = new PdfOptions();
                    CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                    {
                        TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = Aspose.Imaging.SmoothingMode.None,
                        PageWidth = page.Width,
                        PageHeight = page.Height
                    };
                    pdfOptions.VectorRasterizationOptions = rasterOptions;

                    // Save the current page as a separate PDF file
                    page.Save(outputPath, pdfOptions);
                    pageIndex++;
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
 * 1. When a designer needs to convert each vector page of a multi‑page CorelDRAW (CDR) file into individual PDF documents for client review, they can use this C# Aspose.Imaging code.
 * 2. When an automated publishing workflow must extract every page from a CDR brochure and save them as separate PDF pages for batch printing, the example provides the required rasterization and file handling.
 * 3. When a web service receives uploaded multi‑page CDR files and must deliver each page as a standalone PDF for downstream processing, developers can employ this code to load, cache, and export the pages.
 * 4. When a document management system needs to archive each vector layer of a multi‑page CDR illustration as a separate searchable PDF, the C# snippet shows how to set PDF options and preserve page dimensions.
 * 5. When a QA tool validates the visual fidelity of each page in a CDR project by comparing generated PDFs against reference images, this Aspose.Imaging routine supplies the per‑page PDF conversion needed for the tests.
 */