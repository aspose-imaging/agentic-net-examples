using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = args.Length > 0 ? args[0] : "input.png";
        string outputPath = args.Length > 1 ? args[1] : "output.png";

        // Load the image
        using (var image = Image.Load(inputPath))
        {
            // Cast to the specific format (PNG in this example)
            var pngImage = (PngImage)image;

            // Define the mask region (example ellipse)
            var mask = new GraphicsPath();
            var figure = new Figure();
            figure.AddShape(new EllipseShape(new RectangleF(350, 170, 570 - 350, 400 - 170)));
            mask.AddFigure(figure);

            // Create watermark removal options using the Telea algorithm
            var options = new TeleaWatermarkOptions(mask);

            // Perform watermark removal
            using (RasterImage result = WatermarkRemover.PaintOver(pngImage, options))
            {
                // Save the cleaned image
                result.Save(outputPath);
            }
        }
    }
}