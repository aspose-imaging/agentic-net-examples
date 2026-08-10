// HOW-TO: Use DetectedObjectList to Seed Graph Cut for Accurate Background Removal in C# (Aspose.Imaging for .NET)
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
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Temporary file for ExportOptions.Source
        string tempPath = Path.Combine(Path.GetTempPath(), "mask_temp.png");
        Directory.CreateDirectory(Path.GetDirectoryName(tempPath));

        try
        {
            // Load source image as RasterImage
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Seed Graph Cut with assumed objects (example rectangles)
                List<AssumedObjectData> assumedObjects = new List<AssumedObjectData>();
                assumedObjects.Add(new AssumedObjectData(DetectedObjectType.Human, new Rectangle(100, 100, 150, 300)));
                // Add more assumed objects as needed
                // assumedObjects.Add(new AssumedObjectData(DetectedObjectType.Other, new Rectangle(300, 200, 80, 120)));

                // Configure auto masking options
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

                // Perform masking
                using (MaskingResult results = new ImageMasking(image).Decompose(options))
                using (RasterImage foreground = (RasterImage)results[1].GetImage())
                {
                    // Save the foreground (masked object) to the final output
                    foreground.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }

                // Clean up temporary export file
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
 * 1. When you need to automatically remove the background from a JPEG photo while preserving a detected human subject, you can seed the Graph Cut algorithm with a DetectedObjectList and export the result as a PNG with transparency.
 * 2. When building an e‑commerce image pipeline that must isolate products from complex scenes, you can define assumed object rectangles, run auto‑masking Graph Cut, and save the cut‑out for further processing.
 * 3. When creating a photo‑editing tool that lets users quickly extract people from group pictures, you can use the detected object data to guide Graph Cut and generate a high‑quality mask without manual strokes.
 * 4. When preparing assets for augmented‑reality applications, you can segment foreground objects from a source image using Graph Cut seeded by detection results and output a transparent PNG for overlay.
 * 5. When automating batch processing of scanned documents that contain logos or signatures, you can feed the detected object locations into Graph Cut to separate those elements from the page background and save them as separate image files.
 */
