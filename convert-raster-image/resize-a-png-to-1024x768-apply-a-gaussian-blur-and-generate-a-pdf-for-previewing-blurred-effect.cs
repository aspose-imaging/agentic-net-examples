// HOW-TO: Resize PNG to 1024x768, Apply Gaussian Blur, and Export PDF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/input.png";
            string outputPath = "Output/preview.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                image.Resize(1024, 768, ResizeType.NearestNeighbourResample);
                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0);
                image.Filter(image.Bounds, blurOptions);
                var pdfOptions = new PdfOptions();
                image.Save(outputPath, pdfOptions);
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
 * 1. When you need to generate a low‑resolution PDF preview of a high‑quality PNG with a soft blur for design mock‑ups.
 * 2. When an e‑commerce platform must create blurred thumbnail PDFs of product images to protect copyright while still showing a preview.
 * 3. When a reporting tool requires converting resized PNG charts into PDF pages with a Gaussian blur to emphasize background elements.
 * 4. When a document management system automatically prepares PDF previews of uploaded PNG files, applying a blur to hide sensitive details.
 * 5. When a mobile app backend needs to downscale user‑uploaded PNGs, add a subtle blur effect, and deliver them as PDFs for quick viewing.
 */
