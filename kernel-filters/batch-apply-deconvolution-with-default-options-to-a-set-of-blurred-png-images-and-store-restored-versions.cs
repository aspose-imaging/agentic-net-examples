// HOW-TO: Batch Deconvolution of Blurred PNG Images with Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
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

            Directory.CreateDirectory(outputDirectory);

            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string filePath in files)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    continue;
                }

                using (RasterImage raster = (RasterImage)Image.Load(filePath))
                {
                    raster.Filter(raster.Bounds, new DeconvolutionFilterOptions(ConvolutionFilter.GetGaussian(3, 1.0)));

                    string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(filePath) + "_restored.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    PngOptions options = new PngOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
                    };
                    raster.Save(outputPath, options);
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
 * 1. When you need to automatically sharpen a large collection of blurry PNG photos taken in low‑light conditions before uploading them to a web gallery.
 * 2. When a desktop application must restore scanned documents that appear out of focus by applying a Gaussian deconvolution filter to each PNG file in a folder.
 * 3. When a batch image‑processing pipeline requires C# code to read PNG files, remove blur with default deconvolution settings, and save the cleaned versions with a “_restored” suffix.
 * 4. When you want to integrate Aspose.Imaging into a server‑side service that cleans up user‑submitted PNG screenshots that are blurred due to compression artifacts.
 * 5. When an automated quality‑control script must iterate through an input directory, apply deconvolution to every PNG, and store the results in a separate output folder for further analysis.
 */
