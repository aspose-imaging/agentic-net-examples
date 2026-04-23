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
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputDefaultPath = "output_default.png";
            string outputCustomPath = "output_custom.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputDefaultPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputCustomPath));

            // ---------- Auto masking with default strokes ----------
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
                using (MaskingResult results = new ImageMasking(image).Decompose(defaultOptions))
                {
                    var duration = (DateTime.Now - start).TotalMilliseconds;
                    Console.WriteLine($"Default strokes duration: {duration} ms");

                    using (RasterImage resultImage = (RasterImage)results[1].GetImage())
                    {
                        resultImage.Save(outputDefaultPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                    }
                }

                // ---------- Auto masking with custom user strokes ----------
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
                    Args = new AutoMaskingArgs
                    {
                        ObjectsPoints = new Point[][]
                        {
                            defaultOptions.DefaultBackgroundStrokes,
                            defaultOptions.DefaultForegroundStrokes
                        }
                    }
                };

                start = DateTime.Now;
                using (MaskingResult results = new ImageMasking(image).Decompose(customOptions))
                {
                    var duration = (DateTime.Now - start).TotalMilliseconds;
                    Console.WriteLine($"Custom strokes duration: {duration} ms");

                    using (RasterImage resultImage = (RasterImage)results[1].GetImage())
                    {
                        resultImage.Save(outputCustomPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
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