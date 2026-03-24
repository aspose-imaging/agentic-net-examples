using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output\\result.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (var image = Image.Load(inputPath))
        {
            var pngImage = (PngImage)image;

            var mask = new GraphicsPath();
            var figure = new Figure();
            figure.AddShape(new EllipseShape(new RectangleF(100, 100, 200, 150)));
            mask.AddFigure(figure);

            var options = new TeleaWatermarkOptions(mask);

            using (var result = WatermarkRemover.PaintOver(pngImage, options))
            {
                result.Save(outputPath);
            }
        }
    }
}