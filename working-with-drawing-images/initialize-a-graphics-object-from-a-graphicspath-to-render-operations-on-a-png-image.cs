using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\output.png";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a file stream for the output PNG
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Set up PNG options with the stream as source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create a new PNG image of size 500x500
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize Graphics object for drawing on the image
                Graphics graphics = new Graphics(image);

                // Clear the background with a wheat color
                graphics.Clear(Aspose.Imaging.Color.Wheat);

                // Build a GraphicsPath containing a rectangle figure
                GraphicsPath graphicsPath = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 400f, 400f)));
                graphicsPath.AddFigure(figure);

                // Draw the path using a black pen of width 5
                graphics.DrawPath(new Pen(Aspose.Imaging.Color.Black, 5), graphicsPath);

                // Save all changes to the PNG file
                image.Save();
            }
        }
    }
}