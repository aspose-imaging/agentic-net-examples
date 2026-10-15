// HOW-TO: Crop Image to Central Square and Convert to SVG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/input.jpg";
        string outputPath = "Output/output.svg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                int size = Math.Min(raster.Width, raster.Height);
                int offsetX = (raster.Width - size) / 2;
                int offsetY = (raster.Height - size) / 2;
                Aspose.Imaging.Rectangle cropRect = new Aspose.Imaging.Rectangle(offsetX, offsetY, size, size);
                raster.Crop(cropRect);

                var svgOptions = new SvgOptions();
                raster.Save(outputPath, svgOptions);
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
 * 1. When you need to generate a square SVG logo from a rectangular JPEG photo for responsive web design.
 * 2. When you must preprocess scanned documents by extracting the central square area before vectorizing them for printing.
 * 3. When creating thumbnails that require a centered square crop and conversion to scalable SVG for UI icons.
 * 4. When automating batch processing of product images to ensure a uniform square aspect ratio in SVG format for e‑commerce catalogs.
 * 5. When integrating image handling in a C# application that needs to cache raster data, crop to the middle region, and output vector graphics for further editing.
 */
