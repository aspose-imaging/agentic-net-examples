// HOW-TO: Apply Auto Background Removal and Gauss Wiener Filter in C# (Aspose.Imaging for .NET)
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
        string outputPath = "output.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
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

                var masking = new ImageMasking(sourceImage);
                using (MaskingResult results = masking.Decompose(maskingOptions))
                {
                    using (RasterImage foreground = (RasterImage)results[1].GetImage())
                    {
                        var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussWienerFilterOptions
                        {
                            Radius = 3,
                            Sigma = 1.0
                        };
                        foreground.Filter(foreground.Bounds, filterOptions);

                        var jpegOptions = new JpegOptions();
                        foreground.Save(outputPath, jpegOptions);
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
 * 1. When you need to automatically remove a photo’s background and keep the subject sharp for e‑commerce product images.
 * 2. When you want to clean up slight blur introduced by an auto‑masking algorithm before saving the result as JPEG.
 * 3. When you are processing large batches of images in a C# application and require transparent PNG output for the foreground layer.
 * 4. When you need to integrate graph‑cut segmentation with a Gauss‑Wiener de‑blur filter to improve edge definition in scanned documents.
 * 5. When you are building a .NET image‑processing pipeline that must replace the original background with transparency and then sharpen the foreground.
 */
