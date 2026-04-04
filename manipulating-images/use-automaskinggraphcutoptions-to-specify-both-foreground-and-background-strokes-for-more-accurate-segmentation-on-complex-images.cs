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
        // Hard‑coded paths
        string inputPath = "input.jpg";
        string outputPath = "output.png";
        string refinedOutputPath = "output_refined.png";
        string tempPath = "tempMask.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);
        Directory.CreateDirectory(Path.GetDirectoryName(refinedOutputPath) ?? string.Empty);
        Directory.CreateDirectory(Path.GetDirectoryName(tempPath) ?? string.Empty);

        // Load source image
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // First pass – calculate default background/foreground strokes
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

            using (MaskingResult results = new ImageMasking(image).Decompose(options))
            {
                using (RasterImage resultImage = (RasterImage)results[1].GetImage())
                {
                    resultImage.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }
            }

            // Retrieve the automatically generated strokes
            Point[] backgroundStrokes = options.DefaultBackgroundStrokes;
            Point[] foregroundStrokes = options.DefaultForegroundStrokes;

            // Second pass – supply explicit background and foreground strokes
            options.CalculateDefaultStrokes = false;
            options.Args = new AutoMaskingArgs
            {
                ObjectsPoints = new Point[][] { backgroundStrokes, foregroundStrokes }
            };

            using (MaskingResult refinedResults = new ImageMasking(image).Decompose(options))
            {
                using (RasterImage refinedImage = (RasterImage)refinedResults[1].GetImage())
                {
                    refinedImage.Save(refinedOutputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }
            }
        }

        // Delete temporary file used for ExportOptions
        if (File.Exists(tempPath))
        {
            File.Delete(tempPath);
        }
    }
}