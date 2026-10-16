// HOW-TO: Remove Background from PNG and Apply Median Filter in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\image.png";
            string outputPath = "Output\\result.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    var maskingOptions = new AutoMaskingGraphCutOptions
                    {
                        CalculateDefaultStrokes = true,
                        FeatheringRadius = (Math.Max(sourceImage.Width, sourceImage.Height) / 500) + 1,
                        Method = SegmentationMethod.GraphCut,
                        Decompose = false,
                        ExportOptions = new PngOptions
                        {
                            ColorType = PngColorType.TruecolorWithAlpha,
                            Source = new StreamSource(ms)
                        },
                        BackgroundReplacementColor = Color.Transparent
                    };

                    var masking = new ImageMasking(sourceImage);
                    using (MaskingResult maskingResult = masking.Decompose(maskingOptions))
                    using (RasterImage foreground = (RasterImage)maskingResult[1].GetImage())
                    {
                        foreground.Filter(foreground.Bounds, new MedianFilterOptions(3));

                        foreground.Save(outputPath, new PngOptions
                        {
                            ColorType = PngColorType.TruecolorWithAlpha,
                            Source = new FileCreateSource(outputPath, false)
                        });
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
 * 1. When you need to extract a foreground object from a PNG and make the background transparent while smoothing edge noise.
 * 2. When preparing product photos for e‑commerce, you want to remove the original background and apply a median filter to eliminate small artifacts before uploading.
 * 3. When processing scanned documents saved as PNG, you need to isolate the text region, replace the background with transparency, and smooth speckles for OCR accuracy.
 * 4. When creating assets for a game engine, you must strip the background from PNG sprites and apply a 3×3 median filter to ensure clean edges without jagged pixels.
 * 5. When automating batch image cleanup, you require a C# routine that removes backgrounds from PNG files and applies a median filter to reduce visual noise across all images.
 */
