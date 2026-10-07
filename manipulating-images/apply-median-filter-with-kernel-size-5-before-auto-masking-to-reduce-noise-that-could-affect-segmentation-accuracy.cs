// HOW-TO: Apply Median Filter and Auto Mask Image to PNG with Transparency in C# (Aspose.Imaging for .NET)
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
        string outputPath = "output\\masked.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                // Apply median filter with kernel size 5
                raster.Filter(raster.Bounds, new MedianFilterOptions(5));

                // Configure auto masking options
                var maskingOptions = new AutoMaskingGraphCutOptions
                {
                    CalculateDefaultStrokes = true,
                    FeatheringRadius = (Math.Max(raster.Width, raster.Height) / 500) + 1,
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    ExportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new StreamSource(new MemoryStream())
                    },
                    BackgroundReplacementColor = Color.Transparent
                };

                var masking = new ImageMasking(raster);
                using (MaskingResult results = masking.Decompose(maskingOptions))
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
 * 1. When you need to remove salt‑and‑pepper noise from a JPEG before extracting the foreground for a product catalog image with a transparent background.
 * 2. When you want to automatically segment a scanned photograph into foreground and background using graph‑cut segmentation while preserving edge detail.
 * 3. When you are preparing images for web overlays and must generate PNG files with an alpha channel after denoising and auto‑masking.
 * 4. When you process batch photos in a C# application and require a single call to filter and mask each image to create cut‑out assets for UI design.
 * 5. When you need to improve segmentation accuracy on noisy medical or satellite images by applying a median filter before performing auto‑masking.
 */
