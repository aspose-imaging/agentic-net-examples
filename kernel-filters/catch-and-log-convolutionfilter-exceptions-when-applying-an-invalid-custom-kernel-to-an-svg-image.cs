// HOW-TO: Handle Convolution Filter Exceptions When Applying Invalid Kernel to SVG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load SVG and rasterize to PNG
            using (var image = Aspose.Imaging.Image.Load(inputPath))
            {
                var svgImage = (SvgImage)image;
                string tempPngPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp.png");
                var pngOptions = new PngOptions();
                svgImage.Save(tempPngPath, pngOptions);
            }

            // Load rasterized PNG and apply invalid convolution filter
            using (var raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(Path.Combine(Path.GetDirectoryName(outputPath), "temp.png")))
            {
                double[,] invalidKernel = new double[,]
                {
                    { 1, 0 },
                    { 0, 1 },
                    { 1, 1 }
                };

                try
                {
                    var filterOptions = new ConvolutionFilterOptions(invalidKernel);
                    raster.Filter(raster.Bounds, filterOptions);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Convolution filter error: {ex.Message}");
                }

                var pngOptions = new PngOptions();
                raster.Save(outputPath, pngOptions);
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
 * 1. When you need to convert an SVG diagram to a PNG and ensure that any invalid convolution kernel applied during processing does not crash the application.
 * 2. When you want to log detailed errors from a custom image filter while rasterizing vector graphics for web thumbnails.
 * 3. When your automated pipeline applies user‑defined convolution kernels to SVG‑derived images and must gracefully handle malformed kernels.
 * 4. When debugging image‑processing scripts that use Aspose.Imaging to apply filters, you need to capture and record filter‑specific exceptions.
 * 5. When building a C# service that transforms SVG assets to PNG and applies image effects, you must safeguard against invalid filter parameters to maintain service stability.
 */
