using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Load the image
        using (var image = Image.Load(inputPath))
        {
            // Cast to specific format (PNG in this case)
            var pngImage = (PngImage)image;

            // Define the watermark mask (ellipse region)
            var mask = new GraphicsPath();
            var figure = new Figure();
            // Ellipse covering the area where the watermark is located
            figure.AddShape(new EllipseShape(new RectangleF(350, 170, 570 - 350, 400 - 170)));
            mask.AddFigure(figure);

            // Create watermark removal options using the Telea algorithm
            var options = new TeleaWatermarkOptions(mask);

            // Remove the watermark
            var result = WatermarkRemover.PaintOver(pngImage, options);

            // Save the processed image
            result.Save(outputPath);
        }
    }
}