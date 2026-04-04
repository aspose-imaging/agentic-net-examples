using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
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

        // Load the input image as a raster image
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Create a Graphics instance for drawing
            Graphics graphics = new Graphics(image);

            // Build a graphics path containing a rectangle figure
            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure();
            figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 400f, 400f)));
            path.AddFigure(figure);

            // Create a linear gradient brush for the fill
            using (LinearGradientBrush brush = new LinearGradientBrush(
                new RectangleF(50f, 50f, 400f, 400f),
                Color.Blue,
                Color.Red,
                0f))
            {
                // Fill the path with the gradient brush
                graphics.FillPath(brush, path);
            }

            // Save the modified image as PNG
            PngOptions pngOptions = new PngOptions();
            image.Save(outputPath, pngOptions);
        }
    }
}