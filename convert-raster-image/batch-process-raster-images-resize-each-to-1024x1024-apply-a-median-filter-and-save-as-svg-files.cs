// HOW-TO: Batch Resize Raster Images to 1024x1024 and Convert to SVG in C# (Aspose.Imaging for .NET)
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
        try
        {
            string inputDirectory = "InputImages";
            string outputDirectory = "OutputSvgs";

            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(outputDirectory);

            string[] files = Directory.GetFiles(inputDirectory);
            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                using (Image img = Image.Load(inputPath))
                {
                    RasterImage raster = img as RasterImage;
                    if (raster == null)
                    {
                        Console.Error.WriteLine($"Not a raster image: {inputPath}");
                        continue;
                    }

                    if (!raster.IsCached)
                        raster.CacheData();

                    raster.Resize(1024, 1024);
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));

                    string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".svg");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    raster.Save(outputPath, new SvgOptions());
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
 * 1. When you need to automatically prepare a large set of photos for web display by resizing them to a uniform 1024 × 1024 resolution, reducing noise with a median filter, and delivering them as scalable SVG files.
 * 2. When a content‑management system must ingest raster scans, clean them, and store them in a vector‑friendly format for responsive design.
 * 3. When an e‑commerce platform wants to generate lightweight, resolution‑independent product thumbnails from high‑resolution JPEG or PNG uploads.
 * 4. When a digital‑archiving workflow requires batch conversion of scanned documents into SVG while applying noise reduction to improve OCR accuracy.
 * 5. When a game‑asset pipeline needs to standardize texture sizes, remove speckle noise, and export them as SVG for UI scaling across devices.
 */
