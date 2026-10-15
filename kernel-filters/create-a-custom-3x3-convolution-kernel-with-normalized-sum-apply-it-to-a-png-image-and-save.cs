// HOW-TO: Apply Custom Normalized 3x3 Convolution Filter to PNG in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            double[,] customKernel = new double[,]
            {
                { 0.0625, 0.125, 0.0625 },
                { 0.125, 0.25, 0.125 },
                { 0.0625, 0.125, 0.0625 }
            };

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

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
 * 1. When you need to blur a PNG image with a Gaussian‑like kernel in a C# application.
 * 2. When you want to implement a custom sharpening or edge‑detection filter by defining your own 3×3 matrix.
 * 3. When processing scanned documents and you need to reduce noise before OCR by applying a normalized convolution.
 * 4. When creating thumbnails and you want to smooth the image uniformly without changing its dimensions.
 * 5. When building a graphics pipeline that requires applying the same convolution filter to multiple PNG files programmatically.
 */
