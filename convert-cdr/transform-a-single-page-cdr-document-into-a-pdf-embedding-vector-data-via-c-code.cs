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
            // Hardcoded input and output paths
            string inputPath = "Input\\sample.cdr";
            string outputPath = "Output\\sample.pdf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR document
            using (Image image = Image.Load(inputPath))
            {
                // Cast to CdrImage to access pages
                CdrImage cdrImage = (CdrImage)image;

                // Get the first (single) page
                int pageNumber = 0;
                CdrImagePage imagePage = (CdrImagePage)cdrImage.Pages[pageNumber];

                // Configure PDF options with vector rasterization settings
                PdfOptions pdfOptions = new PdfOptions();
                CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                };
                pdfOptions.VectorRasterizationOptions = rasterOptions;

                // Set page dimensions to match the CDR page size
                pdfOptions.VectorRasterizationOptions.PageWidth = imagePage.Width;
                pdfOptions.VectorRasterizationOptions.PageHeight = imagePage.Height;

                // Save the page as PDF
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
 * 1. When a developer needs to convert a single‑page CorelDRAW (CDR) design to a PDF for client‑ready documentation while preserving vector quality, they can use this C# code with Aspose.Imaging.
 * 2. When an ASP.NET application must generate PDF invoices from CDR templates on the fly, this code provides the necessary rasterization options to keep text crisp and layout accurate.
 * 3. When a batch‑processing service has to create PDF previews of individual CDR logo files for a marketing portal, the example shows how to load each page and save it as a vector‑based PDF.
 * 4. When a CAD workflow requires PDF output that matches the exact dimensions of a CDR drawing, the code demonstrates setting page width and height via CdrRasterizationOptions.
 * 5. When a document‑management system needs to validate and display CDR files by converting them to searchable PDFs, this snippet illustrates the straightforward C# conversion process.
 */