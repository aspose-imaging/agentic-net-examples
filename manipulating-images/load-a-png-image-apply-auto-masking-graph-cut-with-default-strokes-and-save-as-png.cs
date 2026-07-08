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
        string inputPath = "input.png";
        string outputPath = "output.png";

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

                MaskingResult results = new ImageMasking(image).Decompose(maskingOptions);

                using (RasterImage resultImage = (RasterImage)results[1].GetImage())
                {
                    resultImage.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
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
 * 1. When building an e‑commerce platform that automatically removes backgrounds from product PNG photos using Aspose.Imaging’s auto‑masking Graph Cut algorithm.
 * 2. When creating a photo‑editing service that isolates the main subject in user‑uploaded PNG images by applying default strokes and saving the result with a transparent background.
 * 3. When developing a batch‑processing tool that extracts foreground objects from PNG assets for game UI, leveraging C# image loading, Graph Cut segmentation, and PNG export with alpha channel.
 * 4. When implementing an automated workflow that cleans up scanned PNG illustrations by generating cut‑out images with transparent backgrounds for digital publishing.
 * 5. When integrating a C# application that generates PNG thumbnails with removed backgrounds for social‑media sharing, using Aspose.Imaging’s auto‑masking Graph Cut feature.
 */