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
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <inputImagePath> <outputApngPath>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Export options for the masking step (transparent PNG in memory)
            PngOptions maskExportOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                Source = new StreamSource(new MemoryStream())
            };

            // Configure GraphCut masking with automatic strokes and feathering
            AutoMaskingGraphCutOptions maskingOptions = new AutoMaskingGraphCutOptions
            {
                CalculateDefaultStrokes = true,
                FeatheringRadius = (Math.Max(sourceImage.Width, sourceImage.Height) / 500) + 1,
                Method = SegmentationMethod.GraphCut,
                Decompose = false,
                ExportOptions = maskExportOptions,
                BackgroundReplacementColor = Color.Transparent
            };

            // Perform background removal
            using (MaskingResult maskingResult = new ImageMasking(sourceImage).Decompose(maskingOptions))
            using (RasterImage foreground = (RasterImage)maskingResult[1].GetImage())
            {
                // Save the processed image as a transparent APNG
                ApngOptions apngSaveOptions = new ApngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    DefaultFrameTime = 100,
                    NumPlays = 0,
                    Source = new FileCreateSource(outputPath, false)
                };

                foreground.Save(outputPath, apngSaveOptions);
            }
        }
    }
}