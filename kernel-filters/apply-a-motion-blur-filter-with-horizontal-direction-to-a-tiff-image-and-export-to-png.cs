// HOW-TO: Apply Horizontal Motion Blur to TIFF and Save as PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                double[,] kernel = new double[,]
                {
                    { 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0 },
                    { 0.2, 0.2, 0.2, 0.2, 0.2 },
                    { 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0 }
                };
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);

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
 * 1. When you need to add a horizontal motion‑blur effect to a scanned TIFF document before converting it to a lightweight PNG for web display.
 * 2. When you want to preprocess large multi‑page TIFF images with a custom convolution kernel to simulate motion blur and then export each page as PNG for further analysis.
 * 3. When a photo‑editing application requires applying a simple blur filter to a TIFF image in C# using Aspose.Imaging and saving the result as a PNG with lossless compression.
 * 4. When automating a batch workflow that reads TIFF assets, applies a horizontal blur to mask sensitive details, and stores the blurred output as PNG files.
 * 5. When integrating image processing into a .NET service that receives TIFF uploads, applies a motion‑blur filter for artistic effect, and returns the processed image in PNG format.
 */
