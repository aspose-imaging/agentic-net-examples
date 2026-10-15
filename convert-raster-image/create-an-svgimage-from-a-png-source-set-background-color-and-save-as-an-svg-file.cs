// HOW-TO: Convert PNG to SVG With White Background In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "Input\\source.png";
            string outputPath = "Output\\result.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                SvgOptions options = new SvgOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    }
                };

                image.Save(outputPath, options);
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
 * 1. When you need to embed a raster PNG logo into a scalable SVG document while ensuring a consistent white canvas for web pages.
 * 2. When generating printable vector graphics from user‑uploaded PNG images and you must set a solid background to avoid transparency issues.
 * 3. When converting product photos stored as PNG files into SVG format for responsive UI components that require a defined page size.
 * 4. When automating batch processing of PNG assets to SVG for a design system, preserving original dimensions and applying a uniform background color.
 * 5. When creating SVG placeholders from PNG thumbnails in a C# application, using Aspose.Imaging to control page width, height, and background.
 */
