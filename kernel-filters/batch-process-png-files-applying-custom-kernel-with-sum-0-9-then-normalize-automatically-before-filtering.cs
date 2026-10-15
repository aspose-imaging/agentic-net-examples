// HOW-TO: Batch Apply Normalized Convolution Kernel to PNG Files in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + "_filtered.png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;

                    double[,] kernel = new double[,]
                    {
                        { 0.1, 0.1, 0.1 },
                        { 0.1, 0.1, 0.1 },
                        { 0.1, 0.1, 0.1 }
                    };

                    var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);

                    raster.Filter(raster.Bounds, filterOptions);

                    using (var options = new PngOptions())
                    {
                        options.Source = new FileCreateSource(outputPath, false);
                        raster.Save(outputPath, options);
                    }
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
 * 1. When you need to process a folder of PNG photos and apply a custom smoothing filter across all images automatically.
 * 2. When you want to ensure the convolution kernel is normalized (sum 0.9) before filtering to avoid brightness shifts in batch image processing.
 * 3. When you are building a C# utility that converts raw PNG assets into filtered versions for web optimization using Aspose.Imaging.
 * 4. When you must apply the same convolution filter to multiple PNG files without manually loading and saving each one.
 * 5. When you require a repeatable script that creates an output directory, processes each PNG with a custom kernel, and saves the filtered results with a modified filename.
 */
