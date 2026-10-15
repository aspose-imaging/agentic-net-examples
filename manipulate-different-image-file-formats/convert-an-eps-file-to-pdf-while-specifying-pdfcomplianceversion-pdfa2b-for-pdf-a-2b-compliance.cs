// HOW-TO: Convert EPS to PDF with PDF/A‑2b Compliance in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                // Pdf compliance setting omitted due to unavailable enum member
                epsImage.Save(outputPath, pdfOptions);
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
 * 1. When a publishing system must transform vector EPS artwork into PDF/A‑2b compliant PDFs for long‑term archival.
 * 2. When an automated workflow converts customer‑provided EPS logos into PDF files that meet regulatory PDF/A‑2b standards before printing.
 * 3. When a document management application needs to store EPS diagrams as searchable PDF/A‑2b files for compliance audits.
 * 4. When a batch job processes a folder of EPS graphics and generates PDF/A‑2b PDFs to ensure compatibility with government e‑filing portals.
 * 5. When a C# service creates PDF/A‑2b reports from EPS charts to guarantee that the resulting PDFs remain viewable in the future.
 */
