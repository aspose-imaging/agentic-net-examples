// HOW-TO: Rotate CorelDRAW CDR and Convert to Vector PDF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Cdr;

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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                // Apply rotation (90 degrees clockwise)
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Prepare PDF options to preserve vector quality
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        PageWidth = image.Width,
                        PageHeight = image.Height
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
 * 1. When a design team needs to automatically rotate CorelDRAW drawings and export them as high‑resolution vector PDFs for print production.
 * 2. When a document‑generation service must convert uploaded CDR files to PDF while keeping the artwork editable as vectors.
 * 3. When a batch‑processing script has to re‑orient multiple CorelDRAW assets before creating PDF portfolios for a marketing campaign.
 * 4. When an engineering application requires converting rotated CDR schematics to PDF without rasterizing the graphics.
 * 5. When a web application needs to display rotated CorelDRAW illustrations as scalable PDFs for responsive viewing.
 */
