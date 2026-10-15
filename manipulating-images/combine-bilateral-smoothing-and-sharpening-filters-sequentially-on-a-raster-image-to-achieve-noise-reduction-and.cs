// HOW-TO: Apply Bilateral Smoothing Followed By Sharpen Filter To PNG In C# (Aspose.Imaging for .NET)
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

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Apply bilateral smoothing filter
                image.Filter(
                    image.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.BilateralSmoothingFilterOptions());

                // Apply sharpening filter
                image.Filter(
                    image.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions());

                // Save the processed image
                PngOptions saveOptions = new PngOptions();
                image.Save(outputPath, saveOptions);
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
 * 1. When you need to clean up noisy scanned PNG photos while preserving edge detail for a web gallery.
 * 2. When processing medical imaging PNGs where reducing grain but keeping sharp anatomical boundaries is required.
 * 3. When preparing product photos for e‑commerce, applying noise reduction and then sharpening to make items look crisp.
 * 4. When automating batch enhancement of PNG screenshots from UI tests, smoothing artifacts before sharpening UI elements.
 * 5. When improving satellite PNG imagery by removing sensor noise and enhancing terrain edges for better visual analysis.
 */
