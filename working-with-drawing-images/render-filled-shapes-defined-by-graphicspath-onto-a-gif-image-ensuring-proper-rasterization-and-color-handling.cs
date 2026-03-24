using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = "output/output.gif";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a new GIF image (400x300 pixels)
        var gifOptions = new GifOptions();
        using (Image image = Image.Create(gifOptions, 400, 300))
        {
            // Initialize graphics object for drawing
            var graphics = new Graphics(image);

            // Clear background to white
            graphics.Clear(Color.White);

            // Build a graphics path with several shapes
            var path = new GraphicsPath();
            var figure = new Figure();

            // Rectangle shape
            figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));
            // Ellipse shape
            figure.AddShape(new EllipseShape(new RectangleF(100f, 80f, 150f, 100f)));
            // Pie shape (arc from 0 to 120 degrees)
            figure.AddShape(new PieShape(new RectangleF(150f, 100f, 120f, 120f), 0f, 120f));

            // Add the figure to the path
            path.AddFigure(figure);

            // Fill the interior of the path with a solid light‑blue brush
            var brush = new SolidBrush(Color.LightBlue);
            graphics.FillPath(brush, path);

            // Optionally draw the outline with a dark‑blue pen
            var pen = new Pen(Color.DarkBlue, 2);
            graphics.DrawPath(pen, path);

            // Save the rendered GIF image
            image.Save(outputPath);
        }
    }
}