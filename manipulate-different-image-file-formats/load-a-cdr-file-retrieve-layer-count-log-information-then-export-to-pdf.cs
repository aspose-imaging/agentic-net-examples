using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Data\sample.cdr";
        string outputPath = @"C:\Data\sample.pdf";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (CdrImage image = (CdrImage)Image.Load(inputPath))
            {
                // Log the number of pages (layers) in the CDR file
                Console.WriteLine($"Page count: {image.PageCount}");

                // Export the first page to PDF
                int pageNumber = 0;
                CdrImagePage page = (CdrImagePage)image.Pages[pageNumber];

                // Configure PDF export options
                PdfOptions pdfOptions = new PdfOptions();
                CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions()
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                };
                pdfOptions.VectorRasterizationOptions = rasterOptions;
                pdfOptions.VectorRasterizationOptions.PageWidth = page.Width;
                pdfOptions.VectorRasterizationOptions.PageHeight = page.Height;

                // Save the page as a PDF file
                page.Save(outputPath, pdfOptions);
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
 * 1. When a graphic design workflow requires converting CorelDRAW (CDR) files to PDF for client review, a developer can use this code to load the CDR, log the number of pages, and export the first page as a PDF.
 * 2. When an automated document processing system needs to verify the layer count of a CDR file before archiving, this snippet loads the image, prints the page count, and saves a PDF preview.
 * 3. When a batch conversion tool must ensure the output directory exists and safely handle missing CDR files, the example demonstrates file existence checks, directory creation, and exception handling while converting to PDF.
 * 4. When a .NET application has to preserve the exact dimensions and rasterization settings of a CorelDRAW page during PDF generation, the code configures CdrRasterizationOptions and uses Aspose.Imaging to produce a high‑fidelity PDF.
 * 5. When integrating Aspose.Imaging into a CI/CD pipeline to generate PDF documentation from design assets, this code shows how to load a CDR, retrieve its page count, and export a selected page to PDF in a single, reusable block.
 */