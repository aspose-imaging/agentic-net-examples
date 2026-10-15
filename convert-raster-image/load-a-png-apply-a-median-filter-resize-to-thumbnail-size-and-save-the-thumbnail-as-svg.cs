// HOW-TO: Create PNG Thumbnail with Median Filter and Save as SVG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageFilters.FilterOptions;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/input.png";
            string outputPath = "Output/output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                var medianOptions = new MedianFilterOptions(3);
                raster.Filter(raster.Bounds, medianOptions);

                int thumbWidth = 150;
                int thumbHeight = 150;
                raster.Resize(thumbWidth, thumbHeight, ResizeType.NearestNeighbourResample);

                var svgOptions = new SvgOptions();
                raster.Save(outputPath, svgOptions);
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
 * 1. When you need to generate a small, noise‑reduced preview of a PNG for web pages and store it as a scalable SVG file.
 * 2. When converting high‑resolution PNG assets into lightweight SVG thumbnails for responsive design without losing vector quality.
 * 3. When preprocessing PNG images with a median filter before resizing to eliminate speckle noise in automated image pipelines.
 * 4. When creating SVG icons from raster PNG sources for use in UI libraries that require vector formats.
 * 5. When building a C# service that batch‑processes PNG files, applies smoothing, resizes them to 150 × 150 pixels, and outputs SVG thumbnails for faster loading.
 */
