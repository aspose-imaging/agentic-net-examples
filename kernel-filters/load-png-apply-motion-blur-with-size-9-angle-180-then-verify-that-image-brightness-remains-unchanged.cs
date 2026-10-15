// HOW-TO: Apply 180 Degree Motion Blur to PNG and Check Brightness in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/input.png";
        string outputPath = "Output/output.png";

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
                int[] beforePixels = raster.LoadArgb32Pixels(raster.Bounds);
                double beforeBrightness = 0;
                foreach (int argb in beforePixels)
                {
                    int r = (argb >> 16) & 0xFF;
                    int g = (argb >> 8) & 0xFF;
                    int b = argb & 0xFF;
                    beforeBrightness += (r + g + b) / 3.0;
                }
                beforeBrightness /= beforePixels.Length;

                var motionKernel = ConvolutionFilter.GetBlurMotion(9, 180);
                var options = new ConvolutionFilterOptions(motionKernel);
                raster.Filter(raster.Bounds, options);

                int[] afterPixels = raster.LoadArgb32Pixels(raster.Bounds);
                double afterBrightness = 0;
                foreach (int argb in afterPixels)
                {
                    int r = (argb >> 16) & 0xFF;
                    int g = (argb >> 8) & 0xFF;
                    int b = argb & 0xFF;
                    afterBrightness += (r + g + b) / 3.0;
                }
                afterBrightness /= afterPixels.Length;

                double diff = Math.Abs(afterBrightness - beforeBrightness);
                if (diff > 1.0)
                {
                    Console.WriteLine("Brightness changed.");
                }
                else
                {
                    Console.WriteLine("Brightness unchanged.");
                }

                var saveOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                raster.Save(outputPath, saveOptions);
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
 * 1. When you need to add a horizontal motion blur effect to a PNG image while ensuring the overall brightness stays the same for consistent visual appearance.
 * 2. When you want to preprocess product photos by simulating camera shake without altering their exposure levels before uploading to an e‑commerce site.
 * 3. When you are building a test suite that validates that a convolution filter does not unintentionally brighten or darken images.
 * 4. When you create animated GIF frames by blurring each PNG frame uniformly and need to confirm brightness uniformity across frames.
 * 5. When you develop a desktop utility that lets users apply a 9‑pixel motion blur to screenshots and you must guarantee the resulting image is not overly bright or dim.
 */
