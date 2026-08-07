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
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.png";

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
 * 1. When a developer needs to automatically remove the background from a high‑resolution JPEG photograph and export the isolated subject as a PNG with an alpha channel for use in web design.
 * 2. When an e‑commerce platform wants to batch‑process product images, applying graph‑cut segmentation to generate transparent PNG thumbnails without manually drawing strokes.
 * 3. When a mobile app backend must extract foreground objects from user‑uploaded photos in C# and store them as lossless PNGs for later compositing in AR experiences.
 * 4. When a digital asset management system requires a fast, code‑only solution to separate subjects from complex backgrounds using Aspose.Imaging’s AutoMaskingGraphCutOptions with feathering to smooth edges.
 * 5. When a developer is benchmarking the performance of Aspose.Imaging’s graph‑cut auto‑masking with default strokes versus custom strokes to choose the optimal configuration for real‑time image editing tools.
 */