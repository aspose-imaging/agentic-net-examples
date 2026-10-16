// HOW-TO: Resize BMP to 300x300, Apply Median Filter, Export as PDF in C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "input.bmp");
            string outputPath = Path.Combine("Output", "output.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                if (!raster.IsCached) raster.CacheData();

                raster.Resize(300, 300);
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));

                raster.Save(outputPath, new PdfOptions());
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
 * 1. When you need to convert legacy BMP scans into compact PDF documents while standardizing them to a fixed 300 × 300 pixel size.
 * 2. When you want to reduce noise in a BMP image before embedding it in a PDF report by applying a median filter.
 * 3. When an automated workflow must generate printable PDFs from BMP assets that must be uniformly resized for consistent layout.
 * 4. When you are building a document‑generation service that accepts BMP uploads, cleans the image, and returns a PDF for downstream processing.
 * 5. When you need to preprocess BMP graphics for archival, ensuring they are resized, denoised, and stored in a PDF container for long‑term preservation.
 */
