// HOW-TO: Perform Graph Cut Segmentation with Assumed Objects and Export PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;
using Aspose.Imaging.Sources;

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
                var assumedObjects = new List<AssumedObjectData>();
                assumedObjects.Add(new AssumedObjectData(DetectedObjectType.Human, new Rectangle(50, 50, 200, 200)));

                var maskingOptions = new AutoMaskingGraphCutOptions
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

                using (MaskingResult results = new ImageMasking(image).Decompose(maskingOptions))
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
 * 1. When you need to isolate a human figure from a JPEG photo and save the cutout as a transparent PNG using graph cut segmentation in C#.
 * 2. When you want to provide the masking algorithm with known object locations (assumed objects) to improve segmentation accuracy on raster images.
 * 3. When you require automatic stroke generation and feathering based on image size for seamless foreground extraction in .NET applications.
 * 4. When you need to replace the background with transparency while preserving the original colors and alpha channel for further compositing.
 * 5. When you are building a batch processing tool that extracts foreground objects from various JPEG files and outputs high‑quality PNG assets.
 */
