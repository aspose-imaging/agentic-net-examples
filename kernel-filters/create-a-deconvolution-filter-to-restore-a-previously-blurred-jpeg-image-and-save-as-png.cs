// HOW-TO: Restore Blurred JPEG with Deconvolution Filter and Save as PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                int size = 3;
                double sigma = 1.0;
                var deconvOptions = new Aspose.Imaging.ImageFilters.FilterOptions.DeconvolutionFilterOptions(
                    Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetGaussian(size, sigma));

                raster.Filter(raster.Bounds, deconvOptions);

                var pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                raster.Save(outputPath, pngOptions);
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
 * 1. When a web application needs to improve the quality of user‑uploaded blurry JPEG photos before displaying them, this code can deblur the image and convert it to PNG for lossless presentation.
 * 2. When an archival system receives scanned JPEG documents that appear out of focus, the deconvolution filter restores readability and the PNG output preserves the enhanced details.
 * 3. When a mobile app processes camera‑captured JPEG images affected by motion blur and requires a high‑resolution PNG for further graphic editing, this routine performs the restoration automatically.
 * 4. When a batch processing tool must convert a collection of blurred JPEG assets to PNG while applying a Gaussian deconvolution to meet publishing standards, the code provides a programmable solution.
 * 5. When a scientific imaging workflow needs to correct blur in JPEG microscopy images and store the corrected results in a lossless PNG format for analysis, this example demonstrates the required steps.
 */
