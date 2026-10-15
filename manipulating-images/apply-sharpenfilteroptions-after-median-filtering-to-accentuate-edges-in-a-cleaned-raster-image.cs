// HOW-TO: Apply Median Then Sharpen Filter to JPEG in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output\\output.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions());

                var jpegOptions = new JpegOptions
                {
                    Quality = 90
                };
                raster.Save(outputPath, jpegOptions);
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
 * 1. When you need to reduce noise in a scanned photo before highlighting edges for a product catalog, you can apply a median filter followed by a sharpen filter using Aspose.Imaging in C#.
 * 2. When preparing medical imaging thumbnails where speckle noise must be removed and subtle details emphasized, this code cleans the raster image and sharpens it before saving as JPEG.
 * 3. When automating batch processing of security camera snapshots to improve clarity for facial recognition, the median filter smooths grain and the sharpen filter accentuates facial features.
 * 4. When converting low‑resolution screenshots into higher‑quality JPEGs for documentation, the combined filters remove pixelation and make text edges crisper.
 * 5. When building a web service that receives user‑uploaded photos and returns a cleaned, edge‑enhanced JPEG for social media sharing, the code demonstrates the required filtering steps in C#.
 */
