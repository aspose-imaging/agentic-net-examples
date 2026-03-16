using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;
using Aspose.Imaging;

// Create a file stream for the output GIF
using (FileStream stream = new FileStream(@"C:\temp\output.gif", FileMode.Create))
{
    // Configure GIF options and associate the stream source
    GifOptions gifOptions = new GifOptions();
    gifOptions.Source = new StreamSource(stream);

    // Create a new GIF image with desired dimensions
    using (Image image = Image.Create(gifOptions, 400, 300))
    {
        // Initialize Graphics object for drawing on the image
        Graphics graphics = new Graphics(image);

        // Optional: clear the background with a solid color
        graphics.Clear(Color.White);

        // Instantiate an empty GraphicsPath
        GraphicsPath graphicsPath = new GraphicsPath();

        // Create a Figure and add shapes (rectangle and ellipse) to it
        Figure figure = new Figure();
        figure.AddShape(new RectangleShape(new RectangleF(20f, 20f, 200f, 150f)));
        figure.AddShape(new EllipseShape(new RectangleF(250f, 50f, 100f, 100f)));

        // Add the Figure to the GraphicsPath
        graphicsPath.AddFigure(figure);

        // Draw the path onto the image using a blue pen of width 3
        graphics.DrawPath(new Pen(Color.Blue, 3), graphicsPath);

        // Save all changes to the GIF file
        image.Save();
    }
}