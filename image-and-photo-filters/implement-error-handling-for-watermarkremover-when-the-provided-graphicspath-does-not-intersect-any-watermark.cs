// HOW-TO: Remove Watermark From PNG Using Telea Algorithm With Error Handling In C# (Aspose.Imaging for .NET)
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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var image = Image.Load(inputPath))
            {
                var rasterImage = (RasterImage)image;

                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(50, 50, 100, 100)));
                mask.AddFigure(figure);

                try
                {
                    var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(
                        rasterImage,
                        new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask));

                    using (result)
                    {
                        result.Save(outputPath, new PngOptions());
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Watermark removal error: {ex.Message}");
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
 * 1. When you need to automatically erase a logo or text watermark from user‑uploaded PNG images while ensuring the program gracefully reports if the defined mask does not overlap any watermark.
 * 2. When building a batch image‑processing service that removes watermarks from scanned documents stored as PNG files and must continue processing even when some images lack watermarks.
 * 3. When integrating Aspose.Imaging into a C# desktop application that lets users draw custom shapes to specify watermark regions and requires robust error handling for mismatched selections.
 * 4. When creating a server‑side API that receives PNG files and a geometric mask, and you must return a clean image or a clear error message if the mask fails to intersect the watermark.
 * 5. When developing an automated workflow that cleans up product screenshots by removing embedded watermarks using the Telea inpainting method and needs to log any failures without crashing the application.
 */
