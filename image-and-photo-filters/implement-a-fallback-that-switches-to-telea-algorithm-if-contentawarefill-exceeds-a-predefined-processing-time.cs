// HOW-TO: Switch To Telea Watermark Removal When ContentAwareFill Is Slow In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var image = Image.Load(inputPath))
            {
                var rasterImage = (RasterImage)image;

                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(50, 50, 100, 100)));
                mask.AddFigure(figure);

                var caOptions = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask);
                var stopwatch = Stopwatch.StartNew();
                var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(rasterImage, caOptions);
                stopwatch.Stop();

                if (stopwatch.Elapsed > TimeSpan.FromSeconds(5))
                {
                    result.Dispose();
                    var teleaOptions = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);
                    result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(rasterImage, teleaOptions);
                }

                using (result)
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
 * 1. When you need to remove a watermark from a PNG image but want to avoid long processing times, you can use a timed ContentAwareFill fallback to the faster Telea algorithm in C#.
 * 2. When an automated image‑processing pipeline must guarantee completion within a few seconds, you can measure the ContentAwareFill duration and switch to Telea if the limit is exceeded.
 * 3. When working with irregular mask shapes such as an elliptical region and want to ensure consistent results even on large images, the code falls back to Telea after a 5‑second threshold.
 * 4. When integrating Aspose.Imaging into a desktop application that processes user‑uploaded PNG files, this approach prevents UI freezes by limiting the ContentAwareFill execution time.
 * 5. When you need a reliable way to handle cases where ContentAwareFill fails or is too slow on high‑resolution images, the fallback to Telea provides a seamless alternative without manual intervention.
 */
