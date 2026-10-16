// HOW-TO: Resize Image to 1024x1024, Sharpen, and Save as PDF in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\sample.png";
            string outputPath = "Output\\result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached) image.CacheData();

                image.Resize(1024, 1024);
                image.Filter(image.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions());

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
 * 1. When you need to generate a high‑resolution PDF thumbnail from a PNG by resizing it to a fixed 1024×1024 size and enhancing details with a sharpening filter using Aspose.Imaging in C#.
 * 2. When an e‑commerce platform must convert product photos into uniformly sized, sharpened PDF catalogs for printing or offline viewing.
 * 3. When a document management system automatically processes uploaded raster images, standardizes them to 1024×1024 pixels, applies a sharpen filter, and stores the result as PDF files.
 * 4. When a reporting tool creates PDF reports that include raster graphics, and you want to ensure each image fits a 1024×1024 layout and appears crisp after conversion.
 * 5. When a mobile app backend receives user‑submitted images, needs to resize them to a specific dimension, improve clarity, and deliver them as PDFs for archival purposes.
 */
