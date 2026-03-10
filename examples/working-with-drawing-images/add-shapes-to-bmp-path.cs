using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Define BMP options and output file source
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource("output.bmp", false);

        // Create a BMP image with specified dimensions
        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.Wheat);

            // Create a graphics path to hold figures
            GraphicsPath graphicsPath = new GraphicsPath();

            // Create a figure and add shapes to it
            Figure figure = new Figure();
            figure.AddShape(new RectangleShape(new RectangleF(10f, 10f, 300f, 300f)));
            figure.AddShape(new EllipseShape(new RectangleF(50f, 50f, 300f, 300f)));
            figure.AddShape(new PieShape(
                new RectangleF(new PointF(250f, 250f), new SizeF(200f, 200f)),
                0f,
                45f));

            // Add the figure to the graphics path
            graphicsPath.AddFigure(figure);

            // Draw the path onto the image using a black pen
            graphics.DrawPath(new Pen(Color.Black, 2), graphicsPath);

            // Save the image (output file is already bound via FileCreateSource)
            image.Save();
        }
    }
}