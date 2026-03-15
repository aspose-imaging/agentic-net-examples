using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <program> <inputImagePath> <outputImagePath>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        using (var image = Image.Load(inputPath))
        {
            var raster = (RasterImage)image;

            var mask = new GraphicsPath();
            var figure = new Figure();
            figure.AddShape(new RectangleShape(new RectangleF(0, 0, raster.Width, raster.Height)));
            mask.AddFigure(figure);

            var options = new TeleaWatermarkOptions(mask);

            using (var result = WatermarkRemover.PaintOver(raster, options))
            {
                result.Save(outputPath);
            }
        }
    }
}