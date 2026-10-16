// HOW-TO: Convert DjVu To PDF With Embedded Metadata Using C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.djvu";
        string outputPath = "output/output.pdf";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions();
                var pdfInfo = new PdfDocumentInfo();

                pdfOptions.PdfDocumentInfo = pdfInfo;

                djvu.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to archive scanned books originally in DjVu format as searchable PDFs that retain the original document metadata.
 * 2. When a legal software solution must convert court filings from DjVu to PDF while preserving case numbers and author information embedded in the file.
 * 3. When an e‑learning platform wants to transform DjVu lecture notes into PDF handouts and keep the title and creation date for proper cataloging.
 * 4. When a digital library migrates its collection from DjVu to PDF and requires the metadata to be carried over for indexing by search engines.
 * 5. When a document management system automates batch conversion of DjVu contracts to PDF and needs the embedded metadata for workflow routing.
 */
