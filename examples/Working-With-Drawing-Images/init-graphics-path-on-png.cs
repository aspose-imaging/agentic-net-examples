using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Output PNG file path
        string outputPath = "output.png";

        // Configure PNG options and bind the output file via FileCreateSource
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        // Create a PNG image canvas of 500x500 pixels
        using (Image image = Image.Create(pngOptions, 500, 500))
        {
            // Initialize Graphics for drawing on the image
            Graphics graphics = new Graphics(image);

            // Clear the canvas with a wheat color background
            graphics.Clear(Color.Wheat);

            // Create a GraphicsPath to hold figures
            GraphicsPath graphicsPath = new GraphicsPath();

            // Create a Figure and add shapes to it
            Figure figure = new Figure();
            figure.AddShape(new RectangleShape(new RectangleF(10f, 10f, 300f, 300f)));
            figure.AddShape(new EllipseShape(new RectangleF(50f, 50f, 300f, 300f)));

            // Add the Figure to the GraphicsPath
            graphicsPath.AddFigure(figure);

            // Draw the path onto the image using a black pen
            graphics.DrawPath(new Pen(Color.Black, 2), graphicsPath);

            // Save the image (output file is already bound by FileCreateSource)
            image.Save();
        }
    }
}