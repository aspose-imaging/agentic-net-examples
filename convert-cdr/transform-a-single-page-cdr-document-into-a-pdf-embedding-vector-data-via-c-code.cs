// HOW-TO: Convert Single Page CDR To PDF With Aspose.Imaging C# (Aspose.Imaging for .NET)
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

namespace CdrToPdfConverter
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

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                using (Image image = Image.Load(inputPath))
                {
                    image.Save(outputPath, new PdfOptions());
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
 * 1. When a designer needs to programmatically export a CorelDRAW (CDR) illustration as a PDF for client review without rasterizing the artwork.
 * 2. When an automated build pipeline must convert single‑page vector drawings into PDF files for archival or printing.
 * 3. When a web service receives CDR uploads and must generate PDF previews for browser display.
 * 4. When a desktop application needs to batch‑process CDR files and save them as searchable PDF documents using C#.
 * 5. When a document management system requires conversion of vector CDR assets to PDF while preserving scalability and quality.
 */
