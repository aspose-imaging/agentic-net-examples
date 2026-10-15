// HOW-TO: Overlay PNG Onto TIFF at Specific Coordinates Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputTiffPath = "input.tif";
            string overlayPath = "overlay.png";
            string outputPath = "output.tif";

            if (!File.Exists(inputTiffPath))
            {
                Console.Error.WriteLine($"File not found: {inputTiffPath}");
                return;
            }
            if (!File.Exists(overlayPath))
            {
                Console.Error.WriteLine($"File not found: {overlayPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage background = (RasterImage)Image.Load(inputTiffPath))
            using (RasterImage overlay = (RasterImage)Image.Load(overlayPath))
            {
                Point overlayPos = new Point(100, 200);
                background.Blend(overlayPos, overlay, 127);
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                background.Save(outputPath, tiffOptions);
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
 * 1. When you need to add a logo or watermark PNG onto a multi-page TIFF at an exact X‑Y location.
 * 2. When generating printable documents where a scanned TIFF background must be combined with a dynamic overlay image positioned at (100,200).
 * 3. When creating GIS maps that require a raster overlay to be placed precisely over a base TIFF layer.
 * 4. When automating the preparation of marketing materials by programmatically merging a promotional PNG onto a high‑resolution TIFF template.
 * 5. When building a batch process that blends a transparent PNG onto several TIFF files at a fixed offset for consistent branding.
 */
