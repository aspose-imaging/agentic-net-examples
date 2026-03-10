using System;
using Aspose.Imaging;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.FileFormats.Png;

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
            // Cast to the specific format (PNG in this example)
            var pngImage = (PngImage)image;

            // Define the mask region using a graphics path
            var mask = new GraphicsPath();
            var figure = new Figure();
            figure.AddShape(new EllipseShape(new RectangleF(350, 170, 570 - 350, 400 - 170)));
            mask.AddFigure(figure);

            // Create watermark removal options (Telea algorithm)
            var options = new TeleaWatermarkOptions(mask);

            // Remove the watermark
            using (RasterImage result = WatermarkRemover.PaintOver(pngImage, options))
            {
                // Save the processed image
                result.Save(outputPath);
            }
        }

        Console.WriteLine("Watermark removal completed.");
    }
}