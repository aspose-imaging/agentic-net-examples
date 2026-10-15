// HOW-TO: Apply Custom Convolution Kernel to PNG Image in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                double[,] customKernel = new double[,]
                {
                    { 0.25, 0,    0,    0,    0    },
                    { 0,    0.2,  0,    0,    0    },
                    { 0,    0,    0.1,  0,    0    },
                    { 0,    0,    0,    0.2,  0    },
                    { 0,    0,    0,    0,    0.25 }
                };

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(customKernel);
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
 * 1. When you need to emphasize specific diagonal features in a PNG by applying a user‑defined convolution matrix in a C# application.
 * 2. When creating a custom sharpening or smoothing effect that cannot be achieved with built‑in filters, you can define your own kernel and apply it to a raster image.
 * 3. When processing scanned documents or graphics where you want to selectively boost pixel values along certain axes using a custom filter before saving the result as PNG.
 * 4. When building an image‑editing tool that lets users draw brush strokes to generate a kernel matrix for artistic convolution effects on PNG files.
 * 5. When automating batch processing of PNG assets to apply a consistent custom convolution filter for visual consistency across a game or UI assets.
 */
