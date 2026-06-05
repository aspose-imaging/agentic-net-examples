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
        string inputPath = "input/input.png";
        string outputPath = "output/output.png";
        string tempPath = "temp/tempMask.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(tempPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                var maskingOptions = new AutoMaskingGraphCutOptions
                {
                    CalculateDefaultStrokes = true,
                    FeatheringRadius = 5,
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    ExportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new FileCreateSource(tempPath)
                    },
                    BackgroundReplacementColor = Color.Transparent
                };

                using (MaskingResult results = new ImageMasking(image).Decompose(maskingOptions))
                {
                    using (RasterImage resultImage = (RasterImage)results[1].GetImage())
                    {
                        resultImage.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                    }
                }
            }

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
 * 1. When a developer needs to automatically remove a complex background from a PNG product photo and preserve smooth edges by setting a custom feathering radius with Aspose.Imaging’s AutoMaskingGraphCutOptions.
 * 2. When an e‑commerce site must generate transparent PNG thumbnails from user‑uploaded images with irregular subjects, using graph‑cut segmentation and a 5‑pixel feather to avoid jagged cut‑outs.
 * 3. When a mobile app requires server‑side processing to isolate a foreground object in a PNG, export it with truecolor with alpha, and apply a feathered mask for a professional look using Aspose.Imaging masking results.
 * 4. When a digital marketing tool needs to batch‑process PNG logos, automatically segment them with graph‑cut, apply a feathered mask to smooth the edges, and save the cleaned images with transparent backgrounds.
 * 5. When a photo‑editing service wants to provide an API that accepts PNG files, performs automatic background removal with a configurable feathering radius, and returns the masked image while cleaning up temporary mask files.
 */