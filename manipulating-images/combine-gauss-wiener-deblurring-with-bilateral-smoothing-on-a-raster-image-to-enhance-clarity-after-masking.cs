// HOW-TO: Apply Gauss Wiener Deblurring and Bilateral Smoothing After Auto Masking in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
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
                        Source = new StreamSource(new MemoryStream())
                    },
                    BackgroundReplacementColor = Color.Transparent
                };

                using (MaskingResult maskingResult = new ImageMasking(sourceImage).Decompose(maskingOptions))
                using (RasterImage foreground = (RasterImage)maskingResult[1].GetImage())
                {
                    // Apply Gauss-Wiener deblurring
                    foreground.Filter(foreground.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussWienerFilterOptions());

                    // Apply Bilateral smoothing
                    foreground.Filter(foreground.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.BilateralSmoothingFilterOptions());

                    // Save the enhanced image
                    foreground.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
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
 * 1. When you need to remove blur from a photographed document while preserving edges after extracting the foreground with graph‑cut masking, you can use this code.
 * 2. When preparing product photos for e‑commerce, you can automatically mask the item, deblur it with Gauss‑Wiener, and smooth skin or surface details with bilateral filtering before saving as PNG with transparency.
 * 3. When cleaning up scanned medical images, the combination of auto masking, deblurring, and bilateral smoothing helps enhance diagnostic details without affecting the surrounding background.
 * 4. When creating assets for a game, you can isolate characters, sharpen them using Gauss‑Wiener, and apply bilateral smoothing to reduce noise while keeping sharp edges, then export to a PNG with an alpha channel.
 * 5. When processing satellite or aerial imagery, this workflow lets you mask regions of interest, improve clarity with deblurring, and smooth terrain variations while retaining edge definition for further analysis.
 */
