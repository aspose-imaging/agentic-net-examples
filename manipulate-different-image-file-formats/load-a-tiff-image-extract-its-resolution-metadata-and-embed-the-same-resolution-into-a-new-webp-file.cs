// HOW-TO: Convert TIFF to WebP while Preserving Resolution Metadata in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\source.tif";
            string outputPath = "Output\\result.webp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image tiffImage = Image.Load(inputPath))
            {
                int width = tiffImage.Width;
                int height = tiffImage.Height;

                RasterImage rasterTiff = (RasterImage)tiffImage;
                double hRes = rasterTiff.HorizontalResolution;
                double vRes = rasterTiff.VerticalResolution;

                Aspose.Imaging.Color[] pixels = rasterTiff.LoadPixels(tiffImage.Bounds);

                using (WebPOptions webpOptions = new WebPOptions())
                {
                    webpOptions.Source = new FileCreateSource(outputPath, false);
                    webpOptions.Lossless = false;
                    webpOptions.ResolutionSettings = new ResolutionSetting((int)hRes, (int)vRes);

                    using (Image webpImage = Image.Create(webpOptions, width, height))
                    {
                        ((RasterImage)webpImage).SavePixels(webpImage.Bounds, pixels);
                        webpImage.Save();
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
 * 1. When you need to generate web‑optimized WebP thumbnails from high‑resolution TIFF scans while keeping the original DPI for accurate print scaling.
 * 2. When a GIS or medical imaging application must convert large TIFF raster files to WebP for faster web delivery without losing resolution information.
 * 3. When an e‑commerce platform wants to store product photos as WebP but must retain the source image’s resolution metadata for consistent display across devices.
 * 4. When a batch processing script has to preserve the horizontal and vertical resolution values while converting archival TIFF documents to a smaller WebP format.
 * 5. When a digital asset management system needs to extract DPI from TIFF files and embed it into WebP files to maintain metadata integrity during format migration.
 */
