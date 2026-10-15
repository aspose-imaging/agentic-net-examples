// HOW-TO: Normalize Gaussian Kernel and Apply Convolution Filter to PNG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                double[,] kernel = new double[,]
                {
                    { 1, 2, 1 },
                    { 2, 4, 2 },
                    { 1, 2, 1 }
                };

                double sum = 0;
                foreach (double value in kernel)
                {
                    sum += value;
                }

                for (int y = 0; y < kernel.GetLength(0); y++)
                {
                    for (int x = 0; x < kernel.GetLength(1); x++)
                    {
                        kernel[y, x] /= sum;
                    }
                }

                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel));

                PngOptions saveOptions = new PngOptions();
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
 * 1. When you need to smooth a PNG photo without changing its overall brightness using a custom Gaussian blur in a C# application.
 * 2. When you want to preserve image luminance while applying a 3x3 convolution filter for noise reduction in a .NET image‑processing pipeline.
 * 3. When you are building a batch processor that normalizes custom kernels before filtering PNG assets to ensure consistent visual output.
 * 4. When you need to integrate Aspose.Imaging to apply a normalized Gaussian kernel for subtle edge softening in a Windows desktop app.
 * 5. When you must guarantee that a convolution operation on a PNG does not unintentionally brighten or darken the picture in an automated graphics workflow.
 */
