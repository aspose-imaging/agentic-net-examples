// HOW-TO: Measure Graph Cut Auto‑Masking Performance With Default vs Custom Strokes in C# (Aspose.Imaging for .NET)
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
            // Hard‑coded input and output paths
            string inputPath = "input.jpg";
            string outputDefaultPath = "output\\default.png";
            string outputCustomPath = "output\\custom.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputDefaultPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputCustomPath));

            // -------------------- Default strokes (auto‑calculated) --------------------
            var swDefault = new System.Diagnostics.Stopwatch();
            swDefault.Start();

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
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

                using (MaskingResult results = new ImageMasking(image).Decompose(defaultOptions))
                {
                    using (RasterImage resultImage = (RasterImage)results[1].GetImage())
                    {
                        resultImage.Save(outputDefaultPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                    }
                }
            }

            swDefault.Stop();

            // -------------------- Custom user strokes --------------------
            // Example user‑defined points (background and foreground)
            Point[][] userPoints = new Point[][]
            {
                new Point[] { new Point(10, 10), new Point(20, 10) }, // background points
                new Point[] { new Point(30, 30) }                     // foreground points
            };

            var swCustom = new System.Diagnostics.Stopwatch();
            swCustom.Start();

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                var customOptions = new AutoMaskingGraphCutOptions
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
                        ObjectsPoints = userPoints
                    }
                };

                using (MaskingResult results = new ImageMasking(image).Decompose(customOptions))
                {
                    using (RasterImage resultImage = (RasterImage)results[1].GetImage())
                    {
                        resultImage.Save(outputCustomPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                    }
                }
            }

            swCustom.Stop();

            // Output timing results
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
 * 1. When you need to benchmark how quickly Aspose.Imaging’s Graph Cut auto‑masking generates masks using automatically calculated strokes versus user‑defined strokes on JPEG images.
 * 2. When you want to compare the processing time of default stroke generation against custom stroke input to decide which approach meets real‑time performance requirements in a photo‑editing application.
 * 3. When you are evaluating the impact of feathering radius and segmentation method on mask creation speed for PNG export with transparency.
 * 4. When you need to ensure that output directories exist and verify input files before running automated background removal in a batch‑processing pipeline.
 * 5. When you are profiling the performance of Aspose.Imaging’s ImageMasking.Decompose method to optimize resource usage in a C# service that processes large images.
 */
