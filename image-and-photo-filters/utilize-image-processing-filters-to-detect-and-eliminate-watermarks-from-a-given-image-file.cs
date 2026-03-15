using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Expect input and output file paths as command‑line arguments
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: WatermarkRemover <inputImagePath> <outputImagePath>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        // Load the source image
        using (var image = Image.Load(inputPath))
        {
            // Cast to the concrete format (PNG in this example)
            var pngImage = (PngImage)image;

            // Define a mask region (ellipse) that covers the watermark area
            var mask = new GraphicsPath();
            var figure = new Figure();
            // Adjust the rectangle values to match the watermark location in your image
            figure.AddShape(new EllipseShape(new RectangleF(50, 50, 100, 100)));
            mask.AddFigure(figure);

            // Use the Telea algorithm for watermark removal
            var options = new TeleaWatermarkOptions(mask);

            // Perform the removal; the method returns a new RasterImage
            using (var result = WatermarkRemover.PaintOver(pngImage, options))
            {
                // Save the cleaned image
                result.Save(outputPath);
            }
        }
    }
}