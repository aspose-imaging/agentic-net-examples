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
        // Hard‑coded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Seed list for Graph Cut – replace with actual detected objects if available
        List<AssumedObjectData> assumedObjects = new List<AssumedObjectData>();
        assumedObjects.Add(new AssumedObjectData(DetectedObjectType.Human, new Rectangle(100, 100, 150, 300)));
        assumedObjects.Add(new AssumedObjectData(DetectedObjectType.Other, new Rectangle(300, 200, 80, 120)));

        // Load the source image as a RasterImage
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Configure Graph Cut options with the assumed objects
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

            // Perform the masking operation
            using (MaskingResult maskingResult = new ImageMasking(image).Decompose(options))
            {
                // Retrieve the foreground (object) image
                using (RasterImage foreground = (RasterImage)maskingResult[1].GetImage())
                {
                    // Save the result as a PNG with transparency
                    foreground.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }
            }
        }
    }
}