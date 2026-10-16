// HOW-TO: Correct Missed Regions in Graph Cut Auto‑Mask Using Manual Points C# (Aspose.Imaging for .NET)
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
        string inputPath = "input.jpg";
        string outputPath = "output/output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                var maskingOptions = new AutoMaskingGraphCutOptions
                {
                    CalculateDefaultStrokes = true,
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
                                new Point(50, 50),
                                new Point(150, 150)
                            }
                        }
                    }
                };

                var masking = new ImageMasking(image);
                using (MaskingResult results = masking.Decompose(maskingOptions))
                using (RasterImage foreground = (RasterImage)results[1].GetImage())
                {
                    foreground.Save(outputPath, new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha
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
 * 1. When you need to remove a background from a JPEG photo but the automatic Graph Cut leaves small leftover artifacts, you can supply manual point arrays to fine‑tune the mask and export a transparent PNG.
 * 2. When processing product images for an e‑commerce site, you can combine auto‑masking with custom points to ensure logos or labels are fully isolated before saving as PNG with alpha channel.
 * 3. When preparing assets for a game engine, you may want to automatically segment characters from a raster image and then manually correct missed edges using point coordinates to produce a clean PNG sprite.
 * 4. When building a batch image‑cleanup tool in C#, you can use Aspose.Imaging to auto‑mask photos and add manual point corrections for small regions, then save the result with transparent background for further compositing.
 * 5. When creating a photo‑editing application that lets users adjust auto‑generated masks, you can programmatically apply Graph Cut masking and let the UI supply point arrays to fix imperfections, outputting a true‑color PNG with alpha.
 */
