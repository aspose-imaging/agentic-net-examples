using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.png";

        using (Aspose.Imaging.RasterImage image = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
        {
            var maskingOptions = new Aspose.Imaging.Masking.Options.AutoMaskingGraphCutOptions
            {
                CalculateDefaultStrokes = true,
                FeatheringRadius = (Math.Max(image.Width, image.Height) / 500) + 1,
                Method = Aspose.Imaging.Masking.Options.SegmentationMethod.GraphCut,
                Decompose = false,
                BackgroundReplacementColor = Aspose.Imaging.Color.Transparent
            };

            using (var maskingResult = new Aspose.Imaging.Masking.ImageMasking(image).Decompose(maskingOptions))
            using (Aspose.Imaging.RasterImage resultImage = (Aspose.Imaging.RasterImage)maskingResult[1].GetImage())
            {
                resultImage.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
            }
        }
    }
}