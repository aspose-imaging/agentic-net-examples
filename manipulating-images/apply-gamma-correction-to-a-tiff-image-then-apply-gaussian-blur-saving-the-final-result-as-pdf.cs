// HOW-TO: Apply Gamma Correction and Gaussian Blur to TIFF and Save as PDF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.tif";
            string outputPath = "Output\\result.pdf";

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

                raster.AdjustGamma(1.2f);

                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0f);
                raster.Filter(raster.Bounds, blurOptions);

                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    raster.Save(outputPath, pdfOptions);
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
 * 1. When you need to improve the brightness and reduce noise of scanned TIFF documents before archiving them as searchable PDFs.
 * 2. When preparing high‑resolution TIFF images for printing, applying gamma correction and a subtle blur to achieve consistent visual quality in the final PDF.
 * 3. When converting medical imaging TIFF files to PDF while adjusting gamma to enhance contrast and applying Gaussian blur to smooth artifacts.
 * 4. When automating a workflow that processes batch TIFF photos, corrects exposure, adds a softening effect, and outputs them as PDF reports.
 * 5. When integrating Aspose.Imaging in a C# application to transform legacy TIFF assets with gamma and blur filters before delivering them to end‑users in PDF format.
 */
