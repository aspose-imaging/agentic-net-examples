// HOW-TO: Convert Multi‑Page CDR to Separate PDF Files in C# (Aspose.Imaging for .NET)
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
            string outputDirectory = @"C:\Data\PdfOutput";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the CDR image
            using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
            {
                // Log page (layer) count
                int pageCount = cdrImage.PageCount;
                Console.WriteLine($"Cdr file contains {pageCount} page(s).");

                // Export each page to a separate PDF file
                for (int i = 0; i < pageCount; i++)
                {
                    // Get the specific page
                    CdrImagePage page = (CdrImagePage)cdrImage.Pages[i];

                    // Prepare output PDF path
                    string outputPath = Path.Combine(outputDirectory, $"page_{i}.pdf");

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Set up PDF export options with rasterization settings
                    PdfOptions pdfOptions = new PdfOptions();
                    CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                    {
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None,
                        PageWidth = page.Width,
                        PageHeight = page.Height
                    };
                    pdfOptions.VectorRasterizationOptions = rasterOptions;

                    // Save the page as PDF
                    page.Save(outputPath, pdfOptions);
                    Console.WriteLine($"Exported page {i} to {outputPath}");
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
 * 1. When you need to programmatically extract each layer of a CorelDRAW (CDR) document and save them as individual PDF files for printing or archiving.
 * 2. When an automated workflow must verify the number of pages in a CDR file before converting it to PDFs for downstream processing.
 * 3. When a .NET application has to generate PDF previews of each CDR page with specific rasterization settings like no smoothing and single‑bit text rendering.
 * 4. When you want to batch‑convert multiple CDR files into PDFs and store the results in a predefined folder structure.
 * 5. When integrating Aspose.Imaging into a document management system to preserve the original dimensions of CDR pages while exporting them to PDF format.
 */
