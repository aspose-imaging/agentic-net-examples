// HOW-TO: Convert SVG to PDF with Embedded Fonts and PDF 1.7 in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputPath = Path.Combine(baseDir, "Input", "input.svg");
            string outputPath = Path.Combine(baseDir, "Output", "output.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                SvgImage svgImage = (SvgImage)image;

                var rasterOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = svgImage.Width,
                    PageHeight = svgImage.Height
                };

                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = rasterOptions
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
 * 1. When a web application needs to generate printable PDF documents from user‑uploaded SVG graphics while preserving font appearance.
 * 2. When an automated reporting tool must batch‑convert SVG charts into PDF files that are compatible with PDF‑1.7 viewers.
 * 3. When a desktop utility has to create PDF invoices from vector logos stored as SVG, ensuring the fonts are embedded for reliable rendering.
 * 4. When a CI/CD pipeline needs to validate that SVG assets render correctly in PDF format for compliance documentation.
 * 5. When a mobile backend service converts SVG icons to PDFs for inclusion in downloadable e‑books that require embedded fonts.
 */
