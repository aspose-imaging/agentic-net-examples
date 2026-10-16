// HOW-TO: Increase Edge Enhancement on PNG Using Custom Emboss 3x3 Kernel in C# (Aspose.Imaging for .NET)
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

            string outputDir = Path.GetDirectoryName(outputPath);
            if (string.IsNullOrEmpty(outputDir))
                outputDir = ".";
            Directory.CreateDirectory(outputDir);

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                double[,] kernel = new double[,]
                {
                    { -4, -2, 0 },
                    { -2, 2, 2 },
                    { 0, 2, 4 }
                };

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);

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
 * 1. When a developer needs to highlight fine details in a PNG photograph for a product catalog, they can apply a stronger emboss filter using Aspose.Imaging’s convolution kernel in C#.
 * 2. When preparing images for a print‑ready brochure, a programmer may increase edge contrast on PNG graphics to make text and line art stand out by tweaking the emboss 3x3 coefficients.
 * 3. When building a desktop application that visualizes terrain elevation maps, a developer can enhance terrain edges in PNG tiles by applying a custom emboss kernel with Aspose.Imaging.
 * 4. When creating a game asset pipeline, an engineer might boost the perceived depth of sprite PNGs by adjusting the emboss filter coefficients before saving the result.
 * 5. When automating batch processing of scanned documents, a C# script can improve readability of faint lines in PNG scans by strengthening the emboss filter through a modified convolution matrix.
 */
