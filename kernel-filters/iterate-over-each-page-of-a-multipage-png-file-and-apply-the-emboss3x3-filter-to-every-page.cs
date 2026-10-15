// HOW-TO: Apply Emboss3x3 Filter to Every Page of a Multipage PNG in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                if (image is IMultipageImage multipage)
                {
                    foreach (var page in multipage.Pages)
                    {
                        var raster = (RasterImage)page;
                        var kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3;
                        var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                        raster.Filter(raster.Bounds, filterOptions);
                    }

                    var saveOptions = new PngOptions();
                    image.Save(outputPath, saveOptions);
                }
                else
                {
                    Console.Error.WriteLine("The input image is not a multipage image.");
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
 * 1. When you need to add a 3×3 emboss effect to each frame of an animated PNG for a stylized UI.
 * 2. When processing scanned multi‑page documents saved as PNG and you want to highlight edges on every page.
 * 3. When generating embossed thumbnails from a multi‑page PNG sprite sheet for a game.
 * 4. When preparing print‑ready multi‑page PNG assets and require a uniform emboss filter across all pages.
 * 5. When converting a multi‑page PNG into a single file while applying the same convolution filter to maintain visual consistency.
 */
