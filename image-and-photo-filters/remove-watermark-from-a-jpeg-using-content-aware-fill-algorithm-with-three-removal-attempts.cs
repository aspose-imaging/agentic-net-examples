// HOW-TO: Remove Watermark From JPEG Using Content Aware Fill In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output/output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                var mask = new GraphicsPath();
                var figure = new Figure();
                var rect = new RectangleF(50, 50, 100, 50);
                figure.AddShape(new RectangleShape(rect));
                mask.AddFigure(figure);

                var options = new ContentAwareFillWatermarkOptions(mask)
                {
                    MaxPaintingAttempts = 3
                };

                using (RasterImage result = WatermarkRemover.PaintOver(raster, options))
                {
                    var jpegOptions = new JpegOptions();
                    result.Save(outputPath, jpegOptions);
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
 * 1. When you need to automatically erase a logo or text watermark from a JPEG photo before publishing it on a website.
 * 2. When you must clean up scanned documents that contain faint watermarks and save the result as a high‑quality JPEG using C#.
 * 3. When an e‑commerce platform requires batch processing of product images to remove supplier watermarks without manual editing.
 * 4. When a mobile app generates user‑uploaded screenshots that include overlay watermarks and you want to programmatically remove them server‑side.
 * 5. When a digital archivist wants to restore old JPEG images by applying a content‑aware fill algorithm with multiple painting attempts to ensure seamless background reconstruction.
 */
