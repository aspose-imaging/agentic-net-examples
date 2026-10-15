// HOW-TO: Batch Apply Horizontal and Vertical Edge Detection to SVGs in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-14
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "input_svgs";
            string outputFolder = "output_edges";

            Directory.CreateDirectory(outputFolder);

            foreach (string svgPath in Directory.GetFiles(inputFolder, "*.svg"))
            {
                if (!File.Exists(svgPath))
                {
                    Console.Error.WriteLine($"File not found: {svgPath}");
                    return;
                }

                using (Image svgImage = Image.Load(svgPath))
                {
                    using (MemoryStream pngStream = new MemoryStream())
                    {
                        PngOptions pngOptions = new PngOptions();
                        svgImage.Save(pngStream, pngOptions);
                        pngStream.Position = 0;

                        var kernels = new Dictionary<string, double[,]>
                        {
                            { "horizontal", new double[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } } },
                            { "vertical",   new double[,] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } } }
                        };

                        foreach (var kvp in kernels)
                        {
                            string orientation = kvp.Key;
                            double[,] kernel = kvp.Value;

                            pngStream.Position = 0;
                            using (Image rasterImg = Image.Load(pngStream))
                            {
                                RasterImage raster = rasterImg as RasterImage;
                                if (raster == null)
                                {
                                    Console.Error.WriteLine($"Failed to rasterize: {svgPath}");
                                    continue;
                                }

                                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

                                string outputPath = Path.Combine(outputFolder,
                                    Path.GetFileNameWithoutExtension(svgPath) + "_" + orientation + ".png");
                                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                                raster.Save(outputPath, new PngOptions());
                            }
                        }
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
 * 1. When you need to automatically generate edge maps from a collection of SVG icons for computer‑vision preprocessing.
 * 2. When you want to convert vector graphics to raster PNGs and extract horizontal and vertical edges for feature extraction in a machine‑learning pipeline.
 * 3. When you are building a batch workflow that creates stylized line‑art versions of SVG illustrations for printing or web thumbnails.
 * 4. When you must analyze the shape outlines of SVG diagrams by applying custom Sobel‑like kernels to detect edges in different orientations.
 * 5. When you require a C# solution that processes multiple SVG files, rasterizes them, and outputs edge‑detected images for quality‑control or visual testing.
 */
