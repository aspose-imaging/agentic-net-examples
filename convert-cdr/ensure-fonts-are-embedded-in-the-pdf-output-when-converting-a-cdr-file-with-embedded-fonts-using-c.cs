using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.cdr";
            string outputPath = "Output/sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions
                {
                    KeepMetadata = true,
                    VectorRasterizationOptions = new CdrRasterizationOptions
                    {
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None,
                        Positioning = PositioningTypes.DefinedByDocument
                    }
                };

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
 * 1. When a graphic design studio needs to convert CorelDRAW (.cdr) artwork with custom fonts into PDF for client review while preserving exact typography.
 * 2. When an automated document generation system must batch‑process CDR files into searchable PDFs that retain embedded fonts for compliance reporting.
 * 3. When a web application offers on‑the‑fly preview of uploaded CDR designs as PDFs and must ensure the fonts appear correctly on any device without requiring the original font files.
 * 4. When a print shop prepares print‑ready PDFs from CDR source files and wants to embed the fonts to avoid font substitution errors during RIP processing.
 * 5. When a digital asset management workflow archives CDR illustrations as PDFs with embedded fonts to guarantee long‑term fidelity and easy indexing.
 */