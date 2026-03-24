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
        string inputPath = "input\\watermarked.png";
        string outputPath = "output\\cleaned.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image and remove the watermark
        using (var image = Image.Load(inputPath))
        {
            var pngImage = (PngImage)image;

            // Define the mask region (example ellipse)
            var mask = new GraphicsPath();
            var figure = new Figure();
            figure.AddShape(new EllipseShape(new RectangleF(350, 170, 570 - 350, 400 - 170)));
            mask.AddFigure(figure);

            // Use Telea algorithm for watermark removal
            var options = new TeleaWatermarkOptions(mask);

            // Perform removal
            using (var result = WatermarkRemover.PaintOver(pngImage, options))
            {
                result.Save(outputPath);
            }
        }
    }
}