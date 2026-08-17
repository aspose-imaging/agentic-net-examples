// HOW-TO: Convert DetectedObjectList To AssumedObjectData For Graph Cut Segmentation In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
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
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                List<AssumedObjectData> assumedObjects = new List<AssumedObjectData>();
                assumedObjects.Add(new AssumedObjectData(DetectedObjectType.Human, new Rectangle(100, 100, 150, 300)));
                assumedObjects.Add(new AssumedObjectData(DetectedObjectType.Other, new Rectangle(300, 200, 80, 120)));

                AutoMaskingGraphCutOptions options = new AutoMaskingGraphCutOptions
                {
                    AssumedObjects = assumedObjects,
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

                using (MaskingResult results = new ImageMasking(image).Decompose(options))
                {
                    using (RasterImage resultImage = (RasterImage)results[1].GetImage())
                    {
                        resultImage.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
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
 * 1. When you need to automatically separate foreground objects like people from a JPEG photo and export the result as a transparent PNG using Graph Cut segmentation.
 * 2. When you want to provide custom object hints (human, other) to improve mask accuracy for image masking in a .NET application.
 * 3. When you are building a photo‑editing tool that replaces the background of raster images with transparency while preserving edge quality.
 * 4. When you require programmatic generation of assumed object data from detection results to feed Aspose.Imaging’s AutoMaskingGraphCutOptions.
 * 5. When you need to process large images and calculate an appropriate feathering radius automatically for smooth mask edges.
 */
