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
        // Output ICO file path (hardcoded)
        string outputPath = "output/icon.ico";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure ICO options with a FileCreateSource bound to the output path
        IcoOptions icoOptions = new IcoOptions();
        icoOptions.Source = new FileCreateSource(outputPath, false);

        // Define canvas dimensions
        int width = 256;
        int height = 256;

        // Create the ICO image canvas
        using (Image image = Image.Create(icoOptions, width, height))
        {
            // Initialize Graphics for drawing on the image
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.Transparent); // Clear background

            // Build a GraphicsPath with a rectangle and an ellipse
            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure();

            // Rectangle shape
            figure.AddShape(new RectangleShape(new RectangleF(20f, 20f, 200f, 200f)));
            // Ellipse shape
            figure.AddShape(new EllipseShape(new RectangleF(60f, 60f, 120f, 120f)));

            // Add the figure to the path
            path.AddFigure(figure);

            // Draw the path using a black pen
            Pen pen = new Pen(Color.Black, 3);
            graphics.DrawPath(pen, path);

            // Save the image (output path already bound)
            image.Save();
        }
    }
}