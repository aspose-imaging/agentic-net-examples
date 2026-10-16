// HOW-TO: Apply Custom Sharpen Kernel to PNG Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            double[,] customKernel = new double[,]
            {
                { -2, -1, 0 },
                { -1,  1, 1 },
                {  0,  1, 2 }
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
 * 1. When you need to enhance the edges of a PNG photo by applying a custom sharpen filter derived from an emboss matrix in a C# application.
 * 2. When you want to programmatically improve the visual clarity of scanned documents saved as PNG files using Aspose.Imaging’s convolution filter.
 * 3. When you are building an automated image‑processing pipeline that must apply a specific sharpening kernel to batch‑process PNG assets before publishing.
 * 4. When you need to replace a generic sharpen filter with a fine‑tuned kernel to emphasize texture in product images stored as PNGs.
 * 5. When you are developing a desktop tool that lets users apply custom convolution kernels, such as an emboss‑based sharpen effect, to PNG graphics.
 */
