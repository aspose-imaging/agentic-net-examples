using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging;

// Create a file stream for the output PNG file
using (FileStream stream = new FileStream(@"C:\temp\output.png", FileMode.Create))
{
    // Initialize PNG options and associate the stream as the source
    PngOptions pngOptions = new PngOptions();
    pngOptions.Source = new StreamSource(stream);

    // Create a new PNG image with the specified dimensions
    using (Image image = Image.Create(pngOptions, 400, 400))
    {
        // Initialize the Graphics object for drawing on the image
        Graphics graphics = new Graphics(image);

        // Fill the background with a light color
        graphics.Clear(Color.Wheat);

        // Build a GraphicsPath containing several shapes
        GraphicsPath graphicsPath = new GraphicsPath();
        Figure figure = new Figure();

        // Add a rectangle shape
        figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 300f, 200f)));

        // Add an ellipse shape
        figure.AddShape(new EllipseShape(new RectangleF(100f, 150f, 200f, 150f)));

        // Add a pie shape
        figure.AddShape(new PieShape(new RectangleF(150f, 100f, 100f, 100f), 0f, 120f));

        // Attach the figure to the path
        graphicsPath.AddFigure(figure);

        // Draw the constructed path using a black pen of width 3
        graphics.DrawPath(new Pen(Color.Black, 3), graphicsPath);

        // Persist the changes to the PNG file
        image.Save();
    }
}