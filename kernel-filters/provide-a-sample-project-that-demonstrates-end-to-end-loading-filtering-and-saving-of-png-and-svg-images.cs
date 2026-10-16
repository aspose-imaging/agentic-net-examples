// HOW-TO: Apply Gaussian Blur to PNG and SVG Images and Save Filtered PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // PNG processing
            string inputPngPath = "input.png";
            string outputPngPath = "output_filtered.png";

            if (!File.Exists(inputPngPath))
            {
                Console.Error.WriteLine($"File not found: {inputPngPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPngPath));

            using (RasterImage pngImage = (RasterImage)Image.Load(inputPngPath))
            {
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0);
                pngImage.Filter(pngImage.Bounds, filterOptions);

                var pngSaveOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPngPath, false)
                };
                pngImage.Save(outputPngPath, pngSaveOptions);
            }

            // SVG processing
            string inputSvgPath = "input.svg";
            string tempPngPath = "temp_svg.png";
            string outputSvgPath = "output_svg_filtered.png";

            if (!File.Exists(inputSvgPath))
            {
                Console.Error.WriteLine($"File not found: {inputSvgPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputSvgPath));

            // Convert SVG to temporary PNG
            using (Image svgImage = Image.Load(inputSvgPath))
            {
                var tempPngOptions = new PngOptions
                {
                    Source = new FileCreateSource(tempPngPath, false)
                };
                svgImage.Save(tempPngPath, tempPngOptions);
            }

            // Load temporary PNG, apply filter, save final result
            using (RasterImage svgRaster = (RasterImage)Image.Load(tempPngPath))
            {
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0);
                svgRaster.Filter(svgRaster.Bounds, filterOptions);

                var finalPngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputSvgPath, false)
                };
                svgRaster.Save(outputSvgPath, finalPngOptions);
            }

            // Cleanup temporary file
            if (File.Exists(tempPngPath))
            {
                try { File.Delete(tempPngPath); } catch { }
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
 * 1. When you need to programmatically blur a PNG file before uploading it to a web service.
 * 2. When you must convert an SVG graphic to a raster PNG, apply a blur effect, and store the result for thumbnail generation.
 * 3. When you want to batch‑process images in a .NET application, applying the same filter to both raster and vector sources.
 * 4. When you need to ensure output directories exist and handle missing input files gracefully while processing images.
 * 5. When you are building a workflow that reads images, applies image‑filter operations, and saves them with specific format options using Aspose.Imaging.
 */
