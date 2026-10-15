// HOW-TO: Resize PNG to 1024x1024 Apply Median Filter and Save as PDF in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.png";
            string outputPath = "output/output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                if (!raster.IsCached)
                    raster.CacheData();

                raster.Resize(1024, 1024);

                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));

                PdfOptions pdfOptions = new PdfOptions();
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
 * 1. When you need to archive high‑resolution PNG screenshots as compact PDF files while reducing visual noise.
 * 2. When a web service must standardize uploaded PNG avatars to a 1024×1024 size, clean them with a median filter, and store them as PDFs for legal retention.
 * 3. When an automated batch job processes scanned PNG documents, resizes them, removes speckles, and converts them to PDF for a document management system.
 * 4. When a desktop application prepares product images for printing catalogs by resizing, smoothing, and exporting them to PDF format.
 * 5. When a compliance tool converts PNG evidence files into fixed‑layout PDFs after normalizing dimensions and applying noise reduction.
 */
