// HOW-TO: Adjust TIFF Brightness and Apply Gaussian Blur Then Save as PDF in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/sample.tif";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = "Output/result.pdf";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;
                if (!rasterImage.IsCached)
                {
                    rasterImage.CacheData();
                }

                // Adjust brightness (example value: 50)
                rasterImage.AdjustBrightness(50);

                // Apply Gaussian blur
                var gaussianOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions
                {
                    Radius = 5,
                    Sigma = 1.5
                };
                rasterImage.Filter(rasterImage.Bounds, gaussianOptions);

                // Save as PDF
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
 * 1. When you need to enhance the visual quality of scanned TIFF documents by brightening them before converting to a searchable PDF.
 * 2. When you want to reduce noise and smooth edges of a TIFF image using Gaussian blur before archiving it as a PDF.
 * 3. When a batch process must standardize the brightness of multi‑page TIFF files and output them as PDFs for printing.
 * 4. When you are building a C# application that prepares medical imaging TIFFs for PDF reports with consistent illumination and softening effects.
 * 5. When you need to programmatically convert legacy TIFF graphics to PDF while applying image adjustments to meet publishing guidelines.
 */
