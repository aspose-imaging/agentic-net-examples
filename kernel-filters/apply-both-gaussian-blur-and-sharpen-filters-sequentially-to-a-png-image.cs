// HOW-TO: Apply Gaussian Blur Followed by Sharpen to PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output\\output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions());
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions());

                PngOptions options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                raster.Save(outputPath, options);
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
 * 1. When you need to soften a PNG image to reduce noise and then enhance its edges for a clearer preview in a C# application.
 * 2. When preparing product photos for an e‑commerce site, applying blur to hide background details and sharpening the subject to make it stand out using Aspose.Imaging.
 * 3. When creating thumbnails that require a gentle blur to avoid aliasing followed by a sharpen pass to retain crispness, all in .NET.
 * 4. When processing scanned documents where a Gaussian blur removes speckles and a subsequent sharpen filter restores text sharpness before saving as PNG.
 * 5. When building an automated image pipeline that sequentially applies blur and sharpen filters to improve visual quality of PNG assets in a Windows service.
 */
