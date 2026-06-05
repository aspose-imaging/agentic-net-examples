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

            // Load the CDR image
            using (CdrImage image = (CdrImage)Image.Load(inputPath))
            {
                // Select the first page (index 0)
                CdrImagePage page = (CdrImagePage)image.Pages[0];

                // Prepare PDF export options with rasterization settings
                PdfOptions pdfOptions = new PdfOptions();
                CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    PageWidth = page.Width,
                    PageHeight = page.Height
                };
                pdfOptions.VectorRasterizationOptions = rasterOptions;

                // Export the page to PDF
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
 * 1. When a developer needs to convert a CorelDRAW CDR file to a PDF for client delivery, this C# code flattens the layers and exports the drawing as a PDF using Aspose.Imaging.
 * 2. When an automated workflow must generate printable PDFs from multi‑page CDR documents, the code loads each CDR page, applies rasterization options, and saves it as a PDF.
 * 3. When a web service has to validate and archive uploaded CorelDRAW drawings as PDF files, the snippet verifies the file, creates the output folder, and performs the conversion with Aspose.Imaging.
 * 4. When a desktop application requires batch processing of CDR graphics to PDF for compliance reporting, the example demonstrates loading the CDR image, setting page dimensions, and saving the flattened PDF.
 * 5. When an integration script needs to ensure consistent PDF rendering of CorelDRAW artwork across platforms, the code uses CdrRasterizationOptions (e.g., TextRenderingHint and SmoothingMode) to control the export quality.
 */