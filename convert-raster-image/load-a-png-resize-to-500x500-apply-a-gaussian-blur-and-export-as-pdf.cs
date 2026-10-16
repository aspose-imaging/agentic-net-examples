// HOW-TO: Resize PNG, Apply Gaussian Blur, and Save as PDF in C# (Aspose.Imaging for .NET)
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
        string inputPath = "Input\\image.png";
        string outputPath = "Output\\result.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Resize(500, 500);
                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.5f);
                raster.Filter(raster.Bounds, blurOptions);
                var pdfOptions = new PdfOptions();
                raster.Save(outputPath, pdfOptions);
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
 * 1. When you need to generate a blurred thumbnail PDF from a high‑resolution PNG for a web catalog.
 * 2. When you must convert user‑uploaded PNG images into uniformly sized PDF previews with a soft focus effect.
 * 3. When creating printable PDF brochures that require all PNG graphics to be resized to 500 × 500 pixels and have a subtle Gaussian blur applied.
 * 4. When automating a batch process that standardizes PNG assets, applies a blur for watermarking, and outputs them as PDF files for archival.
 * 5. When integrating image processing into a C# application to transform PNG logos into PDF assets with consistent dimensions and a smooth blur for UI placeholders.
 */
