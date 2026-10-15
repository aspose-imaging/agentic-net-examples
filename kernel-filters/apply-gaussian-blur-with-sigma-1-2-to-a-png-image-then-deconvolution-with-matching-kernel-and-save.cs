// HOW-TO: Apply Gaussian Blur and Deconvolution to PNG in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                // Gaussian blur kernel
                double[,] gaussianKernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetGaussian(3, 1.2);
                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(gaussianKernel);
                raster.Filter(raster.Bounds, blurOptions);

                // Deconvolution with the same kernel
                var deconvOptions = new Aspose.Imaging.ImageFilters.FilterOptions.DeconvolutionFilterOptions(gaussianKernel);
                raster.Filter(raster.Bounds, deconvOptions);

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
 * 1. When you need to reduce noise in a PNG photograph before analysis by applying a Gaussian blur with a specific sigma.
 * 2. When you want to restore the original sharpness of a blurred PNG by performing deconvolution with the same kernel.
 * 3. When you are building an automated C# pipeline that preprocesses scanned documents, blurs them to hide sensitive details, then reverses the blur for quality checks.
 * 4. When you need to demonstrate image processing concepts such as convolution and deconvolution in a .NET tutorial using Aspose.Imaging.
 * 5. When you are creating a batch job that processes PNG assets, applies a controlled blur for artistic effect, and then attempts to recover details to compare before‑and‑after results.
 */
