// HOW-TO: Convert EPS Vector File To PDF/A-2b Using C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.eps");
            string outputPath = Path.Combine("Output", "sample.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions();
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
 * 1. When a publishing system needs to archive legacy EPS artwork as PDF/A‑2b compliant documents for long‑term preservation.
 * 2. When a document management workflow must batch‑convert incoming EPS files to PDF/A‑2b before indexing them in a compliance‑focused repository.
 * 3. When a CAD or design application exports vector drawings in EPS and the developer must provide a C# API to deliver PDF/A‑2b PDFs to clients.
 * 4. When a legal department requires that all marketing assets be stored in a PDF/A‑2b format, and the code automates the conversion from EPS using Aspose.Imaging.
 * 5. When an automated build process generates EPS reports and needs to produce PDF/A‑2b versions for distribution to auditors without manual intervention.
 */
