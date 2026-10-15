// HOW-TO: Measure Execution Time of Median and Gauss Wiener Filters in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "input";
            string outputFolder = "output";

            if (!Directory.Exists(inputFolder))
            {
                Console.Error.WriteLine($"Input folder not found: {inputFolder}");
                return;
            }

            string[] files = Directory.GetFiles(inputFolder);
            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Median Filter
                using (var image = Aspose.Imaging.Image.Load(inputPath))
                {
                    var raster = image as Aspose.Imaging.RasterImage;
                    if (raster == null) continue;

                    var sw = new System.Diagnostics.Stopwatch();
                    sw.Start();
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));
                    sw.Stop();

                    Console.WriteLine($"Median filter applied to {Path.GetFileName(inputPath)} in {sw.ElapsedMilliseconds} ms.");

                    string outputPath = Path.Combine(outputFolder, $"{Path.GetFileNameWithoutExtension(inputPath)}_median.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    raster.Save(outputPath, new PngOptions());
                }

                // Gauss Wiener Filter
                using (var image = Aspose.Imaging.Image.Load(inputPath))
                {
                    var raster = image as Aspose.Imaging.RasterImage;
                    if (raster == null) continue;

                    var sw = new System.Diagnostics.Stopwatch();
                    sw.Start();
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussWienerFilterOptions(3, 1.0));
                    sw.Stop();

                    Console.WriteLine($"Gauss Wiener filter applied to {Path.GetFileName(inputPath)} in {sw.ElapsedMilliseconds} ms.");

                    string outputPath = Path.Combine(outputFolder, $"{Path.GetFileNameWithoutExtension(inputPath)}_gausswiener.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    raster.Save(outputPath, new PngOptions());
                }

                // Bilateral Smoothing Filter
                using (var image = Aspose.Imaging.Image.Load(inputPath))
                {
                    var raster = image as Aspose.Imaging.RasterImage;
                    if (raster == null) continue;

                    var sw = new System.Diagnostics.Stopwatch();
                    sw.Start();
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.BilateralSmoothingFilterOptions());
                    sw.Stop();

                    Console.WriteLine($"Bilateral smoothing filter applied to {Path.GetFileName(inputPath)} in {sw.ElapsedMilliseconds} ms.");

                    string outputPath = Path.Combine(outputFolder, $"{Path.GetFileNameWithoutExtension(inputPath)}_bilateral.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    raster.Save(outputPath, new PngOptions());
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
 * 1. When you need to profile how long a median filter takes on a large set of PNG or JPEG files before optimizing image‑processing pipelines.
 * 2. When you want to compare the performance of different noise‑reduction filters, such as median and Gauss‑Wiener, on a batch of raster images using Aspose.Imaging for .NET.
 * 3. When you are building an automated quality‑control tool that logs the processing time of each filter to identify bottlenecks in a production workflow.
 * 4. When you must generate filtered versions of images and record the elapsed milliseconds for each operation to meet SLA or reporting requirements.
 * 5. When you are debugging or tuning image‑enhancement code and need precise timing data for each filter applied to files in an input folder.
 */
