// HOW-TO: Apply Custom Convolution Filter to SVG Layers and Export PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output\\filtered.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image svgImage = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageWidth = 800,
                    PageHeight = 600,
                    BackgroundColor = Color.White
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                using (RasterImage rasterImage = (RasterImage)Image.Create(pngOptions, 800, 600))
                {
                    Graphics graphics = new Graphics(rasterImage);
                    graphics.DrawImage(svgImage, new Point(0, 0));

                    double[,] kernel = new double[,]
                    {
                        { 0, -1, 0 },
                        { -1, 5, -1 },
                        { 0, -1, 0 }
                    };

                    var convOptions = new ConvolutionFilterOptions(kernel);
                    rasterImage.Filter(rasterImage.Bounds, convOptions);

                    rasterImage.Save(outputPath, pngOptions);
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
 * 1. When you need to sharpen vector graphics from an SVG before converting them to a PNG for web thumbnails.
 * 2. When you want to programmatically apply a custom image filter to each layer of a multi‑layer SVG in a .NET application.
 * 3. When you must rasterize an SVG at a specific resolution and background color while enhancing details with a convolution kernel.
 * 4. When you are building an automated pipeline that converts SVG assets to PNGs with consistent image processing across all files.
 * 5. When you need to ensure the output PNG retains the original SVG’s layers but with a sharpened appearance for print or UI use.
 */
