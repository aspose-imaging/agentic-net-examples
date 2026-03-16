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
        // Create a file stream for the output PNG image
        using (FileStream stream = new FileStream(@"output.png", FileMode.Create))
        {
            // Set up PNG options and associate the stream as the source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create a new image with the desired dimensions (500x500)
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize Graphics object for drawing on the image
                Graphics graphics = new Graphics(image);

                // Clear the background with a wheat color
                graphics.Clear(Color.Wheat);

                // Create a GraphicsPath to hold custom shapes
                GraphicsPath graphicsPath = new GraphicsPath();

                // Create a Figure and add various shapes to it
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(10f, 10f, 300f, 300f)));
                figure.AddShape(new EllipseShape(new RectangleF(50f, 50f, 300f, 300f)));
                figure.AddShape(new PieShape(new RectangleF(new PointF(250f, 250f), new SizeF(200f, 200f)), 0f, 45f));

                // Add the Figure to the GraphicsPath
                graphicsPath.AddFigure(figure);

                // Draw the path using a black pen with a width of 2
                graphics.DrawPath(new Pen(Color.Black, 2), graphicsPath);

                // Save the image (the stream will be flushed automatically)
                image.Save();
            }
        }
    }
}