using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputTeleaPath = "output_telea.png";
        string outputCafPath = "output_caf.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(outputTeleaPath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputCafPath));

        // Load the image
        using (var image = Image.Load(inputPath))
        {
            // Cast to RasterImage for watermark removal
            var rasterImage = (RasterImage)image;

            // Define mask using an ellipse shape
            var mask = new GraphicsPath();
            var figure = new Figure();
            figure.AddShape(new EllipseShape(new RectangleF(350, 170, 570 - 350, 400 - 170)));
            mask.AddFigure(figure);

            // Telea algorithm
            var teleaOptions = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);
            using (var teleaResult = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(rasterImage, teleaOptions))
            {
                teleaResult.Save(outputTeleaPath);
            }

            // Content Aware Fill algorithm
            var cafOptions = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask)
            {
                MaxPaintingAttempts = 4
            };
            using (var cafResult = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(rasterImage, cafOptions))
            {
                cafResult.Save(outputCafPath);
            }
        }
    }
}