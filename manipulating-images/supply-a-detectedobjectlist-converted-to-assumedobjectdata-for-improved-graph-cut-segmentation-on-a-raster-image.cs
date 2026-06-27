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
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

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
 * 1. When a developer needs to convert a DetectedObjectList into AssumedObjectData and apply AutoMaskingGraphCutOptions to automatically remove the background of JPEG product photos and save them as transparent PNGs for e‑commerce catalogs.
 * 2. When a developer wants to feed a list of detected humans into AssumedObjectData to perform graph‑cut segmentation that isolates people in security camera footage while leaving other objects untouched.
 * 3. When a developer builds a medical imaging application that transforms a DetectedObjectList of patient silhouettes into AssumedObjectData to achieve precise graph‑cut separation from scan backgrounds.
 * 4. When a developer adds a feature to an image‑editing app that converts user‑selected objects into AssumedObjectData, runs graph‑cut masking, and replaces the original background with a custom color or transparency.
 * 5. When a developer automates a content‑management pipeline by converting detection results into AssumedObjectData for graph‑cut masking, producing PNG thumbnails with transparent backgrounds for social‑media sharing.
 */