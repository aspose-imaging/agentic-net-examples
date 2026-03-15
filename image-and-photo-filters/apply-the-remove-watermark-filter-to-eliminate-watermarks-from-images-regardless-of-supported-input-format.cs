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
        // Expect input and output file paths as command‑line arguments
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <program> <inputImagePath> <outputImagePath>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        // Load the source image (any supported raster format)
        using (var image = Image.Load(inputPath))
        {
            var rasterImage = (RasterImage)image;

            // Define a mask region (example ellipse)
            var mask = new GraphicsPath();
            var figure = new Figure();
            figure.AddShape(new EllipseShape(new RectangleF(350, 170, 220, 230)));
            mask.AddFigure(figure);

            // Use the Telea algorithm for watermark removal
            var options = new TeleaWatermarkOptions(mask);

            // Perform watermark removal
            using (var result = WatermarkRemover.PaintOver(rasterImage, options))
            {
                // Save the cleaned image; format inferred from output file extension
                result.Save(outputPath);
            }
        }
    }
}