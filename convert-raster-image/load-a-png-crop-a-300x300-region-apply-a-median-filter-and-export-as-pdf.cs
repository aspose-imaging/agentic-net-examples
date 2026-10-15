// HOW-TO: Crop PNG, Apply Median Filter, and Save as PDF in C# (Aspose.Imaging for .NET)
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
        string inputPath = "Input/input.png";
        string outputPath = "Output/output.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached)
                    image.CacheData();

                var cropRect = new Rectangle(0, 0, 300, 300);
                image.Crop(cropRect);

                var medianOptions = new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3);
                image.Filter(image.Bounds, medianOptions);

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
 * 1. When you need to extract a specific 300 × 300 area from a PNG, reduce noise with a median filter, and generate a PDF report.
 * 2. When converting scanned PNG thumbnails into clean PDF pages for archival or printing.
 * 3. When preparing a cropped and denoised image snippet for inclusion in a PDF invoice or catalog.
 * 4. When automating the preprocessing of PNG graphics before embedding them into a PDF document in a C# application.
 * 5. When building a batch job that trims, smooths, and bundles PNG assets into PDF files for distribution.
 */
