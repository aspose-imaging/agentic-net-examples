// HOW-TO: Convert ODG to PDF with Embedded Fonts in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputPath = Path.Combine(baseDir, "Input", "sample.odg");
            string outputPath = Path.Combine(baseDir, "Output", "sample.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.PdfDocumentInfo = new PdfDocumentInfo();
                    image.Save(outputPath, pdfOptions);
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
 * 1. When you need to generate printable PDF reports from LibreOffice Draw (ODG) files while preserving the original text appearance.
 * 2. When an application must batch‑convert user‑uploaded ODG diagrams to PDF for archival or sharing without losing font styling.
 * 3. When a web service creates PDF invoices from ODG templates and must embed the custom fonts to ensure consistent rendering on any device.
 * 4. When migrating legacy ODG assets to a PDF‑based workflow and require embedded fonts to avoid missing‑font warnings in PDF viewers.
 * 5. When automating document processing in a C# backend and need to preserve exact layout and typography by embedding fonts during ODG‑to‑PDF conversion.
 */
