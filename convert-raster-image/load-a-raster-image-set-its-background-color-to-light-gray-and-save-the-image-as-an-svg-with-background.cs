// HOW-TO: Convert PNG to SVG with Light Gray Background in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.png";
            string outputPath = "Output\\sample.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.LightGray,
                        PageWidth = image.Width,
                        PageHeight = image.Height
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
 * 1. When you need to embed a raster PNG into a scalable SVG for a web page and want a uniform light‑gray canvas behind the image.
 * 2. When preparing graphics for print or PDF export and require the SVG to have a consistent background color that matches a design palette.
 * 3. When converting UI icons from PNG to SVG so they scale without loss while preserving a light‑gray background for visual consistency across themes.
 * 4. When generating email newsletters that use SVG images and need a solid background to ensure the image displays correctly in clients that ignore PNG transparency.
 * 5. When building a responsive design system that stores assets as SVG files with a predefined background color to simplify theming and layout calculations.
 */
