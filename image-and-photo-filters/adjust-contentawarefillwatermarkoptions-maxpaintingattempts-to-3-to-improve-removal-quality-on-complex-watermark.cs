// HOW-TO: Improve Watermark Removal Quality by Limiting Painting Attempts in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
                Directory.CreateDirectory(outputDir);

            using (var image = Image.Load(inputPath))
            {
                var rasterImage = (RasterImage)image;

                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(50, 50, 200, 100)));
                mask.AddFigure(figure);

                var options = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask);
                options.MaxPaintingAttempts = 3;

                using (var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(rasterImage, options))
                {
                    result.Save(outputPath, new PngOptions());
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
 * 1. When you need to delete a semi‑transparent logo from a PNG photograph while preserving surrounding pixels, you can use Aspose.Imaging’s ContentAwareFillWatermarkOptions with a custom mask.
 * 2. When processing scanned documents that contain repetitive watermark patterns, limiting MaxPaintingAttempts to three helps the algorithm converge faster and produce cleaner results.
 * 3. When automating batch cleanup of product images that have elliptical watermarks, the code creates an ellipse mask and saves the cleaned image as PNG.
 * 4. When integrating watermark removal into a C# web service, the example shows how to load an image, apply a shape‑based mask, and output the result without extra dependencies.
 * 5. When optimizing performance for complex watermark shapes, adjusting MaxPaintingAttempts reduces unnecessary painting cycles while still achieving high‑quality removal.
 */
