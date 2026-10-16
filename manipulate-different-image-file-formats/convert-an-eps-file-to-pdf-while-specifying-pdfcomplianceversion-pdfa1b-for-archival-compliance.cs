// HOW-TO: Convert EPS to PDF/A-1b for Archival Compliance in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Pdf;

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

            using (EpsImage image = (EpsImage)Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions();
                pdfOptions.PdfCoreOptions = new PdfCoreOptions { PdfCompliance = PdfComplianceVersion.PdfA1b };
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
 * 1. When you need to archive vector graphics from EPS files in a PDF/A-1b compliant format for long‑term preservation.
 * 2. When a publishing workflow requires converting designer‑provided EPS artwork into PDF for inclusion in PDF/A‑1b compliant documents.
 * 3. When a regulatory system mandates that all exported PDFs meet PDF/A‑1b standards, and you must automate the conversion from EPS.
 * 4. When you are building a .NET service that transforms incoming EPS logos into PDF/A‑1b PDFs for use in legal contracts.
 * 5. When you need to ensure that EPS diagrams are saved as searchable, standards‑compliant PDFs for electronic document management systems.
 */
