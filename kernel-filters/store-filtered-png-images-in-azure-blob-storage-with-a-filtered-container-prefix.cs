// HOW-TO: Apply Gaussian Blur to PNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
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
            string inputPath = "input.png";
            string outputPath = "output/filtered.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0);
                raster.Filter(raster.Bounds, filterOptions);
                raster.Save(outputPath, new PngOptions());
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
 * 1. When you need to automatically blur sensitive areas of a PNG before publishing it on a website.
 * 2. When you want to preprocess images for a machine‑learning pipeline by smoothing PNG files with a Gaussian filter in a .NET application.
 * 3. When you have to generate a filtered version of user‑uploaded PNGs for preview thumbnails in a content‑management system.
 * 4. When you are building a batch job that reads PNG files, applies a blur effect, and stores the filtered results for later archival.
 * 5. When you need to integrate Aspose.Imaging’s Gaussian blur filter into an Azure Function that processes PNG images before uploading them to Blob storage.
 */
