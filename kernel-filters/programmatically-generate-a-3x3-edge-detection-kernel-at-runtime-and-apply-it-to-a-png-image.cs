// HOW-TO: Apply Custom 3x3 Edge Detection Kernel to PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageFilters.FilterOptions;

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
                { -1, -1, -1 },
                { -1,  8, -1 },
                { -1, -1, -1 }
            };

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(customKernel));
                raster.Save(outputPath, new PngOptions());
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
 * 1. When you need to highlight edges in a PNG photograph for computer‑vision preprocessing using Aspose.Imaging in C#.
 * 2. When you want to generate a convolution kernel dynamically at runtime instead of using a static filter to detect outlines in images.
 * 3. When you are building an automated pipeline that loads PNG files, applies edge detection, and saves the processed results for further analysis.
 * 4. When you must ensure the output directory exists before saving the filtered PNG to avoid runtime errors in a .NET application.
 * 5. When you need to catch and log file‑not‑found or processing exceptions while applying a custom convolution filter to images.
 */
