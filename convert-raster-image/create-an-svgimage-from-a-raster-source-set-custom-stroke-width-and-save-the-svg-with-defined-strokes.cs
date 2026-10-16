// HOW-TO: Create SVG from PNG with Custom Stroke Width in C# (Aspose.Imaging for .NET)
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
        string inputPath = "input.png";
        string outputPath = "output/output.svg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image loadedImage = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = loadedImage as Aspose.Imaging.RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Failed to load raster image.");
                    return;
                }

                var svgOptions = new SvgOptions();
                using (Aspose.Imaging.Image svgImage = Aspose.Imaging.Image.Create(svgOptions, raster.Width, raster.Height))
                {
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(svgImage);
                    graphics.Clear(Aspose.Imaging.Color.White);
                    graphics.DrawImage(raster, new Aspose.Imaging.Point(0, 0));

                    Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 5);
                    graphics.DrawRectangle(pen, 0, 0, raster.Width - 1, raster.Height - 1);

                    svgImage.Save(outputPath);
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
 * 1. When you need to convert a PNG logo into a scalable SVG and add a thick black border for consistent branding across different screen sizes.
 * 2. When generating vector graphics for print layouts, you can raster‑to‑SVG conversion with a defined stroke to ensure crisp outlines.
 * 3. When automating batch processing of UI icons, this code creates SVG files with uniform stroke widths for easy theming.
 * 4. When preparing images for responsive web design, you can embed a custom‑width rectangle around the original raster to maintain aspect ratio in SVG.
 * 5. When building a C# tool that adds decorative frames to raster pictures before exporting them as scalable SVG assets.
 */
