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
        // Output ICO file path
        string outputPath = "output.ico";

        // Define image dimensions
        int width = 256;
        int height = 256;

        // Create ICO options and bind to file source
        IcoOptions icoOptions = new IcoOptions();
        icoOptions.Source = new FileCreateSource(outputPath, false);

        // Create the image canvas
        using (Image image = Image.Create(icoOptions, width, height))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Create a graphics path
            GraphicsPath path = new GraphicsPath();

            // Create a figure and add shapes
            Figure figure = new Figure();
            figure.AddShape(new RectangleShape(new RectangleF(20f, 20f, 200f, 200f)));
            figure.AddShape(new EllipseShape(new RectangleF(60f, 60f, 120f, 120f)));
            figure.AddShape(new PieShape(new RectangleF(80f, 80f, 80f, 80f), 0f, 120f));

            // Add the figure to the path
            path.AddFigure(figure);

            // Draw the path with a black pen
            graphics.DrawPath(new Pen(Color.Black, 3), path);

            // Save the image (already bound to the file source)
            image.Save();
        }
    }
}