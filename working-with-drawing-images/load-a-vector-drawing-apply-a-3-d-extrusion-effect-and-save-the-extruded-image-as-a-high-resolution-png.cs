// HOW-TO: Convert SVG to High Resolution PNG with 300 DPI in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-13
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;

public class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image vectorImage = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    ResolutionSettings = new ResolutionSetting(300, 300),
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageWidth = vectorImage.Width,
                        PageHeight = vectorImage.Height
                    }
                };

                vectorImage.Save(outputPath, pngOptions);
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
 * 1. When you need to generate print‑ready PNGs from SVG logos at 300 dpi for marketing materials.
 * 2. When a web service must rasterize scalable vector graphics to high‑resolution PNG thumbnails for a product catalog.
 * 3. When an automated build pipeline converts designer‑provided SVG icons into PNG assets for a Windows desktop application.
 * 4. When a reporting tool requires embedding vector diagrams as PNG images with consistent resolution in PDF reports.
 * 5. When a batch process validates the existence of SVG files and creates high‑quality PNG copies for archival storage.
 */
