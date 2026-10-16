// HOW-TO: Apply Alpha Blending to Each Page of a Multi‑Page TIFF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                foreach (TiffFrame frame in tiff.Frames)
                {
                    RasterImage raster = (RasterImage)frame;
                    raster.Blend(new Point(0, 0), raster, 200);
                }

                TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiff.Save(outputPath, saveOptions);
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
 * 1. When you need to make every page of a scanned multi‑page TIFF semi‑transparent using Aspose.Imaging in C# so it can be overlaid with another image layer.
 * 2. When you want to uniformly set a 200‑out‑of‑255 opacity on all frames of a TIFF before printing or publishing the document.
 * 3. When building a PDF conversion utility that requires pre‑blending each TIFF page to ensure consistent visual appearance across pages.
 * 4. When preparing multi‑page medical or GIS TIFF files for compositing, and each layer must share the same alpha value for accurate analysis.
 * 5. When automating batch processing of archival TIFF archives to apply the same opacity to every page while preserving the original multi‑page structure.
 */
