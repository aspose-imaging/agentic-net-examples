// HOW-TO: Compare Telea and ContentAwareFill Watermark Removal Quality in C# (Aspose.Imaging for .NET)
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
        string inputPath = "input.png";
        string outputTeleaPath = "output\\output_telea.png";
        string outputCafPath = "output\\output_caf.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputTeleaPath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputCafPath));

        try
        {
            using (var image = Image.Load(inputPath))
            {
                var raster = (RasterImage)image;

                var mask = new GraphicsPath();
                var figure = new Figure();
                var ellipseRect = new RectangleF(50, 50, 100, 100);
                figure.AddShape(new EllipseShape(ellipseRect));
                mask.AddFigure(figure);

                var teleaOptions = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);
                using (var resultTelea = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, teleaOptions))
                {
                    resultTelea.Save(outputTeleaPath, new PngOptions());
                }

                var cafOptions = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask);
                using (var resultCaf = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, cafOptions))
                {
                    resultCaf.Save(outputCafPath, new PngOptions());
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
 * 1. When you need to evaluate which algorithm—Telea or ContentAwareFill—produces cleaner results for removing circular watermarks from PNG images in a C# application.
 * 2. When you want to automatically generate side‑by‑side before‑and‑after images to demonstrate watermark‑removal quality to clients.
 * 3. When integrating Aspose.Imaging into a batch‑processing pipeline that must choose the best removal method for logos embedded in product photos.
 * 4. When testing the impact of different mask shapes (e.g., ellipses) on the effectiveness of Telea versus ContentAwareFill in a .NET image‑editing tool.
 * 5. When creating a proof‑of‑concept that saves the output of both algorithms to separate files for visual comparison in quality‑control workflows.
 */
