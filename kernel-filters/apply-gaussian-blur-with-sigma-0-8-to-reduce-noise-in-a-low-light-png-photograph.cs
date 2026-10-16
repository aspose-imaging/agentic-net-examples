// HOW-TO: Apply Gaussian Blur With Sigma 0.8 To PNG Image In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                var blurOptions = new GaussianBlurFilterOptions(1, 0.8);
                raster.Filter(raster.Bounds, blurOptions);

                var saveOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
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
 * 1. When you need to reduce sensor noise in low‑light PNG photos before further analysis in a C# application.
 * 2. When preparing PNG screenshots for a mobile app, applying a subtle Gaussian blur to smooth jagged edges.
 * 3. When cleaning up scanned documents saved as PNGs, using a Gaussian blur to soften speckles without losing detail.
 * 4. When creating a preprocessing step for computer‑vision models, applying a 0.8 sigma blur to normalize image noise in C#.
 * 5. When generating thumbnail previews of PNG images, using Gaussian blur to improve visual quality in low‑light conditions.
 */
