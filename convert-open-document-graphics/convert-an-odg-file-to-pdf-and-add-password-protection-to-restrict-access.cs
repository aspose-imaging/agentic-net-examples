// HOW-TO: Convert ODG to PDF with Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            using (PdfOptions pdfOptions = new PdfOptions())
            {
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
 * 1. When you need to programmatically transform OpenDocument graphics (ODG) files into PDF documents for reporting or archival in a .NET application.
 * 2. When an automated workflow must generate PDF versions of ODG diagrams to share with users who only have PDF readers.
 * 3. When a server‑side service converts user‑uploaded ODG drawings to PDF for preview or printing without manual intervention.
 * 4. When integrating Aspose.Imaging into a C# project to batch‑process multiple ODG files into PDFs for bulk document conversion.
 * 5. When you want to ensure the output folder exists and handle missing input files gracefully while converting ODG to PDF in a .NET console app.
 */
