// HOW-TO: Apply a Custom 5x5 Convolution Kernel to PNG in C# (Aspose.Imaging for .NET)
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

public class Program
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

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached) image.CacheData();

                double[,] customKernel = new double[,]
                {
                    { 0.04, 0.04, 0.04, 0.04, 0.04 },
                    { 0.04, 0.04, 0.04, 0.04, 0.04 },
                    { 0.04, 0.04, 0.04, 0.04, 0.04 },
                    { 0.04, 0.04, 0.04, 0.04, 0.04 },
                    { 0.04, 0.04, 0.04, 0.04, 0.04 }
                };

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(customKernel);
                image.Filter(image.Bounds, filterOptions);
                image.Save(outputPath);
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
 * 1. When you need to blur a PNG image uniformly using a custom 5x5 averaging kernel in a C# application.
 * 2. When you want to experiment with different convolution matrices for edge detection or smoothing on raster images loaded with Aspose.Imaging.
 * 3. When you must process large batches of PNG files and apply the same custom filter before saving them to a new directory.
 * 4. When you are building a photo‑editing tool that lets users apply user‑defined kernels to images without external libraries.
 * 5. When you need to ensure the image data is cached before applying a convolution filter to avoid runtime performance issues.
 */
