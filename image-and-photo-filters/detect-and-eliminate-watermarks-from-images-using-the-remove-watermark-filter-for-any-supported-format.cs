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
        // Input and output file paths
        string inputPath = args.Length > 0 ? args[0] : "input.png";
        string outputPath = args.Length > 1 ? args[1] : "output.png";

        // Define the watermark mask (example ellipse)
        var mask = new GraphicsPath();
        var figure = new Figure();
        // Example coordinates: ellipse covering region (350,170) to (570,400)
        figure.AddShape(new EllipseShape(new RectangleF(350, 170, 570 - 350, 400 - 170)));
        mask.AddFigure(figure);

        // Create watermark removal options using the Telea algorithm
        var options = new TeleaWatermarkOptions(mask);

        // Load the image, remove the watermark, and save the result
        using (var image = Image.Load(inputPath))
        {
            var raster = (RasterImage)image;
            using (var result = WatermarkRemover.PaintOver(raster, options))
            {
                result.Save(outputPath);
            }
        }
    }
}