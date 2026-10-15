// HOW-TO: Batch Remove Watermarks from TIFF Files Using Content‑Aware Fill in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "input";
            string outputFolder = "output";

            var tiffFiles = Directory.GetFiles(inputFolder, "*.*", SearchOption.TopDirectoryOnly)
                .Where(f => f.EndsWith(".tif", StringComparison.OrdinalIgnoreCase) || f.EndsWith(".tiff", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            foreach (var inputPath in tiffFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileName + ".tif");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    int width = image.Width;
                    int height = image.Height;

                    var mask = new GraphicsPath();
                    var figure = new Figure();
                    figure.AddShape(new RectangleShape(new RectangleF(0, 0, width, height)));
                    mask.AddFigure(figure);

                    var options = new ContentAwareFillWatermarkOptions(mask);

                    using (RasterImage result = WatermarkRemover.PaintOver((RasterImage)image, options))
                    {
                        var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                        result.Save(outputPath, tiffOptions);
                    }
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
 * 1. When you need to automatically clean scanned documents that contain printed watermarks before archiving them as TIFF files.
 * 2. When a batch of medical imaging TIFFs must have embedded copyright marks removed without manually editing each image.
 * 3. When a document management system imports TIFF files and requires watermark‑free images for OCR processing.
 * 4. When you want to prepare a collection of TIFF graphics for printing by eliminating watermarks using content‑aware fill to preserve background details.
 * 5. When a migration script must process dozens of TIFF files, strip watermarks, and save the results back to a designated output folder.
 */
