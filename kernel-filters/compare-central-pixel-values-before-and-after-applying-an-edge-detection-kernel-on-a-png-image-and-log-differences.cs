// HOW-TO: Compare Center Pixel Values Before and After Edge Detection in C# (Aspose.Imaging for .NET)
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

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                int centerX = raster.Width / 2;
                int centerY = raster.Height / 2;

                int[] before = raster.LoadArgb32Pixels(new Rectangle(centerX, centerY, 1, 1));

                double[,] edgeKernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1, 8, -1 },
                    { -1, -1, -1 }
                };

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(edgeKernel);
                raster.Filter(raster.Bounds, filterOptions);

                int[] after = raster.LoadArgb32Pixels(new Rectangle(centerX, centerY, 1, 1));

                int beforeVal = before[0];
                int afterVal = after[0];
                int diff = beforeVal - afterVal;

                Console.WriteLine($"Center pixel before: 0x{beforeVal:X8}");
                Console.WriteLine($"Center pixel after: 0x{afterVal:X8}");
                Console.WriteLine($"Difference (before - after): {diff}");

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
 * 1. When you need to verify how an edge‑detection filter changes the exact color of a specific pixel in a PNG image during automated quality checks.
 * 2. When building a diagnostic tool that logs pixel‑level differences to detect processing errors after applying convolution kernels in C#.
 * 3. When creating a before‑and‑after visual comparison for a computer‑vision pipeline that uses Aspose.Imaging to ensure edge detection is applied correctly.
 * 4. When developing a batch script that processes images, applies an edge filter, and records the central pixel change to monitor consistency across large datasets.
 * 5. When troubleshooting image‑processing algorithms by isolating the effect of a custom kernel on a known pixel location and saving the resulting image for review.
 */
