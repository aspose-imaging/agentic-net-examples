using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.cdr";
        string outputPath = "Output/sample.pdf";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the CDR image
            using (Image image = Image.Load(inputPath))
            {
                // Set default font to ensure embedding (optional)
                FontSettings.DefaultFontName = "Arial";

                // Configure PDF options with CDR rasterization settings
                PdfOptions pdfOptions = new PdfOptions();
                CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    Positioning = PositioningTypes.DefinedByDocument
                };
                pdfOptions.VectorRasterizationOptions = rasterOptions;

                // Save as PDF with embedded fonts
                image.Save(outputPath, pdfOptions);
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
 * 1. When a graphic design studio needs to archive CorelDRAW (.cdr) artwork as PDF files with embedded fonts to guarantee consistent printing across different machines.
 * 2. When an e‑learning platform automatically converts user‑uploaded CDR illustrations into PDF handouts while preserving text appearance by embedding the fonts.
 * 3. When a legal document management system must transform CDR diagrams into searchable PDFs with embedded fonts to meet compliance and accessibility standards.
 * 4. When a batch processing tool generates PDF reports from multiple CDR files on a server, ensuring the PDFs contain the required fonts so they render correctly on client devices.
 * 5. When a cloud‑based API service offers on‑the‑fly conversion of CDR graphics to PDF for web applications, embedding fonts to avoid missing‑glyph issues in browsers.
 */