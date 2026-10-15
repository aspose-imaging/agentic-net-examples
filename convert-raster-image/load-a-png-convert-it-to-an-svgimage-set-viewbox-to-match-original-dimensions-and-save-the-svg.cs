// HOW-TO: Convert PNG to SVG with Matching ViewBox in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        string inputPath = Path.Combine("Input", "image.png");
        string outputPath = Path.Combine("Output", "image.svg");

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        BackgroundColor = Aspose.Imaging.Color.White
                    }
                };

                image.Save(outputPath, svgOptions);
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
 * 1. When you need to embed a raster PNG into a web page as a scalable SVG without losing its original dimensions.
 * 2. When generating vector graphics from user‑uploaded PNG assets for responsive design in a C# web application.
 * 3. When converting product thumbnail PNGs to SVG format to enable lossless scaling for print‑ready PDFs.
 * 4. When automating batch processing of PNG icons to SVG files while preserving the exact width and height for UI libraries.
 * 5. When creating SVG placeholders from PNG logos for dynamic image rendering in a .NET desktop application.
 */
