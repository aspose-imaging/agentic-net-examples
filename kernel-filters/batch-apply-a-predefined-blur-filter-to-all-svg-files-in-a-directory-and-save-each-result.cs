// HOW-TO: Batch Apply Gaussian Blur to SVG Files and Save as PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "input_svgs";
            string outputDirectory = "output_svgs";

            Directory.CreateDirectory(outputDirectory);

            string[] svgFiles = Directory.GetFiles(inputDirectory, "*.svg");

            foreach (string svgPath in svgFiles)
            {
                if (!File.Exists(svgPath))
                {
                    Console.Error.WriteLine($"File not found: {svgPath}");
                    return;
                }

                using (Image svgImage = Image.Load(svgPath))
                {
                    string tempPngPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(svgPath) + "_temp.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

                    using (PngOptions pngOptions = new PngOptions())
                    {
                        pngOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                        {
                            PageWidth = svgImage.Width,
                            PageHeight = svgImage.Height
                        };
                        svgImage.Save(tempPngPath, pngOptions);
                    }

                    using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
                    {
                        var blurOptions = new GaussianBlurFilterOptions(5, 1.0);
                        raster.Filter(raster.Bounds, blurOptions);

                        string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(svgPath) + "_blur.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                        raster.Save(outputPath);
                    }

                    if (File.Exists(tempPngPath))
                    {
                        File.Delete(tempPngPath);
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
 * 1. When you need to automatically add a soft blur effect to a large collection of SVG icons before publishing them as PNG assets.
 * 2. When you want to generate blurred preview thumbnails from vector graphics for a web gallery using C#.
 * 3. When a design pipeline requires converting SVG logos to raster PNGs with a consistent blur radius for UI consistency.
 * 4. When you must process all SVG files in a folder to create blurred watermarks for PDF reports without manual editing.
 * 5. When an automated build script has to apply a Gaussian blur filter to SVG diagrams and output PNGs for documentation screenshots.
 */
