// HOW-TO: Apply Multiple Gaussian Blur Filters to PNG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDirectory = "Output";

            int[] sizes = new int[] { 3, 5, 7 };
            foreach (int size in sizes)
            {
                string outputPath = Path.Combine(outputDirectory, $"output_gaussian_{size}x{size}.png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage raster = (RasterImage)Image.Load(inputPath))
                {
                    raster.Filter(raster.Bounds, new GaussianBlurFilterOptions { Radius = size });

                    PngOptions options = new PngOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
                    };
                    raster.Save(outputPath, options);
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
 * 1. When you need to compare the visual effect of different blur radii on a PNG before choosing the best setting for a photo‑editing tool.
 * 2. When generating preview thumbnails with varying softness levels for a web gallery using C# and Aspose.Imaging.
 * 3. When testing image‑processing pipelines to ensure that Gaussian blur of 3x3, 5x5, and 7x7 kernels behaves consistently across formats.
 * 4. When creating a series of blurred background images for UI overlays while keeping the original PNG dimensions unchanged.
 * 5. When automating batch processing to produce multiple blurred versions of a single PNG for machine‑learning data augmentation.
 */
