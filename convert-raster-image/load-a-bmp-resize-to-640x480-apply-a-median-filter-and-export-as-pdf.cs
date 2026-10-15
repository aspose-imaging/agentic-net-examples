// HOW-TO: Resize BMP, Apply Median Filter, and Save as PDF in C# (Aspose.Imaging for .NET)
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

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached)
                    image.CacheData();

                image.Resize(640, 480);

                var medianOptions = new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3);
                image.Filter(image.Bounds, medianOptions);

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
 * 1. When you need to convert high‑resolution BMP scans into smaller PDF documents while reducing noise for easier sharing.
 * 2. When generating printable PDF reports from raw bitmap images that must be resized to standard 640×480 dimensions.
 * 3. When preprocessing scanned forms by applying a median filter to remove speckles before embedding them in a PDF.
 * 4. When automating batch conversion of legacy BMP assets to PDF for archiving with consistent image size.
 * 5. When integrating image cleanup and format conversion into a C# web service that delivers PDF previews of uploaded BMP files.
 */
