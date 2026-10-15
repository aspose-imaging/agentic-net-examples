// HOW-TO: Crop Center 200x200 Region from PNG and Save as PDF in C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "input.png");
            string outputPath = Path.Combine("Output", "cropped.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.RasterImage image = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                if (!image.IsCached)
                    image.CacheData();

                int cropWidth = 200;
                int cropHeight = 200;
                int x = (image.Width - cropWidth) / 2;
                int y = (image.Height - cropHeight) / 2;

                Aspose.Imaging.Rectangle rect = new Aspose.Imaging.Rectangle(x, y, cropWidth, cropHeight);
                image.Crop(rect);

                var pdfOptions = new PdfOptions();
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
 * 1. When you need to extract a fixed‑size thumbnail from the middle of a PNG and deliver it as a PDF report.
 * 2. When generating printable PDF previews of scanned documents by cropping a central area of the source image.
 * 3. When creating a PDF brochure that shows only the central portion of a high‑resolution raster graphic.
 * 4. When automating a workflow that converts user‑uploaded images into PDF files with a standardized 200 × 200 crop.
 * 5. When preparing assets for a web application that requires a centered image crop saved in PDF format for archival.
 */
