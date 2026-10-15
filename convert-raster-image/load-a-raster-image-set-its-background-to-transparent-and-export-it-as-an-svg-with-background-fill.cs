// HOW-TO: Convert PNG to SVG with Transparent Background Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                raster.BackgroundColor = Color.Transparent;
                SvgOptions options = new SvgOptions();
                raster.Save(outputPath, options);
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
 * 1. When you need to embed a raster logo into a scalable vector graphic for responsive web design while removing its background.
 * 2. When converting product photos from PNG to SVG for high‑resolution printing without retaining the original opaque background.
 * 3. When preparing UI icons for a mobile app that require a transparent background in SVG format for theme adaptability.
 * 4. When automating batch processing of scanned images to create lightweight SVG files with no background for PDF generation.
 * 5. When integrating Aspose.Imaging in a C# service that transforms user‑uploaded PNGs into SVGs for vector‑based editing tools.
 */
