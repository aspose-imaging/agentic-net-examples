using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Output JPEG file path
        string outputPath = "output.jpg";

        // Configure JPEG creation options with a file source
        JpegOptions jpegOptions = new JpegOptions();
        jpegOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new JPEG image of size 500x500 pixels
        using (Image image = Image.Create(jpegOptions, 500, 500))
        {
            // Initialize graphics for drawing on the image
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Create a graphics path to hold figures
            GraphicsPath graphicsPath = new GraphicsPath();

            // First figure with a rectangle, ellipse, and pie shape
            Figure figure1 = new Figure();
            figure1.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 200f)));
            figure1.AddShape(new EllipseShape(new RectangleF(300f, 50f, 150f, 150f)));
            figure1.AddShape(new PieShape(new RectangleF(200f, 250f, 200f, 200f), 0f, 90f));

            // Second figure with an arc and a polygon shape
            Figure figure2 = new Figure();
            figure2.AddShape(new ArcShape(new RectangleF(50f, 300f, 150f, 150f), 0f, 180f));
            figure2.AddShape(new PolygonShape(new[]
            {
                new PointF(350f, 300f),
                new PointF(400f, 350f),
                new PointF(350f, 400f),
                new PointF(300f, 350f)
            }, true));

            // Add both figures to the graphics path as an array
            graphicsPath.AddFigures(new[] { figure1, figure2 });

            // Draw the path using a black pen
            graphics.DrawPath(new Pen(Color.Black, 2), graphicsPath);

            // Save the image (file is already bound to the source)
            image.Save();
        }
    }
}