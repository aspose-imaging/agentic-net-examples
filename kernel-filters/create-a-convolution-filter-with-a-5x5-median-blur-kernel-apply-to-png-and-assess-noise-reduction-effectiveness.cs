// HOW-TO: Apply 5x5 Blur Convolution Filter to PNG with Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-14
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
        try
        {
            string inputPath = "input.png";
            string outputPath = "output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            double[,] customKernel = new double[,]
            {
                { 0.04, 0.04, 0.04, 0.04, 0.04 },
                { 0.04, 0.04, 0.04, 0.04, 0.04 },
                { 0.04, 0.04, 0.04, 0.04, 0.04 },
                { 0.04, 0.04, 0.04, 0.04, 0.04 },
                { 0.04, 0.04, 0.04, 0.04, 0.04 }
            };

            using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(customKernel));

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
 * 1. When you need to reduce high‑frequency noise in a PNG before further analysis, you can apply a 5×5 convolution blur with Aspose.Imaging in C#.
 * 2. When preparing screenshots for a web report and want to smooth edges without changing the file format, this code blurs the PNG while preserving transparency.
 * 3. When building an automated image‑preprocessing pipeline that must uniformly soften images stored as PNG, you can use the convolution filter to standardize visual quality.
 * 4. When creating a desktop application that lets users clean up scanned documents saved as PNG, the 5×5 blur helps diminish speckles and grain.
 * 5. When testing different noise‑reduction techniques, you can quickly compare the effect of a simple convolution kernel on PNG files using Aspose.Imaging’s Filter method.
 */
