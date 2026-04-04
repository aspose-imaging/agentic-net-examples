using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;

class Program
{
    static void Main(string[] args)
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

        // Load the PNG image
        using (var image = Image.Load(inputPath))
        {
            var pngImage = (PngImage)image;

            // Create mask using GraphicsPath
            var mask = new GraphicsPath();
            var figure = new Figure();
            figure.AddShape(new EllipseShape(new RectangleF(350, 170, 570 - 350, 400 - 170)));
            mask.AddFigure(figure);

            // Configure watermark removal options
            var options = new TeleaWatermarkOptions(mask);

            // Perform watermark removal
            using (var result = WatermarkRemover.PaintOver(pngImage, options))
            {
                // Save the result as PNG
                var pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                result.Save(outputPath, pngOptions);
            }
        }
    }
}