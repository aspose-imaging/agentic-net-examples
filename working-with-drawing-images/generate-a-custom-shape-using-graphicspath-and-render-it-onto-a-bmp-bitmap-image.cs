using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;
using Aspose.Imaging;

// Create BMP options with 24 bits per pixel
BmpOptions bmpOptions = new BmpOptions();
bmpOptions.BitsPerPixel = 24;

// Define output file path (adjust as needed)
bmpOptions.Source = new FileCreateSource(@"c:\temp\customShape.bmp", false);

// Create a 500x500 bitmap image
using (Image image = Image.Create(bmpOptions, 500, 500))
{
    // Initialize graphics object for drawing
    Graphics graphics = new Graphics(image);

    // Clear background with a light color
    graphics.Clear(Color.Wheat);

    // Create a new graphics path
    GraphicsPath graphicsPath = new GraphicsPath();

    // Create a figure to hold custom shapes
    Figure figure = new Figure();

    // Define points for a star shape
    PointF[] starPoints = new PointF[]
    {
        new PointF(250f, 50f),   // top
        new PointF(280f, 180f),
        new PointF(400f, 180f),
        new PointF(300f, 250f),
        new PointF(340f, 380f),
        new PointF(250f, 300f),
        new PointF(160f, 380f),
        new PointF(200f, 250f),
        new PointF(100f, 180f),
        new PointF(220f, 180f)
    };

    // Add the star shape as a closed polygon
    figure.AddShape(new PolygonShape(starPoints, true));

    // Add the figure to the graphics path
    graphicsPath.AddFigure(figure);

    // Draw the custom shape with a thick black pen
    graphics.DrawPath(new Pen(Color.Black, 3), graphicsPath);

    // Save the image to the specified file
    image.Save();
}