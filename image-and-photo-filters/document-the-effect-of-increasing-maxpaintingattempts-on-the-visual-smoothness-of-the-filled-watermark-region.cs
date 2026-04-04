using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPathLow = "output_attempt1.png";
        string outputPathHigh = "output_attempt5.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(outputPathLow));
        Directory.CreateDirectory(Path.GetDirectoryName(outputPathHigh));

        // Load the source image
        using (var image = Image.Load(inputPath))
        {
            var pngImage = (PngImage)image;

            // Define a simple elliptical mask
            var mask = new GraphicsPath();
            var figure = new Figure();
            figure.AddShape(new EllipseShape(new RectangleF(100, 100, 200, 200)));
            mask.AddFigure(figure);

            // -------------------------------------------------
            // Low MaxPaintingAttempts (e.g., 1)
            // Fewer attempts may lead to visible artifacts or less smooth fill.
            // -------------------------------------------------
            var optionsLow = new ContentAwareFillWatermarkOptions(mask)
            {
                MaxPaintingAttempts = 1
            };

            using (var resultLow = WatermarkRemover.PaintOver(pngImage, optionsLow))
            {
                resultLow.Save(outputPathLow, new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(outputPathLow, false)
                });
            }

            // -------------------------------------------------
            // High MaxPaintingAttempts (e.g., 5)
            // More attempts allow the algorithm to choose the best variant,
            // resulting in a smoother and more visually pleasing fill.
            // -------------------------------------------------
            var optionsHigh = new ContentAwareFillWatermarkOptions(mask)
            {
                MaxPaintingAttempts = 5
            };

            using (var resultHigh = WatermarkRemover.PaintOver(pngImage, optionsHigh))
            {
                resultHigh.Save(outputPathHigh, new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(outputPathHigh, false)
                });
            }
        }
    }
}