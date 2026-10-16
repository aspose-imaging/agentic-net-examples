// HOW-TO: Resize BMP to 640x480, Sharpen, and Save as PDF in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.bmp";
            string outputPath = "Output\\result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                // Resize to 640x480
                image.Resize(640, 480);

                // Apply sharpening filter
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                var sharpenOptions = new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions();
                raster.Filter(raster.Bounds, sharpenOptions);

                // Save as PDF
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
 * 1. When you need to convert legacy BMP screenshots into compact PDF reports with a fixed 640x480 size and enhanced sharpness for better readability.
 * 2. When an application must automatically process scanned BMP documents, resize them for web preview, apply a sharpening filter, and output them as PDF files for archiving.
 * 3. When a batch job has to prepare BMP assets for printing by standardizing dimensions, improving edge definition, and packaging the result in a PDF format.
 * 4. When a desktop tool requires on‑the‑fly image enhancement—resizing a BMP to 640×480, sharpening details, and saving the result as a PDF for email attachment.
 * 5. When integrating Aspose.Imaging in a C# service that transforms user‑uploaded BMP images into PDF brochures with consistent size and clearer visuals.
 */
