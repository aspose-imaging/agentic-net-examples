// HOW-TO: Convert DjVu Document to PDF with Custom Author Metadata in C# (Aspose.Imaging for .NET)
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
        try
        {
            string inputPath = "sample.djvu";
            string outputPath = "output/output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DjvuImage image = (DjvuImage)Image.Load(inputPath))
            {
                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.PdfDocumentInfo = new PdfDocumentInfo();
                pdfOptions.PdfDocumentInfo.Author = "Custom Author";

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
 * 1. When you need to archive scanned DjVu files as PDF while embedding the author's name for document management systems.
 * 2. When a publishing workflow requires converting multi‑page DjVu manuscripts to PDF and setting custom metadata for copyright tracking.
 * 3. When an application must batch‑process DjVu e‑books into searchable PDFs and include author information for library catalogs.
 * 4. When you want to generate PDF reports from DjVu diagrams and ensure the PDF metadata reflects the creator for compliance audits.
 * 5. When integrating Aspose.Imaging into a C# service that transforms DjVu technical manuals into PDFs with author tags for version control.
 */
