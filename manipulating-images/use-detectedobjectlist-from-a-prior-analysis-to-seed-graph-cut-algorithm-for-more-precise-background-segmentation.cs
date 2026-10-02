// HOW-TO: Use Graph Cut with Detected Objects for Precise Background Removal in C# (Aspose.Imaging for .NET)
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

        string outputDir = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrEmpty(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        try
        {
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Example assumed objects; replace with actual DetectedObjectList conversion as needed
                List<AssumedObjectData> assumedObjects = new List<AssumedObjectData>();
                // Example: assume a human object at rectangle (50,50,200,400)
                assumedObjects.Add(new AssumedObjectData(DetectedObjectType.Human, new Rectangle(50, 50, 200, 400)));

                AutoMaskingGraphCutOptions maskingOptions = new AutoMaskingGraphCutOptions
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
                    BackgroundReplacementColor = Color.Transparent,
                    AssumedObjects = assumedObjects
                };

                ImageMasking masking = new ImageMasking(image);
                using (MaskingResult results = masking.Decompose(maskingOptions))
                {
                    using (RasterImage foreground = (RasterImage)results[1].GetImage())
                    {
                        foreground.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
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
 * 1. When you need to automatically remove the background of a photo while preserving a detected person for e‑commerce product listings, using Graph Cut segmentation and exporting to a transparent PNG.
 * 2. When you want to replace the background of a portrait with a custom color or image in a C# application, leveraging assumed object data to guide the mask.
 * 3. When building an image‑processing pipeline that must isolate objects identified by a machine‑learning model before further analysis or compositing.
 * 4. When creating a batch‑processing tool that converts JPEGs to PNGs with alpha channels, ensuring accurate edge detection around detected objects.
 * 5. When integrating Aspose.Imaging into a desktop app to generate cut‑out assets for marketing materials, using Graph Cut and assumed objects for high‑quality masks.
 */
