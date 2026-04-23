using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputTeleaPath = "output/telea_result.png";
        string outputCafPath = "output/contentaware_result.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputTeleaPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputCafPath));

            using (var image = Image.Load(inputPath))
            {
                var pngImage = (PngImage)image;

                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(350, 170, 570 - 350, 400 - 170)));
                mask.AddFigure(figure);

                var teleaOptions = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);
                using (var teleaResult = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(pngImage, teleaOptions))
                {
                    teleaResult.Save(outputTeleaPath);
                }

                var cafOptions = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask)
                {
                    MaxPaintingAttempts = 4
                };
                using (var cafResult = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(pngImage, cafOptions))
                {
                    cafResult.Save(outputCafPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}