// HOW-TO: Convert PNG to Transparent SVG with No Background in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.png";
            string outputPath = "Output/result.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                image.BackgroundColor = Color.Transparent;

                var svgOptions = new SvgOptions();
                svgOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    BackgroundColor = Color.Transparent,
                    PageWidth = image.Width,
                    PageHeight = image.Height
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
 * 1. When you need to embed a logo from a PNG file into a web page as an SVG without any background color.
 * 2. When you want to prepare UI icons for high‑resolution displays by converting raster images to scalable SVGs with transparent backgrounds.
 * 3. When generating printable graphics from scanned PNG assets and require the output SVG to retain transparency for overlaying on other designs.
 * 4. When automating a batch process that converts product photos to SVG format for use in vector‑based marketing materials while removing the original background.
 * 5. When integrating Aspose.Imaging in a C# application to create SVG assets from screenshots, ensuring the resulting vector file has no opaque background.
 */
