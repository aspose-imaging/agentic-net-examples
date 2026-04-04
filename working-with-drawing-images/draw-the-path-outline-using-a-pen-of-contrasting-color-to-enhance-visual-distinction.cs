using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\PathOutline.png";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a new PNG image with the specified dimensions
        var pngOptions = new PngOptions();
        using (Image image = Image.Create(pngOptions, 500, 500))
        {
            // Initialize graphics object for drawing
            var graphics = new Graphics(image);

            // Clear the background with a light color
            graphics.Clear(Color.White);

            // Build a graphics path containing a rectangle and an ellipse
            var path = new GraphicsPath();
            var figure = new Figure();

            // Add a rectangle shape
            figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 400f, 400f)));

            // Add an ellipse shape inside the rectangle
            figure.AddShape(new EllipseShape(new RectangleF(100f, 100f, 300f, 300f)));

            // Add the figure to the path
            path.AddFigure(figure);

            // Draw the path outline with a contrasting pen (black on white)
            var pen = new Pen(Color.Black, 3);
            graphics.DrawPath(pen, path);

            // Save the resulting image
            image.Save(outputPath);
        }
    }
}