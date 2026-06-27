using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\input\sample.cdr";
            string outputPath = @"C:\output\sample.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR file
            using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
            {
                // Cache all pages to avoid lazy loading
                foreach (CdrImagePage page in cdrImage.Pages)
                {
                    page.CacheData();
                }

                // Export each page to PDF (flattened)
                // Here we export the first page; repeat loop for all pages if needed
                int pageNumber = 0;
                CdrImagePage imagePage = (CdrImagePage)cdrImage.Pages[pageNumber];

                // Set up PDF export options with rasterization to flatten layers
                PdfOptions pdfOptions = new PdfOptions();
                CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    PageWidth = imagePage.Width,
                    PageHeight = imagePage.Height
                };
                pdfOptions.VectorRasterizationOptions = rasterOptions;

                // Save the page as a PDF
                imagePage.Save(outputPath, pdfOptions);
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
 * 1. When a design studio needs to convert multi‑layer CorelDRAW CDR artwork into a single‑layer PDF for client review without preserving editability.
 * 2. When an automated build pipeline must batch‑process CDR files, flatten their layers, and generate PDF documentation for archiving.
 * 3. When a web service receives uploaded CDR drawings and must render them as PDF invoices, ensuring all vector and text elements are rasterized for consistent display.
 * 4. When a desktop application needs to preview a specific page of a multi‑page CDR file as a PDF, flattening layers to simplify rendering performance.
 * 5. When a legal compliance tool must transform proprietary CDR designs into non‑editable PDF files to meet document‑retention regulations.
 */