// HOW-TO: Apply Gaussian Blur to PNG Image Using Convolution Filter in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageFilters.FilterOptions;

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
                double[,] kernel = new double[,]
                {
                    { 0.0625, 0.125, 0.0625 },
                    { 0.125,  0.25,  0.125 },
                    { 0.0625, 0.125, 0.0625 }
                };

                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

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
 * 1. When you need to soften edges of a product photo before uploading it to an e‑commerce site, you can use this code to apply a Gaussian blur to a PNG file.
 * 2. When creating a thumbnail gallery that requires a subtle blur effect to reduce visual noise, the snippet shows how to process PNG images with Aspose.Imaging in C#.
 * 3. When preparing images for a machine‑learning dataset and want to augment data by blurring, this example demonstrates applying a convolution kernel to PNG raster images.
 * 4. When building a desktop application that lets users apply filters to their screenshots, you can use the code to implement a Gaussian blur filter on PNG files.
 * 5. When automating a batch job that needs to anonymize faces in PNG images by blurring them, the sample shows how to apply a Gaussian kernel with ConvolutionFilterOptions in C#.
 */
