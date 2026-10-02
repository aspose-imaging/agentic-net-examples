// HOW-TO: Reuse Strokes With AutoMasking GraphCut For Batch PNG Masking In C# (Aspose.Imaging for .NET)
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
            string inputDir = "InputImages";
            string outputDir = "OutputImages";

            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                Console.WriteLine($"Input directory created at: {inputDir}. Add PNG files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            string[] files = Directory.GetFiles(inputDir, "*.png");
            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + "_masked.png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    AutoMaskingGraphCutOptions firstOptions = new AutoMaskingGraphCutOptions
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
                    using (MaskingResult firstResult = masking.Decompose(firstOptions))
                    {
                        // Second pass reusing strokes
                        AutoMaskingGraphCutOptions secondOptions = new AutoMaskingGraphCutOptions
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
                            BackgroundReplacementColor = Color.Transparent
                        };

                        using (MaskingResult secondResult = masking.Decompose(secondOptions))
                        {
                            using (RasterImage finalForeground = (RasterImage)secondResult[1].GetImage())
                            {
                                finalForeground.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                            }
                        }
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
 * 1. When you need to automatically generate accurate transparent masks for many PNG photos in a folder without manually drawing strokes each time.
 * 2. When you want to improve background removal quality by reusing calculated strokes across multiple graph‑cut iterations on similar images.
 * 3. When you are building a C# batch‑processing tool that must export masked PNGs with an alpha channel for downstream compositing.
 * 4. When you require feathered edges proportional to image size to avoid harsh borders in the resulting masked images.
 * 5. When you need to automate mask creation for a series of product images while keeping memory usage low by loading each PNG as a RasterImage.
 */
