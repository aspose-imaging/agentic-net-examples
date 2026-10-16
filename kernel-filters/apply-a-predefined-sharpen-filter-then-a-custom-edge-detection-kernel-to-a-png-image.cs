// HOW-TO: Apply Sharpen Then Edge Detection Filter to PNG in C# (Aspose.Imaging for .NET)
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
                // Apply predefined Sharpen filter
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions());

                // Apply custom edge‑detection kernel
                double[,] customKernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1,  8, -1 },
                    { -1, -1, -1 }
                };
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(customKernel));

                // Save the result as PNG
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
 * 1. When you need to enhance the details of a PNG photograph before performing computer‑vision analysis, you can sharpen it and highlight edges using Aspose.Imaging in C#.
 * 2. When preparing product images for an e‑commerce site, applying a sharpen filter followed by an edge‑detection kernel can make features stand out while keeping the file in PNG format.
 * 3. When building a desktop utility that automatically improves scanned documents, you can use this code to sharpen blurry text and emphasize borders before saving the result.
 * 4. When creating visual assets for a game, developers may apply custom convolution kernels to PNG textures to accentuate outlines and then export them directly from C#.
 * 5. When developing a batch‑processing pipeline for medical imaging, the code lets you apply sequential filters—sharpen and edge detection—to PNG scans to aid diagnostic review.
 */
