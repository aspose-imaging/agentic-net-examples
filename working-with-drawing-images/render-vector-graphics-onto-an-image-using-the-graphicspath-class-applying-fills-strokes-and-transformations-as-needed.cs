using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\output.png";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create PNG image options
        var pngOptions = new PngOptions();

        // Create a new image with the specified size
        using (Image image = Image.Create(pngOptions, 500, 500))
        {
            // Initialize graphics object for drawing
            var graphics = new Graphics(image);

            // Clear the background with a light gray color
            graphics.Clear(Color.LightGray);

            // Create a graphics path to hold vector shapes
            var graphicsPath = new GraphicsPath();

            // Create a figure and add shapes to it
            var figure = new Figure();

            // Rectangle shape
            figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));

            // Ellipse shape
            figure.AddShape(new EllipseShape(new RectangleF(100f, 100f, 200f, 150f)));

            // Pie shape (arc from 0 to 120 degrees)
            figure.AddShape(new PieShape(new RectangleF(150f, 150f, 200f, 200f), 0f, 120f));

            // Add the figure to the graphics path
            graphicsPath.AddFigure(figure);

            // Fill the path with a semi‑transparent blue brush
            var fillBrush = new SolidBrush(Color.FromArgb(128, Color.Blue));
            graphics.FillPath(fillBrush, graphicsPath);

            // Draw the outline of the path with a red pen
            var outlinePen = new Pen(Color.Red, 3);
            graphics.DrawPath(outlinePen, graphicsPath);

            // Save the image to the output file
            image.Save(outputPath);
        }
    }
}