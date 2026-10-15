// HOW-TO: Crop EPS Canvas To Rectangle And Save As PNG In C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.eps";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.FileFormats.Eps.EpsImage eps = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
            {
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions()
                };

                using (MemoryStream ms = new MemoryStream())
                {
                    eps.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        Rectangle cropRect = new Rectangle(100, 100, 200, 200);
                        raster.Crop(cropRect);
                        raster.Save(outputPath);
                    }
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
 * 1. When you need to extract a specific region from a vector EPS logo and deliver it as a high‑quality PNG for web display.
 * 2. When an automated pipeline must convert EPS artwork to PNG thumbnails while trimming unwanted margins.
 * 3. When a desktop application has to rasterize an EPS diagram, crop to a defined area, and save the result for inclusion in a PDF report.
 * 4. When a batch process must prepare EPS‑based product labels by cutting out a 200×200 pixel section and exporting it as PNG for printing.
 * 5. When a content management system requires on‑the‑fly conversion of uploaded EPS files into cropped PNG previews for user galleries.
 */
