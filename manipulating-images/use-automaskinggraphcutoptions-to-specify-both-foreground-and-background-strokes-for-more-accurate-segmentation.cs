// HOW-TO: Use AutoMaskingGraphCutOptions With Foreground And Background Strokes In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output/result.png";
            string tempPath = Path.Combine(Path.GetTempPath(), "mask_temp.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // First pass: calculate default strokes
                var options = new AutoMaskingGraphCutOptions
                {
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

                using (MaskingResult firstResult = new ImageMasking(image).Decompose(options))
                {
                    // Retrieve calculated strokes
                    Point[] backgroundStrokes = options.DefaultBackgroundStrokes;
                    Point[] foregroundStrokes = options.DefaultForegroundStrokes;

                    // Second pass: use explicit strokes
                    options.CalculateDefaultStrokes = false;
                    options.Args = new AutoMaskingArgs
                    {
                        ObjectsPoints = new Point[][]
                        {
                            backgroundStrokes,
                            foregroundStrokes
                        }
                    };

                    using (MaskingResult secondResult = new ImageMasking(image).Decompose(options))
                    {
                        using (RasterImage foreground = (RasterImage)secondResult[1].GetImage())
                        {
                            foreground.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                        }
                    }
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

/*
 * Real-World Use Cases:
 * 1. When you need to extract a subject from a complex JPEG photo and save it as a transparent PNG for web thumbnails.
 * 2. When you want to automatically generate foreground and background masks for product images before placing them on different backgrounds.
 * 3. When you are building a photo‑editing tool that lets users refine segmentation by providing custom strokes for accurate cut‑out.
 * 4. When you need to batch‑process scanned documents to separate text (foreground) from paper (background) for OCR preprocessing.
 * 5. When you are creating AR assets and require precise object isolation from cluttered scenes using graph‑cut segmentation in C#.
 */
