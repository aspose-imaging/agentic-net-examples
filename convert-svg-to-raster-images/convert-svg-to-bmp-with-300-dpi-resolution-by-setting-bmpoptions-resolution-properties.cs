// HOW-TO: Convert SVG to BMP with 300 DPI Resolution in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.svg");
            string outputPath = Path.Combine("Output", "sample.bmp");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var svgImage = (Aspose.Imaging.FileFormats.Svg.SvgImage)image;

                var bmpOptions = new BmpOptions();
                bmpOptions.ResolutionSettings = new Aspose.Imaging.ResolutionSetting(300, 300);
                bmpOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    PageWidth = svgImage.Width,
                    PageHeight = svgImage.Height
                };

                image.Save(outputPath, bmpOptions);
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
 * 1. When you need to generate high‑resolution bitmap thumbnails from vector SVG logos for print‑ready PDFs in a C# application.
 * 2. When a desktop publishing workflow requires converting scalable SVG illustrations to 300 DPI BMP files for legacy Windows imaging tools.
 * 3. When an automated reporting system must embed SVG charts into BMP images with exact DPI settings for accurate scaling on scanned documents.
 * 4. When a game‑engine asset pipeline transforms SVG UI assets into BMP textures with 300 DPI to match the engine’s pixel‑per‑inch expectations.
 * 5. When a batch processing service creates BMP previews of SVG diagrams for archival storage, preserving the original dimensions and DPI.
 */
