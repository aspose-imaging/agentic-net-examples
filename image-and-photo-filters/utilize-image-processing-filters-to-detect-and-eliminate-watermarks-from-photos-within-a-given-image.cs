using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Expect input and output file paths as arguments
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <program> <inputImagePath> <outputImagePath>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        // Load the image
        using (var image = Image.Load(inputPath))
        {
            // Cast to RasterImage as required by WatermarkRemover
            var raster = (RasterImage)image;

            // Define a mask region (example ellipse)
            var mask = new GraphicsPath();
            var figure = new Figure();
            // Adjust coordinates as needed to cover the watermark area
            figure.AddShape(new EllipseShape(new RectangleF(100, 100, 200, 50)));
            mask.AddFigure(figure);

            // Create watermark removal options using the Telea algorithm
            var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

            // Perform watermark removal
            using (var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, options))
            {
                // Save the cleaned image
                result.Save(outputPath);
            }
        }
    }
}