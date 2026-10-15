// HOW-TO: Apply Emboss Convolution Filter to PNG and Save in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input\\input.png";
        string outputPath = "output\\output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                double[,] embossKernel = new double[,]
                {
                    { -2, -1, 0 },
                    { -1, 1, 1 },
                    { 0, 1, 2 }
                };

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(embossKernel);
                raster.Filter(raster.Bounds, filterOptions);

                var pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                raster.Save(outputPath, pngOptions);
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
 * 1. When you need to add an emboss effect to a PNG image using Aspose.Imaging in a C# application.
 * 2. When you want to apply a custom 3×3 convolution kernel to enhance the depth of a PNG before publishing it on a website.
 * 3. When an automated .NET workflow must load a PNG, filter it, and save the processed image without changing its size or format.
 * 4. When you are building a server‑side image processing service that applies artistic filters to user‑uploaded PNG files.
 * 5. When you are testing how Aspose.Imaging processes convolution filters on interlaced PNG files in a C# project.
 */
