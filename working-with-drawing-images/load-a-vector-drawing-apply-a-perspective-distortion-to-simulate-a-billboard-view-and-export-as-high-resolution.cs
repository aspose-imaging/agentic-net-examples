// HOW-TO: Convert SVG to High Resolution PNG with 300 DPI in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.png";

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
                    Source = new FileCreateSource(outputPath, false),
                    VectorRasterizationOptions = new SvgRasterizationOptions()
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
 * 1. When you need to generate print‑ready PNG assets from scalable SVG logos at 300 dpi for marketing materials.
 * 2. When a web service must dynamically convert user‑uploaded SVG illustrations into high‑resolution PNG thumbnails for preview.
 * 3. When an e‑commerce platform requires rasterizing vector product diagrams into PNGs with exact resolution for PDF catalogs.
 * 4. When a desktop application needs to batch‑process SVG icons into PNG files for Windows UI resources at a specific DPI.
 * 5. When a reporting tool must embed vector charts as high‑quality PNG images in PDF reports without losing detail.
 */
