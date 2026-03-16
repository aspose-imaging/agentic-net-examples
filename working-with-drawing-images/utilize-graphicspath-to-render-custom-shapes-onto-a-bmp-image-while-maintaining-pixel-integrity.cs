using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Define canvas size
        int width = 500;
        int height = 500;

        // Output BMP file path
        string outputPath = "output.bmp";

        // Configure BMP options
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create the image canvas
        using (Image image = Image.Create(bmpOptions, width, height))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.Wheat); // Clear background

            // Create a graphics path to hold figures
            GraphicsPath path = new GraphicsPath();

            // First figure with rectangle and ellipse
            Figure figure1 = new Figure();
            figure1.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));
            figure1.AddShape(new EllipseShape(new RectangleF(300f, 50f, 150f, 150f)));
            path.AddFigure(figure1);

            // Second figure with pie and polygon
            Figure figure2 = new Figure();
            figure2.AddShape(new PieShape(new RectangleF(100f, 250f, 200f, 200f), 0f, 120f));
            figure2.AddShape(new PolygonShape(
                new PointF[]
                {
                    new PointF(350f, 300f),
                    new PointF(400f, 350f),
                    new PointF(380f, 400f),
                    new PointF(320f, 380f)
                },
                true));
            path.AddFigure(figure2);

            // Draw the combined path with a black pen
            Pen pen = new Pen(Color.Black, 2);
            graphics.DrawPath(pen, path);

            // Save the image (file is already bound via FileCreateSource)
            image.Save();
        }
    }
}