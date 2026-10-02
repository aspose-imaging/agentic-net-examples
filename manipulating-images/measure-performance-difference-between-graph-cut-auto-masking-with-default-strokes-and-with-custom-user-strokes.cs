// HOW-TO: Compare Graph Cut Auto Masking Performance With Default vs Custom Strokes in C# (Aspose.Imaging for .NET)
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
        string outputDefaultPath = "output\\default.png";
        string outputCustomPath = "output\\custom.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputDefaultPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputCustomPath));

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

                DateTime startDefault = DateTime.Now;
                using (MaskingResult defaultResult = new ImageMasking(image).Decompose(defaultOptions))
                using (RasterImage defaultForeground = (RasterImage)defaultResult[1].GetImage())
                {
                    defaultForeground.Save(outputDefaultPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }
                DateTime endDefault = DateTime.Now;
                TimeSpan durationDefault = endDefault - startDefault;
                Console.WriteLine($"Default strokes masking time: {durationDefault.TotalMilliseconds} ms");

                var customPoints = new Point[][] { new Point[] { new Point(image.Width / 2, image.Height / 2) } };
                var customArgs = new AutoMaskingArgs { ObjectsPoints = customPoints };

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
                    Args = customArgs
                };

                DateTime startCustom = DateTime.Now;
                using (MaskingResult customResult = new ImageMasking(image).Decompose(customOptions))
                using (RasterImage customForeground = (RasterImage)customResult[1].GetImage())
                {
                    customForeground.Save(outputCustomPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }
                DateTime endCustom = DateTime.Now;
                TimeSpan durationCustom = endCustom - startCustom;
                Console.WriteLine($"Custom strokes masking time: {durationCustom.TotalMilliseconds} ms");
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
 * 1. When you need to benchmark how quickly Aspose.Imaging’s Graph Cut auto‑masking generates a foreground using default system‑generated strokes versus user‑defined strokes on the same JPEG.
 * 2. When you want to evaluate whether adding custom stroke input improves segmentation speed for batch processing of product photos in a C# application.
 * 3. When you are comparing the runtime impact of default versus custom stroke configurations before integrating auto‑masking into an image‑editing workflow.
 * 4. When you must demonstrate performance differences of Graph Cut segmentation for transparent PNG export in a proof‑of‑concept for a web service.
 * 5. When you are optimizing resource usage by measuring execution time of default and custom stroke masking to choose the most efficient option for a desktop photo‑enhancement tool.
 */
