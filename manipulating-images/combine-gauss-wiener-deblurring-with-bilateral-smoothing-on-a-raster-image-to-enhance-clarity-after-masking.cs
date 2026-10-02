// HOW-TO: Apply Graph Cut Auto Masking with Bilateral Smoothing and Sharpen in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

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

                ImageMasking masking = new ImageMasking(image);
                using (MaskingResult maskResult = masking.Decompose(maskingOptions))
                {
                    using (RasterImage masked = (RasterImage)maskResult[1].GetImage())
                    {
                        masked.Filter(masked.Bounds, new BilateralSmoothingFilterOptions());
                        masked.Filter(masked.Bounds, new SharpenFilterOptions());

                        masked.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
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
 * 1. When you need to automatically separate foreground objects from a PNG photo and then enhance the edges while reducing noise, this code creates a mask with graph cut and applies bilateral smoothing followed by sharpening.
 * 2. When preparing product images for e‑commerce, you can use this routine to remove the background, smooth skin tones, and sharpen details before saving a transparent PNG.
 * 3. When restoring scanned documents that contain blurry text, the combination of auto‑masking, deblurring via bilateral smoothing, and a final sharpen filter improves readability without losing the original layout.
 * 4. When building a C# desktop application that lets users clean up portrait photos, the code demonstrates how to generate a mask, smooth the skin, and enhance facial features in one pipeline.
 * 5. When integrating Aspose.Imaging into a batch‑processing service to clean up large sets of PNG assets, this example shows how to automate masking, noise reduction, and edge enhancement for consistent output.
 */
