// HOW-TO: Resize PNG to Half Size, Apply Median Filter, Save as PDF in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/input.png";
            string outputPath = "Output/output.pdf";

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

                int newWidth = raster.Width / 2;
                int newHeight = raster.Height / 2;
                raster.Resize(newWidth, newHeight);

                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));

                PdfOptions pdfOptions = new PdfOptions();
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
 * 1. When you need to generate a smaller, noise‑reduced PDF version of a high‑resolution PNG for faster web preview.
 * 2. When an application must batch‑process uploaded PNG screenshots, halve their dimensions, remove speckle noise, and archive them as PDFs.
 * 3. When creating printable PDF documents from PNG assets while preserving image quality by applying a median filter before conversion.
 * 4. When a reporting tool requires converting large PNG charts into compact PDF files with reduced size and smoothed edges.
 * 5. When automating the preparation of PNG‑based UI mockups for client review, resizing them and exporting to PDF with noise reduction.
 */
