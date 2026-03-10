using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

// Create a PNG image, draw a red star using GraphicsPath, and save it.
using (FileStream stream = new FileStream(@"C:\temp\star.png", FileMode.Create))
{
    // Initialize PNG options and associate the stream as the source.
    PngOptions pngOptions = new PngOptions();
    pngOptions.Source = new StreamSource(stream);

    // Create a 400x400 image.
    using (Image image = Image.Create(pngOptions, 400, 400))
    {
        // Initialize graphics for the image.
        Graphics graphics = new Graphics(image);

        // Fill the background with light gray.
        graphics.Clear(Color.LightGray);

        // Create a new graphics path.
        GraphicsPath path = new GraphicsPath();

        // Create a figure that will hold the star shape.
        Figure figure = new Figure();

        // Define the points of a star.
        PointF[] starPoints = new PointF[]
        {
            new PointF(200f, 50f),
            new PointF(240f, 150f),
            new PointF(350f, 150f),
            new PointF(260f, 210f),
            new PointF(300f, 320f),
            new PointF(200f, 250f),
            new PointF(100f, 320f),
            new PointF(140f, 210f),
            new PointF(50f, 150f),
            new PointF(160f, 150f)
        };

        // Add a polygon shape using the star points.
        figure.AddShape(new PolygonShape(starPoints));

        // Ensure the figure is closed so the star is a solid outline.
        figure.IsClosed = true;

        // Add the figure to the graphics path.
        path.AddFigure(figure);

        // Draw the path with a thick red pen.
        graphics.DrawPath(new Pen(Color.Red, 3), path);

        // Save the image.
        image.Save();
    }
}