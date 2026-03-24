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
        string inputPath = "input\\image.png";
        string outputPath = "output\\result.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (var image = Image.Load(inputPath))
        {
            // Cast to specific format (PNG in this example)
            var pngImage = (PngImage)image;

            // Define the mask region (ellipse in this case)
            var mask = new GraphicsPath();
            var figure = new Figure();
            figure.AddShape(new EllipseShape(new RectangleF(350, 170, 570 - 350, 400 - 170)));
            mask.AddFigure(figure);

            // Configure Telea algorithm options
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