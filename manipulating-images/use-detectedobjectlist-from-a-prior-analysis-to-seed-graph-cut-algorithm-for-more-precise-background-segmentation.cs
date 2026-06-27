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

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                var assumedObjects = new List<AssumedObjectData>
                {
                    new AssumedObjectData(DetectedObjectType.Human, new Rectangle(100, 100, 150, 300)),
                    new AssumedObjectData(DetectedObjectType.Other, new Rectangle(300, 200, 80, 120))
                };

                var options = new AutoMaskingGraphCutOptions
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

                MaskingResult results = new ImageMasking(image).Decompose(options);

                using (RasterImage foreground = (RasterImage)results[1].GetImage())
                {
                    foreground.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
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
 * 1. When building an e‑commerce platform that automatically removes product backgrounds from JPEG photos and exports the results as transparent PNGs for catalog listings.
 * 2. When creating a photo‑editing app that lets users quickly isolate people or objects in a portrait by providing rough bounding boxes and then applying a Graph Cut algorithm for precise masking.
 * 3. When developing a social‑media image‑processing pipeline that replaces complex scene backgrounds with a solid color or transparency while preserving fine details like hair using assumed object rectangles.
 * 4. When implementing an automated document‑scanning solution that separates scanned handwritten notes from the paper background by seeding the segmentation with detected text regions.
 * 5. When integrating a machine‑learning workflow that supplies detected object coordinates to improve the accuracy of background removal before feeding the foreground PNGs into a downstream AI model.
 */