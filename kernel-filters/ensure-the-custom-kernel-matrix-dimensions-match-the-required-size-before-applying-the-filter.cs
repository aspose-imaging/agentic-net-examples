// HOW-TO: Apply a 5x5 Custom Convolution Filter to JPEG in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image img = Image.Load(inputPath))
            {
                RasterImage raster = img as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                if (!raster.IsCached)
                    raster.CacheData();

                double[,] customKernel = new double[,]
                {
                    { 0.04, 0.04, 0.04, 0.04, 0.04 },
                    { 0.04, 0.04, 0.04, 0.04, 0.04 },
                    { 0.04, 0.04, 0.04, 0.04, 0.04 },
                    { 0.04, 0.04, 0.04, 0.04, 0.04 },
                    { 0.04, 0.04, 0.04, 0.04, 0.04 }
                };

                if (customKernel.GetLength(0) != 5 || customKernel.GetLength(1) != 5)
                {
                    Console.Error.WriteLine("Kernel size must be 5x5.");
                    return;
                }

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(customKernel);
                raster.Filter(raster.Bounds, filterOptions);
                raster.Save(outputPath);
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
 * 1. When you need to blur a JPEG image using a custom 5x5 kernel in a C# application.
 * 2. When you must ensure a convolution matrix matches the required dimensions before applying it to a raster image.
 * 3. When preprocessing photos for computer‑vision algorithms that require uniform smoothing across the entire image.
 * 4. When converting raw image data to a cached raster format to safely apply filters without altering the original file.
 * 5. When automating batch processing that validates input files, applies a custom filter, and saves the result as a new JPEG.
 */
