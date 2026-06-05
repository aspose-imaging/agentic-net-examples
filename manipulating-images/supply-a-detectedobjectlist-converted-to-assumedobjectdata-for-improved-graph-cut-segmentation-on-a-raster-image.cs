using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output.png";
        string tempPath = Path.Combine(Path.GetTempPath(), "mask_temp.png");

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Sample detected objects list (type, bounds)
            var detectedObjects = new List<(Aspose.Imaging.Masking.Options.DetectedObjectType type, Rectangle bounds)>
            {
                (Aspose.Imaging.Masking.Options.DetectedObjectType.Human, new Rectangle(100, 100, 150, 300)),
                (Aspose.Imaging.Masking.Options.DetectedObjectType.Other, new Rectangle(300, 100, 50, 30))
            };

            // Convert to AssumedObjectData list
            var assumedObjects = new List<Aspose.Imaging.Masking.Options.AssumedObjectData>();
            foreach (var obj in detectedObjects)
            {
                assumedObjects.Add(new Aspose.Imaging.Masking.Options.AssumedObjectData(obj.type, obj.bounds));
            }

            // Load image as RasterImage
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Configure AutoMaskingGraphCutOptions with assumed objects
                var options = new Aspose.Imaging.Masking.Options.AutoMaskingGraphCutOptions
                {
                    AssumedObjects = assumedObjects,
                    CalculateDefaultStrokes = true,
                    FeatheringRadius = (Math.Max(image.Width, image.Height) / 500) + 1,
                    Method = Aspose.Imaging.Masking.Options.SegmentationMethod.GraphCut,
                    Decompose = false,
                    ExportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new FileCreateSource(tempPath, false)
                    },
                    BackgroundReplacementColor = Color.Transparent
                };

                // Perform masking
                var results = new Aspose.Imaging.Masking.ImageMasking(image).Decompose(options);

                // Save foreground (masked object) as PNG
                using (RasterImage resultImage = (RasterImage)results[1].GetImage())
                {
                    resultImage.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }
            }

            // Clean up temporary file
            if (File.Exists(tempPath))
            {
                File.Delete(tempPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}