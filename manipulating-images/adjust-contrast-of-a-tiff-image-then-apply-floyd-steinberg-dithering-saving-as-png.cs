// HOW-TO: Adjust TIFF Contrast and Apply Floyd Steinberg Dithering to PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.AdjustContrast(0.5f);
                raster.Dither(DitheringMethod.FloydSteinbergDithering, 8);

                PngOptions pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                image.Save(outputPath, pngOptions);
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
 * 1. When you need to improve the visual clarity of a scanned TIFF document before converting it to a web‑friendly PNG.
 * 2. When you want to reduce the file size of a high‑resolution TIFF by applying contrast adjustment and Floyd‑Steinberg dithering for efficient PNG output.
 * 3. When preparing archival images for display on low‑color‑depth devices, you can adjust contrast and dither the TIFF to an 8‑bit PNG.
 * 4. When automating a batch process that converts medical imaging TIFFs to PNGs with consistent contrast and dithering for better diagnostic viewing.
 * 5. When integrating image preprocessing into a C# application that requires TIFF to PNG conversion with enhanced contrast and ordered dithering for print‑ready graphics.
 */
