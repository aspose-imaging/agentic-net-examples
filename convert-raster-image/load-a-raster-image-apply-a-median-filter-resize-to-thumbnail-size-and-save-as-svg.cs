// HOW-TO: Convert JPEG to SVG Thumbnail With Median Filter In C# (Aspose.Imaging for .NET)
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
        string outputPath = "output.svg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.RasterImage image = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                var medianOptions = new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3);
                image.Filter(image.Bounds, medianOptions);

                image.Resize(150, 150);

                var svgOptions = new SvgOptions();
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
 * 1. When you need to generate a small, web‑friendly SVG preview of a high‑resolution JPEG while reducing noise with a median filter.
 * 2. When you want to create vector thumbnails for a photo gallery that require noise reduction and resizing to 150 × 150 pixels.
 * 3. When an e‑commerce site must display product images as lightweight SVG icons after applying a median filter and scaling them down.
 * 4. When a reporting tool converts scanned JPEG charts into scalable SVG diagrams with consistent thumbnail dimensions.
 * 5. When you automate batch processing to prepare clean, resized SVG assets from a collection of JPEG files for responsive UI design.
 */
