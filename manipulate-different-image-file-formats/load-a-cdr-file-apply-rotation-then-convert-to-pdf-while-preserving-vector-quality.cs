// HOW-TO: Rotate CDR Image 90 Degrees and Convert to Vector PDF in C# (Aspose.Imaging for .NET)
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
        string inputPath = "sample.cdr";
        string outputPath = "sample.pdf";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the CDR file
            using (CdrImage image = (CdrImage)Image.Load(inputPath))
            {
                // Apply rotation (e.g., 90 degrees)
                image.Rotate(90);

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

                // Save as PDF while preserving vector quality
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
 * 1. When a designer needs to programmatically rotate a CorelDRAW file and export it as a high‑quality PDF for printing.
 * 2. When an automated workflow must convert legacy CDR assets to PDF while keeping vector fidelity for downstream editing.
 * 3. When a web service generates PDFs from uploaded CDR files and must ensure the orientation matches user specifications.
 * 4. When a batch process needs to rotate multiple CDR drawings and save them as searchable PDFs without rasterizing the graphics.
 * 5. When a document management system requires preserving vector data while converting rotated CDR diagrams to PDF for archival.
 */
