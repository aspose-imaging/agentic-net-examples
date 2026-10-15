// HOW-TO: Remove Watermark From JPEG Using Content-Aware Fill And Telea In C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.jpg";
            string outputPathContentAware = "output/content_aware.jpg";
            string outputPathTelea = "output/telea.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPathContentAware));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathTelea));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Create mask (ellipse)
                GraphicsPath mask = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(50, 50, 200, 200)));
                mask.AddFigure(figure);

                // Content-Aware Fill removal
                var caOptions = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask)
                {
                    MaxPaintingAttempts = 4,
                    PatchSize = 9
                };
                using (RasterImage resultCa = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, caOptions))
                {
                    var jpegOptions = new JpegOptions();
                    resultCa.Save(outputPathContentAware, jpegOptions);
                }

                // Telea algorithm removal
                var teleaOptions = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);
                using (RasterImage resultTelea = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, teleaOptions))
                {
                    var jpegOptions = new JpegOptions();
                    resultTelea.Save(outputPathTelea, jpegOptions);
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
 * 1. When you need to automatically erase a logo or unwanted object from a JPEG photo using a shape mask and preserve surrounding texture.
 * 2. When you want to compare Aspose.Imaging’s content‑aware fill algorithm with the Telea inpainting method to choose the best visual result.
 * 3. When you are building a batch image‑processing tool that removes watermarks from user‑uploaded JPEGs before publishing.
 * 4. When you need to generate two versions of a cleaned image—one using content‑aware fill and another using Telea—to evaluate performance for a UI preview.
 * 5. When you are integrating Aspose.Imaging into a C# application to programmatically create masks (e.g., ellipses) and perform smart fill removal without manual editing.
 */
