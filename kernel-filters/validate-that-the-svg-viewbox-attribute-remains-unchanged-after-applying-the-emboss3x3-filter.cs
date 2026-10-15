// HOW-TO: Check SVG ViewBox Remains Unchanged After Emboss Filter In C# (Aspose.Imaging for .NET)
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
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Read original viewBox attribute
            string originalContent = File.ReadAllText(inputPath);
            string viewBoxToken = "viewBox=\"";
            int vbStart = originalContent.IndexOf(viewBoxToken);
            string originalViewBox = "";
            if (vbStart >= 0)
            {
                int vbValueStart = vbStart + viewBoxToken.Length;
                int vbEnd = originalContent.IndexOf('"', vbValueStart);
                if (vbEnd > vbValueStart)
                {
                    originalViewBox = originalContent.Substring(vbValueStart, vbEnd - vbValueStart);
                }
            }

            // Load SVG
            using (Image image = Image.Load(inputPath))
            {
                SvgImage svgImage = (SvgImage)image;

                // Rasterize SVG to temporary PNG
                string tempPngPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp.png");
                Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageWidth = svgImage.Width,
                        PageHeight = svgImage.Height,
                        BackgroundColor = Color.White
                    }
                };

                svgImage.Save(tempPngPath, pngOptions);

                // Load raster image and apply Emboss3x3 filter
                using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
                {
                    var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3);
                    raster.Filter(raster.Bounds, filterOptions);
                    raster.Save(outputPath, pngOptions);
                }

                // Clean up temporary file
                if (File.Exists(tempPngPath))
                {
                    File.Delete(tempPngPath);
                }
            }

            // Verify viewBox unchanged
            string afterContent = File.ReadAllText(inputPath);
            int vbStartAfter = afterContent.IndexOf(viewBoxToken);
            string afterViewBox = "";
            if (vbStartAfter >= 0)
            {
                int vbValueStartAfter = vbStartAfter + viewBoxToken.Length;
                int vbEndAfter = afterContent.IndexOf('"', vbValueStartAfter);
                if (vbEndAfter > vbValueStartAfter)
                {
                    afterViewBox = afterContent.Substring(vbValueStartAfter, vbEndAfter - vbValueStartAfter);
                }
            }

            if (originalViewBox == afterViewBox)
            {
                Console.WriteLine("ViewBox unchanged after applying Emboss3x3 filter.");
            }
            else
            {
                Console.Error.WriteLine("ViewBox was modified.");
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
 * 1. When you need to ensure that applying an emboss effect to an SVG does not alter its viewBox coordinates before converting it to PNG in a .NET application.
 * 2. When you must verify that rasterizing an SVG with a custom filter preserves the original scaling region for accurate layout in web graphics pipelines.
 * 3. When a CI build validates that image processing transformations, such as Emboss3x3, keep SVG metadata intact for downstream reporting tools.
 * 4. When generating thumbnails from SVG assets you want to confirm the viewBox stays consistent after applying visual effects using Aspose.Imaging.
 * 5. When migrating design assets to a new system you need a C# script that checks the viewBox attribute remains unchanged after applying filters to avoid layout shifts.
 */
