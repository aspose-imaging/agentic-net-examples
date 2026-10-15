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
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
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

            // Load SVG and rasterize to PNG
            using (Image image = Image.Load(inputPath))
            {
                SvgImage svgImage = (SvgImage)image;
                var rasterOptions = new SvgRasterizationOptions();
                rasterOptions.PageWidth = svgImage.Width;
                rasterOptions.PageHeight = svgImage.Height;

                var pngOptions = new PngOptions();
                pngOptions.VectorRasterizationOptions = rasterOptions;

                svgImage.Save(tempPngPath, pngOptions);
            }

            // Load rasterized PNG and apply Gaussian blur filter
            using (Image img = Image.Load(tempPngPath))
            {
                RasterImage raster = (RasterImage)img;
                var kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetGaussian(5, 1.0);
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
 * 1. When you need to add a subtle blur effect to vector graphics before converting them to raster PNG for web thumbnails.
 * 2. When you want to preprocess SVG logos with a Gaussian filter to reduce sharp edges for print layouts.
 * 3. When automating batch processing of SVG assets to create blurred PNG versions for UI backgrounds.
 * 4. When integrating image processing into a C# service that receives SVG files and outputs softened PNG previews.
 * 5. When testing the visual impact of different blur radii on vector illustrations by programmatically applying a Gaussian kernel.
 */
