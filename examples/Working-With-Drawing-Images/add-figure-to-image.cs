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
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.Wheat);

                // Create a graphics path and a figure
                GraphicsPath graphicsPath = new GraphicsPath();
                Figure figure = new Figure();

                // Add shapes to the figure
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 300f, 300f)));
                figure.AddShape(new EllipseShape(new RectangleF(100f, 100f, 200f, 200f)));
                figure.AddShape(new PieShape(new RectangleF(new PointF(200f, 200f), new SizeF(150f, 150f)), 0f, 45f));

                // Add the figure to the graphics path
                graphicsPath.AddFigure(figure);

                // Draw the path with a black pen
                graphics.DrawPath(new Pen(Color.Black, 2), graphicsPath);

                // Save the image (stream is already bound)
                image.Save();
            }
        }
    }
}