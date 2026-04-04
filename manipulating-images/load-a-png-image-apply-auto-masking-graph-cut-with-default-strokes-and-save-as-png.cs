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
        string tempFilePath = "tempMask.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
        Directory.CreateDirectory(Path.GetDirectoryName(tempFilePath));

        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            AutoMaskingGraphCutOptions options = new AutoMaskingGraphCutOptions
            {
                CalculateDefaultStrokes = true,
                FeatheringRadius = (Math.Max(image.Width, image.Height) / 500) + 1,
                Method = SegmentationMethod.GraphCut,
                Decompose = false,
                ExportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(tempFilePath, false)
                },
                BackgroundReplacementColor = Color.Transparent
            };

            MaskingResult results = new ImageMasking(image).Decompose(options);

            using (RasterImage resultImage = (RasterImage)results[1].GetImage())
            {
                resultImage.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
            }
        }

        if (File.Exists(tempFilePath))
        {
            File.Delete(tempFilePath);
        }
    }
}