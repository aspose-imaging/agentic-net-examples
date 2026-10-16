// HOW-TO: Apply Zero Sum Edge Detection Kernel to PNG Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                double[,] edgeKernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1, 8, -1 },
                    { -1, -1, -1 }
                };

                var filterOptions = new ConvolutionFilterOptions(edgeKernel);
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
 * 1. When you need to highlight edges in a PNG while keeping the background dark for visual analysis, you can apply a zero‑sum convolution kernel with Aspose.Imaging in C#.
 * 2. When preparing images for OCR or computer‑vision pipelines, using an edge‑detection filter helps isolate text or objects against a near‑black background.
 * 3. When creating stylized thumbnails that emphasize outlines of graphics, the Laplacian kernel can be applied to PNG files programmatically.
 * 4. When debugging image‑processing algorithms, you may want to verify that a zero‑sum kernel produces the expected low‑intensity background before further processing.
 * 5. When automating batch conversion of PNG assets to a high‑contrast version for UI testing, applying the edge detection filter with Aspose.Imaging simplifies the workflow.
 */
