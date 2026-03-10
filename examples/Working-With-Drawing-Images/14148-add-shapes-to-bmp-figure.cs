using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Set BMP options (24 bits per pixel)
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        // Define output file path
        bmpOptions.Source = new FileCreateSource("output.bmp", false);

        // Create a 500x500 BMP image
        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.Wheat);

            // Create a graphics path and a figure
            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure();

            // Add shapes to the figure
            figure.AddShape(new RectangleShape(new RectangleF(10f, 10f, 300f, 300f)));
            figure.AddShape(new EllipseShape(new RectangleF(50f, 50f, 300f, 300f)));
            figure.AddShape(new PieShape(new Rectangle(new Point(110, 110), new Size(200, 200)), 0f, 90f));

            // Add the figure to the path
            path.AddFigure(figure);

            // Draw the path with a black pen
            graphics.DrawPath(new Pen(Color.Black, 2), path);

            // Save the image
            image.Save();
        }
    }
}