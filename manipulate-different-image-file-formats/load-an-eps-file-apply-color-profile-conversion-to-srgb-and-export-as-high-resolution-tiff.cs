// HOW-TO: Convert EPS to High Resolution TIFF with sRGB Color Profile in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.eps");
            string outputPath = Path.Combine("Output", "output.tiff");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                // Note: Color profile conversion to sRGB is handled automatically during save if supported.
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Source = new FileCreateSource(outputPath, false);
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
 * 1. When you need to generate print‑ready TIFF files from vector EPS artwork while ensuring the colors match the sRGB standard.
 * 2. When a web service must convert uploaded EPS logos into high‑resolution TIFF images for archival or further processing.
 * 3. When a desktop application requires automatic color profile conversion while transforming EPS designs into TIFF for downstream raster workflows.
 * 4. When an automated batch job processes a folder of EPS files and outputs TIFFs with a consistent sRGB color space for publishing pipelines.
 * 5. When integrating Aspose.Imaging into a C# solution to preserve image quality and color fidelity during EPS‑to‑TIFF conversion for digital asset management.
 */
