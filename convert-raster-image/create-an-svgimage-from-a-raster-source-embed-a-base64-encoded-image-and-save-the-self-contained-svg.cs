// HOW-TO: Create Self‑Contained SVG from JPEG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
        string inputPath = "input.jpg";
        string outputPath = "output/output.svg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image rasterImg = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = rasterImg as Aspose.Imaging.RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Failed to load raster image.");
                    return;
                }

                int width = raster.Width;
                int height = raster.Height;

                SvgOptions svgOptions = new SvgOptions();

                using (Aspose.Imaging.Image svgImg = Aspose.Imaging.Image.Create(svgOptions, width, height))
                {
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(svgImg);
                    graphics.DrawImage(raster, new Aspose.Imaging.Point(0, 0));
                    svgImg.Save(outputPath, svgOptions);
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
 * 1. When you need to embed a JPEG into a single SVG file for web pages without external image references.
 * 2. When generating printable vector graphics that include raster photos and must be portable across systems.
 * 3. When creating email newsletters that require an SVG with an embedded base64 image to avoid attachment limits.
 * 4. When converting user‑uploaded photos to self‑contained SVG icons for a UI that only supports vector assets.
 * 5. When automating batch processing to turn a folder of raster images into independent SVG files for archival purposes.
 */
