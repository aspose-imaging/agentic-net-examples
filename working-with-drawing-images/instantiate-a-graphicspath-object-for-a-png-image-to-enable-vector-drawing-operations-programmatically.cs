using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.FileFormats.Tiff.PathResources;

// Create a file stream for the output PNG image
using (FileStream stream = new FileStream(@"output.png", FileMode.Create))
{
    // Set up PNG options and associate the stream as the source
    PngOptions pngOptions = new PngOptions();
    pngOptions.Source = new StreamSource(stream);

    // Create a new PNG image with desired dimensions (e.g., 500x500)
    using (Image image = Image.Create(pngOptions, 500, 500))
    {
        // Initialize Graphics object to draw on the image surface
        Graphics graphics = new Graphics(image);
        graphics.Clear(Color.Wheat); // Optional: clear background

        // Instantiate an empty GraphicsPath for vector drawing
        GraphicsPath graphicsPath = new GraphicsPath();

        // Example: add a simple rectangle figure to the path
        Figure figure = new Figure();
        figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));
        graphicsPath.AddFigure(figure);

        // Draw the path using a black pen
        graphics.DrawPath(new Pen(Color.Black, 2), graphicsPath);

        // Save the PNG image (writes to the stream)
        image.Save();
    }
}