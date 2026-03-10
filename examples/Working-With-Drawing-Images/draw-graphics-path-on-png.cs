using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Create a file stream for the output PNG image
        using (FileStream stream = new FileStream("output.png", FileMode.Create))
        {
            // Configure PNG options and associate the stream source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create a new PNG image with width and height of 500 pixels
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize the graphics object for drawing on the image
                Graphics graphics = new Graphics(image);

                // Clear the drawing surface with a light wheat color
                graphics.Clear(Color.Wheat);

                // Create a graphics path to hold complex shapes
                GraphicsPath path = new GraphicsPath();

                // Create a figure and add various shapes to it
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 200f)));
                figure.AddShape(new EllipseShape(new RectangleF(100f, 100f, 200f, 150f)));
                figure.AddShape(new PieShape(new RectangleF(new PointF(150f, 150f), new SizeF(200f, 200f)), 0f, 120f));

                // Add the figure to the graphics path
                path.AddFigure(figure);

                // Draw the constructed path using a black pen with width 3
                graphics.DrawPath(new Pen(Color.Black, 3), path);

                // Save the image to the stream (and thus to the file)
                image.Save();
            }
        }
    }
}