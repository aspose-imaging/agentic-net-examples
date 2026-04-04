using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;
using Aspose.Imaging.Shapes;

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

        // Load the image
        using (var image = Image.Load(inputPath))
        {
            var pngImage = (PngImage)image;

            // Create a mask composed of multiple ellipses
            var mask = new GraphicsPath();

            // First ellipse
            var figure1 = new Figure();
            figure1.AddShape(new EllipseShape(new RectangleF(100, 80, 150, 120)));
            mask.AddFigure(figure1);

            // Second ellipse
            var figure2 = new Figure();
            figure2.AddShape(new EllipseShape(new RectangleF(300, 200, 180, 140)));
            mask.AddFigure(figure2);

            // Third ellipse
            var figure3 = new Figure();
            figure3.AddShape(new EllipseShape(new RectangleF(500, 50, 200, 160)));
            mask.AddFigure(figure3);

            // Configure watermark removal options (using Telea algorithm)
            var options = new TeleaWatermarkOptions(mask);

            // Perform watermark removal
            using (RasterImage result = WatermarkRemover.PaintOver(pngImage, options))
            {
                // Save the result as PNG
                var saveOptions = new PngOptions();
                result.Save(outputPath, saveOptions);
            }
        }
    }
}