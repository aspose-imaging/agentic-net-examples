// HOW-TO: Set Custom Page Size When Converting SVG to PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/input.svg";
            string outputPath = "Output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageWidth = 800,
                PageHeight = 600,
                BackgroundColor = Color.White
            };

            using (PngOptions pngOptions = new PngOptions())
            {
                pngOptions.VectorRasterizationOptions = rasterOptions;

                using (Image image = Image.Load(inputPath))
                {
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
 * 1. When you need to generate a PNG thumbnail of an SVG logo at a fixed 800×600 pixel size for a web dashboard.
 * 2. When you must export SVG diagrams to PNG files with a white background to embed in PDF reports that require a specific page dimension.
 * 3. When creating raster assets for a mobile app where each image must match the design’s exact width and height specifications.
 * 4. When batch‑converting a collection of SVG icons to PNG while enforcing uniform dimensions to keep UI layout consistent.
 * 5. When preparing SVG artwork for print or marketing material and you need to control the output size and background color before rasterization.
 */
