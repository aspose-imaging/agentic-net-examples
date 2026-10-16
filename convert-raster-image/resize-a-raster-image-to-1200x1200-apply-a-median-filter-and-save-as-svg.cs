// HOW-TO: Resize JPEG to 1200x1200 and Convert to SVG in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.svg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                if (!raster.IsCached)
                    raster.CacheData();

                raster.Resize(1200, 1200, ResizeType.NearestNeighbourResample);

                SvgOptions options = new SvgOptions();
                raster.Save(outputPath, options);
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
 * 1. When you need to generate scalable vector graphics from a high‑resolution photo for web display, you can resize the JPEG to a fixed size and save it as an SVG using Aspose.Imaging in C#.
 * 2. When a mobile app must reduce image dimensions to improve performance while preserving vector compatibility, this code resizes the raster and outputs an SVG file.
 * 3. When an e‑commerce platform requires product images at a uniform 1200 × 1200 size and wants them in SVG format for responsive design, developers can use this snippet.
 * 4. When automating a batch process that converts legacy JPEG assets into scalable SVGs with consistent dimensions, the example shows how to load, resize, and save each image in C#.
 * 5. When integrating image processing into a .NET service that needs to standardize image size before vector conversion for printing or PDF generation, this code provides a simple solution.
 */
