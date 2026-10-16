// HOW-TO: Crop Top Right Quadrant of Image and Save as PDF in C# (Aspose.Imaging for .NET)
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
        string inputPath = "Input/image.png";
        string outputPath = "Output/cropped.pdf";

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

                int halfWidth = raster.Width / 2;
                int halfHeight = raster.Height / 2;
                Aspose.Imaging.Rectangle rect = new Aspose.Imaging.Rectangle(halfWidth, 0, halfWidth, halfHeight);
                raster.Crop(rect);
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
 * 1. When you need to extract the upper-right portion of a PNG chart and embed it in a PDF report.
 * 2. When generating printable PDFs that contain only a specific quadrant of a scanned document.
 * 3. When creating thumbnails of the top-right area of a large raster image for a web preview.
 * 4. When automating the conversion of a portion of a bitmap into a PDF for archival purposes.
 * 5. When processing batch images to crop a defined rectangle and store the result as PDF files using C#.
 */
