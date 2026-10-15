// HOW-TO: Set SVG DPI and Rasterize to PNG with 300 DPI in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.svg";
            string outputPath = "Output/sample.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (PngOptions pngOptions = new PngOptions())
                {
                    pngOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        BackgroundColor = Color.White
                    };
                    pngOptions.ResolutionSettings = new ResolutionSetting(300, 300);
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
 * 1. When you need to convert an SVG logo to a high‑resolution PNG for print media while preserving a specific 300 DPI setting.
 * 2. When generating thumbnails from vector graphics for a web gallery and you must ensure all images share the same DPI for consistent sizing.
 * 3. When automating batch processing of SVG icons to PNG assets for a mobile app that requires a uniform resolution across devices.
 * 4. When preparing SVG diagrams for inclusion in a PDF report and you need the rasterized PNG to match the document’s DPI for sharpness.
 * 5. When integrating vector artwork into a game engine and you must rasterize it to PNG at a fixed DPI to avoid scaling artifacts.
 */
