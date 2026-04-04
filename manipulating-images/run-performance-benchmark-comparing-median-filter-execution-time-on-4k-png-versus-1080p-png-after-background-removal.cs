using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath4K = @"C:\Images\image_4k.png";
        string inputPath1080p = @"C:\Images\image_1080p.png";
        string outputPath4K = @"C:\Images\output_4k.png";
        string outputPath1080p = @"C:\Images\output_1080p.png";

        // Verify 4K input file exists
        if (!File.Exists(inputPath4K))
        {
            Console.Error.WriteLine($"File not found: {inputPath4K}");
            return;
        }

        // Verify 1080p input file exists
        if (!File.Exists(inputPath1080p))
        {
            Console.Error.WriteLine($"File not found: {inputPath1080p}");
            return;
        }

        // -------------------- Process 4K image --------------------
        using (Aspose.Imaging.RasterImage image = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath4K))
        {
            var maskExportOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                Source = new StreamSource(new MemoryStream())
            };

            var maskingOptions = new Aspose.Imaging.Masking.Options.AutoMaskingGraphCutOptions
            {
                CalculateDefaultStrokes = true,
                FeatheringRadius = (Math.Max(image.Width, image.Height) / 500) + 1,
                Method = Aspose.Imaging.Masking.Options.SegmentationMethod.GraphCut,
                Decompose = false,
                ExportOptions = maskExportOptions,
                BackgroundReplacementColor = Aspose.Imaging.Color.Transparent
            };

            using (Aspose.Imaging.Masking.Result.MaskingResult maskingResult =
                new Aspose.Imaging.Masking.ImageMasking(image).Decompose(maskingOptions))
            using (Aspose.Imaging.RasterImage foreground = (Aspose.Imaging.RasterImage)maskingResult[1].GetImage())
            {
                var sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                foreground.Filter(foreground.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));
                sw.Stop();

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath4K));

                var saveOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(outputPath4K, false)
                };
                foreground.Save(outputPath4K, saveOptions);

                Console.WriteLine($"Median filter on 4K image took {sw.ElapsedMilliseconds} ms");
            }
        }

        // -------------------- Process 1080p image --------------------
        using (Aspose.Imaging.RasterImage image = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath1080p))
        {
            var maskExportOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                Source = new StreamSource(new MemoryStream())
            };

            var maskingOptions = new Aspose.Imaging.Masking.Options.AutoMaskingGraphCutOptions
            {
                CalculateDefaultStrokes = true,
                FeatheringRadius = (Math.Max(image.Width, image.Height) / 500) + 1,
                Method = Aspose.Imaging.Masking.Options.SegmentationMethod.GraphCut,
                Decompose = false,
                ExportOptions = maskExportOptions,
                BackgroundReplacementColor = Aspose.Imaging.Color.Transparent
            };

            using (Aspose.Imaging.Masking.Result.MaskingResult maskingResult =
                new Aspose.Imaging.Masking.ImageMasking(image).Decompose(maskingOptions))
            using (Aspose.Imaging.RasterImage foreground = (Aspose.Imaging.RasterImage)maskingResult[1].GetImage())
            {
                var sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                foreground.Filter(foreground.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));
                sw.Stop();

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath1080p));

                var saveOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(outputPath1080p, false)
                };
                foreground.Save(outputPath1080p, saveOptions);

                Console.WriteLine($"Median filter on 1080p image took {sw.ElapsedMilliseconds} ms");
            }
        }
    }
}