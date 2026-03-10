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
        // Output file path
        string outputPath = "output.bmp";

        // Set up BMP options
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new image with the specified options
        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.Wheat);

            // First figure with an ellipse and a pie shape
            Figure figure1 = new Figure();
            figure1.AddShape(new Shapes.EllipseShape(new RectangleF(50, 50, 300, 300)));
            figure1.AddShape(new Shapes.PieShape(new Rectangle(110, 110, 200, 200), 0, 90));

            // Second figure with an arc, polygon, and rectangle shape
            Figure figure2 = new Figure();
            figure2.AddShape(new Shapes.ArcShape(new RectangleF(10, 10, 300, 300), 0, 45));
            figure2.AddShape(new Shapes.PolygonShape(
                new[] { new PointF(150, 10), new PointF(150, 200), new PointF(250, 300), new PointF(350, 400) },
                true));
            figure2.AddShape(new Shapes.RectangleShape(new RectangleF(new Point(250, 250), new Size(200, 200))));

            // Create an array of figures
            Figure[] figures = new[] { figure1, figure2 };

            // Initialize a graphics path with the figures array
            GraphicsPath path = new GraphicsPath(figures);

            // Draw the path using a black pen
            graphics.DrawPath(new Pen(Color.Black, 2), path);

            // Save the image to the file
            image.Save();
        }
    }
}