// HOW-TO: Apply Gaussian Blur to PNG and Save as PDF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input/input.png";
        string outputPath = "output/output.pdf";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0f);
                raster.Filter(raster.Bounds, blurOptions);

                var pdfOptions = new PdfOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

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
 * 1. When you need to create a blurred preview PDF of a high‑resolution PNG for faster web viewing.
 * 2. When generating printable PDF documents from PNG assets while applying a softening effect to hide sensitive details.
 * 3. When automating a workflow that converts scanned PNG images into PDF reports with a uniform Gaussian blur for aesthetic consistency.
 * 4. When building a C# service that receives PNG logos, applies a subtle blur, and outputs them as PDF files for branding guidelines.
 * 5. When preparing marketing materials that require PNG images to be blurred and bundled into a single PDF for client review.
 */
