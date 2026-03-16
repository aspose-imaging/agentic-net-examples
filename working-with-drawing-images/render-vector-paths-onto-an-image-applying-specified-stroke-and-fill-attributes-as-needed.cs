using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.FileFormats.Png;

class VectorPathRendering
{
    static void Main()
    {
        // Define image size and format
        int width = 500;
        int height = 500;
        var pngOptions = new PngOptions();

        // Create a new raster image
        using (Image image = Image.Create(pngOptions, width, height))
        {
            // Initialize graphics object for drawing
            var graphics = new Graphics(image);

            // Optional: clear background with a solid color
            graphics.Clear(Color.White);

            // Build a graphics path
            var path = new GraphicsPath();

            // Create a figure (closed for filling)
            var figure = new Figure { IsClosed = true };

            // Add shapes to the figure
            figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));
            figure.AddShape(new EllipseShape(new RectangleF(150f, 120f, 200f, 150f)));

            // Add the figure to the path
            path.AddFigure(figure);

            // Define stroke (pen) and fill (brush) attributes
            var pen = new Pen(Color.Blue, 3);               // Stroke: blue, 3px width
            var brush = new SolidBrush(Color.Yellow);       // Fill: solid yellow

            // Fill the interior of the path
            graphics.FillPath(brush, path);

            // Draw the outline of the path
            graphics.DrawPath(pen, path);

            // Save the resulting image to disk
            image.Save("output.png");
        }
    }
}