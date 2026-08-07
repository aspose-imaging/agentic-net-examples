// HOW-TO: How to Use AutoMaskingGraphCutOptions for Precise Image Segmentation in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
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
        // Hard‑coded input and output file paths
        string inputPath = "input.jpg";
        string outputPath = "output.png";
        string refinedOutputPath = "output_refined.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // ---------- First pass – auto calculate default strokes ----------
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                var options = new AutoMaskingGraphCutOptions
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
                    BackgroundReplacementColor = Color.Transparent
                };

                // Perform masking
                using (MaskingResult maskingResult = new ImageMasking(image).Decompose(options))
                using (RasterImage foreground = (RasterImage)maskingResult[1].GetImage())
                {
                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    // Save the first result
                    foreground.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }

                // Capture the automatically generated strokes
                Point[] backgroundStrokes = options.DefaultBackgroundStrokes;
                Point[] foregroundStrokes = options.DefaultForegroundStrokes;
                Rectangle[] objectRectangles = options.DefaultObjectsRectangles;

                // ---------- Second pass – use captured strokes ----------
                // Re‑load the source image because the previous one is disposed
                using (RasterImage image2 = (RasterImage)Image.Load(inputPath))
                {
                    // Disable default stroke calculation and supply captured strokes
                    options.CalculateDefaultStrokes = false;
                    options.Args = new AutoMaskingArgs
                    {
                        ObjectsPoints = new Point[][] { backgroundStrokes, foregroundStrokes },
                        ObjectsRectangles = objectRectangles
                    };

                    using (MaskingResult refinedResult = new ImageMasking(image2).Decompose(options))
                    using (RasterImage refinedForeground = (RasterImage)refinedResult[1].GetImage())
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(refinedOutputPath));
                        refinedForeground.Save(refinedOutputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
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
 * 1. When you need to automatically extract the foreground of a complex JPEG photo and save it as a transparent PNG using Aspose.Imaging in C#.
 * 2. When you want to improve segmentation accuracy by providing both foreground and background strokes with AutoMaskingGraphCutOptions for images with intricate edges.
 * 3. When you are building a web service that removes backgrounds from user‑uploaded images and requires high‑quality alpha channels.
 * 4. When you need to batch‑process product photos to isolate items from cluttered backgrounds before publishing them online.
 * 5. When you are integrating image masking into a desktop application and must ensure the output retains original dimensions and color depth while using graph‑cut segmentation.
 */
