// HOW-TO: Auto Mask Image With Graph Cut And Median Filter In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output\\result.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
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
                    BackgroundReplacementColor = Color.Transparent
                };

                using (MaskingResult results = new ImageMasking(image).Decompose(maskingOptions))
                using (RasterImage foreground = (RasterImage)results[1].GetImage())
                {
                    var medianOptions = new MedianFilterOptions(3);
                    foreground.Filter(foreground.Bounds, medianOptions);
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
 * 1. When you need to automatically remove the background from a JPEG photo and save the foreground as a transparent PNG for web thumbnails.
 * 2. When you want to isolate objects in scanned documents, apply a median filter to reduce noise, and export the result with an alpha channel for further composition.
 * 3. When building a batch processing tool that extracts subjects from product images, cleans up edges with graph‑cut segmentation, and outputs high‑quality PNGs for e‑commerce catalogs.
 * 4. When creating a C# application that prepares images for machine‑learning pipelines by generating clean foreground masks and smoothing them to improve model accuracy.
 * 5. When developing a photo‑editing feature that lets users quickly separate people from backgrounds, apply noise reduction, and save the edited layer as a PNG with transparency.
 */
