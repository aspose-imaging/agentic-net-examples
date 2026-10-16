// HOW-TO: Measure Image Brightness Before and After Custom Gaussian Blur in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

                int[] beforePixels = raster.LoadArgb32Pixels(raster.Bounds);
                double beforeBrightness = ComputeAverageBrightness(beforePixels);
                Console.WriteLine($"Average brightness before: {beforeBrightness:F4}");

                double[,] customKernel = new double[,]
                {
                    { 0.0625, 0.125, 0.0625 },
                    { 0.125,  0.25,  0.125 },
                    { 0.0625, 0.125, 0.0625 }
                };

                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(customKernel));

                int[] afterPixels = raster.LoadArgb32Pixels(raster.Bounds);
                double afterBrightness = ComputeAverageBrightness(afterPixels);
                Console.WriteLine($"Average brightness after: {afterBrightness:F4}");

                var jpegOptions = new JpegOptions();
                image.Save(outputPath, jpegOptions);
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
            total += (r + g + b) / 3;
        }
        return (double)total / argbPixels.Length;
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to verify that applying a custom Gaussian blur does not unintentionally darken or brighten JPEG photos in an automated editing workflow.
 * 2. When building a quality‑control step that logs average luminance before and after smoothing to ensure consistent visual output across a batch of images.
 * 3. When developing a machine‑vision preprocessing pipeline that requires brightness monitoring to maintain reliable detection after applying a convolution filter.
 * 4. When preparing medical or scientific images for analysis and must confirm that a custom kernel preserves overall brightness while reducing noise.
 * 5. When creating an artistic effect with a custom kernel and want to compare pre‑ and post‑filter brightness to fine‑tune the visual impact.
 */
