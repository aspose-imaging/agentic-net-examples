// HOW-TO: Correct Graph Cut Masking Errors with Manual Point Array in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hard‑coded paths
            string inputPath = "input.jpg";
            string outputPath = "output.png";
            string finalOutputPath = "output_corrected.png";

            // Validate input file
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(finalOutputPath));

            // ---------- First pass: auto‑masking with default strokes ----------
            MaskingResult results;
            AutoMaskingGraphCutOptions autoOptions;
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                autoOptions = new AutoMaskingGraphCutOptions
                {
                    CalculateDefaultStrokes = true,
                    FeatheringRadius = (Math.Max(image.Width, image.Height) / 500) + 1,
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    ExportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new FileCreateSource("temp_auto.png", false)
                    },
                    BackgroundReplacementColor = Color.Transparent
                };

                results = new ImageMasking(image).Decompose(autoOptions);
            }

            // Save the initial foreground result (optional)
            using (RasterImage resultImage = (RasterImage)results[1].GetImage())
            {
                resultImage.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
            }

            // Retrieve default strokes for manual correction
            Point[] backgroundStrokes = autoOptions.DefaultBackgroundStrokes;
            Point[] foregroundStrokes = autoOptions.DefaultForegroundStrokes;
            Rectangle[] objectRectangles = autoOptions.DefaultObjectsRectangles;

            // ---------- Add manual correction points ----------
            var correctedBackground = new List<Point>();
            if (backgroundStrokes != null) correctedBackground.AddRange(backgroundStrokes);
            correctedBackground.Add(new Point(100, 100));
            correctedBackground.Add(new Point(150, 100));

            var correctedForeground = new List<Point>();
            if (foregroundStrokes != null) correctedForeground.AddRange(foregroundStrokes);
            correctedForeground.Add(new Point(500, 200));

            // ---------- Second pass: re‑run masking with combined points ----------
            GraphCutMaskingOptions secondOptions = new GraphCutMaskingOptions
            {
                FeatheringRadius = 3,
                Method = SegmentationMethod.GraphCut,
                Decompose = false,
                ExportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource("temp_second.png", false)
                },
                BackgroundReplacementColor = Color.Transparent,
                Args = new AutoMaskingArgs
                {
                    ObjectsPoints = new Point[][]
                    {
                        correctedBackground.ToArray(),
                        correctedForeground.ToArray()
                    },
                    ObjectsRectangles = objectRectangles
                }
            };

            using (RasterImage image2 = (RasterImage)Image.Load(inputPath))
            {
                results = new ImageMasking(image2).Decompose(secondOptions);
            }

            // Save the final corrected foreground result
            using (RasterImage finalImage = (RasterImage)results[1].GetImage())
            {
                finalImage.Save(finalOutputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
            }

            // Clean up temporary files
            if (File.Exists("temp_auto.png")) File.Delete("temp_auto.png");
            if (File.Exists("temp_second.png")) File.Delete("temp_second.png");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to automatically extract the foreground of a JPEG photo using Aspose.Imaging’s GraphCut algorithm but must fix small missed spots with a custom point array before saving as a transparent PNG.
 * 2. When you want to generate a mask for product images, apply auto‑masking, then manually refine edges around logos or text that the algorithm didn’t capture correctly.
 * 3. When building a batch‑processing tool that removes backgrounds from scanned documents and requires precise correction of tiny artifacts that remain after the initial auto‑mask.
 * 4. When integrating image segmentation into a C# web service and need to combine default strokes with user‑provided correction points to ensure clean cut‑outs for e‑commerce thumbnails.
 * 5. When creating a photo‑editing workflow that replaces the background with transparency, using Aspose.Imaging to auto‑mask and then applying a manual point array to perfect the mask for complex hair or fur details.
 */
