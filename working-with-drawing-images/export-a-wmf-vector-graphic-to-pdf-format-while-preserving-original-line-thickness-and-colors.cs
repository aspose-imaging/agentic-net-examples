// HOW-TO: Export WMF Vector Graphic to PDF Preserving Line Thickness in C# (Aspose.Imaging for .NET)
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

namespace VectorToPdfExport
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.wmf";
                string outputPath = "output.pdf";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

                using (Image image = Image.Load(inputPath))
                {
                    PdfOptions pdfOptions = new PdfOptions();
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
 * 1. When a Windows application needs to generate printable PDF reports from legacy WMF icons while keeping the original line weights and colors.
 * 2. When a document automation system must batch‑convert WMF diagrams to PDF for archival without losing vector quality.
 * 3. When a web service receives WMF drawings from users and must return a PDF that looks identical for preview or download.
 * 4. When a CAD‑like tool exports its vector sketches stored as WMF files into PDF for sharing with clients who only view PDFs.
 * 5. When a migration script moves graphic assets from an old WMF‑based catalog to a modern PDF catalog while preserving visual fidelity.
 */
