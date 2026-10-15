// HOW-TO: Resize Image to 1200px Width and Save as PDF in C# (Aspose.Imaging for .NET)
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

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "Input\\sample.png";
                string outputPath = "Output\\sample.pdf";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputDir = Path.GetDirectoryName(outputPath);
                Directory.CreateDirectory(outputDir);

                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;
                    if (!raster.IsCached)
                    {
                        raster.CacheData();
                    }

                    int newWidth = 1200;
                    int newHeight = (int)Math.Round((double)raster.Height * newWidth / raster.Width);
                    raster.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

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
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert a high‑resolution PNG into a web‑friendly PDF that fits a 1200‑pixel width layout while preserving the original aspect ratio.
 * 2. When you want to downscale product photos to a consistent width before embedding them in PDFs for an online catalog.
 * 3. When a web application must accept user‑uploaded raster images, resize them to 1200 px wide, and deliver the result as a PDF for responsive display.
 * 4. When you are batch‑processing scanned documents, resizing each image to a standard width and saving them as PDFs for archival and quick browser viewing.
 * 5. When building a reporting tool that inserts resized images into PDF reports to ensure fast loading and uniform appearance across devices.
 */
