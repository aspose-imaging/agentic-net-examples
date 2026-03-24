using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\Images\input.apng";
        string outputPath = @"C:\Images\output.apng";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            var pngExport = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                Source = new StreamSource(new MemoryStream())
            };

            var maskingOptions = new AutoMaskingGraphCutOptions
            {
                CalculateDefaultStrokes = true,
                FeatheringRadius = (Math.Max(sourceImage.Width, sourceImage.Height) / 500) + 1,
                Method = SegmentationMethod.GraphCut,
                Decompose = false,
                ExportOptions = pngExport,
                BackgroundReplacementColor = Color.Transparent
            };

            var masking = new ImageMasking(sourceImage);
            using (MaskingResult maskingResult = masking.Decompose(maskingOptions))
            using (RasterImage foreground = (RasterImage)maskingResult[1].GetImage())
            {
                var apngSaveOptions = new ApngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    DefaultFrameTime = 100,
                    NumPlays = 0
                };
                foreground.Save(outputPath, apngSaveOptions);
            }
        }
    }
}