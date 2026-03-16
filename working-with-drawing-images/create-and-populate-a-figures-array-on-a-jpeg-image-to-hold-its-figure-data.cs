using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Define output JPEG file path
        string outputPath = Path.Combine(Environment.CurrentDirectory, "output.jpg");

        // Configure JPEG options with a file create source
        JpegOptions jpegOptions = new JpegOptions();
        jpegOptions.Source = new FileCreateSource(outputPath, false);

        // Create a JPEG image with specified dimensions
        using (Image image = Image.Create(jpegOptions, 500, 500))
        {
            // Initialize graphics for drawing on the image
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.Wheat);

            // Create a graphics path to hold figures
            GraphicsPath graphicsPath = new GraphicsPath();

            // First figure with an ellipse and a pie shape
            Figure figure1 = new Figure();
            figure1.AddShape(new EllipseShape(new RectangleF(50, 50, 300, 300)));
            figure1.AddShape(new PieShape(new Rectangle(new Point(110, 110), new Size(200, 200)), 0, 90));

            // Second figure with an arc, polygon, and rectangle shape
            Figure figure2 = new Figure();
            figure2.AddShape(new ArcShape(new RectangleF(10, 10, 300, 300), 0, 45));
            figure2.AddShape(new PolygonShape(new[]
            {
                new PointF(150, 10),
                new PointF(150, 200),
                new PointF(250, 300),
                new PointF(350, 400)
            }, true));
            figure2.AddShape(new RectangleShape(new RectangleF(new Point(250, 250), new Size(200, 200))));

            // Populate an array of figures and add to the graphics path
            Figure[] figures = new[] { figure1, figure2 };
            graphicsPath.AddFigures(figures);

            // Draw the path using a black pen
            graphics.DrawPath(new Pen(Color.Black, 2), graphicsPath);

            // Save the image (source is already bound to the file)
            image.Save();
        }
    }
}