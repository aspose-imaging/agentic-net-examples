// HOW-TO: Set Custom DPI When Converting JPEG to PDF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.jpg");
            string outputPath = Path.Combine("Output", "output.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.ResolutionSettings = new Aspose.Imaging.ResolutionSetting(300, 300);
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
 * 1. When you need to generate a high‑resolution PDF from a JPEG for professional printing, you can set a custom DPI before saving.
 * 2. When creating PDF documents for archival standards that require 300 dpi images, this code ensures the output meets the specification.
 * 3. When a web service must convert user‑uploaded photos to PDFs with consistent resolution for downstream processing, the DPI setting guarantees uniform quality.
 * 4. When integrating Aspose.Imaging into a C# application that produces PDFs for e‑signatures, adjusting the DPI helps maintain legibility of scanned signatures.
 * 5. When automating batch conversion of marketing assets from JPEG to PDF and need each PDF to have the same high‑resolution settings, this approach provides a reliable solution.
 */
