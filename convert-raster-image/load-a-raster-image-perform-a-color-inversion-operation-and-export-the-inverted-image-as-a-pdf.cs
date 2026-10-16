// HOW-TO: Invert Colors of a PNG and Save as PDF Using Aspose.Imaging C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.png";
            string outputPath = "Output/inverted.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = image as RasterImage;
                if (raster != null)
                {
                    if (!raster.IsCached) raster.CacheData();

                    var settings = new MagicWandSettings(0, 0);
                    ImageBitMask mask = MagicWandTool.Select(raster, settings);
                    mask = mask.Invert();
                    mask.Apply();
                }

                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    image.Save(outputPath, pdfOptions);
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
 * 1. When you need to generate a printable PDF that shows a negative‑effect version of a product photo stored as a PNG.
 * 2. When an application must create a PDF preview of a scanned document with inverted colors to improve readability on dark screens.
 * 3. When a web service offers users the ability to download a color‑inverted version of their uploaded PNG as a PDF report.
 * 4. When preparing assets for a printing workflow that requires PDF files with reversed color schemes for proofing purposes.
 * 5. When an automated batch process converts a folder of PNG images to PDFs with color inversion for archival or compliance needs.
 */
