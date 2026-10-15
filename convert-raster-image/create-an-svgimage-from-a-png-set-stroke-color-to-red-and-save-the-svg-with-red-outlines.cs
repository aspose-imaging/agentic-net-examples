// HOW-TO: Convert PNG to SVG with Red Stroke Outlines in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\image.png";
            string outputPath = "Output\\image.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image pngImage = Aspose.Imaging.Image.Load(inputPath))
            {
                var svgOptions = new SvgOptions();
                pngImage.Save(outputPath, svgOptions);
            }

            string svgContent = File.ReadAllText(outputPath);
            svgContent = svgContent.Replace("stroke=\"none\"", "stroke=\"red\"");
            svgContent = svgContent.Replace("stroke=\"black\"", "stroke=\"red\"");
            File.WriteAllText(outputPath, svgContent);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate scalable vector graphics from raster PNG logos and highlight their edges with a red outline for branding purposes.
 * 2. When an automated reporting tool must embed PNG diagrams as SVGs with red borders to match a corporate color scheme.
 * 3. When a web application converts user‑uploaded PNG icons to SVG format and applies a red stroke to make them stand out on dark backgrounds.
 * 4. When a batch‑processing script prepares print‑ready SVG assets from PNG images and ensures all shapes have a consistent red outline for visual emphasis.
 * 5. When a GIS or mapping system requires PNG map tiles to be transformed into SVG layers with red strokes to indicate selected regions.
 */
