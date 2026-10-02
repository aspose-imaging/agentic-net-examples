// HOW-TO: Benchmark Median Filter Speed on 4K vs 1080p PNG After Background Removal in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath4K = "input_4k.png";
            string inputPath1080p = "input_1080p.png";
            string outputPath4K = "output_4k.png";
            string outputPath1080p = "output_1080p.png";

            if (!File.Exists(inputPath4K))
            {
                Console.Error.WriteLine($"File not found: {inputPath4K}");
                return;
            }
            if (!File.Exists(inputPath1080p))
            {
                Console.Error.WriteLine($"File not found: {inputPath1080p}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath4K));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath1080p));

            // Process 4K image
            Stopwatch sw4K = new Stopwatch();
            sw4K.Start();
            using (RasterImage image = (RasterImage)Image.Load(inputPath4K))
            {
                var maskingOptions = new AutoMaskingGraphCutOptions
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

                ImageMasking masking = new ImageMasking(image);
                using (MaskingResult result = masking.Decompose(maskingOptions))
                using (RasterImage foreground = (RasterImage)result[1].GetImage())
                {
                    foreground.Filter(foreground.Bounds, new MedianFilterOptions(3));
                    var saveOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new FileCreateSource(outputPath4K, false)
                    };
                    foreground.Save(outputPath4K, saveOptions);
                }
            }
            sw4K.Stop();
            long medianTime4K = sw4K.ElapsedMilliseconds;

            // Process 1080p image
            Stopwatch sw1080p = new Stopwatch();
            sw1080p.Start();
            using (RasterImage image = (RasterImage)Image.Load(inputPath1080p))
            {
                var maskingOptions = new AutoMaskingGraphCutOptions
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

                ImageMasking masking = new ImageMasking(image);
                using (MaskingResult result = masking.Decompose(maskingOptions))
                using (RasterImage foreground = (RasterImage)result[1].GetImage())
                {
                    foreground.Filter(foreground.Bounds, new MedianFilterOptions(3));
                    var saveOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new FileCreateSource(outputPath1080p, false)
                    };
                    foreground.Save(outputPath1080p, saveOptions);
                }
            }
            sw1080p.Stop();
            long medianTime1080p = sw1080p.ElapsedMilliseconds;

            Console.WriteLine($"Median filter time (4K): {medianTime4K} ms");
            Console.WriteLine($"Median filter time (1080p): {medianTime1080p} ms");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When optimizing an image‑processing pipeline, a developer can measure how long a median filter takes on high‑resolution (4K) versus HD (1080p) PNGs after removing the background.
 * 2. When deciding whether to apply background removal before filtering, a developer can compare execution times to choose the most efficient order for large PNG assets.
 * 3. When scaling a photo‑editing application, a developer can use this benchmark to ensure that processing 4K PNGs with Aspose.Imaging stays within acceptable performance limits.
 * 4. When evaluating hardware or server configurations, a developer can run the code to see how median‑filter performance varies with image size after auto‑masking.
 * 5. When documenting performance best practices, a developer can illustrate the impact of image resolution on filter speed by benchmarking 4K and 1080p PNG files with Aspose.Imaging in C#.
 */
