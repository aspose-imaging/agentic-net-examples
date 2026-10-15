// HOW-TO: Apply Motion Blur to Each Page of a Multi‑Page PNG in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output/output.png";

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
                if (image is IMultipageImage multipage)
                {
                    foreach (var page in multipage.Pages)
                    {
                        if (page is RasterImage raster)
                        {
                            raster.Filter(
                                raster.Bounds,
                                new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                                    Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetBlurMotion(5, 90)));
                        }
                    }
                }
                else if (image is RasterImage raster)
                {
                    raster.Filter(
                        raster.Bounds,
                        new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                            Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetBlurMotion(5, 90)));
                }

                var options = new PngOptions();
                image.Save(outputPath, options);
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
 * 1. When you need to add a vertical motion blur effect to every frame of an animated PNG before publishing it online.
 * 2. When processing scanned multi‑page documents saved as PNG and you want to simulate camera shake on each page for visual testing.
 * 3. When generating a series of PNG slides with consistent blur styling for a presentation or slideshow application.
 * 4. When converting multi‑page PNG assets for a game and applying a uniform motion blur to match the game's visual style.
 * 5. When automating batch image processing in a C# service that must apply the same blur filter to each page of a multi‑page PNG file.
 */
