// HOW-TO: Batch Apply Graph Cut Auto Mask to PNG Images in C# (Aspose.Imaging for .NET)
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
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.png");
            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + "_masked.png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    var maskingOptions = new GraphCutMaskingOptions
                    {
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
                                new Point[]
                                {
                                    new Point(10, 10),
                                    new Point(100, 10),
                                    new Point(100, 100),
                                    new Point(10, 100)
                                }
                            }
                        }
                    };

                    using (MaskingResult results = new ImageMasking(image).Decompose(maskingOptions))
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
 * 1. When you need to automatically remove backgrounds from a large set of product photos stored as PNG files before uploading them to an e‑commerce site.
 * 2. When you want to preprocess scanned PNG documents by segmenting foreground objects using Graph Cut to improve OCR accuracy.
 * 3. When you are building a desktop tool that lets users draw strokes to define foreground and background and then batch‑mask multiple PNG assets for game development.
 * 4. When you must generate transparent PNG icons from existing images by applying auto‑masking with feathered edges across an entire folder.
 * 5. When you are preparing PNG textures for a graphics pipeline and need to isolate subjects using Graph Cut segmentation without manually editing each file.
 */
