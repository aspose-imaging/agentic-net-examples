// HOW-TO: Convert ODG to PDF and Set Document Title in C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "sample.odg");
            string outputPath = Path.Combine("Output", "sample.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.PdfDocumentInfo = new PdfDocumentInfo();
                pdfOptions.PdfDocumentInfo.Title = "Converted ODG Document";

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
 * 1. When you need to programmatically convert LibreOffice Draw (ODG) drawings to PDF files for distribution while embedding a custom title in the PDF metadata.
 * 2. When automating a batch process that generates PDF reports from ODG templates and requires the document title to be searchable in PDF viewers.
 * 3. When integrating Aspose.Imaging into a C# application to preserve document information by setting the PDF title after converting vector graphics.
 * 4. When creating a workflow that validates the existence of source ODG files, converts them to PDF, and ensures the output folder structure is created automatically.
 * 5. When handling exceptions during ODG‑to‑PDF conversion in .NET to log errors and prevent application crashes.
 */
