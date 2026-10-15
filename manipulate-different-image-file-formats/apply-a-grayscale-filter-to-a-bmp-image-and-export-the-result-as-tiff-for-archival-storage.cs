// HOW-TO: Convert BMP to Grayscale TIFF for Archival in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "image.bmp");
            string outputPath = Path.Combine("Output", "image.tiff");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                if (!raster.IsCached) raster.CacheData();
                raster.Grayscale();
                raster.Save(outputPath, new TiffOptions(TiffExpectedFormat.Default));
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
 * 1. When you need to archive legacy BMP scans as lossless grayscale TIFF files to reduce file size while preserving detail.
 * 2. When a document management system requires all incoming images to be stored in a single‑channel TIFF format for compliance.
 * 3. When converting color BMP screenshots to grayscale TIFF for inclusion in legal evidence packages.
 * 4. When preparing medical imaging data by stripping color from BMP files and saving them as TIFF for long‑term storage.
 * 5. When automating a batch process that normalizes BMP assets to grayscale TIFF before uploading to a cloud archive.
 */
