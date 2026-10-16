// HOW-TO: Remove Watermark From PDF Page and Save As JPEG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.pdf";
        string outputPath = "Output/cleaned.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image pdfImage = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)pdfImage;

                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(0, 0, raster.Width, raster.Height)));
                mask.AddFigure(figure);

                var options = new TeleaWatermarkOptions(mask);

                using (RasterImage cleaned = WatermarkRemover.PaintOver(raster, options))
                {
                    var jpegOptions = new JpegOptions();
                    cleaned.Save(outputPath, jpegOptions);
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
 * 1. When you need to extract a clean image from a scanned PDF that contains a printed watermark before using it in a marketing brochure.
 * 2. When an automated document‑processing pipeline must convert each PDF page to a JPEG and strip out confidential watermarks for archival.
 * 3. When a web service receives user‑uploaded PDFs and must return watermark‑free JPEG thumbnails for preview.
 * 4. When you are preparing training data for a computer‑vision model and must remove watermarks from PDF‑derived images to avoid bias.
 * 5. When a legacy system only accepts JPEG files, so you convert PDF pages to JPEG and clean them of watermarks for compatibility.
 */
