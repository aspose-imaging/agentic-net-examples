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
        // Output file path
        string outputPath = "output.png";

        // Set PNG options and specify the file source
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new image with the specified dimensions
        using (Image image = Image.Create(pngOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.Wheat); // Clear background

            // Create a graphics path to hold figures
            GraphicsPath graphicsPath = new GraphicsPath();

            // Create a figure and add shapes to it
            Figure figure = new Figure();
            figure.AddShape(new RectangleShape(new RectangleF(10f, 10f, 300f, 300f)));
            figure.AddShape(new EllipseShape(new RectangleF(50f, 50f, 300f, 300f)));
            figure.AddShape(new PieShape(
                new RectangleF(new PointF(250f, 250f), new SizeF(200f, 200f)),
                0f,
                45f));

            // Add the figure to the graphics path
            graphicsPath.AddFigure(figure);

            // Draw the path onto the image using a black pen
            graphics.DrawPath(new Pen(Color.Black, 2), graphicsPath);

            // Save the image to the file
            image.Save();
        }
    }
}