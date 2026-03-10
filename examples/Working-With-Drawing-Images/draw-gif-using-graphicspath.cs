using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        // Create a file stream for the output GIF image
        using (FileStream stream = new FileStream(@"C:\temp\output.gif", FileMode.Create))
        {
            // Initialize GIF options and assign the stream as the source
            GifOptions gifOptions = new GifOptions();
            gifOptions.Source = new StreamSource(stream);

            // Create a new GIF image with desired dimensions (500x500)
            using (Image image = Image.Create(gifOptions, 500, 500))
            {
                // Initialize Graphics object for drawing on the image
                Graphics graphics = new Graphics(image);

                // Clear the background with a wheat color
                graphics.Clear(Color.Wheat);

                // Create a GraphicsPath and a Figure to hold shapes
                GraphicsPath graphicsPath = new GraphicsPath();
                Figure figure = new Figure();

                // Add a rectangle shape to the figure
                figure.AddShape(new RectangleShape(new RectangleF(10f, 10f, 300f, 300f)));

                // Add an ellipse shape to the figure
                figure.AddShape(new EllipseShape(new RectangleF(50f, 50f, 300f, 300f)));

                // Add a pie shape to the figure
                figure.AddShape(new PieShape(
                    new RectangleF(new PointF(250f, 250f), new SizeF(200f, 200f)),
                    0f, 45f));

                // Add the figure to the graphics path
                graphicsPath.AddFigure(figure);

                // Draw the path using a black pen with thickness 2
                graphics.DrawPath(new Pen(Color.Black, 2), graphicsPath);

                // Save all changes to the GIF image
                image.Save();
            }
        }
    }
}