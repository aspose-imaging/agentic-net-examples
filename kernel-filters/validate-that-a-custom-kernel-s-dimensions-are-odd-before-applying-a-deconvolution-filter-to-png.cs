// HOW-TO: Validate Odd Kernel Size Before Deconvolution Filter on PNG in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            double[,] kernel = new double[,]
            {
                { 1, 2, 1 },
                { 2, 4, 2 },
                { 1, 2, 1 }
            };

            int rows = kernel.GetLength(0);
            int cols = kernel.GetLength(1);
            if (rows % 2 == 0 || cols % 2 == 0)
            {
                Console.Error.WriteLine("Kernel dimensions must be odd.");
                return;
            }

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                var deconvOptions = new DeconvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, deconvOptions);

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
 * 1. When you need to sharpen a PNG image using a custom kernel and must ensure the kernel dimensions are odd to prevent runtime errors.
 * 2. When processing medical or scientific PNG scans with a deconvolution filter and you want to programmatically validate the kernel shape.
 * 3. When building an automated image‑processing pipeline that applies custom deconvolution to PNG files and must guard against invalid even‑sized kernels.
 * 4. When creating a desktop C# application that lets users upload PNGs and apply custom filters, you need to check kernel dimensions before applying the filter.
 * 5. When integrating Aspose.Imaging into a server‑side service that enhances PNG graphics with deconvolution, you must verify the kernel is odd to comply with the library’s requirements.
 */
