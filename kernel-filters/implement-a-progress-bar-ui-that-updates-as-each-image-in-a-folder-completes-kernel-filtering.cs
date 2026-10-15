// HOW-TO: Apply Custom Convolution Filter to Images with Progress Bar in C# (Aspose.Imaging for .NET)
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

            Directory.CreateDirectory(outputFolder);

            var files = Directory.GetFiles(inputFolder);
            int total = files.Length;
            int processed = 0;

            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                using (var image = Aspose.Imaging.Image.Load(inputPath))
                {
                    var raster = image as Aspose.Imaging.RasterImage;
                    if (raster == null)
                    {
                        continue;
                    }

                    double[,] kernel = new double[,]
                    {
                        { -2, -1, 0 },
                        { -1, 1, 1 },
                        { 0, 1, 2 }
                    };

                    var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                    raster.Filter(raster.Bounds, filterOptions);

                    string fileName = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputFolder, fileName + "_filtered.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    var pngOptions = new PngOptions();
                    raster.Save(outputPath, pngOptions);
                }

                processed++;
                Console.Write($"\rProcessed {processed}/{total} images.");
            }

            Console.WriteLine("\nDone.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to batch‑process a folder of photos applying a custom convolution kernel and monitor the operation with a console progress indicator.
 * 2. When you want to convert various raster images to filtered PNG files for further analysis or web publishing.
 * 3. When you must integrate Aspose.Imaging’s convolution filter into an automated pipeline that reports how many images have been processed.
 * 4. When you require a simple C# utility to apply edge‑enhancement or sharpening effects to all images in a directory and track completion.
 * 5. When you are building a command‑line tool that validates each file, applies a custom kernel, saves the result, and provides real‑time feedback to the user.
 */
