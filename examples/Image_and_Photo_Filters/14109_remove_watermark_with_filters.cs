using System;
using Aspose.Imaging;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Load the image and cast to RasterImage
        using (var image = Image.Load(inputPath))
        {
            var rasterImage = (RasterImage)image;

            // Create a mask using GraphicsPath and an ellipse shape
            var mask = new GraphicsPath();
            var figure = new Figure();
            // Define ellipse bounds (x, y, width, height)
            figure.AddShape(new EllipseShape(new RectangleF(350, 170, 570 - 350, 400 - 170)));
            mask.AddFigure(figure);

            // Initialize watermark removal options (Telea algorithm)
            var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

            // Perform watermark removal
            using (var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(rasterImage, options))
            {
                // Save the cleaned image
                result.Save(outputPath);
            }
        }
    }
}