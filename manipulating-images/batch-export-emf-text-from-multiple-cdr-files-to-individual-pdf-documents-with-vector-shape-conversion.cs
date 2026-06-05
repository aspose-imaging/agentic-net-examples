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
            // Hard‑coded list of CDR files to process
            string[] inputFiles = new[]
            {
                @"C:\Images\Sample1.cdr",
                @"C:\Images\Sample2.cdr",
                @"C:\Images\Sample3.cdr"
            };

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output PDF path (same folder, same name, .pdf extension)
                string outputPath = Path.ChangeExtension(inputPath, ".pdf");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the CDR image
                using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
                {
                    // Configure PDF export options
                    PdfOptions pdfOptions = new PdfOptions();

                    // Configure rasterization options for vector conversion
                    CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                    {
                        TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = Aspose.Imaging.SmoothingMode.None,
                        Positioning = Aspose.Imaging.ImageOptions.PositioningTypes.DefinedByDocument
                    };

                    // Assign rasterization options to PDF options
                    pdfOptions.VectorRasterizationOptions = rasterOptions;

                    // Export the entire CDR document (all pages) to PDF
                    cdrImage.Save(outputPath, pdfOptions);
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
 * 1. When a design studio needs to convert a batch of CorelDRAW (.cdr) files into searchable PDF documents while preserving vector shapes for high‑resolution printing.
 * 2. When an automated document workflow must extract EMF text from multiple CDR source files and generate individual PDF reports for archival compliance.
 * 3. When a SaaS platform offers on‑the‑fly conversion of user‑uploaded CDR artwork to PDF, ensuring that text remains crisp by rasterizing vector content with specific rendering hints.
 * 4. When a corporate branding team wants to mass‑export logo assets stored in CDR format to PDF for distribution to partners, maintaining exact positioning and smoothing settings.
 * 5. When a batch processing script is required to validate the existence of CDR files, create corresponding PDF files in the same directory, and apply consistent rasterization options for consistent visual output across all pages.
 */