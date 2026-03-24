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
        string inputPath = "input.jpg";
        string outputPath = "output.apng";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        string tempPngPath = Path.Combine(Path.GetTempPath(), "mask_temp.png");

        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            var maskingOptions = new AutoMaskingGraphCutOptions
            {
                CalculateDefaultStrokes = true,
                FeatheringRadius = (Math.Max(sourceImage.Width, sourceImage.Height) / 500) + 1,
                Method = SegmentationMethod.GraphCut,
                Decompose = false,
                ExportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(tempPngPath, false)
                },
                BackgroundReplacementColor = Color.Transparent
            };

            using (MaskingResult results = new ImageMasking(sourceImage).Decompose(maskingOptions))
            {
                using (RasterImage foreground = (RasterImage)results[1].GetImage())
                {
                    foreground.Save(outputPath, new ApngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        DefaultFrameTime = 200,
                        NumPlays = 0
                    });
                }
            }

            if (File.Exists(tempPngPath))
            {
                File.Delete(tempPngPath);
            }
        }
    }
}