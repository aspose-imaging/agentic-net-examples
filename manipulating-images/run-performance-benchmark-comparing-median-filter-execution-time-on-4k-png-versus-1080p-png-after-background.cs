// HOW-TO: Benchmark Median Filter Speed on 4K vs 1080p PNG After Background Removal in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath4K = "input_4k.png";
            string inputPath1080p = "input_1080p.png";
            string outputPath4K = "output_4k.png";
            string outputPath1080p = "output_1080p.png";

            if (!File.Exists(inputPath4K))
            {
                Console.Error.WriteLine($"File not found: {inputPath4K}");
                return;
            }
            if (!File.Exists(inputPath1080p))
            {
                Console.Error.WriteLine($"File not found: {inputPath1080p}");
                return;
            }

            // Process 4K image
            using (RasterImage raster4K = (RasterImage)Image.Load(inputPath4K))
            {
                var maskingOptions4K = new AutoMaskingGraphCutOptions
                {
                    CalculateDefaultStrokes = true,
                    FeatheringRadius = (Math.Max(raster4K.Width, raster4K.Height) / 500) + 1,
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    ExportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new StreamSource(new MemoryStream())
                    },
                    BackgroundReplacementColor = Color.Transparent
                };

                var masking4K = new ImageMasking(raster4K);
                using (MaskingResult result4K = masking4K.Decompose(maskingOptions4K))
                using (RasterImage foreground4K = (RasterImage)result4K[1].GetImage())
                {
                    var medianOptions = new MedianFilterOptions(3);
                    var sw = System.Diagnostics.Stopwatch.StartNew();
                    foreground4K.Filter(foreground4K.Bounds, medianOptions);
                    sw.Stop();

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath4K));
                    foreground4K.Save(outputPath4K, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });

                    Console.WriteLine($"Median filter on 4K image took {sw.ElapsedMilliseconds} ms");
                }
            }

            // Process 1080p image
            using (RasterImage raster1080p = (RasterImage)Image.Load(inputPath1080p))
            {
                var maskingOptions1080p = new AutoMaskingGraphCutOptions
                {
                    CalculateDefaultStrokes = true,
                    FeatheringRadius = (Math.Max(raster1080p.Width, raster1080p.Height) / 500) + 1,
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    ExportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new StreamSource(new MemoryStream())
                    },
                    BackgroundReplacementColor = Color.Transparent
                };

                var masking1080p = new ImageMasking(raster1080p);
                using (MaskingResult result1080p = masking1080p.Decompose(maskingOptions1080p))
                using (RasterImage foreground1080p = (RasterImage)result1080p[1].GetImage())
                {
                    var medianOptions = new MedianFilterOptions(3);
                    var sw = System.Diagnostics.Stopwatch.StartNew();
                    foreground1080p.Filter(foreground1080p.Bounds, medianOptions);
                    sw.Stop();

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath1080p));
                    foreground1080p.Save(outputPath1080p, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });

                    Console.WriteLine($"Median filter on 1080p image took {sw.ElapsedMilliseconds} ms");
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
 * 1. When you need to determine how long a median filter takes on high‑resolution 4K PNGs versus 1080p PNGs after removing the background, to optimize an automated product‑photo cleanup pipeline.
 * 2. When evaluating whether your server hardware can handle batch background‑removal and noise‑reduction for large‑format images in a web‑based photo‑editing service.
 * 3. When measuring the performance impact of graph‑cut masking on subsequent filtering steps for medical imaging scans that are stored as PNG files.
 * 4. When comparing processing times to set realistic SLAs for a cloud API that applies background removal and median smoothing to user‑uploaded images of different resolutions.
 * 5. When profiling the Aspose.Imaging .NET library to decide if you should pre‑scale 4K images before applying median filtering in a real‑time video‑game texture pipeline.
 */
