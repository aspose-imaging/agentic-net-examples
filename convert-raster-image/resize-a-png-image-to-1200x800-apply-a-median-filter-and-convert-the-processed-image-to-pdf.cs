// HOW-TO: Resize PNG to 1200x800, Apply Median Filter, Save as PDF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\image.png";
            string outputPath = "Output\\processed.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                image.Resize(1200, 800);

                RasterImage raster = (RasterImage)image;
                if (!raster.IsCached) raster.CacheData();

                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));

                PdfOptions pdfOptions = new PdfOptions();
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
 * 1. When you need to generate a printable PDF from a high‑resolution PNG while reducing noise and standardizing the page size for reports.
 * 2. When a web service must accept user‑uploaded PNG screenshots, clean them with a median filter, resize them to 1200×800, and deliver them as PDF invoices.
 * 3. When an automated batch job processes product catalog images, applies noise reduction, resizes them for uniform thumbnails, and archives them in PDF format.
 * 4. When a desktop application creates PDF manuals from PNG diagrams, ensuring consistent dimensions and smoothing artifacts before saving.
 * 5. When a document conversion pipeline requires converting filtered and resized PNG assets into PDF for compliance‑ready documentation.
 */
