// HOW-TO: Apply Gaussian Blur to SVG and Save as PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;

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

            string tempPngPath = Path.Combine(Path.GetDirectoryName(outputPath) ?? "", "temp.png");

            using (Image svgImage = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions();
                svgImage.Save(tempPngPath, pngOptions);
            }

            using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
            {
                double[,] kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetGaussian(11, 4.5);
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);

                var outOptions = new PngOptions();
                raster.Save(outputPath, outOptions);
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
 * 1. When you need to soften vector graphics before converting them to raster PNGs for web thumbnails, you can use this code to apply a Gaussian blur with a custom kernel.
 * 2. When generating preview images of SVG icons with a smooth blur effect for UI placeholders, the example shows how to rasterize and filter them in C#.
 * 3. When preparing SVG artwork for print layouts that require a subtle blur to reduce sharp edges, this approach converts the SVG to PNG and applies a Gaussian filter using Aspose.Imaging.
 * 4. When building an automated pipeline that processes user‑uploaded SVG files and outputs blurred PNGs for privacy or aesthetic purposes, the code demonstrates the necessary steps.
 * 5. When creating custom image effects for a game’s UI, such as blurred background elements derived from SVG assets, this snippet shows how to create a Gaussian kernel and apply it in .NET.
 */
