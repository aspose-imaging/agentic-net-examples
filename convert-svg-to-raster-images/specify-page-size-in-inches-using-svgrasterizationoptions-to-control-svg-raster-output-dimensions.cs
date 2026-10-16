// HOW-TO: Set SVG Raster Output Size In Inches Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.svg";
            string outputPath = "Output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
                int dpi = 96;
                rasterOptions.PageWidth = 8 * dpi;
                rasterOptions.PageHeight = 6 * dpi;
                rasterOptions.BackgroundColor = Color.White;

                using (PngOptions pngOptions = new PngOptions())
                {
                    pngOptions.VectorRasterizationOptions = rasterOptions;
                    pngOptions.ResolutionSettings = new ResolutionSetting(dpi, dpi);
                    image.Save(outputPath, pngOptions);
                }
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
 * 1. When you need to convert an SVG logo to a PNG thumbnail with exact 8‑by‑6‑inch dimensions for a web catalog.
 * 2. When you must generate print‑ready PNG images from SVG illustrations while preserving a specific DPI and page size.
 * 3. When a reporting tool requires SVG charts to be rasterized to PNG at a fixed physical size for PDF embedding.
 * 4. When an e‑commerce platform needs product SVG drawings rendered as PNGs that match a predefined inch‑based layout.
 * 5. When automating batch conversion of SVG assets to PNGs with consistent page dimensions for a mobile app’s asset pipeline.
 */
