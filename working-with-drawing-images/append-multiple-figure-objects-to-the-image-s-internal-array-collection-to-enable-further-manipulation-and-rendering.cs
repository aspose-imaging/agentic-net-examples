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
        string outputPath = "output.png";

        // Set up PNG options with a file create source
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new image canvas (500x500)
        using (Image image = Image.Create(pngOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.Wheat);

            // Create a graphics path to hold figures
            GraphicsPath graphicsPath = new GraphicsPath();

            // First figure with a rectangle and an ellipse
            Figure figure1 = new Figure();
            figure1.AddShape(new RectangleShape(new RectangleF(10f, 10f, 200f, 200f)));
            figure1.AddShape(new EllipseShape(new RectangleF(250f, 250f, 150f, 150f)));

            // Second figure with a polygon
            Figure figure2 = new Figure();
            figure2.AddShape(new PolygonShape(
                new[] { new PointF(100f, 300f), new PointF(150f, 350f), new PointF(200f, 300f) },
                true));

            // Append both figures to the graphics path
            graphicsPath.AddFigures(new[] { figure1, figure2 });

            // Render the path onto the image using a black pen
            graphics.DrawPath(new Pen(Color.Black, 2), graphicsPath);

            // Save the image (the file is already bound to the source)
            image.Save();
        }
    }
}