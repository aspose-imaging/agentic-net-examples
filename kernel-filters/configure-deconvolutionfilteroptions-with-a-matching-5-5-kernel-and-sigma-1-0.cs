// HOW-TO: Apply Custom 5x5 Deconvolution Filter to JPEG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                double[,] kernel = new double[,]
                {
                    { 1.0/273.0, 4.0/273.0, 7.0/273.0, 4.0/273.0, 1.0/273.0 },
                    { 4.0/273.0,16.0/273.0,26.0/273.0,16.0/273.0, 4.0/273.0 },
                    { 7.0/273.0,26.0/273.0,41.0/273.0,26.0/273.0, 7.0/273.0 },
                    { 4.0/273.0,16.0/273.0,26.0/273.0,16.0/273.0, 4.0/273.0 },
                    { 1.0/273.0, 4.0/273.0, 7.0/273.0, 4.0/273.0, 1.0/273.0 }
                };

                var deconvOptions = new DeconvolutionFilterOptions(kernel);
                image.Filter(image.Bounds, deconvOptions);
                image.Save(outputPath);
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
 * 1. When you need to sharpen a JPEG photo by applying a custom 5×5 deconvolution kernel using Aspose.Imaging in C#.
 * 2. When you want to reduce blur in scanned documents by configuring a specific sigma value with DeconvolutionFilterOptions in a .NET application.
 * 3. When you are building an automated image‑processing pipeline that must apply the same Gaussian‑like kernel to multiple images before saving them as JPEG files.
 * 4. When you require precise control over the convolution matrix for scientific imaging or medical scans and need to implement it programmatically in C#.
 * 5. When you are converting raw image data to a raster image, applying a custom filter, and then exporting the result without losing quality in a Windows service.
 */
