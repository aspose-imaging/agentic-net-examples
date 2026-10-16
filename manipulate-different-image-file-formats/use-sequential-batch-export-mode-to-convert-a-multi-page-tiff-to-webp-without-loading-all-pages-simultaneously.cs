// HOW-TO: Convert Multi‑Page TIFF to Animated WebP Using Sequential Export in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/multipage.tif";
        string outputPath = "Output/animated.webp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                WebPOptions options = new WebPOptions
                {
                    Lossless = false,
                    Quality = 80
                };

                tiff.PageExportingAction = (int pageIndex, Image page) =>
                {
                    // Ensure the page is cached (optional)
                    if (page is RasterImage raster && !raster.IsCached)
                    {
                        raster.CacheData();
                    }
                };

                tiff.Save(outputPath, options);
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
 * 1. When you need to generate a lightweight animated WebP from a large multi‑page TIFF for web delivery while keeping memory usage low.
 * 2. When a server‑side C# service must batch‑process scanned documents and output them as lossily compressed WebP animations for faster preview.
 * 3. When an image‑processing pipeline has to convert archival TIFF files to WebP with specific quality settings without loading every page into RAM.
 * 4. When you want to create animated WebP thumbnails from multi‑page medical or engineering TIFFs in a .NET application that runs on limited resources.
 * 5. When a cloud function must transform incoming multi‑page TIFF uploads into WebP animations on the fly, using Aspose.Imaging’s sequential export to avoid out‑of‑memory errors.
 */
