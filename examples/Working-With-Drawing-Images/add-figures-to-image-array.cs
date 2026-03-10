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

        // Create a file stream for the output image
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Set up PNG options with the stream as source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create a new image with the specified dimensions
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.Wheat);

                // Create a graphics path to hold figures
                GraphicsPath graphicsPath = new GraphicsPath();

                // First figure with rectangle and pie shapes
                Figure figure1 = new Figure();
                figure1.AddShape(new RectangleShape(new RectangleF(50, 50, 300, 300)));
                figure1.AddShape(new PieShape(new Rectangle(new Point(110, 110), new Size(200, 200)), 0, 90));

                // Second figure with arc, polygon, and rectangle shapes
                Figure figure2 = new Figure();
                figure2.AddShape(new ArcShape(new RectangleF(10, 10, 300, 300), 0, 45));
                figure2.AddShape(new PolygonShape(
                    new[]
                    {
                        new PointF(150, 10),
                        new PointF(150, 200),
                        new PointF(250, 300),
                        new PointF(350, 400)
                    }, true));
                figure2.AddShape(new RectangleShape(new RectangleF(new Point(250, 250), new Size(200, 200))));

                // Add both figures to the graphics path as an array
                graphicsPath.AddFigures(new[] { figure1, figure2 });

                // Draw the path onto the image
                graphics.DrawPath(new Pen(Color.Black, 2), graphicsPath);

                // Save the image (stream source is already bound)
                image.Save();
            }
        }
    }
}