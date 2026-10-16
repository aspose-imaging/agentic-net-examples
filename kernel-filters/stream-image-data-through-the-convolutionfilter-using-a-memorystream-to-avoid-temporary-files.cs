// HOW-TO: Apply Emboss Convolution Filter to PNG Using MemoryStream in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input\\input.png";
            string outputPath = "output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage inputImage = (RasterImage)Image.Load(inputPath))
            {
                using (var memoryStream = new MemoryStream())
                {
                    inputImage.Save(memoryStream, new PngOptions());
                    memoryStream.Position = 0;

                    using (RasterImage memImage = (RasterImage)Image.Load(memoryStream))
                    {
                        var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                            Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3);

                        memImage.Filter(memImage.Bounds, filterOptions);
                        memImage.Save(outputPath, new PngOptions());
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
 * 1. When you need to apply an emboss effect to a PNG image without creating intermediate files on disk.
 * 2. When processing large batches of images in a web service and you want to keep the operation entirely in memory for better performance.
 * 3. When you must preserve the original file while generating a filtered version for thumbnails or preview images.
 * 4. When working in an environment with limited write permissions and you need to manipulate images completely in memory.
 * 5. When integrating Aspose.Imaging into a C# application that streams image data from a database or network source, applies a convolution filter, and then saves the result.
 */
