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
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
            {
                var maskingOptions = new AutoMaskingGraphCutOptions
                {
                    Args = new AutoMaskingArgs
                    {
                        ObjectsPoints = new Point[][]
                        {
                            new Point[] { new Point(30, 30), new Point(30, 60), new Point(60, 30) },
                            new Point[] { new Point(120, 120), new Point(150, 150) }
                        }
                    },
                    CalculateDefaultStrokes = false,
                    FeatheringRadius = 3,
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    BackgroundReplacementColor = Color.Transparent,
                    ExportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new StreamSource(new MemoryStream())
                    }
                };

                using (MaskingResult maskingResult = new ImageMasking(sourceImage).Decompose(maskingOptions))
                using (RasterImage foreground = (RasterImage)maskingResult[1].GetImage())
                {
                    float targetDpi = (float)Math.Max(foreground.HorizontalResolution, foreground.VerticalResolution);
                    foreground.HorizontalResolution = targetDpi;
                    foreground.VerticalResolution = targetDpi;

                    foreground.Save(outputPath, new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha
                    });
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}