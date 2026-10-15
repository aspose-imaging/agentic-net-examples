// HOW-TO: Increase DNG Image Contrast by 30% and Save as TIFF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.dng";
            string outputPath = "output/result.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DngImage dng = (DngImage)Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)dng;
                raster.AdjustContrast(30f);
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                dng.Save(outputPath, tiffOptions);
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
 * 1. When a photographer needs to enhance the contrast of raw DNG files before archiving them as lossless TIFFs for print production.
 * 2. When a scientific imaging pipeline requires adjusting the visual contrast of DNG sensor data by a fixed percentage and converting it to TIFF for compatibility with analysis software.
 * 3. When a mobile app backend processes uploaded raw photos, boosts their contrast by 30%, and stores the results in TIFF format for high‑quality downstream processing.
 * 4. When a digital asset management system must batch‑convert raw DNG images with increased contrast into TIFF to preserve detail while meeting format standards.
 * 5. When a developer builds a C# utility that programmatically tweaks DNG contrast and outputs TIFF files for integration with legacy workflows that only accept TIFF.
 */
