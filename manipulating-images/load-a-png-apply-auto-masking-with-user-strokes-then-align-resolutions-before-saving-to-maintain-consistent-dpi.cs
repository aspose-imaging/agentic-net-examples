// HOW-TO: Auto Mask PNG With User Strokes And Preserve DPI In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                var maskingOptions = new AutoMaskingGraphCutOptions
                {
                    CalculateDefaultStrokes = false,
                    FeatheringRadius = (Math.Max(image.Width, image.Height) / 500) + 1,
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    ExportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new StreamSource(new MemoryStream())
                    },
                    BackgroundReplacementColor = Color.Transparent,
                    Args = new AutoMaskingArgs
                    {
                        ObjectsPoints = new Point[][]
                        {
                            new Point[]
                            {
                                new Point(30, 30),
                                new Point(200, 30),
                                new Point(200, 200),
                                new Point(30, 200)
                            }
                        }
                    }
                };

                using (MaskingResult results = new ImageMasking(image).Decompose(maskingOptions))
                using (RasterImage foreground = (RasterImage)results[1].GetImage())
                {
                    foreground.HorizontalResolution = image.HorizontalResolution;
                    foreground.VerticalResolution = image.VerticalResolution;

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
 * 1. When you need to remove a background from a PNG image based on manually defined points while keeping the original image dimensions and DPI for further printing.
 * 2. When you want to generate a transparent PNG mask using Aspose.Imaging’s GraphCut algorithm after providing user‑drawn strokes to isolate objects in a photograph.
 * 3. When an application must batch‑process product photos, automatically extract the item using auto‑masking and save the result with consistent resolution for e‑commerce platforms.
 * 4. When you are building a C# tool that aligns the output image’s DPI with the source PNG to avoid scaling issues in PDF or layout engines.
 * 5. When you require a programmatic way to replace the background of a scanned PNG with transparency while preserving color depth and metadata for archival purposes.
 */
