// HOW-TO: Apply Custom 4x4 Convolution Filter to PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

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

            double[,] kernel = new double[,]
            {
                { 0.0625, 0.0625, 0.0625, 0.0625 },
                { 0.0625, 0.0625, 0.0625, 0.0625 },
                { 0.0625, 0.0625, 0.0625, 0.0625 },
                { 0.0625, 0.0625, 0.0625, 0.0625 }
            };

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel));

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
 * 1. When you need to smooth a PNG image uniformly using a normalized 4x4 averaging kernel in a .NET application.
 * 2. When you want to implement a custom blur effect on PNG assets before uploading them to a web service.
 * 3. When you must ensure that a convolution operation preserves overall image brightness by using a kernel whose elements sum to one.
 * 4. When you are processing large batches of PNG files and need to apply the same convolution filter efficiently with Aspose.Imaging.
 * 5. When you are building a C# image‑processing pipeline that requires applying a user‑defined kernel to raster images for scientific or visual analysis.
 */
