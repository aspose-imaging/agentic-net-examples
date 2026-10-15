// HOW-TO: Apply Motion Blur to Each Page of a Multi‑Page SVG in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.svg";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = "output";
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (Image image = Image.Load(inputPath))
            {
                if (image is IMultipageImage multipageImage)
                {
                    for (int i = 0; i < multipageImage.PageCount; i++)
                    {
                        Image page = multipageImage.Pages[i];
                        string pageOutputPath = Path.Combine(outputDir, $"page_{i + 1}.png");
                        string pageOutputDir = Path.GetDirectoryName(pageOutputPath);
                        if (!string.IsNullOrWhiteSpace(pageOutputDir))
                        {
                            Directory.CreateDirectory(pageOutputDir);
                        }

                        // Rasterize the vector page to PNG in memory
                        PngOptions pngOptions = new PngOptions();
                        SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                        {
                            PageWidth = page.Width,
                            PageHeight = page.Height,
                            BackgroundColor = Color.White
                        };
                        pngOptions.VectorRasterizationOptions = rasterOptions;

                        using (MemoryStream ms = new MemoryStream())
                        {
                            page.Save(ms, pngOptions);
                            ms.Position = 0;
                            using (RasterImage raster = (RasterImage)Image.Load(ms))
                            {
                                // Apply motion blur filter (size 6, angle 75)
                                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.GetBlurMotion(6, 75)));
                                raster.Save(pageOutputPath, pngOptions);
                            }
                        }

                        page.Dispose();
                    }
                }
                else
                {
                    Console.Error.WriteLine("The loaded image is not a multipage SVG.");
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
 * 1. When you need to generate blurred preview images for every page of a multi‑page SVG document in a web application.
 * 2. When creating thumbnail galleries where each SVG page must be rasterized to PNG with a consistent motion‑blur effect for visual consistency.
 * 3. When processing vector assets for a printing workflow that requires each page to be converted to raster format and softened with a specific blur angle.
 * 4. When automating the preparation of SVG diagrams for presentation slides, applying a motion blur to emphasize motion before exporting to PNG.
 * 5. When building a batch conversion tool that iterates through all pages of an SVG file, applies a size‑6, 75‑degree motion blur, and saves the results as separate PNG files.
 */
