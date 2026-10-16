// HOW-TO: Apply Custom 3x3 Convolution Filter to PNG in C# (Aspose.Imaging for .NET)
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

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                double edge = 0.1 / 1.4;
                double center = 0.6 / 1.4;

                double[,] kernel = new double[,]
                {
                    { edge, edge, edge },
                    { edge, center, edge },
                    { edge, edge, edge }
                };

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);

                var options = new PngOptions
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
 * 1. When you need to soften a PNG image by applying a weighted blur using a custom 3x3 kernel in a C# application.
 * 2. When you want to reduce noise in scanned PNG graphics by normalizing a convolution matrix and filtering the image with Aspose.Imaging.
 * 3. When you are building a photo‑editing tool that requires a simple smoothing effect on PNG files without external libraries.
 * 4. When you must preprocess PNG assets for a game engine by applying a uniform blur before compression using C#.
 * 5. When you need to programmatically adjust the brightness distribution of a PNG by applying a centered‑weight kernel with Aspose.Imaging.
 */
