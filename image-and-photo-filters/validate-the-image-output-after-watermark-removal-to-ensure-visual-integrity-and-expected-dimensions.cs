using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.FileFormats.Png;

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

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to specific format (PNG in this example)
            var pngImage = (PngImage)image;

            // Define a mask region (example ellipse)
            var mask = new GraphicsPath();
            var figure = new Figure();
            figure.AddShape(new EllipseShape(new RectangleF(100, 100, 200, 150)));
            mask.AddFigure(figure);

            // Configure watermark removal options (Telea algorithm)
            var options = new TeleaWatermarkOptions(mask);

            // Perform watermark removal
            using (RasterImage result = WatermarkRemover.PaintOver(pngImage, options))
            {
                // Validate that the result dimensions match the original
                if (result.Width != pngImage.Width || result.Height != pngImage.Height)
                {
                    Console.Error.WriteLine("Result dimensions do not match the original image.");
                }

                // Save the processed image
                result.Save(outputPath);
            }
        }
    }
}