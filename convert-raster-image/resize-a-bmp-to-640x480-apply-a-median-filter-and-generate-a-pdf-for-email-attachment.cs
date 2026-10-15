// HOW-TO: Resize BMP to 640x480, Apply Median Filter and Save as PDF in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\image.bmp";
            string outputPath = "Output\\image.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                raster.Resize(640, 480);
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));

                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    image.Save(outputPath, pdfOptions);
                }
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
 * 1. When you need to shrink a large BMP screenshot to a standard 640×480 size, reduce noise with a median filter, and attach the result as a PDF in an automated email.
 * 2. When generating PDF reports from legacy BMP assets, you can resize the images, clean them with a median filter, and embed them directly into the PDF for distribution.
 * 3. When building a C# service that processes scanned BMP documents, applying a median filter improves readability before converting the pages to PDF for client delivery.
 * 4. When creating email‑ready PDFs from BMP logos, resizing ensures consistent layout while the median filter removes speckles that could affect visual quality.
 * 5. When integrating Aspose.Imaging into a workflow that converts user‑uploaded BMP files into compact, filtered PDFs for archiving or emailing.
 */
