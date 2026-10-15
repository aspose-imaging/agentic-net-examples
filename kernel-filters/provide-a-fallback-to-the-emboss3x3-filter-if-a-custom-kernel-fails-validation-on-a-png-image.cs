// HOW-TO: Apply Custom Convolution Filter with Fallback to Emboss on PNG in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input/input.png";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                try
                {
                    double[,] customKernel = new double[,]
                    {
                        { -2, -1, 0 },
                        { -1, 1, 1 },
                        { 0, 1, 2 }
                    };
                    var customOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(customKernel);
                    raster.Filter(raster.Bounds, customOptions);
                }
                catch (Exception)
                {
                    var fallbackOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3);
                    raster.Filter(raster.Bounds, fallbackOptions);
                }

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
 * 1. When you need to enhance a PNG image with a custom edge‑detect kernel but must ensure the operation succeeds even if the kernel is invalid, using Aspose.Imaging’s fallback to an emboss filter.
 * 2. When processing user‑uploaded PNG files in a C# web service and you want to apply a proprietary convolution effect while automatically reverting to a safe default filter if validation fails.
 * 3. When building a batch image‑processing tool that applies artistic filters to PNGs and requires a reliable fallback to prevent runtime errors from malformed kernel matrices.
 * 4. When integrating custom image‑analysis algorithms in a .NET application and you need to guarantee that every PNG is saved after applying either the custom filter or the built‑in Emboss3x3 filter.
 * 5. When creating a photo‑editing feature that lets developers experiment with custom convolution kernels on PNGs, with Aspose.Imaging automatically handling invalid kernels by switching to a standard emboss effect.
 */
