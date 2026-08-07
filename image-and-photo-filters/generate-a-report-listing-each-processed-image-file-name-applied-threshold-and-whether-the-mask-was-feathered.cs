// HOW-TO: Create Masked PNGs and Report Thresholds Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            // Hard‑coded input files and associated parameters
            var inputs = new List<string>
            {
                @"C:\Images\input1.jpg",
                @"C:\Images\input2.jpg"
            };

            var thresholds = new List<int> { 5, 12 };               // example threshold values
            var feathered = new List<bool> { true, false };        // whether feathering is applied

            // Header for the report
            Console.WriteLine("FileName\tThreshold\tFeathered");

            for (int i = 0; i < inputs.Count; i++)
            {
                string inputPath = inputs[i];
                int threshold = thresholds[i];
                bool isFeathered = feathered[i];

                // Verify input existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Prepare output path
                string outputDir = @"C:\Images\Output";
                Directory.CreateDirectory(outputDir);
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + "_masked.png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Configure masking options
                var maskingOptions = new GraphCutMaskingOptions
                {
                    FeatheringRadius = isFeathered ? threshold : 0,
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    ExportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new StreamSource(new MemoryStream())
                    },
                    BackgroundReplacementColor = Color.Transparent
                };

                // Perform masking
                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                using (MaskingResult result = new ImageMasking(image).Decompose(maskingOptions))
                using (RasterImage masked = (RasterImage)result[1].GetImage())
                {
                    // Save the masked image
                    masked.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }

                // Output report line
                Console.WriteLine($"{Path.GetFileName(inputPath)}\t{threshold}\t{isFeathered}");
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
 * 1. When you need to batch‑process JPEG photos to extract foreground objects and save the results as PNG masks with optional feathering.
 * 2. When you want to generate a simple console report that lists each processed file, the graph‑cut threshold used, and whether feathering was applied.
 * 3. When you have to ensure output directories exist before saving masked images in an automated image‑processing pipeline.
 * 4. When you need to apply different threshold values per image to control the sensitivity of the graph‑cut segmentation.
 * 5. When you must handle missing source files gracefully while continuing to process the remaining images.
 */
