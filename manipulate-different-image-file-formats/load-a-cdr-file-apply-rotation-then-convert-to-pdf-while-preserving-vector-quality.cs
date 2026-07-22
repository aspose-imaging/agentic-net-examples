using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.cdr";
        string outputPath = @"C:\Images\sample_rotated.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the CDR file
            using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
            {
                // Apply rotation (e.g., 90 degrees)
                cdrImage.Rotate(90f);

                // Set up PDF save options with vector rasterization to preserve vector quality
                PdfOptions pdfOptions = new PdfOptions();
                CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    Positioning = PositioningTypes.DefinedByDocument
                };
                pdfOptions.VectorRasterizationOptions = rasterOptions;

                // Save the rotated image as PDF
                cdrImage.Save(outputPath, pdfOptions);
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
 * 1. When a graphic designer needs to automatically rotate a CorelDRAW (CDR) illustration by 90 degrees and export it as a high‑quality PDF for client review.
 * 2. When a document management system must batch‑process CDR files, apply a fixed orientation, and store them as searchable PDFs without losing vector fidelity.
 * 3. When an e‑learning platform converts rotated CDR diagrams into PDF handouts that retain crisp lines for printing at any size.
 * 4. When a print shop receives CDR artwork that must be re‑oriented before generating PDF proofs that preserve vector details for accurate color separation.
 * 5. When a web service offers on‑the‑fly rotation of uploaded CDR logos and returns PDF files that keep the original vector quality for branding assets.
 */