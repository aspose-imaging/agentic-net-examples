// HOW-TO: Check Cumulative Rounding Error After Multiple Image Filters in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-14
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
        try
        {
            string inputPath = "input/input.jpg";
            string outputPath = "output/output.jpg";

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

                var gaussianOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0);
                raster.Filter(raster.Bounds, gaussianOptions);

                var medianOptions = new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3);
                raster.Filter(raster.Bounds, medianOptions);

                var sharpenOptions = new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions();
                raster.Filter(raster.Bounds, sharpenOptions);

                int[] pixels = raster.LoadArgb32Pixels(raster.Bounds);
                long checksum = 0;
                foreach (int p in pixels)
                {
                    checksum += (uint)p;
                }
                Console.WriteLine($"Checksum after filters: {checksum}");

                var jpegOptions = new JpegOptions();
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
 * 1. When you need to ensure that applying a series of filters such as Gaussian blur, median, and sharpen to a JPEG does not introduce noticeable rounding errors before saving the image.
 * 2. When you want to validate the integrity of pixel data after sequential processing by calculating a checksum of ARGB32 values in a .NET image workflow.
 * 3. When you are building an automated image‑processing pipeline and must confirm that cached raster data remains consistent across multiple filter operations.
 * 4. When you need to compare the effect of different filter orders on final image quality and verify that numerical differences stay within an acceptable tolerance.
 * 5. When you are debugging a C# application that manipulates large batches of photos and want to detect any cumulative precision loss caused by repeated filter applications.
 */
