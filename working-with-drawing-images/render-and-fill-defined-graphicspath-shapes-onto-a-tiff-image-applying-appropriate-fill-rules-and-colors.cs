using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "Input.tif";
        string outputPath = "Output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the TIFF image
        using (var image = (TiffImage)Image.Load(inputPath))
        {
            // Create a new GraphicsPath
            var graphicsPath = new GraphicsPath();

            // Define a figure with several shapes
            var figure = new Figure();
            // Rectangle
            figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));
            // Ellipse
            figure.AddShape(new EllipseShape(new RectangleF(300f, 80f, 180f, 180f)));
            // Pie (sector)
            figure.AddShape(new PieShape(new RectangleF(200f, 250f, 200f, 200f), 0f, 120f));

            // Add the figure to the path
            graphicsPath.AddFigure(figure);

            // Create graphics object for drawing
            var graphics = new Graphics(image);

            // Fill the path with a solid blue brush
            var brush = new SolidBrush(Color.Blue);
            graphics.FillPath(brush, graphicsPath);

            // Optionally draw the outline with a black pen
            var pen = new Pen(Color.Black, 2);
            graphics.DrawPath(pen, graphicsPath);

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save the modified image
            image.Save(outputPath);
        }
    }
}