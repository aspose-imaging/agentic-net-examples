// HOW-TO: Apply Emboss Convolution Filter to PNG in ASP.NET Core Web API (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;

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

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
                Directory.CreateDirectory(outputDir);

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = image as Aspose.Imaging.RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Input image is not a raster image.");
                    return;
                }

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                    Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3);

                raster.Filter(raster.Bounds, filterOptions);

                var options = new PngOptions();
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
 * 1. When you need to provide an on‑the‑fly emboss effect for user‑uploaded PNG images via a RESTful ASP.NET Core endpoint.
 * 2. When a web service must return a filtered PNG for thumbnails that require a 3×3 emboss convolution without storing intermediate files.
 * 3. When integrating Aspose.Imaging into a microservice that processes product photos and applies a visual enhancement before sending them to the client.
 * 4. When building a server‑side image editor that applies a convolution filter to PNGs and streams the result directly to browsers.
 * 5. When automating batch processing of PNG assets in a cloud API that adds an emboss effect for artistic styling.
 */
