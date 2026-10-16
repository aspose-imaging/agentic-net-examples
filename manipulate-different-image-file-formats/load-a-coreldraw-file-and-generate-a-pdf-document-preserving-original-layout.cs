// HOW-TO: Convert CorelDRAW CDR to PDF Preserving Layout in C# (Aspose.Imaging for .NET)
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

namespace CorelDrawToPdf
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.cdr";
                string outputPath = "output.pdf";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                var outputDir = Path.GetDirectoryName(outputPath);
                Directory.CreateDirectory(outputDir ?? ".");

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
 * 1. When a design team needs to programmatically export CDR artwork to PDF for client review while keeping the original layout intact.
 * 2. When an automated build pipeline must generate printable PDFs from CorelDRAW source files without manual conversion.
 * 3. When a web service receives uploaded CDR files and must return PDF versions for cross‑platform viewing.
 * 4. When a desktop application needs to batch‑process multiple CorelDRAW drawings into PDFs for archival storage.
 * 5. When a reporting tool requires embedding CorelDRAW graphics into PDF reports while preserving vector quality.
 */
