using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Output file path and canvas dimensions
        string outputPath = "output.gif";
        int width = 500;
        int height = 500;

        // Configure GIF creation options with a file source
        GifOptions gifOptions = new GifOptions();
        gifOptions.Source = new FileCreateSource(outputPath, false);

        // Create a GIF image canvas bound to the output file
        using (Image image = Image.Create(gifOptions, width, height))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White); // Set background color

            // Build a graphics path containing multiple filled shapes
            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure();

            // Rectangle shape
            figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));
            // Ellipse shape
            figure.AddShape(new EllipseShape(new RectangleF(300f, 50f, 150f, 150f)));
            // Polygon shape
            PointF[] polygonPoints = new PointF[]
            {
                new PointF(100f, 300f),
                new PointF(200f, 250f),
                new PointF(300f, 300f),
                new PointF(250f, 400f),
                new PointF(150f, 400f)
            };
            figure.AddShape(new PolygonShape(polygonPoints, true));

            // Add the figure to the path
            path.AddFigure(figure);

            // Fill the combined path with a solid brush
            SolidBrush fillBrush = new SolidBrush(Color.LightBlue);
            graphics.FillPath(fillBrush, path);

            // Optional: draw an outline around the filled shapes
            Pen outlinePen = new Pen(Color.DarkBlue, 2);
            graphics.DrawPath(outlinePen, path);

            // Save the image (file is already bound via FileCreateSource)
            image.Save();
        }
    }
}