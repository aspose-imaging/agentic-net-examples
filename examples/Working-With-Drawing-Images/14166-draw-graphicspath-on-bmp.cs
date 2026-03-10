using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Output BMP file path
        string outputPath = @"c:\temp\output.bmp";

        // Configure BMP options
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new BMP image with the specified size
        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            // Initialize graphics for drawing on the image
            Graphics graphics = new Graphics(image);
            graphics.Clear(Aspose.Imaging.Color.Wheat); // Fill background

            // Create a graphics path to hold figures
            GraphicsPath path = new GraphicsPath();

            // First figure: ellipse and pie shape
            Figure figure1 = new Figure();
            figure1.AddShape(new EllipseShape(new RectangleF(50, 50, 300, 300)));
            figure1.AddShape(new PieShape(new Rectangle(110, 110, 200, 200), 0, 90));

            // Second figure: arc, polygon, and rectangle shape
            Figure figure2 = new Figure();
            figure2.AddShape(new ArcShape(new RectangleF(10, 10, 300, 300), 0, 45));
            figure2.AddShape(new PolygonShape(new[]
            {
                new PointF(150, 10),
                new PointF(150, 200),
                new PointF(250, 300),
                new PointF(350, 400)
            }, true));
            figure2.AddShape(new RectangleShape(new RectangleF(new Point(250, 250), new Size(200, 200))));

            // Add both figures to the graphics path
            path.AddFigures(new[] { figure1, figure2 });

            // Draw the path using a black pen
            graphics.DrawPath(new Pen(Aspose.Imaging.Color.Black, 2), path);

            // Save the image to the specified file
            image.Save();
        }
    }
}