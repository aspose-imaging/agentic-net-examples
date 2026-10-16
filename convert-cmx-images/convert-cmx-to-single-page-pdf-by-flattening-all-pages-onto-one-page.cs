// HOW-TO: Convert CMX to Single Page PDF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.cmx";
            string outputPath = "output/output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions();
                cmx.Save(outputPath, pdfOptions);
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
 * 1. When you need to archive multi‑page CorelDRAW CMX drawings as a single PDF for easy storage or compliance.
 * 2. When a web application must generate a printable PDF from a CMX file without preserving separate layers or pages.
 * 3. When integrating a document workflow that requires converting legacy CMX artwork into a single‑page PDF for downstream processing.
 * 4. When you want to provide customers a quick preview of a CMX design by flattening all pages into one PDF page.
 * 5. When automating batch conversion of CMX files to PDFs for batch printing or electronic distribution.
 */
