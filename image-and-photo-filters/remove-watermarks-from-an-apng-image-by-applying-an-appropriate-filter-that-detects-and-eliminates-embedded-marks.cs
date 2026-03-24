using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.apng";
        string outputPath = "output.apng";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        using (Image image = Image.Load(inputPath))
        {
            ApngImage apngImage = (ApngImage)image;

            var mask = new GraphicsPath();
            var figure = new Figure();
            figure.AddShape(new EllipseShape(new RectangleF(50, 50, 200, 100)));
            mask.AddFigure(figure);

            var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

            using (RasterImage result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(apngImage, options))
            {
                result.Save(outputPath, new ApngOptions());
            }
        }
    }
}