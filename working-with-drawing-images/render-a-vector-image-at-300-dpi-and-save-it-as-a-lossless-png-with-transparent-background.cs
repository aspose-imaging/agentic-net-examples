// HOW-TO: Render SVG to 300 DPI Transparent PNG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            PngOptions pngOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                Source = new FileCreateSource(outputPath, false),
                ResolutionSettings = new Aspose.Imaging.ResolutionSetting(300, 300),
                VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.Transparent
                }
            };

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                image.Save(outputPath, pngOptions);
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
 * 1. When a web application needs to generate high‑resolution PNG thumbnails from user‑uploaded SVG logos while preserving transparency.
 * 2. When a desktop publishing tool must export vector illustrations as lossless PNGs at print‑ready 300 DPI for inclusion in PDFs.
 * 3. When an e‑commerce platform wants to create product images from SVG designs that retain crisp edges and a transparent background for overlay on different backgrounds.
 * 4. When a reporting service converts SVG charts into PNG assets for email attachments, ensuring the images are sharp at 300 DPI and maintain alpha channel information.
 * 5. When a game development pipeline rasterizes SVG UI elements into PNG sprites with exact DPI settings and transparent backgrounds for seamless integration.
 */
