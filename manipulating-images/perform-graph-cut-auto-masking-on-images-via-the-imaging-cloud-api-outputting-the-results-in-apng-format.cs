using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;

class Program
{
    static void Main(string[] args)
    {
        // Hard‑coded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load source image as RasterImage
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Configure GraphCut auto‑masking options
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

            // Perform masking; results[1] holds the foreground object
            using (MaskingResult maskingResult = new ImageMasking(image).Decompose(maskingOptions))
            using (RasterImage foreground = (RasterImage)maskingResult[1].GetImage())
            {
                foreground.Save(outputPath, new ApngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    DefaultFrameTime = 200,
                    NumPlays = 0 // infinite loop
                });
            }
        }
    }
}