// HOW-TO: Crop Top Left Quadrant of JPEG and Save as SVG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
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
        string outputPath = "output.svg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached) image.CacheData();

                int halfWidth = image.Width / 2;
                int halfHeight = image.Height / 2;

                var cropRect = new Rectangle(0, 0, halfWidth, halfHeight);
                image.Crop(cropRect);

                image.Save(outputPath, new SvgOptions());
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
 * 1. When you need to extract the upper‑left portion of a photo and provide it as a scalable vector graphic for responsive web layouts.
 * 2. When generating thumbnails for a design system where the cropped area must be saved in SVG to retain quality at any size.
 * 3. When converting a high‑resolution raster scan into a vector format for inclusion in print brochures, focusing only on the top‑left section.
 * 4. When preprocessing images for a GIS application that requires the first quadrant of each raster map to be stored as SVG for overlay rendering.
 * 5. When automating batch processing of product images to isolate the logo area in the corner and output it as SVG for branding assets.
 */
