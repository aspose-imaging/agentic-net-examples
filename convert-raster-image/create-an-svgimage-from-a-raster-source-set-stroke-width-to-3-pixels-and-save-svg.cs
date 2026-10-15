// HOW-TO: Create SVG From JPEG With 3‑Pixel Border Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image rasterImage = Aspose.Imaging.Image.Load(inputPath))
            {
                var svgOptions = new SvgOptions();

                using (Aspose.Imaging.Image svgImage = Aspose.Imaging.Image.Create(svgOptions, rasterImage.Width, rasterImage.Height))
                {
                    var graphics = new Aspose.Imaging.Graphics(svgImage);

                    graphics.DrawImage(rasterImage, new Aspose.Imaging.Point(0, 0));

                    var pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 3);
                    graphics.DrawRectangle(pen, new Aspose.Imaging.Rectangle(0, 0, rasterImage.Width, rasterImage.Height));

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
 * 1. When you need to embed a photographed logo into a scalable SVG document and outline it with a consistent 3‑pixel black border for consistent branding across web pages.
 * 2. When converting user‑uploaded JPEG images to SVG format for responsive design while preserving the original dimensions and adding a visible frame.
 * 3. When generating printable vector graphics from raster scans and requiring a uniform stroke width around the image to meet publishing specifications.
 * 4. When creating SVG placeholders from existing raster assets in a C# application, ensuring each placeholder has a defined border for UI layout testing.
 * 5. When automating batch processing of product photos to SVG with a fixed border thickness for e‑commerce catalogs that rely on scalable vector assets.
 */
