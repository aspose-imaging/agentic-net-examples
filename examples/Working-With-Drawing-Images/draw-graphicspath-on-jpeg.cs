using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class GraphicsPathOnJpegExample
{
    static void Main()
    {
        // Output JPEG file path
        string outputPath = @"C:\temp\GraphicsPathExample.jpg";

        // Create a file stream for the output JPEG image
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Initialize JPEG options and associate the stream as the source
            JpegOptions jpegOptions = new JpegOptions();
            jpegOptions.Source = new StreamSource(stream);

            // Create a new image with the specified width and height
            using (Image image = Image.Create(jpegOptions, 500, 500))
            {
                // Initialize the Graphics object for drawing on the image
                Graphics graphics = new Graphics(image);

                // Clear the background with a light color
                graphics.Clear(Color.Wheat);

                // Create a GraphicsPath to hold custom shapes
                GraphicsPath graphicsPath = new GraphicsPath();

                // Create a Figure and add shapes to it
                Figure figure = new Figure();
                // Rectangle shape
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 300f, 200f)));
                // Ellipse shape
                figure.AddShape(new EllipseShape(new RectangleF(150f, 150f, 200f, 150f)));
                // Pie shape
                figure.AddShape(new PieShape(new RectangleF(new PointF(200f, 200f), new SizeF(150f, 150f)), 0f, 45f));

                // Add the figure to the graphics path
                graphicsPath.AddFigure(figure);

                // Draw the path using a black pen of width 2
                graphics.DrawPath(new Pen(Color.Black, 2), graphicsPath);

                // Save all changes to the JPEG stream
                image.Save();
            }
        }
    }
}