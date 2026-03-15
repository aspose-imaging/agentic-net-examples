using System;
using Aspose.Imaging;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <inputPath> <outputPath>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        using (var image = Image.Load(inputPath))
        {
            var pngImage = (PngImage)image;

            // Define a mask covering the central area of the image
            var mask = new GraphicsPath();
            var figure = new Figure();

            int x = pngImage.Width / 4;
            int y = pngImage.Height / 4;
            int width = pngImage.Width / 2;
            int height = pngImage.Height / 2;

            figure.AddShape(new EllipseShape(new RectangleF(x, y, width, height)));
            mask.AddFigure(figure);

            var options = new TeleaWatermarkOptions(mask);

            using (var result = WatermarkRemover.PaintOver(pngImage, options))
            {
                result.Save(outputPath);
            }
        }
    }
}