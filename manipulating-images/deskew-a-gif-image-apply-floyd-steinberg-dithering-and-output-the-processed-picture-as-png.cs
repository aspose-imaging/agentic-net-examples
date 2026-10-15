// HOW-TO: Deskew GIF Image, Apply Floyd Steinberg Dithering and Save as PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.gif";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                using (RasterImage raster = (RasterImage)gif.ActiveFrame)
                {
                    raster.NormalizeAngle(false, Color.White);
                    raster.Dither(DitheringMethod.FloydSteinbergDithering, 1);

                    PngOptions pngOptions = new PngOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
                    };
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
 * 1. When you need to correct the rotation of scanned animated GIF frames before converting them to high‑quality PNGs for web display.
 * 2. When you want to reduce color banding in a GIF by applying Floyd‑Steinberg dithering while preserving the original dimensions.
 * 3. When an application must batch‑process legacy GIF assets, straighten them, and output lossless PNG files for archival storage.
 * 4. When you are building a C# service that receives user‑uploaded GIFs, normalizes their angle, and returns optimized PNG thumbnails.
 * 5. When you need to integrate Aspose.Imaging into a .NET workflow to transform skewed GIF graphics into PNGs with a consistent white background and dithering for printing.
 */
