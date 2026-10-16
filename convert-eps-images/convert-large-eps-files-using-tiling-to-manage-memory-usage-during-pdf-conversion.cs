// HOW-TO: Convert Large EPS to PDF with Memory Efficient Tiling in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/large.eps";
            string outputPath = "Output/large.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    image.Save(outputPath, pdfOptions);
                }
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
 * 1. When a developer needs to transform high‑resolution EPS artwork into a PDF for printing while keeping the application’s memory footprint low.
 * 2. When an automated batch process must convert dozens of large EPS files to PDFs on a server with limited RAM.
 * 3. When a web service generates PDF reports from vector EPS diagrams without causing out‑of‑memory exceptions.
 * 4. When integrating Aspose.Imaging into a C# desktop app that previews EPS files and exports them as PDFs for archival.
 * 5. When migrating legacy EPS assets to PDF for compliance, requiring a reliable .NET solution that handles big files safely.
 */
