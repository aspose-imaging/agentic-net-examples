using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.FileFormats.Jpeg;

// Create a file stream for the output JPEG image
using (FileStream stream = new FileStream(@"C:\temp\vector_output.jpg", FileMode.Create))
{
    // Configure JPEG options and associate the stream as the source
    JpegOptions jpegOptions = new JpegOptions();
    jpegOptions.Source = new StreamSource(stream);

    // Create a new JPEG image with the desired dimensions (e.g., 600x400)
    using (Image image = Image.Create(jpegOptions, 600, 400))
    {
        // Initialize the Graphics object for drawing on the image
        Graphics graphics = new Graphics(image);

        // Optional: clear the background with a solid color
        graphics.Clear(Color.White);

        // Build a GraphicsPath containing vector shapes
        GraphicsPath path = new GraphicsPath();

        // Create a figure to hold multiple shapes
        Figure figure = new Figure();

        // Add a rectangle shape to the figure
        figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));

        // Add an ellipse shape to the figure
        figure.AddShape(new EllipseShape(new RectangleF(300f, 100f, 150f, 150f)));

        // Add the figure to the graphics path
        path.AddFigure(figure);

        // Define a pen for outlining the path (blue color, 3-pixel width)
        Pen pen = new Pen(Color.Blue, 3);

        // Render the vector path onto the image surface
        graphics.DrawPath(pen, path);

        // Save all changes to the JPEG image (the stream is already linked)
        image.Save();
    }
}