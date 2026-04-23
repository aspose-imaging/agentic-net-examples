using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                var options = new Aspose.Imaging.Masking.Options.AutoMaskingGraphCutOptions
                {
                    CalculateDefaultStrokes = true,
                    FeatheringRadius = (Math.Max(image.Width, image.Height) / 500) + 1,
                    Method = Aspose.Imaging.Masking.Options.SegmentationMethod.GraphCut,
                    Decompose = false,
                    ExportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new FileCreateSource("tempMask.png")
                    },
                    BackgroundReplacementColor = Aspose.Imaging.Color.Transparent
                };

                var masking = new Aspose.Imaging.Masking.ImageMasking(image);
                using (Aspose.Imaging.Masking.Result.MaskingResult results = masking.Decompose(options))
                {
                    using (RasterImage resultImage = (RasterImage)results[1].GetImage())
                    {
                        resultImage.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                    }
                }

                if (File.Exists("tempMask.png"))
                {
                    File.Delete("tempMask.png");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}