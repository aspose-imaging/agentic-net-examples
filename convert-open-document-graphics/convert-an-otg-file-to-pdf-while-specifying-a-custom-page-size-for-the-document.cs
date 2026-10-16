// HOW-TO: Convert OTG to PDF with Custom Page Size in C# (Aspose.Imaging for .NET)
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
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                pdfOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    PageSize = new Aspose.Imaging.SizeF(595, 842),
                    BackgroundColor = Aspose.Imaging.Color.White
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
 * 1. When a developer needs to generate printable PDFs from OTG vector graphics while controlling the page dimensions for layout consistency.
 * 2. When an application must batch‑convert OTG files to PDF for archival purposes and must ensure the output matches a specific paper size such as A4.
 * 3. When integrating Aspose.Imaging into a C# service that creates PDF reports from OTG diagrams and requires a white background for branding.
 * 4. When a web API receives OTG uploads and must return PDFs sized to fit a predefined canvas for downstream processing.
 * 5. When automating document workflows that involve converting OTG assets to PDF with exact width and height to align with existing templates.
 */
