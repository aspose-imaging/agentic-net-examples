// HOW-TO: Apply Gamma Correction to TIFF and Save as PNG in C# (Aspose.Imaging for .NET)
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
        string baseDir = Directory.GetCurrentDirectory();
        string inputPath = Path.Combine(baseDir, "Input", "input.tif");
        string outputPath = Path.Combine(baseDir, "Output", "output.png");

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                raster.AdjustGamma(1.2f);

                using (PngOptions pngOptions = new PngOptions())
                {
                    image.Save(outputPath, pngOptions);
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
 * 1. When you need to brighten a scanned TIFF document for web display by adjusting its gamma and converting it to a lightweight PNG format.
 * 2. When a medical imaging application must correct the luminance of a TIFF X‑ray image before storing it as PNG for integration with a viewer.
 * 3. When an e‑commerce platform wants to improve the visual consistency of product photos originally in TIFF by applying gamma correction and delivering them as PNG thumbnails.
 * 4. When a batch processing script has to prepare archival TIFF graphics for mobile apps, adjusting gamma to enhance contrast and saving them as PNG to reduce file size.
 * 5. When a digital publishing workflow requires converting high‑resolution TIFF artwork to PNG while fine‑tuning brightness through gamma adjustment using C# and Aspose.Imaging.
 */
