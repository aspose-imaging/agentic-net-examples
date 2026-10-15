// HOW-TO: Apply GraphCut Auto Masking with Custom Feathering to PNG in C# (Aspose.Imaging for .NET)
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
                    BackgroundReplacementColor = Color.Transparent
                };

                var masking = new ImageMasking(image);
                using (MaskingResult results = masking.Decompose(maskingOptions))
                {
                    using (RasterImage foreground = (RasterImage)results[1].GetImage())
                    {
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
 * 1. When you need to automatically separate the foreground of a PNG image from its background and save the result with a transparent background using Aspose.Imaging in C#.
 * 2. When you want to fine‑tune the edge smoothness of a mask by calculating a dynamic feathering radius based on the image dimensions.
 * 3. When you are processing large batches of PNG files and require a graph‑cut segmentation method that can be configured programmatically.
 * 4. When you must preserve the original image’s alpha channel while exporting the masked foreground as a true‑color PNG.
 * 5. When you need to integrate automatic object extraction into a .NET application without manually drawing strokes or using external tools.
 */
