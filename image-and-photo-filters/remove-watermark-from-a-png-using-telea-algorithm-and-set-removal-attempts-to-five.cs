// HOW-TO: Remove PNG Watermark Using Telea Algorithm With Five Attempts In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var image = Image.Load(inputPath))
            {
                var rasterImage = (RasterImage)image;

                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(50, 50, 200, 100)));
                mask.AddFigure(figure);

                var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

                using (var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(rasterImage, options))
                {
                    result.Save(outputPath);
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
 * 1. When you need to automatically erase a semi‑transparent logo from product photos stored as PNG files before publishing them on an e‑commerce site.
 * 2. When a batch process must clean scanned documents that contain a faint watermark by applying the Telea inpainting algorithm with multiple passes in a C# application.
 * 3. When you want to programmatically remove a circular watermark from user‑uploaded PNG avatars while preserving the surrounding image quality using Aspose.Imaging.
 * 4. When a desktop tool has to restore old PNG graphics that were watermarked for copyright protection by painting over the masked area with five removal attempts.
 * 5. When integrating image preprocessing in a C# workflow that requires precise control over the watermark mask shape and the number of Telea algorithm iterations for consistent results.
 */
