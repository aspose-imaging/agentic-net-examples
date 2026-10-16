// HOW-TO: Batch Apply Emboss5x5 Filter to PNG Images in C# (Aspose.Imaging for .NET)
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
            string inputDirectory = "Input";
            string outputDirectory = "Output";

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
            foreach (string filePath in files)
            {
                string outputPath = Path.Combine(outputDirectory, Path.GetFileName(filePath));
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    continue;
                }

                using (RasterImage raster = (RasterImage)Image.Load(filePath))
                {
                    var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss5x5);
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
 * 1. When you need to automatically add an emboss effect to a large collection of PNG files for a product catalog.
 * 2. When you want to preprocess scanned PNG graphics with a 5x5 emboss convolution before uploading to a web gallery.
 * 3. When you are building a C# batch image pipeline that applies the predefined Emboss5x5 filter to every PNG in a folder.
 * 4. When you must generate stylized PNG assets for a game UI by applying a uniform emboss filter without manual editing.
 * 5. When you require a simple C# script to read PNG images, apply a convolution filter, and save the results to a separate output directory.
 */
