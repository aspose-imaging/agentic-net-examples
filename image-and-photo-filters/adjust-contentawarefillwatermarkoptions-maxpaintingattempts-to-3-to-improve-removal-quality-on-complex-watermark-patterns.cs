using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image as a RasterImage
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Define the mask using a graphics path
            var mask = new GraphicsPath();
            var figure = new Figure();
            // Example ellipse mask; adjust coordinates as needed
            figure.AddShape(new EllipseShape(new RectangleF(350, 170, 220, 230)));
            mask.AddFigure(figure);

            // Configure ContentAwareFillWatermarkOptions with MaxPaintingAttempts = 3
            var options = new ContentAwareFillWatermarkOptions(mask)
            {
                MaxPaintingAttempts = 3
            };

            // Perform watermark removal
            using (RasterImage result = WatermarkRemover.PaintOver(sourceImage, options))
            {
                // Save the resulting image
                result.Save(outputPath);
            }
        }
    }
}