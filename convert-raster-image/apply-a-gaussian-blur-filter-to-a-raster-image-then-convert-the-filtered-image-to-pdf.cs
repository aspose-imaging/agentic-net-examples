// HOW-TO: Apply Gaussian Blur to JPEG and Save as PDF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = Path.Combine("Input", "sample.jpg");
        string outputPath = Path.Combine("Output", "sample.pdf");

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0f);
                raster.Filter(raster.Bounds, blurOptions);

                var pdfOptions = new PdfOptions();
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
 * 1. When you need to soften a JPEG photo before embedding it in a PDF report using C#.
 * 2. When you want to create a blurred background image for a printable brochure and export it as a PDF.
 * 3. When you must preprocess scanned documents with a Gaussian blur to reduce noise before converting them to PDF files.
 * 4. When you are generating PDF catalogs and require a consistent blur effect on product images programmatically.
 * 5. When you need to automate image‑to‑PDF conversion with a blur filter for privacy masking in a .NET application.
 */
