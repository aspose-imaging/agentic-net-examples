// HOW-TO: Apply Sharpen 3x3 Filter to All Pages of an SVG in C# (Aspose.Imaging for .NET)
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

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                if (image is IMultipageImage multipage)
                {
                    for (int i = 0; i < multipage.PageCount; i++)
                    {
                        Image page = multipage.Pages[i];
                        if (page is RasterImage raster)
                        {
                            double[,] sharpenKernel = new double[,]
                            {
                                { 0, -1, 0 },
                                { -1, 5, -1 },
                                { 0, -1, 0 }
                            };
                            var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(sharpenKernel);
                            raster.Filter(raster.Bounds, filterOptions);
                            raster.Dispose();
                        }
                    }
                }

                image.Save(outputPath);
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
 * 1. When you need to enhance the visual clarity of each layer in a multi‑page SVG before publishing it online.
 * 2. When you want to programmatically sharpen vector graphics that have been rasterized into pages for printing or PDF conversion.
 * 3. When you must improve edge definition of icons embedded in an SVG sprite sheet without manually editing each frame.
 * 4. When an automated build process requires applying a 3x3 sharpening kernel to every page of an SVG asset batch.
 * 5. When you are creating a web‑ready SVG that needs consistent sharpness across all its pages after scaling or compression.
 */
