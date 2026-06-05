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
            // Hardcoded input and output paths
            string inputPath = @"C:\Input\sample.cdr";
            string outputPath = @"C:\Output\sample.cdr.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CorelDRAW file
            using (Image image = Image.Load(inputPath))
            {
                // Configure PDF export options
                var pdfOptions = new PdfOptions();

                // Set vector rasterization options specific to CDR
                var rasterOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = Aspose.Imaging.SmoothingMode.None,
                    Positioning = PositioningTypes.DefinedByDocument
                };

                pdfOptions.VectorRasterizationOptions = rasterOptions;

                // Save as PDF preserving original layout
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
 * 1. When a design studio needs to batch‑convert client‑supplied CorelDRAW (.cdr) artwork into print‑ready PDF files while keeping the original vector layout intact.
 * 2. When an automated document workflow must extract a CDR file from a file share, render it with precise text rendering hints, and store the result as a PDF for archival compliance.
 * 3. When a web application offers a “download as PDF” feature for uploaded CorelDRAW drawings, using C# and Aspose.Imaging to preserve positioning and smoothing settings.
 * 4. When a reporting tool generates marketing collateral by loading CDR templates and exporting them to PDF to ensure consistent appearance across different operating systems.
 * 5. When a quality‑control script validates that a CorelDRAW design exists, creates the necessary output folder, and saves the file as a PDF with vector rasterization options for downstream review.
 */