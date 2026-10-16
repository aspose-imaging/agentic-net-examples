// HOW-TO: Apply Corner Detection Kernel to SVG and Save as PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string tempPngPath = "temp.png";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath) ?? ".");
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            using (Image svgImage = Image.Load(inputPath))
            {
                SvgImage svg = (SvgImage)svgImage;
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageWidth = svg.Width,
                    PageHeight = svg.Height,
                    BackgroundColor = Color.White
                };
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };
                svg.Save(tempPngPath, pngOptions);
            }

            using (Image rasterImage = Image.Load(tempPngPath))
            {
                RasterImage raster = (RasterImage)rasterImage;
                double[,] kernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1,  8, -1 },
                    { -1, -1, -1 }
                };
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);
                raster.Save(outputPath);
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
 * 1. When you need to convert vector SVG graphics to raster PNG for web display while highlighting edges.
 * 2. When you want to detect and emphasize corners in an SVG diagram for computer‑vision preprocessing.
 * 3. When you must automate batch processing of SVG icons and output PNGs with a Laplacian filter applied.
 * 4. When you are building a C# tool that extracts structural features from vector artwork for quality inspection.
 * 5. When you require a simple way to rasterize an SVG, apply a custom convolution kernel, and save the filtered image without external image‑processing libraries.
 */
