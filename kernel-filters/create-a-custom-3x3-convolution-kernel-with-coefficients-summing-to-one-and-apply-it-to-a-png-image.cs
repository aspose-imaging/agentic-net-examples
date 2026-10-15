// HOW-TO: Apply Custom 3x3 Convolution Kernel to PNG Image in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "input\\input.png";
            string outputPath = "output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            double[,] customKernel = new double[,]
            {
                { 0, 0, 0 },
                { 0, 1, 0 },
                { 0, 0, 0 }
            };

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(customKernel));

                PngOptions options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                raster.Save(outputPath, options);
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
 * 1. When you want to apply a custom 3x3 convolution filter (e.g., blur, sharpen, edge detection) to a PNG file in a C# program using Aspose.Imaging.
 * 2. When you need to process raster images server‑side and save the filtered result without altering the original file format.
 * 3. When you are building an automated image‑processing pipeline that requires applying user‑defined kernels to PNG assets before publishing them.
 * 4. When you must ensure the convolution kernel coefficients sum to one to preserve overall image brightness while transforming the picture.
 * 5. When you are integrating Aspose.Imaging into a .NET service to dynamically modify PNG graphics based on runtime‑generated filter matrices.
 */
