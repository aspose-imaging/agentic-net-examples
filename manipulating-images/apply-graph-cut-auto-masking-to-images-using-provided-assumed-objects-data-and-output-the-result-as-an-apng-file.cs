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
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Prepare assumed objects for auto‑masking
        var assumedObjects = new List<AssumedObjectData>();
        assumedObjects.Add(new AssumedObjectData(DetectedObjectType.Human, new Rectangle(100, 100, 150, 300)));

        // Temporary file for internal export options
        string tempExportPath = Path.GetTempFileName();

        // Load source image and perform graph‑cut auto‑masking
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            var maskingOptions = new AutoMaskingGraphCutOptions
            {
                AssumedObjects = assumedObjects,
                CalculateDefaultStrokes = true,
                FeatheringRadius = (Math.Max(image.Width, image.Height) / 500) + 1,
                Method = SegmentationMethod.GraphCut,
                Decompose = false,
                ExportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(tempExportPath, false)
                },
                BackgroundReplacementColor = Color.Transparent
            };

            // Execute masking
            using (MaskingResult results = new ImageMasking(image).Decompose(maskingOptions))
            {
                // Retrieve foreground (masked object) image
                using (RasterImage foreground = (RasterImage)results[1].GetImage())
                {
                    // Save result as APNG
                    foreground.Save(outputPath, new ApngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha
                    });
                }
            }
        }

        // Clean up temporary export file
        if (File.Exists(tempExportPath))
        {
            File.Delete(tempExportPath);
        }
    }
}