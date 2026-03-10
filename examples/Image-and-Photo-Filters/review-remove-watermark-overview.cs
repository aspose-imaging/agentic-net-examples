using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths (can be passed as arguments)
        string inputPath = args.Length > 0 ? args[0] : "input.png";
        string outputPath = args.Length > 1 ? args[1] : "output.png";

        // Load the image
        using (var image = Image.Load(inputPath))
        {
            // Cast to the specific format (PNG in this example)
            var pngImage = (PngImage)image;

            // Define the mask region using a graphics path
            var mask = new GraphicsPath();
            var figure = new Figure();
            // Example ellipse mask (x, y, width, height)
            figure.AddShape(new EllipseShape(new RectangleF(350, 170, 570 - 350, 400 - 170)));
            mask.AddFigure(figure);

            // Choose the Telea algorithm for watermark removal
            var options = new TeleaWatermarkOptions(mask);

            // Perform the removal; the result is a new raster image
            using (var result = WatermarkRemover.PaintOver(pngImage, options))
            {
                // Save the cleaned image
                result.Save(outputPath);
            }
        }
    }
}