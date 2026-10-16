// HOW-TO: Convert WMF to Scalable PDF with Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace WmfToPdfConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.wmf";
                string outputPath = "output/output.pdf";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    PdfOptions options = new PdfOptions();
                    image.Save(outputPath, options);
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
 * 1. When a developer needs to embed Windows Metafile graphics into a PDF report while preserving vector quality for zoom‑in without pixelation.
 * 2. When an application must batch‑convert legacy WMF icons into searchable PDF documents for archival or compliance purposes.
 * 3. When a CAD or diagramming tool exports drawings as WMF and the downstream system requires PDF output that remains resolution‑independent.
 * 4. When a web service receives WMF files from users and must generate printable PDFs that keep the original vector shapes intact.
 * 5. When automating document generation in C# and the workflow includes converting vector‑based WMF logos into PDF brochures without losing scalability.
 */
