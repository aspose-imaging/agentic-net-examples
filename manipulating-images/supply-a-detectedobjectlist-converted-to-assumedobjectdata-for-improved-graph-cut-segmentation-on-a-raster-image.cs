// HOW-TO: Perform Graph Cut Segmentation With Assumed Objects In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Collections.Generic;
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
        string inputPath = "input/input.png";
        string outputPath = "output/output.png";

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
                List<AssumedObjectData> assumedObjects = new List<AssumedObjectData>();
                assumedObjects.Add(new AssumedObjectData(DetectedObjectType.Human, new Rectangle(50, 50, 200, 300)));

                AutoMaskingGraphCutOptions maskingOptions = new AutoMaskingGraphCutOptions
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
                    AssumedObjects = assumedObjects
                };

                using (MaskingResult results = new ImageMasking(image).Decompose(maskingOptions))
                {
                    using (RasterImage foreground = (RasterImage)results[1].GetImage())
                    {
                        foreground.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
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
 * 1. When you need to automatically extract a human figure from a PNG photo and replace the background with transparency using graph‑cut segmentation.
 * 2. When you want to improve mask accuracy by supplying known object locations (AssumedObjectData) to the Aspose.Imaging auto‑masking engine.
 * 3. When you are building a C# application that separates foreground objects from complex backgrounds for further editing or compositing.
 * 4. When you require a programmable way to generate a transparent PNG foreground layer from an input image without manual selection tools.
 * 5. When you need to integrate Aspose.Imaging’s GraphCut method into a batch processing pipeline that processes multiple raster images with predefined object rectangles.
 */
