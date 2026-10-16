// HOW-TO: Convert ODG to PDF with Custom Metadata in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
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
            string inputPath = "Input/sample.odg";
            string outputPath = "Output/sample.pdf";

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
                    pdfOptions.PdfDocumentInfo = new PdfDocumentInfo
                    {
                        Author = "Custom Author",
                        Title = "Custom Title"
                    };
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
 * 1. When you need to generate PDF reports from LibreOffice Draw (ODG) drawings while embedding author and title information for document management systems.
 * 2. When an application must batch‑convert user‑uploaded ODG files to searchable PDFs and preserve custom metadata for compliance auditing.
 * 3. When a web service creates printable PDFs from ODG diagrams and wants to set the PDF’s author and title fields for proper indexing in content repositories.
 * 4. When integrating Aspose.Imaging in a C# workflow to transform ODG assets into PDFs with embedded metadata for digital asset management.
 * 5. When automating the archival of ODG design files as PDFs with consistent metadata to ensure consistent cataloging in enterprise archives.
 */
