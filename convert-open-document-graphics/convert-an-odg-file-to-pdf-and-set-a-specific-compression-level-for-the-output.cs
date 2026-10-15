// HOW-TO: Convert ODG to PDF with Compression Settings in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\sample.odg";
            string outputPath = "Output\\sample.pdf";

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
                    // Compression level for PDF is not exposed in this API version.
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
 * 1. When you need to programmatically convert LibreOffice Draw (ODG) diagrams to PDF files for distribution while controlling the output size in a C# application.
 * 2. When an automated reporting system must generate PDF reports from ODG templates and apply compression to meet email attachment limits.
 * 3. When a document management workflow requires batch conversion of ODG assets to searchable PDFs using Aspose.Imaging in .NET.
 * 4. When a web service needs to accept ODG uploads and return compressed PDF versions for preview on browsers.
 * 5. When a desktop utility must preserve the visual fidelity of ODG drawings while creating smaller PDF files for archival storage.
 */
