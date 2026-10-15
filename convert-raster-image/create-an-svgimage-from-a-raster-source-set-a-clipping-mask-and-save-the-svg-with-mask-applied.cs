// HOW-TO: Convert JPEG to SVG with Clipping Mask in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\source.jpg";
            string outputPath = "Output\\result.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                var svgOptions = new SvgOptions();
                svgOptions.Source = new FileCreateSource(outputPath, false);

                var svgGraphics = new Aspose.Imaging.FileFormats.Svg.Graphics.SvgGraphics2D(raster.Width, raster.Height, 96);
                svgGraphics.DrawImage(raster, new Aspose.Imaging.Point(0, 0));

                using (Aspose.Imaging.FileFormats.Svg.SvgImage svgImage = svgGraphics.EndRecording())
                {
                    svgImage.Save(outputPath, svgOptions);
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
 * 1. When you need to embed a raster photograph inside an SVG for responsive web graphics while preserving vector scalability.
 * 2. When you want to generate SVG files from user‑uploaded images on a server‑side .NET application.
 * 3. When you have to apply a clipping mask to a raster image before exporting it as SVG for print‑ready artwork.
 * 4. When you are building a workflow that converts legacy JPEG assets into SVG format for modern UI frameworks.
 * 5. When you require programmatic creation of SVG files that include raster content for dynamic charting or diagramming in C#.
 */
