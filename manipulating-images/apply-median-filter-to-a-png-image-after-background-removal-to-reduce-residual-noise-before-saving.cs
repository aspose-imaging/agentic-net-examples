// HOW-TO: Auto Mask PNG Background And Denoise With Median Filter C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input\\image.png";
            string outputPath = "output\\result.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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
                    foreground.Filter(foreground.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));

                    foreground.Save(outputPath, new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new FileCreateSource(outputPath, false)
                    });
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
 * 1. When you need to extract a foreground object from a PNG with a complex background while preserving transparency for further compositing.
 * 2. When you want to reduce speckle noise left after automatic background removal before saving the image for web publishing.
 * 3. When processing product photos in an e‑commerce pipeline and require a clean PNG with no residual artifacts.
 * 4. When preparing assets for a game UI and must ensure the masked image has smooth edges and consistent alpha.
 * 5. When automating batch processing of scanned documents to isolate diagrams and need a median filter to smooth jagged edges after segmentation.
 */
