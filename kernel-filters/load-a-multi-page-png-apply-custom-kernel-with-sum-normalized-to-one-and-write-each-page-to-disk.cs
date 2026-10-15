// HOW-TO: Apply Custom Convolution Filter to Each Page of a Multi‑Page PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputDir = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                if (image is Aspose.Imaging.IMultipageImage multipage)
                {
                    int pageCount = multipage.PageCount;
                    for (int i = 0; i < pageCount; i++)
                    {
                        using (Aspose.Imaging.Image page = multipage.Pages[i])
                        {
                            using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)page)
                            {
                                double[,] kernel = new double[,]
                                {
                                    {0.04, 0.04, 0.04, 0.04, 0.04},
                                    {0.04, 0.04, 0.04, 0.04, 0.04},
                                    {0.04, 0.04, 0.04, 0.04, 0.04},
                                    {0.04, 0.04, 0.04, 0.04, 0.04},
                                    {0.04, 0.04, 0.04, 0.04, 0.04}
                                };

                                raster.Filter(raster.Bounds,
                                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel));

                                string outputPath = Path.Combine(outputDir, $"page_{i + 1}.png");
                                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                                var options = new PngOptions();
                                options.Source = new FileCreateSource(outputPath, false);
                                raster.Save(outputPath, options);
                            }
                        }
                    }
                }
                else
                {
                    Console.Error.WriteLine("The input image is not a multi-page image.");
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
 * 1. When you need to preprocess every frame of a multi‑page PNG (such as an animated PNG) with a blur or smoothing effect before further analysis.
 * 2. When you want to extract each page of a multi‑page PNG and save them as separate files after applying a custom kernel for noise reduction.
 * 3. When building a C# batch‑processing tool that applies a uniform convolution filter to all layers of a scanned document stored as a multi‑page PNG.
 * 4. When preparing image data for machine‑learning models by normalizing each page with a sum‑to‑one kernel using Aspose.Imaging in .NET.
 * 5. When creating a server‑side service that receives a multi‑page PNG, applies a custom filter, and returns individual filtered pages for downstream rendering.
 */
