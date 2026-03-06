using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output JPEG file path
        string outputPath = "output.jpg";

        // Configure JPEG options with a file create source
        JpegOptions jpegOptions = new JpegOptions();
        jpegOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new JPEG image canvas
        using (Image image = Image.Create(jpegOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.Wheat);

            // First figure: rectangle and ellipse
            Figure figure1 = new Figure();
            figure1.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));
            figure1.AddShape(new EllipseShape(new RectangleF(100f, 100f, 200f, 200f)));

            // Second figure: arc and polygon
            Figure figure2 = new Figure();
            figure2.AddShape(new ArcShape(new RectangleF(150f, 150f, 200f, 200f), 0f, 180f));
            figure2.AddShape(new PolygonShape(new[]
            {
                new PointF(300f, 300f),
                new PointF(350f, 250f),
                new PointF(400f, 300f),
                new PointF(350f, 350f)
            }, true));

            // Add figures to an array
            Figure[] figures = new[] { figure1, figure2 };

            // Create a graphics path and add the figures
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddFigures(figures);

            // Draw the path onto the image
            graphics.DrawPath(new Pen(Color.Black, 2), graphicsPath);

            // Save the image (source is already bound to the file)
            image.Save();
        }
    }
}