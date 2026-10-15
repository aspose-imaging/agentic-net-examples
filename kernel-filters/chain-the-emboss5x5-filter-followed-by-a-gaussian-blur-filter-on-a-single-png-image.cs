// HOW-TO: Apply Emboss and Gaussian Blur Filters Sequentially to PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

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

            using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss5x5));
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.GetGaussian(5, 1.0)));

                using (PngOptions options = new PngOptions())
                {
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
 * 1. When you need to give a PNG photo a raised‑edge effect followed by a softening blur for a stylized thumbnail in a C# web application.
 * 2. When preparing product images for an e‑commerce site and want to highlight texture with an emboss filter before applying a Gaussian blur to reduce noise using Aspose.Imaging.
 * 3. When creating artistic filters for a desktop photo editor written in C# that first emphasizes edges with a 5×5 emboss kernel and then smooths the result with a Gaussian blur.
 * 4. When automating batch processing of scanned documents to make text stand out with embossing and then soften background artifacts with a blur in a .NET service.
 * 5. When generating game asset sprites where a raised‑relief look is required first, then a subtle blur is added to blend the sprite into the background using Aspose.Imaging for .NET.
 */
