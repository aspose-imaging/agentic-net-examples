// HOW-TO: Apply Bilateral Smoothing Sharpening and Median Filter to JPEG in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output/output.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                image.Filter(image.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.BilateralSmoothingFilterOptions());
                image.Filter(image.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions());
                image.Filter(image.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                JpegOptions saveOptions = new JpegOptions();
                saveOptions.Quality = 90;
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
 * 1. When you need to reduce noise in a scanned JPEG photo while preserving edges before saving it with high quality in a C# application.
 * 2. When you want to enhance the sharpness of low‑resolution product images and then smooth remaining artifacts using Aspose.Imaging filters in .NET.
 * 3. When you are building an automated batch processor that cleans up JPEG screenshots by applying bilateral smoothing, sharpening, and a median filter to improve visual clarity.
 * 4. When you must prepare medical imaging JPEGs for web display by removing speckle noise and enhancing details with a reusable filter pipeline in C#.
 * 5. When you are developing a photo‑editing tool that applies a sequence of noise‑reduction and sharpening filters to user‑uploaded JPEGs before exporting them at 90% quality.
 */
