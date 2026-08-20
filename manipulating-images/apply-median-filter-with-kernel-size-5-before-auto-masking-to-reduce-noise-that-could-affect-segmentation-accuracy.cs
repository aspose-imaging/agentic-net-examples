// HOW-TO: Apply Median Filter And Auto‑Mask Image With GraphCut In C# (Aspose.Imaging for .NET)
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
        try
        {
            string inputPath = @"C:\Images\input.jpg";
            string outputPath = @"C:\Images\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Apply median filter with kernel size 5
                image.Filter(image.Bounds, new MedianFilterOptions(5));

                // Prepare masking export options (in‑memory)
                var exportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new StreamSource(new MemoryStream())
                };

                // Configure auto‑masking options (GraphCut)
                var maskingOptions = new AutoMaskingGraphCutOptions
                {
                    CalculateDefaultStrokes = true,
                    FeatheringRadius = (Math.Max(image.Width, image.Height) / 500) + 1,
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    ExportOptions = exportOptions,
                    BackgroundReplacementColor = Color.Transparent
                };

                // Perform masking
                using (MaskingResult maskingResult = new ImageMasking(image).Decompose(maskingOptions))
                using (RasterImage foreground = (RasterImage)maskingResult[1].GetImage())
                {
                    // Save the foreground (masked) image
                    foreground.Save(outputPath, new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha
                    });
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
 * 1. When you need to remove noise from a noisy photograph before extracting the foreground for a product catalog, you can apply a 5‑pixel median filter and then auto‑mask the subject using GraphCut in C#.
 * 2. When preparing images for transparent PNG overlays in a web application, you can denoise the source JPEG, segment the foreground, and export a PNG with an alpha channel using Aspose.Imaging.
 * 3. When building an automated image‑processing pipeline that separates objects from complex backgrounds in scanned documents, you can use the median filter to smooth speckles and then perform GraphCut segmentation to obtain clean masks.
 * 4. When creating visual assets for mobile games where background removal must be fast and reliable, you can apply a median filter to reduce artifacts and generate a transparent PNG mask programmatically in .NET.
 * 5. When integrating image cleanup and foreground extraction into a document‑management system, you can use this code to pre‑process images, automatically generate masks, and store the results as lossless PNG files.
 */
