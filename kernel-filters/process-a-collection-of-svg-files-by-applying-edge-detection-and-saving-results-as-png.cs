// HOW-TO: Batch Apply Edge Detection to SVG Files and Save as PNG in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "input_svgs";
            string outputFolder = "output_pngs";

            Directory.CreateDirectory(outputFolder);
            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");

            foreach (var inputPath in svgFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileName + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image svgImage = Image.Load(inputPath))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        var pngOptions = new PngOptions();
                        svgImage.Save(ms, pngOptions);
                        ms.Position = 0;

                        using (RasterImage raster = (RasterImage)Image.Load(ms))
                        {
                            double[,] customKernel = new double[,]
                            {
                                { -1, -1, -1 },
                                { -1, 8, -1 },
                                { -1, -1, -1 }
                            };
                            var filterOptions = new ConvolutionFilterOptions(customKernel);
                            raster.Filter(raster.Bounds, filterOptions);
                            raster.Save(outputPath, new PngOptions());
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
 * 1. When you need to automatically highlight outlines of vector graphics before publishing them as raster images.
 * 2. When a web service must convert a folder of SVG icons into PNG thumbnails with edge‑enhanced visuals.
 * 3. When preparing print‑ready assets, you want to detect edges in SVG diagrams and export them as high‑contrast PNGs.
 * 4. When building a batch processing tool that transforms user‑uploaded SVG drawings into PNGs with a custom convolution filter for computer‑vision preprocessing.
 * 5. When integrating Aspose.Imaging into a CI pipeline to verify SVG quality by generating edge‑detected PNG snapshots for visual regression testing.
 */
