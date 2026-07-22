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
            // Hardcoded input CDR file path
            string inputPath = @"C:\temp\sample.cdr";
            // Hardcoded output directory for PDF pages
            string outputDir = @"C:\temp\output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Load the multi‑page CDR image
            using (CdrImage image = (CdrImage)Image.Load(inputPath))
            {
                // Cache all pages to avoid repeated data loading
                foreach (CdrImagePage page in image.Pages)
                {
                    page.CacheData();
                }

                int pageIndex = 0;
                // Iterate through each page and save as an individual PDF
                foreach (CdrImagePage page in image.Pages)
                {
                    // Build output file path for the current page
                    string outputPath = Path.Combine(outputDir, $"page_{pageIndex}.pdf");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Configure PDF export options
                    PdfOptions pdfOptions = new PdfOptions();
                    CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                    {
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None,
                        PageWidth = page.Width,
                        PageHeight = page.Height
                    };
                    pdfOptions.VectorRasterizationOptions = rasterOptions;

                    // Save the current page as a PDF file
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
 * 1. When a design studio needs to use Aspose.Imaging for .NET to convert each page of a multi‑page CorelDRAW (CDR) file into separate PDF documents for client review or printing.
 * 2. When an automated document workflow must extract vector pages from a CDR archive and save them as individual PDFs for downstream processing such as OCR, archiving, or digital signatures.
 * 3. When a web service generates downloadable PDF previews of each page of a multi‑page CDR file uploaded by users, preserving the original page dimensions and rasterization settings.
 * 4. When a batch conversion tool processes a directory of CDR files and creates one PDF per page to integrate with a PDF‑based publishing pipeline that requires page‑by‑page assets.
 * 5. When a quality‑control script validates the rasterization options of each CDR page by exporting them to PDFs and comparing the output against design specifications.
 */