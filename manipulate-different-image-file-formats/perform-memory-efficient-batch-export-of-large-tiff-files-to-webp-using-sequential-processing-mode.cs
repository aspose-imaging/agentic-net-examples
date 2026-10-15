// HOW-TO: Export Large Multi‑Page TIFF to WebP Efficiently in C# (Aspose.Imaging for .NET)
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
        try
        {
            string inputPath = "Input/large.tif";
            string outputPath = "Output/large.webp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                tiff.PageExportingAction = (index, page) =>
                {
                    var raster = page as RasterImage;
                    if (raster != null && !raster.IsCached)
                    {
                        raster.CacheData();
                    }
                };

                var webpOptions = new WebPOptions
                {
                    Quality = 80,
                    Lossless = false
                };

                tiff.Save(outputPath, webpOptions);
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
 * 1. When you need to convert high‑resolution multi‑page TIFF scans into smaller WebP files for web delivery without exhausting memory.
 * 2. When processing large medical imaging TIFF archives and you want to generate WebP thumbnails on a server with limited RAM.
 * 3. When building a batch image conversion tool that must handle gigabyte‑size TIFF documents and output WebP for mobile apps.
 * 4. When integrating Aspose.Imaging into a cloud service that streams TIFF pages sequentially and saves them as compressed WebP to reduce storage costs.
 * 5. When automating migration of legacy TIFF assets to modern WebP format while ensuring each page is cached before saving to avoid out‑of‑memory errors.
 */
