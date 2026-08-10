// HOW-TO: Reuse AutoMasking GraphCut Strokes for Multiple PNGs in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var inputFiles = new List<string>
            {
                "input1.png",
                "input2.png",
                "input3.png"
            };

            var outputFiles = new List<string>
            {
                "output1.png",
                "output2.png",
                "output3.png"
            };

            for (int i = 0; i < inputFiles.Count; i++)
            {
                string inputPath = inputFiles[i];
                string outputPath = outputFiles[i];

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                string tempPath = Path.Combine(Path.GetTempPath(), $"tempMask_{Guid.NewGuid()}.png");

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    AutoMaskingGraphCutOptions options = new AutoMaskingGraphCutOptions
                    {
                        CalculateDefaultStrokes = true,
                        FeatheringRadius = 3,
                        Method = SegmentationMethod.GraphCut,
                        Decompose = false,
                        ExportOptions = new PngOptions
                        {
                            ColorType = PngColorType.TruecolorWithAlpha,
                            Source = new FileCreateSource(tempPath, false)
                        },
                        BackgroundReplacementColor = Color.Transparent
                    };

                    MaskingResult results = new ImageMasking(image).Decompose(options);

                    options.CalculateDefaultStrokes = false;
                    results = new ImageMasking(image).Decompose(options);

                    using (RasterImage resultImage = (RasterImage)results[1].GetImage())
                    {
                        resultImage.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                    }
                }

                if (File.Exists(tempPath))
                {
                    File.Delete(tempPath);
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
 * 1. When you need to automatically generate accurate transparent masks for a batch of PNG images using graph cut segmentation in C#.
 * 2. When you want to apply consistent stroke calculations across several images to improve mask precision without manual input.
 * 3. When you are building an image‑processing pipeline that replaces backgrounds with transparency for product photos stored as PNG files.
 * 4. When you need to export intermediate mask results to temporary PNG files before saving the final masked images.
 * 5. When you are integrating Aspose.Imaging’s AutoMaskingGraphCutOptions into a .NET application to batch‑process images for web or mobile delivery.
 */
