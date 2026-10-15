// HOW-TO: How To Restore Details In A Blurred SVG Using Deconvolution Filter In C# (Aspose.Imaging for .NET)
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
        string inputPath = "input\\image.svg";
        string outputPath = "output\\restored.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                SvgImage svgImage = image as SvgImage;
                if (svgImage == null)
                {
                    Console.Error.WriteLine("The input file is not a valid SVG image.");
                    return;
                }

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageWidth = svgImage.Width,
                        PageHeight = svgImage.Height
                    }
                };

                using (var ms = new MemoryStream())
                {
                    image.Save(ms, pngOptions);
                    ms.Position = 0;
                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetGaussian(3, 1.0)));
                        raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.DeconvolutionFilterOptions(Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetGaussian(3, 1.0)));
                        raster.Save(outputPath, new PngOptions());
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
 * 1. When you receive a blurred SVG logo from a designer and need to sharpen it programmatically before embedding it in a PDF, you can use this code to apply a deconvolution filter and export a clear PNG.
 * 2. When an automated pipeline processes scanned vector graphics that appear fuzzy due to compression, the snippet restores fine details by rasterizing the SVG and applying a Gaussian deconvolution filter in C#.
 * 3. When a web service must convert user‑uploaded SVG icons into high‑quality PNG thumbnails while improving readability, the deconvolution filter helps enhance edges before saving.
 * 4. When a desktop application needs to batch‑process SVG diagrams that were exported with low resolution, this approach restores sharpness and saves the results as PNG files using Aspose.Imaging.
 * 5. When you are building a C# utility to clean up blurred vector illustrations for print production, the code demonstrates how to rasterize the SVG, apply Gaussian deconvolution, and output a print‑ready PNG.
 */
