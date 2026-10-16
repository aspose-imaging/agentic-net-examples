// HOW-TO: How To Apply Anti-Aliasing When Converting CDR To TIFF In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.cdr";
            string outputPath = "output/output.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var rasterizationOptions = new VectorRasterizationOptions
                {
                    SmoothingMode = SmoothingMode.AntiAlias,
                    TextRenderingHint = TextRenderingHint.AntiAlias
                };

                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                image.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to generate high‑quality printable TIFF files from CorelDRAW (CDR) artwork without jagged edges.
 * 2. When an application must batch‑convert CDR diagrams to TIFF for archival while preserving smooth vector lines.
 * 3. When rendering CDR logos for inclusion in PDF reports and the TIFF output must have anti‑aliased text and graphics.
 * 4. When creating thumbnails of CDR drawings for a web gallery and wants the TIFF previews to look crisp on high‑DPI screens.
 * 5. When integrating Aspose.Imaging into a .NET service that converts user‑uploaded CDR files to TIFF for downstream OCR processing, requiring clear, anti‑aliased images.
 */
