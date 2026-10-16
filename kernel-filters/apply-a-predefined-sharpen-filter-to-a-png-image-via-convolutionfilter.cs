// HOW-TO: Apply Sharpen Convolution Filter to PNG Image Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input/input.png";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            double[,] customKernel = new double[,]
            {
                {  0, -1,  0 },
                { -1,  5, -1 },
                {  0, -1,  0 },
            };

            using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(customKernel));

                PngOptions options = new PngOptions();
                options.Source = new FileCreateSource(outputPath, false);
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
 * 1. When you need to programmatically sharpen a PNG product photo before publishing it on an e‑commerce website.
 * 2. When you want to improve the readability of scanned PNG documents by enhancing edges for better OCR results.
 * 3. When you are building a batch‑processing tool that automatically applies a sharpen filter to PNG assets used in a game UI.
 * 4. When you must enhance edge definition in medical imaging PNG files by applying a custom convolution kernel.
 * 5. When you create a server‑side service that receives PNG uploads and returns a sharpened version for higher visual quality.
 */
