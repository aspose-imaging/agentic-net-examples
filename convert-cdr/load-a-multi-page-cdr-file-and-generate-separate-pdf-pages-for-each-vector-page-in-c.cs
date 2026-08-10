// HOW-TO: Convert Multi‑Page CDR to Separate PDF Files in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input CDR file path
            string inputPath = @"C:\Data\sample.cdr";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the CDR image
            using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
            {
                // Iterate through each page in the CDR file
                for (int i = 0; i < cdrImage.PageCount; i++)
                {
                    // Retrieve the specific page
                    CdrImagePage page = (CdrImagePage)cdrImage.Pages[i];

                    // Prepare output PDF file path for the current page
                    string outputPath = $@"C:\Data\output\page{i}.pdf";

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Set up PDF options with rasterization settings matching the page size
                    PdfOptions pdfOptions = new PdfOptions();
                    CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                    {
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None,
                        PageWidth = page.Width,
                        PageHeight = page.Height
                    };
                    pdfOptions.VectorRasterizationOptions = rasterOptions;

                    // Save the individual page as a PDF
                    page.Save(outputPath, pdfOptions);
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
 * 1. When a designer needs to export each page of a multi‑page CorelDRAW (CDR) document as an individual PDF for client review or printing.
 * 2. When an automated workflow must archive every vector page of a CDR file as separate PDF files for document management systems.
 * 3. When a batch conversion tool has to split a large CDR project into single‑page PDFs to reduce file size for web publishing.
 * 4. When a .NET application needs to generate PDF previews of each CDR page for a preview pane in a custom UI.
 * 5. When a reporting service must extract and rasterize each page of a CDR file into PDFs with exact page dimensions for compliance documentation.
 */
