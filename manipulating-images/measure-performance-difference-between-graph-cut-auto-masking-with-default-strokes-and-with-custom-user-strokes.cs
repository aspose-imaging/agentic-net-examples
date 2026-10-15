// HOW-TO: Compare Graph Cut Auto Masking Speed with Default and Custom Strokes in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Diagnostics;
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
            string outputDefaultPath = "output\\default.png";
            string outputCustomPath = "output\\custom.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputDefaultPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputCustomPath));

            Stopwatch swDefault = new Stopwatch();
            Stopwatch swCustom = new Stopwatch();

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Default strokes
                var defaultOptions = new AutoMaskingGraphCutOptions
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

                swDefault.Start();
                using (MaskingResult result = new ImageMasking(image).Decompose(defaultOptions))
                using (RasterImage foreground = (RasterImage)result[1].GetImage())
                {
                    swDefault.Stop();
                    foreground.Save(outputDefaultPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }

                // Custom strokes
                var customOptions = new AutoMaskingGraphCutOptions
                {
                    CalculateDefaultStrokes = false,
                    FeatheringRadius = 3,
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
                            new Point[] { new Point(image.Width / 2, image.Height / 2) }
                        }
                    }
                };

                swCustom.Start();
                using (MaskingResult result = new ImageMasking(image).Decompose(customOptions))
                using (RasterImage foreground = (RasterImage)result[1].GetImage())
                {
                    swCustom.Stop();
                    foreground.Save(outputCustomPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }
            }

            Console.WriteLine($"Default strokes time: {swDefault.ElapsedMilliseconds} ms");
            Console.WriteLine($"Custom strokes time: {swCustom.ElapsedMilliseconds} ms");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to benchmark how default auto‑masking strokes affect processing time versus user‑defined strokes for JPEG images in a C# application.
 * 2. When you want to evaluate the performance impact of Graph Cut segmentation before integrating it into an automated background removal pipeline.
 * 3. When you are comparing memory usage and execution speed of Aspose.Imaging’s AutoMaskingGraphCutOptions with and without custom stroke input for batch image processing.
 * 4. When you need to decide whether to enable CalculateDefaultStrokes for faster prototyping or require manual strokes for more accurate results in a photo‑editing tool.
 * 5. When you are measuring the time saved by using default strokes to generate PNG masks with transparency for downstream compositing tasks.
 */
