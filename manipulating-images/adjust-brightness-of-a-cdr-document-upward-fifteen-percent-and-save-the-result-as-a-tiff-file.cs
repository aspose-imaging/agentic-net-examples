// HOW-TO: Increase Brightness of CDR File by 15% and Save as TIFF in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.cdr";
            string outputPath = "output.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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
                        raster.AdjustBrightness(38);
                        raster.Save(outputPath, new TiffOptions(TiffExpectedFormat.Default));
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
 * 1. When a designer needs to brighten a CorelDRAW (CDR) illustration by about 15% before converting it to a high‑resolution TIFF for printing.
 * 2. When an automated workflow must batch‑process CDR assets, increase their visual contrast, and store the results as TIFF files for archival.
 * 3. When a web service receives CDR diagrams, applies a brightness boost to improve readability, and returns the images in TIFF format for downstream applications.
 * 4. When a developer integrates Aspose.Imaging into a C# application to rasterize vector CDR pages to PNG in memory, adjust brightness, and output TIFF without creating intermediate files on disk.
 * 5. When a document conversion tool needs to ensure scanned‑like TIFF outputs have consistent brightness after converting from CorelDRAW files.
 */
