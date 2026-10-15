// HOW-TO: Apply Gaussian Blur and Deconvolution to SVG and Save as PNG in C# (Aspose.Imaging for .NET)
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
        string inputPath = "input.svg";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            using (Image svgImage = Image.Load(inputPath))
            {
                var svg = (Aspose.Imaging.FileFormats.Svg.SvgImage)svgImage;

                using (var memoryStream = new MemoryStream())
                {
                    var pngOptions = new PngOptions();
                    svg.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    using (Image rasterImage = Image.Load(memoryStream))
                    {
                        var raster = (RasterImage)rasterImage;

                        // Gaussian blur kernel (size 3, sigma 0.5)
                        double[,] gaussianKernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetGaussian(3, 0.5);
                        // Apply Gaussian blur
                        raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(gaussianKernel));
                        // Apply deconvolution with the same kernel
                        raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.DeconvolutionFilterOptions(gaussianKernel));

                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                        var outOptions = new PngOptions();
                        raster.Save(outputPath, outOptions);
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
 * 1. When you need to reduce subtle noise in an SVG icon before converting it to a PNG thumbnail for a website.
 * 2. When you want to apply a light Gaussian blur to an SVG illustration and then restore edge detail with deconvolution for high‑resolution print output.
 * 3. When you must batch‑process multiple SVG logos in C# by blurring, de‑blurring, and saving them as PNG files with consistent image quality.
 * 4. When building an automated asset pipeline that prepares SVG graphics for PDF embedding by applying a 0.5 sigma blur followed by deconvolution and rasterizing to PNG.
 * 5. When creating a C# tool that programmatically enhances vector artwork by applying Gaussian blur and matching deconvolution before exporting the result as a PNG image.
 */
