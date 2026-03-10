using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Define output path and image dimensions
        string outputPath = "output.ico";
        int width = 64;
        int height = 64;

        // Set up ICO options with a file create source
        IcoOptions icoOptions = new IcoOptions();
        icoOptions.Source = new FileCreateSource(outputPath, false);

        // Create the ICO image canvas
        using (Image image = Image.Create(icoOptions, width, height))
        {
            // Initialize Graphics for drawing
            Graphics graphics = new Graphics(image);

            // Clear the canvas with a transparent background
            graphics.Clear(Color.Transparent);

            // Create a GraphicsPath and a Figure
            GraphicsPath graphicsPath = new GraphicsPath();
            Figure figure = new Figure();

            // Add a rectangle shape to the figure
            figure.AddShape(new RectangleShape(new RectangleF(8f, 8f, 48f, 48f)));

            // Add the figure to the graphics path
            graphicsPath.AddFigure(figure);

            // Draw the path using a black pen
            graphics.DrawPath(new Pen(Color.Black, 2), graphicsPath);

            // Save the image (file is already bound to the source)
            image.Save();
        }
    }
}