using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Shapes;
using Aspose.Imaging;

// Create a file stream for the output image
using (FileStream stream = new FileStream(@"output.tiff", FileMode.Create))
{
    // Configure TIFF options (using default expected format)
    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
    tiffOptions.Source = new StreamSource(stream);

    // Create a new 500x500 TIFF image
    using (Image image = Image.Create(tiffOptions, 500, 500))
    {
        // Initialize Graphics object for the image
        Graphics graphics = new Graphics(image);
        graphics.Clear(Color.Wheat); // optional background clear

        // Instantiate a GraphicsPath associated with this image
        GraphicsPath graphicsPath = new GraphicsPath();

        // Create a figure and add some shapes (rectangle and ellipse)
        Figure figure = new Figure();
        figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));
        figure.AddShape(new EllipseShape(new RectangleF(150f, 150f, 200f, 200f)));

        // Add the figure to the GraphicsPath
        graphicsPath.AddFigure(figure);

        // Draw the path onto the image using a black pen
        graphics.DrawPath(new Pen(Color.Black, 2), graphicsPath);

        // Save the changes to the image
        image.Save();
    }
}