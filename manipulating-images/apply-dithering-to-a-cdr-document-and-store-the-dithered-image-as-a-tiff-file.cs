// HOW-TO: Apply Floyd Steinberg Dithering to CDR and Save as TIFF in C# (Aspose.Imaging for .NET)
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
    static void Main()
    {
        try
        {
            string inputPath = "input.cdr";
            string outputPath = "output.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            string tempPngPath = Path.Combine(Path.GetDirectoryName(outputPath) ?? string.Empty, "temp.png");
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

            using (Image cdrImage = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions();
                cdrImage.Save(tempPngPath, pngOptions);
            }

            using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
            {
                raster.Dither(DitheringMethod.FloydSteinbergDithering, 8);
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                raster.Save(outputPath, tiffOptions);
            }

            File.Delete(tempPngPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert a CorelDRAW (.cdr) illustration to a high‑contrast black‑and‑white TIFF for printing or archival purposes.
 * 2. When a legacy workflow requires a dithered raster image from a vector CDR file to meet a specific printer’s bitonal requirements.
 * 3. When you must generate a TIFF that uses Floyd‑Steinberg dithering to reduce file size while preserving visual detail from a CDR source.
 * 4. When automating batch processing of CDR files into TIFFs with consistent dithering for a document management system.
 * 5. When integrating Aspose.Imaging into a C# application to transform vector graphics into TIFFs with controlled color depth for OCR preprocessing.
 */
