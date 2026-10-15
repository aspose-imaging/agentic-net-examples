// HOW-TO: Apply Gaussian Blur Then Sharpen to a TIFF and Save as PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input\\image.tif";
            string outputPath = "output\\image.png";

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
                    Console.Error.WriteLine("Image is not a raster image.");
                    return;
                }

                // Apply Gaussian blur filter
                var gaussOptions = new GaussianBlurFilterOptions(5, 1.0);
                raster.Filter(raster.Bounds, gaussOptions);

                // Apply Sharpen filter
                var sharpenOptions = new SharpenFilterOptions();
                raster.Filter(raster.Bounds, sharpenOptions);

                // Save as PNG
                var pngOptions = new PngOptions();
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
 * 1. When you need to reduce noise in a high‑resolution TIFF scan before sharpening details and delivering the result as a web‑friendly PNG.
 * 2. When you want to preprocess scanned documents by blurring minor artifacts, then enhance edges, and store the final image in PNG for further analysis.
 * 3. When a photo‑editing application requires a batch step that first smooths a TIFF image with a Gaussian blur, applies a sharpen filter, and outputs PNG files for UI display.
 * 4. When converting medical imaging TIFFs to PNG while applying blur to hide patient identifiers and sharpen anatomical features for reporting.
 * 5. When preparing product catalog images stored as TIFFs by smoothing background textures, sharpening product edges, and exporting to PNG for e‑commerce platforms.
 */
