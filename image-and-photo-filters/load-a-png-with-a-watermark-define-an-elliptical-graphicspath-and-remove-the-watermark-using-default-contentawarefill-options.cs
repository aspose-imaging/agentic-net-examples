using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output/output.png";

        try
        {
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

                // Define an elliptical mask using GraphicsPath
                var mask = new GraphicsPath();
                var figure = new Figure();
                // Example ellipse coordinates (x, y, width, height)
                figure.AddShape(new EllipseShape(new RectangleF(100, 100, 200, 150)));
                mask.AddFigure(figure);

                // Use default ContentAwareFill options
                var options = new ContentAwareFillWatermarkOptions(mask);

                // Remove the watermark
                using (var result = WatermarkRemover.PaintOver(pngImage, options))
                {
                    // Save the processed image
                    result.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}