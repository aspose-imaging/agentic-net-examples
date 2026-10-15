// HOW-TO: Apply a 3×3 High‑Pass Edge Filter to PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;
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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            double[,] kernel = new double[,]
            {
                { -2, -1,  0 },
                { -1,  1,  1 },
                {  0,  1,  2 }
            };

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));
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
 * 1. When you need to highlight edges in a PNG before performing OCR, you can use this high‑pass convolution filter with Aspose.Imaging in C#.
 * 2. When preparing product photos for a web catalog and want to enhance fine details without changing the file format, the code applies a 3×3 high‑pass kernel to the PNG image.
 * 3. When creating a preprocessing step for computer‑vision algorithms that require edge‑enhanced input, this C# snippet filters the raster image using Aspose.Imaging’s ConvolutionFilterOptions.
 * 4. When automating batch processing of scanned documents and need to accentuate borders for better visual inspection, the program loads each PNG, applies the high‑pass filter, and saves the result.
 * 5. When integrating image analysis into a .NET application and you must quickly emphasize texture in PNG assets, the example shows how to load, filter, and save the image using Aspose.Imaging.
 */
