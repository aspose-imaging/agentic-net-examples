// HOW-TO: Center Crop a JPEG to 400x400 and Save as PDF in C# (Aspose.Imaging for .NET)
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
        string inputPath = "Input\\image.jpg";
        string outputPath = "Output\\cropped.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;
                if (!raster.IsCached) raster.CacheData();

                int cropWidth = 400;
                int cropHeight = 400;
                int x = (raster.Width - cropWidth) / 2;
                int y = (raster.Height - cropHeight) / 2;
                Aspose.Imaging.Rectangle rect = new Aspose.Imaging.Rectangle(x, y, cropWidth, cropHeight);
                raster.Crop(rect);

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
 * 1. When you need to generate a printable PDF thumbnail of the central area of a large JPEG for a product catalog.
 * 2. When you must extract a 400 × 400 pixel region from scanned documents and embed it in a PDF report using C#.
 * 3. When an application requires converting user‑uploaded photos into a fixed‑size PDF preview for email attachments.
 * 4. When you want to automate the creation of centered PDF stamps from high‑resolution images in a batch processing workflow.
 * 5. When a web service needs to return a cropped portion of an image as a PDF file for compliance documentation.
 */
