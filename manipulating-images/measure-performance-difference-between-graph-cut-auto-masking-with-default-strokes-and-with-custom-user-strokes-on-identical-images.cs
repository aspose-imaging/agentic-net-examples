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
            // Hard‑coded paths
            string inputPath = "input.jpg";
            string outputDir = "output";
            string outputDefaultPath = Path.Combine(outputDir, "default.png");
            string outputCustomPath = Path.Combine(outputDir, "custom.png");

            // Input validation
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputDefaultPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputCustomPath));

            // Load source image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // ---------- Default (auto) strokes ----------
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

                Stopwatch swDefault = Stopwatch.StartNew();
                MaskingResult defaultResult = new ImageMasking(image).Decompose(defaultOptions);
                swDefault.Stop();

                using (defaultResult)
                using (RasterImage resultImage = (RasterImage)defaultResult[1].GetImage())
                {
                    resultImage.Save(outputDefaultPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }

                // ---------- Custom user strokes ----------
                var customArgs = new AutoMaskingArgs
                {
                    ObjectsPoints = new Point[][]
                    {
                        new Point[] { new Point(10, 10), new Point(20, 10) }, // background points
                        new Point[] { new Point(30, 30) }                     // foreground point
                    }
                };

                var customOptions = new GraphCutMaskingOptions
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
                    Args = customArgs
                };

                Stopwatch swCustom = Stopwatch.StartNew();
                MaskingResult customResult = new ImageMasking(image).Decompose(customOptions);
                swCustom.Stop();

                using (customResult)
                using (RasterImage resultImage = (RasterImage)customResult[1].GetImage())
                {
                    resultImage.Save(outputCustomPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }

                // Output timing information
                Console.WriteLine($"Default strokes time: {swDefault.ElapsedMilliseconds} ms");
                Console.WriteLine($"Custom strokes time: {swCustom.ElapsedMilliseconds} ms");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}