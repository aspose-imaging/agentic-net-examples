// HOW-TO: Apply Floyd Steinberg Dithering to TIFF and Save as PNG in C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "image.tif");
            string outputPath = Path.Combine("Output", "dithered.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Dither(DitheringMethod.FloydSteinbergDithering, 8, null);

                using (PngOptions pngOptions = new PngOptions())
                {
                    pngOptions.Source = new FileCreateSource(outputPath, false);
                    raster.Save(outputPath, pngOptions);
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
 * 1. When you need to reduce a high‑color TIFF to an 8‑bit PNG with Floyd‑Steinberg dithering for sharper web graphics.
 * 2. When preparing scanned documents for low‑bandwidth transmission and you want to preserve visual detail by dithering before saving as PNG.
 * 3. When converting archival TIFF images to PNG thumbnails while applying dithering to maintain contrast on displays that support only limited colors.
 * 4. When generating game assets from TIFF source files and require Floyd‑Steinberg dithering to avoid banding in the final PNG sprites.
 * 5. When automating a batch process that transforms multi‑page TIFFs into dithered PNGs for printing workflows that require indexed color images.
 */
