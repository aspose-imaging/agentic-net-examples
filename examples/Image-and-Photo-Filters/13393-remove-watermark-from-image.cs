using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        using (var image = Image.Load(inputPath))
        {
            var pngImage = (PngImage)image;

            var mask = new GraphicsPath();
            var figure = new Figure();
            figure.AddShape(new EllipseShape(new RectangleF(350, 170, 220, 230)));
            mask.AddFigure(figure);

            var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

            using (var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(pngImage, options))
            {
                result.Save(outputPath);
            }
        }
    }
}