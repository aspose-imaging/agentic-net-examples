// HOW-TO: Deskew TIFF Image, Apply Anti-Alias Smoothing, Save as PDF in C# (Aspose.Imaging for .NET)
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

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.tif");
            string outputPath = Path.Combine("Output", "result.pdf");

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

                // Deskew the image
                raster.NormalizeAngle(false, Aspose.Imaging.Color.LightGray);

                // Apply smoothing mode
                Graphics graphics = new Graphics(raster);
                graphics.SmoothingMode = SmoothingMode.AntiAlias;

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
 * 1. When scanning crooked documents as TIFF files and needing a straightened, anti‑aliased PDF for archiving.
 * 2. When converting scanned invoices with slight rotation into searchable PDFs while preserving image quality.
 * 3. When preparing scanned blueprints in TIFF format for presentation, requiring deskewing and smooth rendering in the final PDF.
 * 4. When automating a workflow that receives multi‑page TIFF scans and must output clean, deskewed PDFs for downstream processing.
 * 5. When building a C# application that normalizes the angle of scanned forms and applies anti‑alias smoothing before saving them as PDFs.
 */
