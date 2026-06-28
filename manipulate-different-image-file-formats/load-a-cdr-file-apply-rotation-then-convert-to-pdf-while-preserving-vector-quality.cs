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
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\sample.cdr";
            string outputPath = @"C:\Images\sample_rotated.pdf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir ?? ".");

            // Load the CDR file
            using (Image image = Image.Load(inputPath))
            {
                // Apply a rotation (e.g., 90 degrees clockwise)
                image.Rotate(90f);

                // Prepare PDF save options with vector rasterization settings
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new CdrRasterizationOptions
                    {
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None,
                        Positioning = PositioningTypes.DefinedByDocument
                    }
                };

                // Save the rotated image as PDF while preserving vector quality
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
 * 1. When a graphic designer needs to automatically rotate a CorelDRAW (.cdr) illustration and generate a print‑ready PDF without losing vector sharpness.
 * 2. When a document management system must batch‑process archived CDR files, apply a 90° orientation correction, and store them as searchable PDFs for compliance.
 * 3. When a web service converts user‑uploaded CDR logos into correctly oriented PDFs for use in marketing collateral while keeping the vector data intact.
 * 4. When an automated publishing workflow reorients technical diagrams from CorelDRAW and outputs high‑resolution PDFs for inclusion in e‑books.
 * 5. When a CAD‑to‑PDF conversion tool needs to preserve exact line art and text rendering while rotating the original CDR drawing for proper page layout.
 */