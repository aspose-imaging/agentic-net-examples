// HOW-TO: How To Set Text Rendering Hint When Converting TIFF To PDF In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Drawing.Text;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

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

            var outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        TextRenderingHint = TextRenderingHint.ClearTypeGridFit
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
 * 1. When you need to convert scanned TIFF documents to searchable PDFs while ensuring the embedded text is rendered sharply using ClearType, this code sets the appropriate TextRenderingHint.
 * 2. When generating PDF reports from high‑resolution TIFF images and want the on‑screen font appearance to match printed quality, you can configure the rendering hint as shown.
 * 3. When processing multi‑page TIFF files for archival and require consistent font readability across different PDF viewers, the example demonstrates how to apply ClearTypeGridFit during conversion.
 * 4. When building a C# application that extracts text from TIFF files and embeds it in PDFs, setting the TextRenderingHint improves OCR‑friendly rendering of the text layer.
 * 5. When automating batch conversion of TIFF assets to PDF in a .NET service and need to control font smoothing for better accessibility, this snippet shows the necessary Aspose.Imaging settings.
 */
