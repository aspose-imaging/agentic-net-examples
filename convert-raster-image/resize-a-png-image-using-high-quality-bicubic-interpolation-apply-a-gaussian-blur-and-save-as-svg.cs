// HOW-TO: Resize PNG, Apply Gaussian Blur, and Convert to SVG in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/image.png";
            string outputPath = "Output/image.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                int newWidth = image.Width * 2;
                int newHeight = image.Height * 2;
                image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.5);
                image.Filter(image.Bounds, blurOptions);

                SvgOptions svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        BackgroundColor = Color.White,
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
 * 1. When you need to upscale a PNG logo, soften its edges with a Gaussian blur, and deliver it as a scalable SVG for responsive web design.
 * 2. When a desktop application must generate high‑resolution vector graphics from raster screenshots while applying a blur effect for visual emphasis.
 * 3. When an automated pipeline processes user‑uploaded PNG icons, enlarges them, adds a subtle blur, and stores the result as SVG for use in print or UI assets.
 * 4. When a reporting tool creates blurred background images from PNG charts, resizes them, and embeds them as SVG vectors in PDF reports.
 * 5. When a game development workflow converts blurred, resized PNG textures into SVG files to reduce file size and retain quality across different screen densities.
 */
