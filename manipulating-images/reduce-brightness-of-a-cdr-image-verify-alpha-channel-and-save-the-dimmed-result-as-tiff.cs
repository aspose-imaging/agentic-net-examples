// HOW-TO: Dim CDR Image, Check Alpha Channel, and Save as TIFF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.cdr";
        string outputPath = "output.tiff";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    cdr.Save(ms, new PngOptions
                    {
                        VectorRasterizationOptions = new CdrRasterizationOptions
                        {
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height
                        }
                    });
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        raster.AdjustBrightness(-50);

                        bool hasAlpha = false;
                        Color[] pixels = raster.LoadPixels(raster.Bounds);
                        foreach (Color pixel in pixels)
                        {
                            if (pixel.A < 255)
                            {
                                hasAlpha = true;
                                break;
                            }
                        }
                        Console.WriteLine(hasAlpha ? "Alpha channel present." : "No alpha channel.");

                        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                        raster.Save(outputPath, tiffOptions);
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
 * 1. When you need to import a CorelDRAW (CDR) file into a .NET application, darken it for a watermark effect, verify if any transparency exists, and export the result as a high‑resolution TIFF for printing.
 * 2. When a batch‑processing tool must reduce the brightness of vector graphics, detect alpha transparency, and store the modified images in a lossless TIFF format for archival.
 * 3. When generating preview thumbnails for a document management system, you may dim the original CDR artwork, confirm whether it contains an alpha channel, and save the preview as a TIFF to maintain quality.
 * 4. When preparing assets for a publishing workflow that requires TIFF files, you might need to adjust the CDR source’s brightness, ensure no unintended transparency, and output a ready‑to‑print TIFF.
 * 5. When creating a server‑side image conversion service that accepts CDR uploads, you may want to lower the image’s brightness, check for alpha, and return a TIFF file compatible with downstream graphics pipelines.
 */
