using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Create a file stream for the output TIFF image
        using (FileStream stream = new FileStream("output.tiff", FileMode.Create))
        {
            // Configure TIFF options
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.Source = new StreamSource(stream);

            // Create a new 500x500 TIFF image
            using (Image image = Image.Create(tiffOptions, 500, 500))
            {
                // Initialize Graphics object for drawing on the image
                Graphics graphics = new Graphics(image);

                // Clear the drawing surface with a background color
                graphics.Clear(Color.Wheat);

                // Create an empty GraphicsPath instance
                GraphicsPath graphicsPath = new GraphicsPath();

                // Build a simple figure (a rectangle) and add it to the path
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(10f, 10f, 300f, 300f)));
                graphicsPath.AddFigure(figure);

                // Draw the path onto the image using a black pen
                graphics.DrawPath(new Pen(Color.Black, 2), graphicsPath);

                // Save the changes to the image (the stream is already linked via TiffOptions)
                image.Save();
            }
        }
    }
}