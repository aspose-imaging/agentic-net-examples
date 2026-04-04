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
        string tempPath = Path.Combine(Path.GetTempPath(), "mask_temp.png");

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Build a list of assumed objects (DetectedObjectType + bounds)
        List<AssumedObjectData> assumedObjects = new List<AssumedObjectData>();
        assumedObjects.Add(new AssumedObjectData(DetectedObjectType.Human, new Rectangle(100, 100, 150, 300)));
        assumedObjects.Add(new AssumedObjectData(DetectedObjectType.Other, new Rectangle(300, 100, 50, 30)));

        // Load the source raster image
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Configure auto‑masking options with the assumed objects
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
                    Source = new FileCreateSource(tempPath)
                },
                BackgroundReplacementColor = Color.Transparent
            };

            // Perform segmentation
            using (MaskingResult results = new ImageMasking(image).Decompose(options))
            {
                // Extract the foreground (masked object) and save it
                using (RasterImage foreground = (RasterImage)results[1].GetImage())
                {
                    foreground.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }
            }
        }

        // Clean up temporary export file
        if (File.Exists(tempPath))
        {
            File.Delete(tempPath);
        }
    }
}