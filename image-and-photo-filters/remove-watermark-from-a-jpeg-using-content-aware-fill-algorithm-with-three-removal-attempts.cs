using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Create a mask for the watermark region (example ellipse)
        var mask = new GraphicsPath();
        var figure = new Figure();
        figure.AddShape(new EllipseShape(new RectangleF(100, 100, 200, 150)));
        mask.AddFigure(figure);

        // Configure Content Aware Fill options with three attempts
        var options = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask)
        {
            MaxPaintingAttempts = 3
        };

        // Load the JPEG image, remove the watermark, and save the result
        using (var image = Image.Load(inputPath))
        {
            var jpegImage = (JpegImage)image;

            using (var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(jpegImage, options))
            {
                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the processed image
                result.Save(outputPath);
            }
        }
    }
}