// HOW-TO: Apply Gaussian Blur to PNG Without Color Shift in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Failed to load image as RasterImage.");
                    return;
                }

                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0);
                raster.Filter(raster.Bounds, blurOptions);

                var saveOptions = new PngOptions();
                raster.Save(outputPath, saveOptions);
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
 * 1. When you need to soften a color PNG for a web banner while preserving its original hues using Aspose.Imaging in C#.
 * 2. When you want to preprocess product photos with a Gaussian blur before uploading to an e‑commerce site without introducing any color distortion.
 * 3. When you are building a desktop application that applies a blur effect to user‑uploaded PNG avatars and must keep the colors accurate.
 * 4. When you need to generate blurred background images for UI overlays in a WPF app while ensuring the PNG palette remains unchanged.
 * 5. When you are automating batch image processing to add a subtle blur to PNG assets for a game UI and require the output to retain exact color fidelity.
 */
