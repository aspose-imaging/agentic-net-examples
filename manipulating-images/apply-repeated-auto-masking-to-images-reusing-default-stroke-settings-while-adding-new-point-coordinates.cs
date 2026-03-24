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
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.png";
        string tempExportPath = "tempMask.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);
        Directory.CreateDirectory(Path.GetDirectoryName(tempExportPath) ?? string.Empty);

        // Load source image
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // First masking pass – calculate default strokes
            AutoMaskingGraphCutOptions options = new AutoMaskingGraphCutOptions
            {
                CalculateDefaultStrokes = true,
                FeatheringRadius = (Math.Max(image.Width, image.Height) / 500) + 1,
                Method = SegmentationMethod.GraphCut,
                Decompose = false,
                ExportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(tempExportPath, false)
                },
                BackgroundReplacementColor = Color.Transparent
            };

            using (MaskingResult maskingResult = new ImageMasking(image).Decompose(options))
            {
                // Retrieve default strokes and rectangles
                Point[] defaultBackgroundStrokes = options.DefaultBackgroundStrokes;
                Point[] defaultForegroundStrokes = options.DefaultForegroundStrokes;
                Rectangle[] defaultObjectRectangles = options.DefaultObjectsRectangles;

                // Prepare new point arrays (add one extra point to each)
                Point[] newBackgroundStrokes = new Point[defaultBackgroundStrokes.Length + 1];
                defaultBackgroundStrokes.CopyTo(newBackgroundStrokes, 0);
                newBackgroundStrokes[defaultBackgroundStrokes.Length] = new Point(200, 200); // example point

                Point[] newForegroundStrokes = new Point[defaultForegroundStrokes.Length + 1];
                defaultForegroundStrokes.CopyTo(newForegroundStrokes, 0);
                newForegroundStrokes[defaultForegroundStrokes.Length] = new Point(300, 300); // example point

                // Re‑use options for second pass
                options.CalculateDefaultStrokes = false;
                options.Args = new AutoMaskingArgs
                {
                    ObjectsPoints = new Point[][]
                    {
                        newBackgroundStrokes,
                        newForegroundStrokes
                    },
                    ObjectsRectangles = defaultObjectRectangles
                };
            }

            // Second masking pass with added points
            using (MaskingResult secondResult = new ImageMasking(image).Decompose(options))
            {
                using (RasterImage foreground = (RasterImage)secondResult[1].GetImage())
                {
                    foreground.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }
            }
        }

        // Clean up temporary export file
        if (File.Exists(tempExportPath))
        {
            File.Delete(tempExportPath);
        }
    }
}