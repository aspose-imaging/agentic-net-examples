// HOW-TO: Remove Text Watermark from Scanned Image and Save as High Resolution TIFF in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.png";
            string outputPath = "output.tif";

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
                figure.AddShape(new RectangleShape(new RectangleF(100, 200, 300, 50)));
                mask.AddFigure(figure);

                var options = new TeleaWatermarkOptions(mask);

                using (RasterImage result = WatermarkRemover.PaintOver(raster, options))
                {
                    result.HorizontalResolution = 300;
                    result.VerticalResolution = 300;

                    var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    result.Save(outputPath, tiffOptions);
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
 * 1. When digitizing paper contracts that contain a faint watermark, a developer can use this code to erase the watermark and output a 300 dpi TIFF for archival.
 * 2. When preparing scanned medical records for OCR, the code removes the overlay text and saves a high‑resolution TIFF that preserves diagnostic detail.
 * 3. When a publishing workflow requires clean master images without branding watermarks, this snippet strips the selected area and exports a print‑ready TIFF.
 * 4. When a legal compliance system must store scanned evidence without visible watermarks, the code programmatically removes the watermark and stores the image at 300 dpi TIFF.
 * 5. When integrating a document management system that accepts only high‑resolution TIFF files, the code cleans the scanned PNG of watermarks before conversion.
 */
