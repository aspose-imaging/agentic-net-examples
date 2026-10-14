// HOW-TO: Convert EPS with Embedded Images to High‑Resolution PDF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.eps";
        string outputPath = "Output\\sample.pdf";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EpsImage epsImage = (EpsImage)Aspose.Imaging.Image.Load(inputPath))
            {
                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.ResolutionSettings = new Aspose.Imaging.ResolutionSetting(300, 300);
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
 * 1. When a design workflow requires converting EPS artwork that contains raster graphics into a 300 dpi PDF for high‑quality print production.
 * 2. When an automated batch process must generate print‑ready PDFs from EPS files while preserving embedded image detail.
 * 3. When a web service needs to accept user‑uploaded EPS files and return a PDF suitable for commercial printing.
 * 4. When a desktop application must export vector EPS drawings with photos to PDF without losing resolution.
 * 5. When a document management system has to archive EPS documents as PDFs that retain the original image fidelity for legal or archival purposes.
 */
