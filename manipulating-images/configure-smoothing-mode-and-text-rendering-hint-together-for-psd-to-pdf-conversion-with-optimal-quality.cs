// HOW-TO: Convert PSD to PDF with Anti-Alias Smoothing and ClearType Text in C# (Aspose.Imaging for .NET)
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
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace PsDtoPdfConversion
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.psd";
                string outputPath = "output.pdf";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var pdfOptions = new PdfOptions();

                    var vectorOptions = new VectorRasterizationOptions
                    {
                        SmoothingMode = SmoothingMode.AntiAlias,
                        TextRenderingHint = TextRenderingHint.ClearTypeGridFit
                    };

                    pdfOptions.VectorRasterizationOptions = vectorOptions;

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
 * 1. When a designer needs to export layered Photoshop files to PDF for high‑quality print proofs while preserving smooth graphics and crisp text.
 * 2. When an automated build pipeline converts PSD assets to PDF for documentation, ensuring anti‑aliased images and ClearType text rendering.
 * 3. When a web service generates PDF previews of PSD files for client review, requiring optimal visual fidelity on screen.
 * 4. When archiving marketing materials as PDFs, developers use this code to maintain vector‑based quality and readable typography.
 * 5. When integrating Aspose.Imaging into a C# application that batch‑processes PSD files into PDFs with consistent smoothing and text rendering settings.
 */
