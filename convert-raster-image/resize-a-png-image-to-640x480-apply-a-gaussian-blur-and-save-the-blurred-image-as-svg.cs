// HOW-TO: Resize PNG to 640x480, Apply Gaussian Blur and Export as SVG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output/output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                raster.Resize(640, 480);
                if (!raster.IsCached) raster.CacheData();

                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 5.0);
                raster.Filter(raster.Bounds, blurOptions);

                var svgGraphics = new SvgGraphics2D(640, 480, 96);
                svgGraphics.DrawImage(raster, new Point(0, 0));
                SvgImage svgImage = svgGraphics.EndRecording();
                svgImage.Save(outputPath);
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
 * 1. When you need to generate a scalable vector version of a blurred thumbnail from a high‑resolution PNG for responsive web design.
 * 2. When you want to preprocess product photos by resizing them to 640×480 and applying a soft Gaussian blur before embedding them in SVG icons.
 * 3. When creating low‑bandwidth placeholders, you can convert a PNG to a blurred SVG that scales without pixelation on different screen sizes.
 * 4. When automating a workflow that converts user‑uploaded PNG screenshots into blurred SVG overlays for UI mockups.
 * 5. When preparing graphics for print or PDF generation, you may resize a PNG, blur it, and save it as SVG to retain vector quality while applying a smoothing effect.
 */
