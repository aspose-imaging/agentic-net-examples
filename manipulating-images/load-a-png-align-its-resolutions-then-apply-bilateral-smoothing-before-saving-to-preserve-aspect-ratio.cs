// HOW-TO: Align PNG Resolution and Apply Bilateral Smoothing in C# (Aspose.Imaging for .NET)
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

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                double hRes = raster.HorizontalResolution;
                double vRes = raster.VerticalResolution;
                if (hRes != vRes)
                {
                    double maxRes = Math.Max(hRes, vRes);
                    raster.HorizontalResolution = maxRes;
                    raster.VerticalResolution = maxRes;
                }

                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.BilateralSmoothingFilterOptions());

                PngOptions options = new PngOptions();
                options.Source = new FileCreateSource(outputPath, false);
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
 * 1. When you need to ensure a PNG image has equal horizontal and vertical DPI to avoid distortion on screens or printers.
 * 2. When you want to reduce noise while preserving edges in a PNG by applying a bilateral smoothing filter before further processing.
 * 3. When preparing PNG assets for web or mobile applications and must standardize resolution and improve visual quality without enlarging the file.
 * 4. When converting scanned PNGs with inconsistent DPI into a uniform format for OCR or machine‑learning pipelines.
 * 5. When batch‑processing PNG files to correct aspect‑ratio mismatches and smooth compression artifacts.
 */
