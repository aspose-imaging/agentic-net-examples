using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputTelea = "output_telea.png";
        string outputCaf = "output_caf.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(outputTelea));
        Directory.CreateDirectory(Path.GetDirectoryName(outputCaf));

        // Load the source image
        using (var image = Image.Load(inputPath))
        {
            var pngImage = (PngImage)image;

            // Define the mask (ellipse)
            var mask = new GraphicsPath();
            var figure = new Figure();
            figure.AddShape(new EllipseShape(new RectangleF(350, 170, 570 - 350, 400 - 170)));
            mask.AddFigure(figure);

            // Process with Telea algorithm
            var teleaOptions = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);
            using (var teleaResult = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(pngImage, teleaOptions))
            {
                teleaResult.Save(outputTelea);
            }

            // Process with ContentAwareFill algorithm (default settings)
            var cafOptions = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask)
            {
                MaxPaintingAttempts = 4
            };
            using (var cafResult = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(pngImage, cafOptions))
            {
                cafResult.Save(outputCaf);
            }
        }
    }
}