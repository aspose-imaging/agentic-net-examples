using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging;

// Create BMP options with 24 bits per pixel
BmpOptions bmpOptions = new BmpOptions
{
    BitsPerPixel = 24,
    // Define the output file (non‑temporary)
    Source = new FileCreateSource(@"c:\temp\GraphicsPathExample.bmp", false)
};

// Create a 500x500 BMP image
using (Image image = Image.Create(bmpOptions, 500, 500))
{
    // Initialize graphics for the image
    Graphics graphics = new Graphics(image);

    // Fill background with a light color
    graphics.Clear(Color.Wheat);

    // Create a GraphicsPath to hold multiple figures
    GraphicsPath path = new GraphicsPath();

    // First figure: an ellipse and a pie slice
    Figure figure1 = new Figure();
    figure1.AddShape(new EllipseShape(new RectangleF(50, 50, 300, 300)));
    figure1.AddShape(new PieShape(new RectangleF(110, 110, 200, 200), 0, 90));

    // Second figure: an arc, a polygon, and a rectangle
    Figure figure2 = new Figure();
    figure2.AddShape(new ArcShape(new RectangleF(10, 10, 300, 300), 0, 45));
    figure2.AddShape(new PolygonShape(
        new[]
        {
            new PointF(150, 10),
            new PointF(150, 200),
            new PointF(250, 300),
            new PointF(350, 400)
        },
        true));
    figure2.AddShape(new RectangleShape(new RectangleF(new Point(250, 250), new Size(200, 200))));

    // Add both figures to the path
    path.AddFigures(new[] { figure1, figure2 });

    // Draw the combined path with a black pen of width 2
    graphics.DrawPath(new Pen(Color.Black, 2), path);

    // Save the image to the file system
    image.Save();
}