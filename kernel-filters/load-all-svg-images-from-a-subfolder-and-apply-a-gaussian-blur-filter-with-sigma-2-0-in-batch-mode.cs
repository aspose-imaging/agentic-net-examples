// HOW-TO: Batch Convert SVG to PNG with Gaussian Blur in C# (Aspose.Imaging for .NET)
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
            string inputFolder = "input_svgs";
            string outputFolder = "output_pngs";

            var svgFiles = Directory.GetFiles(inputFolder, "*.svg", SearchOption.TopDirectoryOnly);
            foreach (var inputPath in svgFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var svgImage = (SvgImage)image;

                    using (var memoryStream = new MemoryStream())
                    {
                        var pngOptions = new PngOptions();
                        svgImage.Save(memoryStream, pngOptions);
                        memoryStream.Position = 0;

                        using (Image rasterImage = Image.Load(memoryStream))
                        {
                            var raster = (RasterImage)rasterImage;
                            var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(2, 2.0);
                            raster.Filter(raster.Bounds, blurOptions);
                            var outOptions = new PngOptions();
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
 * 1. When you need to preprocess a collection of SVG icons for a web app by converting them to PNG and applying a soft blur to improve visual consistency.
 * 2. When generating blurred PNG thumbnails from vector illustrations for a mobile gallery that requires uniform image dimensions and format.
 * 3. When preparing SVG-based logos for print or PDF output by rasterizing them to PNG and adding a Gaussian blur to create a subtle background effect.
 * 4. When automating the conversion of SVG assets in a CI/CD pipeline, applying a blur filter to meet design guidelines before deployment.
 * 5. When creating a batch of blurred PNG sprites from SVG game assets to achieve a motion‑blur visual style without manual editing.
 */
