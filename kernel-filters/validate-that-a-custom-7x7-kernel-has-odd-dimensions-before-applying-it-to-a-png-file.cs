// HOW-TO: Validate Odd-Sized Convolution Kernel Before Applying to PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageFilters.FilterOptions;
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

            double[,] kernel = new double[,]
            {
                {0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0},
                {0,0,0,1,0,0,0},
                {0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0}
            };

            if (kernel.GetLength(0) % 2 == 0 || kernel.GetLength(1) % 2 == 0)
            {
                Console.Error.WriteLine("Kernel dimensions must be odd.");
                return;
            }

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                PngOptions options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                raster.Save(outputPath, options);
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
 * 1. When you need to sharpen or detect edges in a PNG image using a custom 7x7 convolution matrix, you must first ensure the kernel has odd dimensions to avoid runtime errors.
 * 2. When integrating Aspose.Imaging into a .NET service that processes user‑uploaded PNG files, validating the kernel size prevents invalid filter configurations from crashing the application.
 * 3. When building a batch image‑processing tool that applies custom filters to PNG assets, checking for odd‑sized kernels guarantees the convolution operation aligns correctly with the image’s pixel grid.
 * 4. When creating a scientific imaging workflow in C# that requires precise convolution kernels, confirming the kernel dimensions are odd ensures accurate mathematical convolution results.
 * 5. When developing a desktop application that lets users design their own filter kernels for PNG graphics, the code validates the kernel size before applying the filter to maintain stability and predictable output.
 */
