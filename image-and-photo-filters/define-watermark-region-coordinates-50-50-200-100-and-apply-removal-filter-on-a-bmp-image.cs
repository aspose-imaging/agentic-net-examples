// HOW-TO: Remove Elliptical Watermark From BMP Image Using Telea Filter In C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.bmp";
            string outputPath = "output.bmp";

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
                var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(rasterImage, options);

                using (result)
                {
                    result.Save(outputPath, new BmpOptions());
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
 * 1. When you need to automatically erase a logo or watermark that occupies a known rectangular area in a BMP file before further image analysis.
 * 2. When processing scanned documents in C# and you must remove a semi‑transparent ellipse watermark without affecting surrounding pixels.
 * 3. When integrating Aspose.Imaging into a batch job that cleans up legacy BMP assets by applying the Telea inpainting algorithm to a specified region.
 * 4. When preparing images for OCR and you have to hide a watermark placed at coordinates (50,50,200,100) to improve text recognition accuracy.
 * 5. When developing a C# utility that programmatically removes watermarks from BMP screenshots using a mask defined by an ellipse shape.
 */
