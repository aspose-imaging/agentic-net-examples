// HOW-TO: Apply Motion Blur to PNG and Measure Brightness Shift in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

public class Program
{
    public static void Main(string[] args)
    {
        string inputPath = "template.png";
        string outputPath = "output/blurred.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                int[] originalPixels = raster.LoadArgb32Pixels(raster.Bounds);
                double sumOriginal = 0;
                foreach (int pixel in originalPixels)
                {
                    int r = (pixel >> 16) & 0xFF;
                    int g = (pixel >> 8) & 0xFF;
                    int b = pixel & 0xFF;
                    sumOriginal += (r + g + b) / 3.0;
                }
                double originalBrightness = sumOriginal / originalPixels.Length;

                double[,] kernel = ConvolutionFilter.GetBlurMotion(10, 150);
                var filterOptions = new ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);

                raster.Save(outputPath);

                int[] blurredPixels = raster.LoadArgb32Pixels(raster.Bounds);
                double sumBlurred = 0;
                foreach (int pixel in blurredPixels)
                {
                    int r = (pixel >> 16) & 0xFF;
                    int g = (pixel >> 8) & 0xFF;
                    int b = pixel & 0xFF;
                    sumBlurred += (r + g + b) / 3.0;
                }
                double blurredBrightness = sumBlurred / blurredPixels.Length;

                double shift = blurredBrightness - originalBrightness;
                Console.WriteLine($"Brightness shift: {shift}");
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
 * 1. When you need to simulate camera motion on a PNG template and evaluate how the blur affects overall image brightness.
 * 2. When generating preview thumbnails that require a consistent motion‑blur effect while tracking luminance changes for quality control.
 * 3. When creating animated UI assets where the blur intensity must be calibrated by measuring the brightness shift between original and blurred frames.
 * 4. When performing automated testing of image‑processing pipelines to verify that applying a motion blur filter produces the expected change in histogram‑based brightness.
 * 5. When developing a photo‑editing tool that lets users apply custom motion blur and instantly see the impact on the image’s average brightness.
 */
