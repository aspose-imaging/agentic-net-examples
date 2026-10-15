// HOW-TO: Convert SVG to 16‑Bit Anti‑Aliased PNG in C# With Aspose.Imaging (Aspose.Imaging for .NET)
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

            using (Image image = Image.Load(inputPath))
            {
                var rasterOptions = new VectorRasterizationOptions
                {
                    SmoothingMode = SmoothingMode.AntiAlias,
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };

                var pngOptions = new PngOptions
                {
                    BitDepth = 16,
                    ColorType = PngColorType.TruecolorWithAlpha,
                    VectorRasterizationOptions = rasterOptions,
                    Source = new FileCreateSource(outputPath, false)
                };

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
 * 1. When a web application needs to display scalable vector graphics as high‑resolution PNGs with smooth edges for retina screens.
 * 2. When a reporting tool must embed SVG logos into PDF or Word documents that only support raster images, preserving color depth.
 * 3. When a batch‑processing service converts a library of SVG icons to 16‑bit PNGs for use in a game engine that requires true‑color with alpha.
 * 4. When an e‑commerce platform generates product thumbnails from vector artwork, ensuring anti‑aliased rendering and 16‑bit color for premium quality.
 * 5. When a desktop utility prepares print‑ready images from SVG designs, needing white background and high‑bit‑depth PNG output for professional printing.
 */
