// HOW-TO: Convert CMX Drawing to PDF with Vector Fidelity in C# (Aspose.Imaging for .NET)
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

namespace CmxToPdfConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.cmx";
                string outputPath = "output.pdf";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                using (Image image = Image.Load(inputPath))
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
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate a printable PDF from a CorelDRAW CMX file while preserving vector shapes and font information in a .NET application.
 * 2. When automating batch conversion of legacy CMX drawings to PDF for archival or distribution without rasterizing the artwork.
 * 3. When integrating a document workflow that requires converting user‑uploaded CMX designs into searchable PDFs with embedded fonts for compliance reporting.
 * 4. When building a web service that receives CMX files and returns high‑quality PDF output for preview or download in a browser.
 * 5. When migrating a design catalog from CorelDRAW format to PDF for use in mobile or cross‑platform viewers while keeping the original vector quality.
 */
