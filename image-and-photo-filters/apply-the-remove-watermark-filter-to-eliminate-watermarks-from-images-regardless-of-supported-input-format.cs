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
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = Path.Combine("output", "result.png");

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Define the mask region (example ellipse)
        var mask = new GraphicsPath();
        var figure = new Figure();
        figure.AddShape(new EllipseShape(new RectangleF(50, 50, 100, 100)));
        mask.AddFigure(figure);

        // Choose Telea algorithm for watermark removal
        var options = new TeleaWatermarkOptions(mask);

        // Load the image, apply watermark removal, and save the result
        using (var image = Image.Load(inputPath))
        {
            var pngImage = (PngImage)image;
            using (var result = WatermarkRemover.PaintOver(pngImage, options))
            {
                result.Save(outputPath);
            }
        }
    }
}