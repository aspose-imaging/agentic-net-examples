using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\input\example.cdr";
            string outputPath = @"C:\output\example.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PDF options with ClearType text rendering
                PdfOptions pdfOptions = new PdfOptions();
                CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = Aspose.Imaging.TextRenderingHint.ClearTypeGridFit
                };
                pdfOptions.VectorRasterizationOptions = rasterOptions;

                // Save as PDF
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
 * 1. When a developer needs to convert CorelDRAW (CDR) artwork to a PDF document while preserving sharp, ClearType‑rendered text for high‑quality printing or on‑screen viewing.
 * 2. When an application must batch‑process CDR files from a folder and generate PDF reports with ClearType text rendering to improve readability on Windows displays.
 * 3. When a web service receives user‑uploaded CDR designs and must return PDF previews with ClearType‑grid‑fit text to ensure the text looks crisp in browsers.
 * 4. When integrating Aspose.Imaging into a C# desktop tool that extracts vector graphics from CDR files and saves them as PDFs with ClearType text rendering for better accessibility.
 * 5. When automating the archival of legacy CDR assets into searchable PDF files and need ClearType text rendering to maintain legibility in the archived documents.
 */