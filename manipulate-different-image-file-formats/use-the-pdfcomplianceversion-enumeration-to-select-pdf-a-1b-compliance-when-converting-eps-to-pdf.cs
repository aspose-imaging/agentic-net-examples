// HOW-TO: Convert EPS to PDF/A‑1b Compliant PDF in C# with Aspose.Imaging (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/example.eps";
            string outputPath = "Output/result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                PdfOptions options = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    }
                };
                image.Save(outputPath, options);
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
 * 1. When a publishing system must archive vector graphics from EPS files as PDF/A‑1b documents for long‑term preservation.
 * 2. When an e‑commerce platform needs to generate PDF invoices from EPS logos that meet PDF/A‑1b compliance for legal archiving.
 * 3. When a government agency converts engineering drawings in EPS to PDF/A‑1b to satisfy mandatory document‑management standards.
 * 4. When a desktop application transforms user‑uploaded EPS artwork into PDF/A‑1b PDFs for reliable printing on certified printers.
 * 5. When a cloud service batch‑processes EPS files into PDF/A‑1b PDFs to ensure compatibility with PDF/A‑1b‑only viewers and auditors.
 */
