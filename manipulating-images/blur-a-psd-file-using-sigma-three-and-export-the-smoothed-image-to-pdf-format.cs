// HOW-TO: Apply Gaussian Blur to PSD and Save as PDF in C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "sample.psd");
            string outputPath = Path.Combine("Output", "blurred.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(0, 3);
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
 * 1. When you need to obscure sensitive details in a Photoshop PSD before sharing it as a PDF report.
 * 2. When you want to create a softened preview of a layered design by applying a sigma‑3 Gaussian blur and exporting it to PDF for client review.
 * 3. When an automated workflow must convert high‑resolution PSD assets into PDF documents with a uniform blur effect for printing proofs.
 * 4. When a web service generates PDF catalogs from PSD templates and requires a consistent blur to reduce visual noise.
 * 5. When a batch process needs to apply a Gaussian blur to multiple PSD files and save the results as PDF files using Aspose.Imaging in C#.
 */
