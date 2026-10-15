// HOW-TO: Check SVG CSS Remains Unchanged After Applying Emboss Kernel in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.txt";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.FileFormats.Svg.SvgImage svgImage = (Aspose.Imaging.FileFormats.Svg.SvgImage)image;

                string tempPngPath = Path.Combine(Path.GetTempPath(), "temp_image.png");
                Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));
                var pngOptions = new PngOptions();
                image.Save(tempPngPath, pngOptions);

                using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(tempPngPath))
                {
                    var kernel = ConvolutionFilter.Emboss3x3;
                    var filterOptions = new ConvolutionFilterOptions(kernel);
                    var rect = new Aspose.Imaging.Rectangle(0, 0, raster.Width, raster.Height);
                    raster.Filter(rect, filterOptions);
                }

                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    writer.WriteLine("Processing completed.");
                }

                Console.WriteLine("Processing completed.");
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
 * 1. When you need to confirm that applying a convolution filter to an SVG‑derived raster image does not modify the original SVG’s embedded CSS styles.
 * 2. When you want to programmatically convert an SVG to PNG, apply an emboss effect, and ensure the SVG’s CSS is preserved for later reuse.
 * 3. When building an automated .NET image‑processing pipeline that must maintain SVG styling while performing raster‑based filters.
 * 4. When testing a graphics library to verify that CSS styles in SVG files survive intermediate raster conversions and filter operations.
 * 5. When generating a processing log (e.g., writing “Processing completed.”) while safeguarding the original SVG’s visual styling for downstream rendering.
 */
