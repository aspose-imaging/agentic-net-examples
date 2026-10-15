// HOW-TO: Rasterize SVG, Apply Sharpen Kernel, and Save as PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "image.svg");
            string outputPath = Path.Combine("Output", "result.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image svgImage = Aspose.Imaging.Image.Load(inputPath))
            {
                using (MemoryStream pngStream = new MemoryStream())
                {
                    using (PngOptions pngOptions = new PngOptions())
                    {
                        pngOptions.Source = new StreamSource(pngStream);
                        svgImage.Save(pngStream, pngOptions);
                    }

                    pngStream.Position = 0;

                    using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(pngStream))
                    {
                        double[,] kernel = new double[,]
                        {
                            { 0, -1, 0 },
                            { -1, 5, -1 },
                            { 0, -1, 0 }
                        };
                        var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                        raster.Filter(raster.Bounds, filterOptions);

                        using (PngOptions outOptions = new PngOptions())
                        {
                            raster.Save(outputPath, outOptions);
                        }
                    }
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
 * 1. When you need to convert an SVG logo to a high‑resolution PNG for web display while enhancing its edges with a custom sharpening filter.
 * 2. When you must programmatically apply a convolution kernel to rasterized vector graphics in a C# application to improve visual clarity before saving.
 * 3. When an automated build process requires transforming SVG assets into PNG thumbnails with consistent image processing applied.
 * 4. When integrating Aspose.Imaging into a server‑side service that receives SVG files, rasterizes them, and returns filtered PNGs for downstream consumption.
 * 5. When creating a batch job that processes multiple SVG diagrams, applies a custom filter, and stores the results as PNG files for reporting or documentation.
 */
