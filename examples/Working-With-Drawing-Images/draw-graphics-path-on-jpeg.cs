using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;
using Aspose.Imaging;

// Create a JPEG image (500x500) using Image.Create with JpegOptions
using (FileStream stream = new FileStream(@"C:\temp\output.jpg", FileMode.Create))
{
    // Set up JPEG options and associate the stream as the source
    JpegOptions jpegOptions = new JpegOptions();
    jpegOptions.Source = new StreamSource(stream);

    // Create the image
    using (Image image = Image.Create(jpegOptions, 500, 500))
    {
        // Initialize Graphics for drawing on the image
        Graphics graphics = new Graphics(image);

        // Clear the background with a light color
        graphics.Clear(Color.Wheat);

        // Create a GraphicsPath instance
        GraphicsPath graphicsPath = new GraphicsPath();

        // Create a Figure to hold multiple shapes
        Figure figure = new Figure();

        // Add a rectangle shape to the figure
        figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));

        // Add an ellipse shape to the figure
        figure.AddShape(new EllipseShape(new RectangleF(300f, 100f, 150f, 150f)));

        // Add a pie shape to the figure
        figure.AddShape(new PieShape(new RectangleF(150f, 250f, 200f, 200f), 0f, 120f));

        // Attach the figure to the graphics path
        graphicsPath.AddFigure(figure);

        // Define a pen (black color, 3-pixel width)
        Pen pen = new Pen(Color.Black, 3);

        // Draw the path onto the image
        graphics.DrawPath(pen, graphicsPath);

        // Save the image (the stream is already linked via jpegOptions)
        image.Save();
    }
}