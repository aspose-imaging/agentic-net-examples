// HOW-TO: Convert TIFF to WebP While Preserving Image Resolution in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output/output.webp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                int width = tiffImage.Width;
                int height = tiffImage.Height;
                double hRes = tiffImage.HorizontalResolution;
                double vRes = tiffImage.VerticalResolution;

                WebPOptions webpOptions = new WebPOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    ResolutionSettings = new ResolutionSetting(hRes, vRes)
                };

                using (Image webpImage = Image.Create(webpOptions, width, height))
                {
                    RasterImage srcRaster = (RasterImage)tiffImage;
                    RasterImage dstRaster = (RasterImage)webpImage;

                    var pixels = srcRaster.LoadPixels(srcRaster.Bounds);
                    dstRaster.SavePixels(dstRaster.Bounds, pixels);

                    webpImage.Save();
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
 * 1. When you need to generate web‑optimized WebP thumbnails from high‑resolution TIFF scans while keeping the original DPI for accurate printing.
 * 2. When a document‑management system must convert archived TIFF files to WebP for faster web delivery but retain the source resolution metadata.
 * 3. When an e‑commerce platform wants to display product images in WebP format without losing the original resolution used for size calculations.
 * 4. When a GIS application converts georeferenced TIFF maps to WebP tiles and must preserve the horizontal and vertical resolution for correct scaling.
 * 5. When a digital asset pipeline automates batch conversion of TIFF artwork to WebP and needs to embed the same DPI values for downstream design tools.
 */
