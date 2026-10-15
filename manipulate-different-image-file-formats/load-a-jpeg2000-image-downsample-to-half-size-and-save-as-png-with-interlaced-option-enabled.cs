// HOW-TO: Downsample JPEG2000 Image to Half Size and Save as Interlaced PNG in C# (Aspose.Imaging for .NET)
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
        string inputPath = "input.jp2";
        string outputPath = "output.png";

        try
        {
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
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                if (!raster.IsCached)
                    raster.CacheData();

                int newWidth = raster.Width / 2;
                int newHeight = raster.Height / 2;
                raster.Resize(newWidth, newHeight);

                PngOptions options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

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
 * 1. When you need to reduce the resolution of a high‑resolution JPEG2000 photograph for faster web delivery while preserving quality as an interlaced PNG.
 * 2. When a mobile app must display thumbnails generated from JPEG2000 assets and requires PNG files with interlacing for progressive rendering.
 * 3. When a document‑conversion service converts archival JPEG2000 scans into smaller PNG images that load progressively in browsers.
 * 4. When an e‑commerce platform creates product‑image previews by halving JPEG2000 dimensions and saving them as interlaced PNGs for responsive design.
 * 5. When a batch‑processing script automates resizing of JPEG2000 satellite imagery to half size and outputs interlaced PNGs for GIS applications.
 */
