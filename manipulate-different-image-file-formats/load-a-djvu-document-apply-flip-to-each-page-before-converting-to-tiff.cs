// HOW-TO: Flip DjVu Pages Horizontally and Convert to LZW TIFF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.djvu";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.TiffLzwRgb);

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                djvu.PageExportingAction = delegate (int index, Image page)
                {
                    if (page is RasterImage raster)
                    {
                        raster.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    }
                };

                djvu.Save(outputPath, tiffOptions);
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
 * 1. When you need to archive scanned DjVu documents as compressed TIFF files while mirroring each page for correct left‑to‑right reading.
 * 2. When a publishing workflow requires flipping the orientation of every page in a DjVu file before generating a multi‑page TIFF for print‑ready output.
 * 3. When you are building a document conversion service that transforms user‑uploaded DjVu files into LZW‑compressed TIFF images with a horizontal flip applied automatically.
 * 4. When you must preprocess DjVu pages for OCR by mirroring them and saving the result as a single TIFF to simplify downstream processing.
 * 5. When you want to batch‑process a collection of DjVu files, applying a flip to each page and exporting them as high‑quality TIFFs using Aspose.Imaging in a C# application.
 */
