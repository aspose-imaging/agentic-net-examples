// HOW-TO: Apply Gaussian Blur and Brightness to TIFF and Save as PDF in C# (Aspose.Imaging for .NET)
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
        string inputPath = "Input\\image.tif";
        string outputPath = "Output\\result.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions();
                blurOptions.Radius = 5;
                blurOptions.Sigma = 1.5f;
                raster.Filter(raster.Bounds, blurOptions);

                raster.AdjustBrightness(30);

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
 * 1. When you need to soften a scanned TIFF document, enhance its visibility, and deliver it as a PDF for archiving.
 * 2. When preparing product manuals where the original TIFF images require a subtle blur and brighter tones before being compiled into a PDF brochure.
 * 3. When converting medical imaging TIFF files to PDF while applying Gaussian blur to reduce noise and adjusting brightness for clearer diagnostic reports.
 * 4. When automating the generation of PDF reports from TIFF graphics and you want to uniformly apply a blur effect and increase brightness to meet branding guidelines.
 * 5. When building a batch processing tool that takes TIFF photographs, smooths them with a Gaussian filter, brightens them, and outputs PDF files for client distribution.
 */
