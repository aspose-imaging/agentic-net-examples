// HOW-TO: Apply Motion Blur to Multiple PNG Images in C# with Aspose.Imaging (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "InputPngs";
            string outputDirectory = "OutputPngs";

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
                    return;
                }

                string fileName = Path.GetFileName(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage raster = (RasterImage)Image.Load(inputPath))
                {
                    double[,] kernel = ConvolutionFilter.GetBlurMotion(3, 45);
                    var filterOptions = new ConvolutionFilterOptions(kernel);
                    raster.Filter(raster.Bounds, filterOptions);

                    var saveOptions = new PngOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
                    };
                    raster.Save(outputPath, saveOptions);
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
 * 1. When you need to add a consistent motion‑blur effect to a whole folder of product photos before uploading them to an e‑commerce site.
 * 2. When you want to automatically preprocess scanned PNG documents by simulating camera movement for visual testing of image‑analysis algorithms.
 * 3. When you have a collection of game sprites in PNG format and must apply the same blur angle and size to create a motion‑trail animation effect.
 * 4. When a desktop application must generate blurred thumbnails for a large set of PNG images without manually editing each file.
 * 5. When you are building a batch image‑conversion pipeline that applies a 3‑pixel, 45‑degree motion blur to PNG assets for a marketing campaign.
 */
