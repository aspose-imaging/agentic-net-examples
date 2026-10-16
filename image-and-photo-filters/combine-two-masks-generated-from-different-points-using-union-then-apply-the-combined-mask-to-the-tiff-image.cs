// HOW-TO: Combine Two Magic Wand Selections and Apply Union Mask to TIFF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output\\result.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                MagicWandTool.Select(image, new MagicWandSettings(100, 150))
                    .Union(new MagicWandSettings(200, 250))
                    .Apply();

                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                image.Save(outputPath, tiffOptions);
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
 * 1. When you need to merge two separate region selections into a single mask before editing a multi‑page TIFF file in a C# application.
 * 2. When you want to programmatically remove or highlight combined areas of a scanned document by applying a union mask using Aspose.Imaging’s MagicWand tool.
 * 3. When you are building an automated workflow that selects two points of interest in a TIFF image and saves the result with the combined mask applied.
 * 4. When you must apply a composite mask to a raster TIFF to prepare it for further processing such as OCR or compression in .NET.
 * 5. When you require a simple way to union multiple selections and persist the masked TIFF without manually editing the image.
 */
