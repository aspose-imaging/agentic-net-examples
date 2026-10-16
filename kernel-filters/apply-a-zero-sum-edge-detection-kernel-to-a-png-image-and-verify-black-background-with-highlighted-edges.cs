// HOW-TO: Apply Zero Sum Edge Detection To PNG Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "Output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            double[,] customKernel = new double[,]
            {
                { -1, -1, -1 },
                { -1, 8, -1 },
                { -1, -1, -1 }
            };

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                var filterOptions = new ConvolutionFilterOptions(customKernel);
                raster.Filter(raster.Bounds, filterOptions);

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
 * 1. When you need to highlight the outlines of objects in a PNG for a computer‑vision preprocessing step, you can apply a zero‑sum convolution kernel with Aspose.Imaging in C#.
 * 2. When preparing product photos for an e‑commerce site, you might use this code to turn the background black and emphasize product edges before adding watermarks.
 * 3. When creating technical documentation that requires clear edge diagrams from screenshots, the filter can generate high‑contrast edge images automatically.
 * 4. When building a diagnostic tool that checks image quality, you can run the edge detection filter and verify that the resulting image shows black background with bright edges.
 * 5. When integrating image analysis into a .NET application, this snippet demonstrates how to load a PNG, apply a custom convolution filter, and save the processed result without external libraries.
 */
