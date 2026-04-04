using System;
using System.IO;
using System.Collections.Generic;
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
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // ---------- First pass: auto‑masking (GraphCut) ----------
        MaskingResult results;
        AutoMaskingGraphCutOptions autoOptions = null;

        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            autoOptions = new AutoMaskingGraphCutOptions
            {
                CalculateDefaultStrokes = true,
                FeatheringRadius = (int)((Math.Max(image.Width, image.Height) / 500) + 1),
                Method = SegmentationMethod.GraphCut,
                Decompose = false,
                ExportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource("temp_auto.png", false)
                },
                BackgroundReplacementColor = Color.Transparent
            };

            results = new ImageMasking(image).Decompose(autoOptions);
        }

        // Retrieve default strokes from the first pass
        Point[] defaultBackgroundStrokes = autoOptions.DefaultBackgroundStrokes;
        Point[] defaultForegroundStrokes = autoOptions.DefaultForegroundStrokes;

        // ---------- Manual correction: add extra foreground points ----------
        Point[] manualForegroundPoints = new Point[]
        {
            new Point(200, 200),
            new Point(210, 210)
        };

        List<Point> combinedForeground = new List<Point>(defaultForegroundStrokes);
        combinedForeground.AddRange(manualForegroundPoints);
        Point[] correctedForegroundStrokes = combinedForeground.ToArray();

        // ---------- Second pass: GraphCut with combined points ----------
        GraphCutMaskingOptions secondOptions = new GraphCutMaskingOptions
        {
            FeatheringRadius = 3,
            Method = SegmentationMethod.GraphCut,
            Decompose = false,
            ExportOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                Source = new FileCreateSource("temp_second.png", false)
            },
            BackgroundReplacementColor = Color.Transparent,
            Args = new AutoMaskingArgs
            {
                ObjectsPoints = new Point[][]
                {
                    defaultBackgroundStrokes,
                    correctedForegroundStrokes
                }
            }
        };

        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        using (MaskingResult finalResult = new ImageMasking(image).Decompose(secondOptions))
        using (RasterImage foreground = (RasterImage)finalResult[1].GetImage())
        {
            foreground.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
        }

        // Clean up temporary files
        if (File.Exists("temp_auto.png")) File.Delete("temp_auto.png");
        if (File.Exists("temp_second.png")) File.Delete("temp_second.png");
    }
}