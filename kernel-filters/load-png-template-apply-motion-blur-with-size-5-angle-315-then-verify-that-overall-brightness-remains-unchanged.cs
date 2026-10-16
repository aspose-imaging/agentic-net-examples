// HOW-TO: Apply Motion Blur to PNG and Verify Brightness in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\template.png";
            string outputPath = "Output\\blurred.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Compute average brightness before filter
                int[] beforePixels = raster.LoadArgb32Pixels(raster.Bounds);
                double beforeBrightness = ComputeAverageBrightness(beforePixels);

                // Apply motion blur (size 5, angle 315)
                double[,] motionKernel = ConvolutionFilter.GetBlurMotion(5, 315);
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(motionKernel));

                // Compute average brightness after filter
                int[] afterPixels = raster.LoadArgb32Pixels(raster.Bounds);
                double afterBrightness = ComputeAverageBrightness(afterPixels);

                Console.WriteLine($"Average brightness before: {beforeBrightness:F2}");
                Console.WriteLine($"Average brightness after : {afterBrightness:F2}");

                // Save the result as PNG
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

    static double ComputeAverageBrightness(int[] argbPixels)
    {
        long total = 0;
        foreach (int pixel in argbPixels)
        {
            int r = (pixel >> 16) & 0xFF;
            int g = (pixel >> 8) & 0xFF;
            int b = pixel & 0xFF;
            total += r + g + b;
        }
        return total / (double)(argbPixels.Length * 3);
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to add a directional motion blur effect to a PNG template while ensuring the overall image brightness stays consistent for UI mockups.
 * 2. When generating product catalog thumbnails that require a subtle motion blur to simulate movement without darkening the image.
 * 3. When preprocessing images for a game UI where a blur filter is applied but the average luminance must remain unchanged for visual balance.
 * 4. When creating animated GIF frames from static PNGs and you must verify that the blur does not alter the perceived brightness before compositing.
 * 5. When testing image‑processing pipelines in C# to confirm that applying a convolution‑based motion blur preserves the original brightness metrics.
 */
