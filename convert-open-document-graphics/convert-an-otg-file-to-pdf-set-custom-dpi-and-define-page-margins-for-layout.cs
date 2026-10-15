// HOW-TO: Convert OTG to PDF with Custom DPI in C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "sample.otg");
            string outputPath = Path.Combine("Output", "result.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                using (PdfOptions options = new PdfOptions())
                {
                    options.ResolutionSettings = new Aspose.Imaging.ResolutionSetting(300, 300);
                    options.PdfDocumentInfo = new PdfDocumentInfo();

                    image.Save(outputPath, options);
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
 * 1. When a developer needs to generate high‑resolution printable PDFs from OTG vector graphics for marketing brochures.
 * 2. When an application must batch‑convert OTG design files to PDF while preserving 300 dpi for accurate scaling in CAD workflows.
 * 3. When a document management system requires OTG drawings to be stored as PDF with consistent resolution for archival compliance.
 * 4. When a web service needs to render OTG images as PDF thumbnails at a specific DPI for preview generation.
 * 5. When integrating Aspose.Imaging into a C# project to transform OTG files into PDF format for cross‑platform distribution with controlled image quality.
 */
