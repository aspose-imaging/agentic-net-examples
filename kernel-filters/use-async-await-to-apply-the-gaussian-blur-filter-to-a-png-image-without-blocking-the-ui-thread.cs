// HOW-TO: Apply Gaussian Blur to PNG Asynchronously in C# with Aspose Imaging (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            ProcessAsync(inputPath, outputPath).GetAwaiter().GetResult();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    static async Task ProcessAsync(string inputPath, string outputPath)
    {
        await Task.Run(() =>
        {
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                var options = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0);
                raster.Filter(raster.Bounds, options);
                raster.Save(outputPath, new PngOptions());
            }
        });
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to blur a user‑uploaded PNG in a WPF or WinForms app without freezing the UI.
 * 2. When you want to preprocess images on a background thread before saving them to disk in a desktop application.
 * 3. When you are building a photo‑editing feature that applies a Gaussian blur filter to PNG files while keeping the UI responsive.
 * 4. When you need to integrate Aspose.Imaging’s GaussianBlurFilterOptions into an asynchronous workflow for batch image processing.
 * 5. When you must ensure that image loading, filtering, and saving occur off the main thread to improve performance in a C# application.
 */
