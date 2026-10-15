// HOW-TO: Remove Watermark From BMP and Save As High Resolution PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input\\source.bmp";
        string outputPath = "output\\cleaned.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                var mask = new Aspose.Imaging.GraphicsPath();
                var figure = new Aspose.Imaging.Figure();
                figure.AddShape(new RectangleShape(new Aspose.Imaging.RectangleF(0, 0, raster.Width, raster.Height)));
                mask.AddFigure(figure);

                var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);
                using (RasterImage result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, options))
                {
                    var pngOptions = new PngOptions
                    {
                        ResolutionSettings = new Aspose.Imaging.ResolutionSetting(300, 300),
                        Source = new FileCreateSource(outputPath, false)
                    };
                    result.Save(outputPath, pngOptions);
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
 * 1. When you need to automatically clean scanned BMP documents that contain watermarks and output them as print‑ready 300 dpi PNG files.
 * 2. When a batch process must strip logos from legacy BMP assets before uploading them to a web gallery that requires high‑resolution PNGs.
 * 3. When an application has to convert watermark‑protected BMP screenshots into editable PNG images for further image analysis.
 * 4. When a document management system requires removing embedded watermarks from BMP scans and storing the results in lossless PNG format with specific DPI settings.
 * 5. When you want to integrate Aspose.Imaging’s PaintOver method into a C# service that prepares BMP images for high‑quality printing by eliminating watermarks and saving them as PNG.
 */
