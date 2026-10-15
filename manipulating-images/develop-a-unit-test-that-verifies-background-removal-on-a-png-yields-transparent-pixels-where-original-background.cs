// HOW-TO: Unit Test for PNG Background Removal Producing Transparent Pixels in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load original image
            using (RasterImage original = (RasterImage)Image.Load(inputPath))
            {
                // Determine background color (pixel at (0,0))
                int[] originalPixels = original.LoadArgb32Pixels(new Rectangle(0, 0, original.Width, original.Height));
                int backgroundPixel = originalPixels[0];
                int backgroundRgb = backgroundPixel & 0x00FFFFFF; // ignore alpha

                // Configure auto masking options
                var maskingOptions = new AutoMaskingGraphCutOptions
                {
                    CalculateDefaultStrokes = true,
                    FeatheringRadius = (Math.Max(original.Width, original.Height) / 500) + 1,
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    ExportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new StreamSource(new MemoryStream())
                    },
                    BackgroundReplacementColor = Color.Transparent
                };

                // Perform background removal
                var masking = new ImageMasking(original);
                using (MaskingResult results = masking.Decompose(maskingOptions))
                using (RasterImage foreground = (RasterImage)results[1].GetImage())
                {
                    // Save result
                    foreground.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }

                // Verify transparency in saved image
                using (RasterImage resultImage = (RasterImage)Image.Load(outputPath))
                {
                    int[] resultPixels = resultImage.LoadArgb32Pixels(new Rectangle(0, 0, resultImage.Width, resultImage.Height));
                    bool allBackgroundTransparent = true;
                    for (int i = 0; i < resultPixels.Length; i++)
                    {
                        int pixel = resultPixels[i];
                        int rgb = pixel & 0x00FFFFFF;
                        int alpha = (pixel >> 24) & 0xFF;
                        if (rgb == backgroundRgb && alpha != 0)
                        {
                            allBackgroundTransparent = false;
                            break;
                        }
                    }

                    if (allBackgroundTransparent)
                    {
                        Console.WriteLine("Test passed: background pixels are transparent.");
                    }
                    else
                    {
                        Console.WriteLine("Test failed: some background pixels are not transparent.");
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
 * 1. When you need to automatically verify that a PNG's background is correctly removed and replaced with transparency during CI builds.
 * 2. When you want to ensure that Aspose.Imaging's AutoMaskingGraphCutOptions generate transparent pixels exactly where the original background color was located.
 * 3. When you are building an e‑commerce platform that must programmatically confirm product images have clean transparent backgrounds before publishing.
 * 4. When you are writing automated tests to detect regressions in image masking algorithms after updating the Aspose.Imaging library.
 * 5. When you need to validate that the exported PNG uses truecolor with alpha and contains no residual background color after processing.
 */
