// HOW-TO: Render TIFF to PDF with Anti-Alias Smoothing in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.tiff";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        SmoothingMode = SmoothingMode.AntiAlias
                    }
                };

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
 * 1. When you need to convert scanned TIFF documents to PDF while preserving smooth edges for professional printing.
 * 2. When generating PDF reports from high‑resolution TIFF graphics and want anti‑aliased rendering to avoid jagged lines.
 * 3. When building a C# application that merges multiple TIFF pages into a single PDF with crisp vector‑like quality.
 * 4. When creating PDF archives of medical imaging TIFF files and require smoother visual details for better readability.
 * 5. When automating document workflows that transform TIFF invoices into PDF format and need anti‑alias smoothing to improve on‑screen presentation.
 */
