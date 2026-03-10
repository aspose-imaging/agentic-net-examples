using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = args.Length > 0 ? args[0] : "input_image.png";
        string outputPath = args.Length > 1 ? args[1] : "output_image.png";

        // Load the image
        using (var image = Image.Load(inputPath))
        {
            // Cast to RasterImage for watermark removal
            var raster = (RasterImage)image;

            // Define the mask area (example ellipse)
            var mask = new GraphicsPath();
            var figure = new Figure();
            figure.AddShape(new EllipseShape(new RectangleF(350, 170, 220, 230)));
            mask.AddFigure(figure);

            // Create watermark removal options (Telea algorithm)
            var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

            // Perform watermark removal
            using (var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, options))
            {
                // Save the resulting image
                result.Save(outputPath);
            }
        }
    }
}