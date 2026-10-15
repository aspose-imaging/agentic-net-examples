// HOW-TO: Convert PNG to PDF with Transparent Background and Median Filter in C# (Aspose.Imaging for .NET)
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

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "image.png");
            string outputPath = Path.Combine("Output", "result.pdf");

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

                raster.BackgroundColor = Aspose.Imaging.Color.Transparent;

                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));

                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.PdfDocumentInfo = new PdfDocumentInfo();
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
 * 1. When you need to embed a cleaned‑up PNG image with a transparent background into a PDF report.
 * 2. When you want to remove noise from a scanned raster graphic before converting it to PDF.
 * 3. When you are generating PDF invoices that require logo images to have no background and smooth edges.
 * 4. When you automate batch processing of PNG assets, applying a median filter and saving them as PDF for archival.
 * 5. When you create printable PDFs from user‑uploaded images while ensuring the background is transparent and visual artifacts are reduced.
 */
