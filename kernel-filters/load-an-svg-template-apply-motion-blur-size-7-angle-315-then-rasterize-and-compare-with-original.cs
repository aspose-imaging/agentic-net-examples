// HOW-TO: Apply Motion Blur to SVG Raster Image and Compare Pixels in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-14
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "template.svg";
            string outputDir = "output";
            string originalRasterPath = Path.Combine(outputDir, "original.png");
            string blurredPath = Path.Combine(outputDir, "blurred.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(originalRasterPath));
            Directory.CreateDirectory(Path.GetDirectoryName(blurredPath));

            using (Image svgImage = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions();
                svgImage.Save(originalRasterPath, pngOptions);
            }

            using (RasterImage originalRaster = (RasterImage)Image.Load(originalRasterPath))
            {
                using (RasterImage blurredRaster = (RasterImage)Image.Load(originalRasterPath))
                {
                    double[,] kernel = ConvolutionFilter.GetBlurMotion(7, 315);
                    var convOptions = new ConvolutionFilterOptions(kernel);
                    blurredRaster.Filter(blurredRaster.Bounds, convOptions);
                    blurredRaster.Save(blurredPath);

                    int diffCount = 0;
                    for (int y = 0; y < originalRaster.Height; y++)
                    {
                        for (int x = 0; x < originalRaster.Width; x++)
                        {
                            var c1 = originalRaster.GetPixel(x, y);
                            var c2 = blurredRaster.GetPixel(x, y);
                            if (c1 != c2) diffCount++;
                        }
                    }
                    Console.WriteLine($"Number of differing pixels: {diffCount}");
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
 * 1. When you need to generate a blurred preview of an SVG logo for a web thumbnail.
 * 2. When you want to programmatically compare a filtered image against the original to detect visual changes.
 * 3. When creating motion‑blur effects for UI assets stored as SVG before converting them to PNG.
 * 4. When testing image‑processing pipelines by applying a convolution filter and verifying pixel differences.
 * 5. When automating quality‑control checks that ensure a motion‑blur operation does not alter unintended regions of a rasterized SVG.
 */
