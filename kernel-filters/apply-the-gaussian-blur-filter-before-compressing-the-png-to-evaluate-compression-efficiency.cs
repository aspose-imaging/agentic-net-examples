// HOW-TO: Apply Gaussian Blur to PNG and Save with Maximum Compression in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

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

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions { Radius = 5 });

                var options = new PngOptions
                {
                    PngCompressionLevel = PngCompressionLevel.ZipLevel9,
                    Source = new FileCreateSource(outputPath, false)
                };

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
 * 1. When you need to reduce visual noise in a PNG before archiving it with the smallest possible file size using Aspose.Imaging in a C# application.
 * 2. When you want to preprocess screenshots with a Gaussian blur to protect sensitive details and then compress them at the highest ZIP level for secure transmission.
 * 3. When generating thumbnails for a web gallery where a soft blur improves aesthetics and the PNG must be stored with maximum compression to save bandwidth.
 * 4. When implementing a batch image optimizer that applies a blur filter to large PNG assets before saving them with ZipLevel9 to meet storage constraints.
 * 5. When creating a PDF report that embeds blurred PNG charts and you need the images compressed tightly to keep the final document size low.
 */
