// HOW-TO: Apply Gaussian Blur to CDR, Resize to 1200x800 and Save as PNG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.cdr";
        string outputPath = "Output\\result.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                string tempPath = "temp.png";

                PngOptions rasterOptions = new PngOptions
                {
                    VectorRasterizationOptions = new CdrRasterizationOptions
                    {
                        PageWidth = cdr.Width,
                        PageHeight = cdr.Height
                    },
                    Source = new FileCreateSource(tempPath, false)
                };

                cdr.Save(tempPath, rasterOptions);

                using (RasterImage raster = (RasterImage)Image.Load(tempPath))
                {
                    var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0);
                    raster.Filter(raster.Bounds, blurOptions);
                    raster.Resize(1200, 800);

                    PngOptions saveOptions = new PngOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
                    };

                    raster.Save(outputPath, saveOptions);
                }

                File.Delete(tempPath);
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
 * 1. When you need to convert a CorelDRAW (CDR) illustration to a web‑ready PNG while softening edges with a Gaussian blur.
 * 2. When you must generate thumbnail‑size PNG previews (1200×800) from high‑resolution CDR files for a product catalog.
 * 3. When an automated pipeline has to rasterize vector CDR artwork, apply a blur effect, and store the result as PNG for further processing.
 * 4. When you are building a C# desktop app that imports CDR graphics, applies a visual filter, and outputs resized PNGs for UI assets.
 * 5. When you want to batch‑process multiple CDR designs, blur them for a background effect, resize them, and save as PNGs using Aspose.Imaging for .NET.
 */
