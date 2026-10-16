// HOW-TO: How to Apply Emboss Filter to JPEG and Log Processing Time in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input/sample.jpg";
        string outputPath = "output/filtered.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (var image = Image.Load(inputPath))
            {
                var raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                double[,] embossKernel = new double[,]
                {
                    { -2, -1, 0 },
                    { -1, 1, 1 },
                    { 0, 1, 2 }
                };
                string kernelType = "Emboss";

                var stopwatch = new System.Diagnostics.Stopwatch();
                stopwatch.Start();

                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(embossKernel));

                stopwatch.Stop();

                Console.WriteLine($"Applied {kernelType} filter in {stopwatch.ElapsedMilliseconds} ms.");

                raster.Save(outputPath, new JpegOptions());
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
 * 1. When you need to add a 3‑D emboss effect to user‑uploaded JPEG photos in a C# web application while measuring how long the filter takes.
 * 2. When you want to benchmark different convolution kernels on raster images using Aspose.Imaging to choose the fastest for real‑time processing.
 * 3. When you are converting scanned documents to JPEG and need to highlight edges with an emboss filter for better visual inspection.
 * 4. When you are building an automated image‑processing pipeline that logs each filter’s execution time for performance monitoring.
 * 5. When you need to ensure a JPEG image is a raster type before applying custom kernel operations to avoid runtime errors.
 */
