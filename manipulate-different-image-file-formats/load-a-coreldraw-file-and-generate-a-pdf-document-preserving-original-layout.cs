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
            // Hardcoded input and output file paths
            string inputPath = @"C:\Data\sample.cdr";
            string outputPath = @"C:\Data\sample.cdr.pdf";

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
                // Prepare PDF export options
                var pdfOptions = new PdfOptions();

                // Configure rasterization options for CDR vector content
                var rasterOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
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
 * 1. When a design studio needs to automatically convert client‑supplied CorelDRAW (.cdr) artwork into PDF files for review while keeping the original layout intact.
 * 2. When a document management system must ingest CDR files and store them as searchable PDFs without manually opening each file in CorelDRAW.
 * 3. When a batch‑processing service generates printable PDFs from a folder of CorelDRAW drawings for a print‑on‑demand workflow.
 * 4. When a web application allows users to upload .cdr files and instantly provides a PDF preview that matches the vector layout of the source file.
 * 5. When an archival tool needs to preserve legacy CorelDRAW graphics by rasterizing them with specific rendering hints and saving them as PDF for long‑term storage.
 */