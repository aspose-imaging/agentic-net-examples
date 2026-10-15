// HOW-TO: Create 150x150 PNG Thumbnail From Large TIFF In C# (Aspose.Imaging for .NET)
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
        try
        {
            string inputPath = "Input\\large.tif";
            string outputPath = "Output\\thumbnail.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached) image.CacheData();

                image.Resize(150, 150, ResizeType.NearestNeighbourResample);

                PngOptions options = new PngOptions();
                image.Save(outputPath, options);
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
 * 1. When you need to generate small preview images for high‑resolution TIFF scans to display in a web gallery.
 * 2. When an application must convert uploaded multi‑megabyte TIFF files into lightweight PNG thumbnails for faster download.
 * 3. When a document management system requires consistent 150 × 150 pixel icons for all TIFF assets.
 * 4. When you want to automate batch processing that creates PNG previews of large medical imaging TIFF files.
 * 5. When a reporting tool needs to embed uniformly sized PNG thumbnails of TIFF maps into PDF reports.
 */
