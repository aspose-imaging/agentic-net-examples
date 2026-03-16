using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Set up BMP options and output file source
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource("output.bmp", false);

        // Create a new image with the specified options
        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.Wheat);

            // Create a graphics path to hold multiple figures
            GraphicsPath graphicsPath = new GraphicsPath();

            // First figure with rectangle and ellipse shapes
            Figure figure1 = new Figure();
            figure1.AddShape(new RectangleShape(new RectangleF(10f, 10f, 200f, 200f)));
            figure1.AddShape(new EllipseShape(new RectangleF(50f, 50f, 150f, 150f)));

            // Second figure with a polygon shape
            Figure figure2 = new Figure();
            figure2.AddShape(new PolygonShape(
                new[] { new PointF(100f, 10f), new PointF(150f, 100f), new PointF(50f, 100f) },
                true));

            // Attach the figures array to the graphics path
            graphicsPath.AddFigures(new[] { figure1, figure2 });

            // Draw the combined path onto the image
            graphics.DrawPath(new Pen(Color.Black, 2), graphicsPath);

            // Save the image (output is bound to the FileCreateSource)
            image.Save();
        }
    }
}