using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.FileFormats.Png;

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
            // Cast to specific format (PNG in this example)
            var pngImage = (PngImage)image;

            // Define the watermark mask (example ellipse)
            var mask = new GraphicsPath();
            var figure = new Figure();
            // Adjust the rectangle values to cover the watermark area
            figure.AddShape(new EllipseShape(new RectangleF(100, 100, 200, 50)));
            mask.AddFigure(figure);

            // Use Telea algorithm for inpainting
            var options = new TeleaWatermarkOptions(mask);

            // Remove the watermark
            using (var result = WatermarkRemover.PaintOver(pngImage, options))
            {
                // Save the cleaned image
                result.Save(outputPath);
            }
        }
    }
}