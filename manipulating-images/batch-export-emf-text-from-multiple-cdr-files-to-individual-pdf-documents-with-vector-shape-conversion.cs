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
            // Hardcoded input CDR files
            string[] inputFiles = new[]
            {
                @"C:\Images\sample1.cdr",
                @"C:\Images\sample2.cdr",
                @"C:\Images\sample3.cdr"
            };

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output PDF path (same folder, .pdf extension)
                string outputPath = Path.ChangeExtension(inputPath, ".pdf");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load CDR image
                using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
                {
                    // Prepare PDF options with CDR rasterization settings
                    PdfOptions pdfOptions = new PdfOptions();
                    CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                    {
                        TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = Aspose.Imaging.SmoothingMode.None,
                        Positioning = Aspose.Imaging.ImageOptions.PositioningTypes.DefinedByDocument
                    };

                    pdfOptions.VectorRasterizationOptions = rasterOptions;

                    // Export the CDR (all pages) to PDF
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
 * 1. When a design studio needs to automatically convert a collection of CorelDRAW (.cdr) artwork files containing EMF text into separate PDF portfolios while preserving vector shapes for high‑resolution printing.
 * 2. When a document management system must ingest multiple CDR source files and generate searchable PDF versions with exact text rendering for archival and compliance purposes.
 * 3. When a marketing automation pipeline has to batch‑process product mock‑ups stored as CDR files and output individual PDF assets that retain scalable vector graphics for web and print distribution.
 * 4. When a software vendor wants to provide a C# utility that transforms client‑supplied CDR drawings into PDF invoices, ensuring the EMF text is rendered with single‑bit per pixel accuracy and no smoothing.
 * 5. When an enterprise workflow needs to convert daily batches of CorelDRAW designs into PDF files for downstream OCR and data extraction while keeping the original vector geometry intact.
 */