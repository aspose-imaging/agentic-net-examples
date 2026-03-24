using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the TIFF image
        using (var image = (TiffImage)Image.Load(inputPath))
        {
            // Create graphics object for drawing
            var graphics = new Graphics(image);

            // Define a custom polygon shape (star-like)
            var points = new[]
            {
                new PointF(100f, 50f),
                new PointF(150f, 150f),
                new PointF(50f, 100f),
                new PointF(150f, 100f),
                new PointF(50f, 150f)
            };

            // Create a figure and add the polygon shape
            var figure = new Figure();
            figure.AddShape(new PolygonShape(points, true));

            // Build the graphics path and add the figure
            var graphicsPath = new GraphicsPath();
            graphicsPath.AddFigure(figure);

            // Draw the path onto the image
            graphics.DrawPath(new Pen(Color.Blue, 3), graphicsPath);

            // Save the modified image to the output path
            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            image.Save(outputPath, tiffOptions);
        }
    }
}