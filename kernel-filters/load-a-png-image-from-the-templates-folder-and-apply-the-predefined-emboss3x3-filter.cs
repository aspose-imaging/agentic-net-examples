// HOW-TO: Apply Emboss 3x3 Filter to PNG Image Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "templates/input.png";
            string outputPath = "output/embossed.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));

                PngOptions options = new PngOptions
                {
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
 * 1. When you need to add a subtle embossed effect to product photos stored as PNG files before uploading them to an e‑commerce site.
 * 2. When you want to preprocess scanned documents by applying a 3×3 emboss convolution to highlight edges for better visual inspection.
 * 3. When you are building a desktop application that generates stylized thumbnails and requires a quick C# method to emboss PNG images.
 * 4. When you must automate batch processing of PNG assets and need to apply the built‑in Emboss3x3 filter using Aspose.Imaging without external libraries.
 * 5. When you are creating a visual tutorial and need to demonstrate how a convolution filter can transform a PNG image in a .NET environment.
 */
