// HOW-TO: Apply Blur Then Edge Detection to SVG and Save as PNG in C# (Aspose.Imaging for .NET)
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
            string tempPath = "temp/temp.png";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(tempPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Convert SVG to PNG
            using (Image svgImage = Image.Load(inputPath))
            {
                SvgImage svg = (SvgImage)svgImage;
                var pngOptions = new PngOptions();
                svg.Save(tempPath, pngOptions);
            }

            // Load raster image and apply filters
            using (Image rasterImage = Image.Load(tempPath))
            {
                RasterImage raster = (RasterImage)rasterImage;

                // Predefined blur filter (Box blur 5x5)
                raster.Filter(
                    raster.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetBlurBox(5)));

                // Custom edge‑detection kernel
                double[,] edgeKernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1,  8, -1 },
                    { -1, -1, -1 }
                };
                raster.Filter(
                    raster.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(edgeKernel));

                // Save final image
                var outPngOptions = new PngOptions();
                raster.Save(outputPath, outPngOptions);
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
 * 1. When you need to convert vector SVG graphics to raster PNG files while applying a soft blur before further processing.
 * 2. When you want to highlight the outlines of an SVG image by applying a custom edge‑detection kernel after rasterization.
 * 3. When building a C# image‑processing pipeline that requires sequential filters such as blur and edge detection on the same picture.
 * 4. When preparing SVG assets for web thumbnails or previews that need both smoothing and edge emphasis using Aspose.Imaging.
 * 5. When automating batch conversion of SVG icons into PNGs with built‑in filters to improve visual clarity for UI design.
 */
