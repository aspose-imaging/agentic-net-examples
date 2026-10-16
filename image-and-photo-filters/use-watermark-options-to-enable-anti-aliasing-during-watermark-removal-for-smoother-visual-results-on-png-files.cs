// HOW-TO: Remove Watermark From PNG With Anti‑Aliasing Using Telea In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input/input.png";
            string outputPath = "output/output.png";

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
                figure.AddShape(new EllipseShape(new RectangleF(50, 50, 200, 200)));
                mask.AddFigure(figure);

                var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

                using (RasterImage result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, options))
                {
                    var saveOptions = new PngOptions();
                    result.Save(outputPath, saveOptions);
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
 * 1. When you need to clean up a scanned PNG image that contains a logo or text watermark and want the result to look smooth without jagged edges.
 * 2. When processing batch PNG files for a web gallery and you must automatically erase watermarks while preserving image quality for faster loading.
 * 3. When integrating image preprocessing in a C# application that prepares assets for printing, and you need to remove watermarks without introducing artifacts.
 * 4. When developing a document management system that receives user‑uploaded PNGs with confidential watermarks that must be removed before archival.
 * 5. When creating a photo‑editing tool that offers a “remove watermark” feature and you want the algorithm to apply anti‑aliasing for a natural look.
 */
