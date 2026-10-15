// HOW-TO: Compare PNG Histogram Before and After Sharpen Filter in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output/output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                int width = raster.Width;
                int height = raster.Height;
                Rectangle bounds = new Rectangle(0, 0, width, height);

                int[] originalPixels = raster.LoadArgb32Pixels(bounds);
                int[] originalHist = new int[256];
                foreach (int pixel in originalPixels)
                {
                    int r = (pixel >> 16) & 0xFF;
                    int g = (pixel >> 8) & 0xFF;
                    int b = pixel & 0xFF;
                    int intensity = (r + g + b) / 3;
                    originalHist[intensity]++;
                }

                double[,] sharpenKernel = new double[,]
                {
                    {  0, -1,  0 },
                    { -1,  5, -1 },
                    {  0, -1,  0 }
                };
                var filterOptions = new ConvolutionFilterOptions(sharpenKernel);
                raster.Filter(bounds, filterOptions);

                var saveOptions = new PngOptions();
                raster.Save(outputPath, saveOptions);

                int[] processedPixels = raster.LoadArgb32Pixels(bounds);
                int[] processedHist = new int[256];
                foreach (int pixel in processedPixels)
                {
                    int r = (pixel >> 16) & 0xFF;
                    int g = (pixel >> 8) & 0xFF;
                    int b = pixel & 0xFF;
                    int intensity = (r + g + b) / 3;
                    processedHist[intensity]++;
                }

                Console.WriteLine("Original Histogram:");
                for (int i = 0; i < 256; i++)
                {
                    Console.WriteLine($"{i}: {originalHist[i]}");
                }

                Console.WriteLine("Processed Histogram:");
                for (int i = 0; i < 256; i++)
                {
                    Console.WriteLine($"{i}: {processedHist[i]}");
                }
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
 * 1. When you need to evaluate how a sharpening filter affects the brightness distribution of a PNG image for quality control.
 * 2. When building an automated pipeline that sharpens scanned photos and verifies the change by comparing pre‑ and post‑filter histograms.
 * 3. When creating a diagnostic tool in C# that logs intensity histogram shifts after applying a convolution filter to detect over‑sharpening.
 * 4. When generating side‑by‑side comparisons of original and processed PNGs to demonstrate the visual impact of a 3×3 sharpen kernel.
 * 5. When performing batch image enhancement with Aspose.Imaging and need to ensure each file’s histogram stays within acceptable limits after processing.
 */
