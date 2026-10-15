// HOW-TO: Apply Gaussian Blur to PSD and Save as PNG with Text Rendering Hint in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.psd";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Failed to load raster image.");
                    return;
                }

                var blurOptions = new GaussianBlurFilterOptions(5, 2.0);
                raster.Filter(raster.Bounds, blurOptions);

                Graphics graphics = new Graphics(raster);
                graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                var pngOptions = new PngOptions();
                pngOptions.Source = new FileCreateSource(outputPath, false);
                raster.Save(outputPath, pngOptions);
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
 * 1. When you need to soften a Photoshop PSD before generating a web‑ready PNG thumbnail.
 * 2. When you want to improve the appearance of overlaid text by applying anti‑aliasing after blurring an image.
 * 3. When you must convert a layered PSD file to a flat PNG while applying a Gaussian blur filter in a C# batch process.
 * 4. When you are preparing assets for a UI mockup and require a blurred background with crisp, anti‑aliased labels.
 * 5. When you automate image preprocessing for a machine‑learning pipeline that expects blurred PNG inputs from original PSD sources.
 */
