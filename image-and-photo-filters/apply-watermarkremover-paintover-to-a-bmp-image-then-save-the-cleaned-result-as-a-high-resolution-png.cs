using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (var image = Image.Load(inputPath))
            {
                var bmpImage = (BmpImage)image;

                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(50, 50, 200, 150)));
                mask.AddFigure(figure);

                var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

                using (var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(bmpImage, options))
                {
                    var pngOptions = new PngOptions();
                    result.Save(outputPath, pngOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}