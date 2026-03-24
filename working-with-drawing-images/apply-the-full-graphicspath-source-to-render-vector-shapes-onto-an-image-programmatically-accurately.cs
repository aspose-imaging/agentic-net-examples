using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Define output file path
        string outputPath = @"C:\Temp\GraphicsPathOutput.png";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up PNG options with a file create source
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new image canvas
        using (Image image = Image.Create(pngOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.Wheat);

            // Create a graphics path
            GraphicsPath graphicsPath = new GraphicsPath();

            // First figure with rectangle, ellipse, and pie
            Figure figure1 = new Figure();
            figure1.AddShape(new RectangleShape(new RectangleF(10f, 10f, 300f, 300f)));
            figure1.AddShape(new EllipseShape(new RectangleF(50f, 50f, 300f, 300f)));
            figure1.AddShape(new PieShape(new RectangleF(new PointF(250f, 250f), new SizeF(200f, 200f)), 0f, 45f));

            // Second figure with arc, polygon, and rectangle
            Figure figure2 = new Figure();
            figure2.AddShape(new ArcShape(new RectangleF(10f, 10f, 300f, 300f), 0f, 45f));
            figure2.AddShape(new PolygonShape(new[]
            {
                new PointF(150f, 10f),
                new PointF(150f, 200f),
                new PointF(250f, 300f),
                new PointF(350f, 400f)
            }, true));
            figure2.AddShape(new RectangleShape(new RectangleF(new Point(250, 250), new Size(200, 200))));

            // Add figures to the graphics path
            graphicsPath.AddFigures(new[] { figure1, figure2 });

            // Draw the path with a black pen
            graphics.DrawPath(new Pen(Color.Black, 2), graphicsPath);

            // Save the image (output is already bound to the file source)
            image.Save();
        }
    }
}