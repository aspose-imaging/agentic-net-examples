using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;
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
                var autoOptions = new AutoMaskingGraphCutOptions
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

                MaskingResult autoResult = new ImageMasking(image).Decompose(autoOptions);

                Point[] defaultBackgroundStrokes = autoOptions.DefaultBackgroundStrokes;
                Point[] defaultForegroundStrokes = autoOptions.DefaultForegroundStrokes;
                Rectangle[] defaultObjectRectangles = autoOptions.DefaultObjectsRectangles;

                var correctedForeground = new List<Point>();
                if (defaultForegroundStrokes != null)
                    correctedForeground.AddRange(defaultForegroundStrokes);
                correctedForeground.Add(new Point(200, 200));
                correctedForeground.Add(new Point(210, 210));

                Point[][] objectsPoints = new Point[2][];
                objectsPoints[0] = defaultBackgroundStrokes ?? new Point[0];
                objectsPoints[1] = correctedForeground.ToArray();

                var secondOptions = new GraphCutMaskingOptions
                {
                    FeatheringRadius = 3,
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    ExportOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new StreamSource(new MemoryStream())
                    },
                    BackgroundReplacementColor = Color.Transparent,
                    Args = new AutoMaskingArgs
                    {
                        ObjectsPoints = objectsPoints,
                        ObjectsRectangles = defaultObjectRectangles
                    }
                };

                using (RasterImage image2 = (RasterImage)Image.Load(inputPath))
                {
                    MaskingResult finalResult = new ImageMasking(image2).Decompose(secondOptions);
                    using (RasterImage finalForeground = (RasterImage)finalResult[1].GetImage())
                    {
                        finalForeground.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}