using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hard‑coded paths
        string inputPath = "input.jpg";
        string outputDefaultPath = "output_default.png";
        string outputCustomPath = "output_custom.png";

        // Input validation
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(outputDefaultPath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputCustomPath));

        // ---------- Default strokes (auto‑calculated) ----------
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

            var start = DateTime.Now;
            MaskingResult result = new ImageMasking(image).Decompose(defaultOptions);
            var elapsed = DateTime.Now - start;

            using (RasterImage resultImage = (RasterImage)result[1].GetImage())
            {
                resultImage.Save(outputDefaultPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
            }

            Console.WriteLine($"Default strokes masking time: {elapsed.TotalMilliseconds} ms");
        }

        // ---------- Custom user strokes ----------
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
                    ObjectsPoints = new Point[][]
                    {
                        // Background points (example)
                        new Point[] { new Point(10, 10), new Point(20, 10) },
                        // Foreground points (example)
                        new Point[] { new Point(30, 30) }
                    }
                }
            };

            var start = DateTime.Now;
            MaskingResult result = new ImageMasking(image).Decompose(customOptions);
            var elapsed = DateTime.Now - start;

            using (RasterImage resultImage = (RasterImage)result[1].GetImage())
            {
                resultImage.Save(outputCustomPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
            }

            Console.WriteLine($"Custom strokes masking time: {elapsed.TotalMilliseconds} ms");
        }
    }
}