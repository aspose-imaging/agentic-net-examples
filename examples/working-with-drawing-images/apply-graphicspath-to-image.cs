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
            // Set PNG options and bind the stream as the source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create a 500x500 PNG image
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing on the image
                Graphics graphics = new Graphics(image);

                // Clear the canvas with a wheat color
                graphics.Clear(Color.Wheat);

                // Create a graphics path to hold figures
                GraphicsPath graphicsPath = new GraphicsPath();

                // Create a figure and add shapes to it
                Figure figure = new Figure();
                // Rectangle shape
                figure.AddShape(new RectangleShape(new RectangleF(10f, 10f, 300f, 300f)));
                // Ellipse shape
                figure.AddShape(new EllipseShape(new RectangleF(50f, 50f, 300f, 300f)));
                // Pie shape
                figure.AddShape(new PieShape(
                    new RectangleF(new PointF(250f, 250f), new SizeF(200f, 200f)),
                    0f, 45f));

                // Add the figure to the graphics path
                graphicsPath.AddFigure(figure);

                // Draw the path using a black pen
                graphics.DrawPath(new Pen(Color.Black, 2), graphicsPath);

                // Save the image (stream is already bound)
                image.Save();
            }
        }
    }
}