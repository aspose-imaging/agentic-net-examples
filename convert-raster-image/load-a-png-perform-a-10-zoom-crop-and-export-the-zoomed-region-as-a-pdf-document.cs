// HOW-TO: Crop Center 10% of PNG and Save as PDF in C# (Aspose.Imaging for .NET)
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
        string inputPath = "Input\\sample.png";
        string outputPath = "Output\\zoomed.pdf";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;
                if (!raster.IsCached) raster.CacheData();

                int cropWidth = (int)(raster.Width * 0.1);
                int cropHeight = (int)(raster.Height * 0.1);
                int offsetX = (raster.Width - cropWidth) / 2;
                int offsetY = (raster.Height - cropHeight) / 2;

                Aspose.Imaging.Rectangle cropRect = new Aspose.Imaging.Rectangle(offsetX, offsetY, cropWidth, cropHeight);
                raster.Crop(cropRect);

                raster.Save(outputPath, new PdfOptions());
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
 * 1. When you need to generate a printable PDF that shows only the central 10 % of a high‑resolution PNG thumbnail.
 * 2. When creating a preview document that focuses on a zoomed‑in region of a PNG for quality‑control reports.
 * 3. When extracting a small area from a scanned PNG map and exporting it as a PDF for inclusion in a GIS presentation.
 * 4. When automating the production of PDF handouts that contain a magnified view of a logo stored as a PNG.
 * 5. When building a batch process that crops the center of multiple PNG assets and converts them to PDF for archival purposes.
 */
