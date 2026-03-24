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
        // Define output path
        string outputPath = @"C:\temp\custom_shape.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a file source for the BMP image
        Source fileSource = new FileCreateSource(outputPath, false);

        // Configure BMP options
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = fileSource;

        // Create a BMP canvas of size 500x500
        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.LightGray);

            // Create a graphics path
            GraphicsPath graphicsPath = new GraphicsPath();

            // Create a figure and add custom shapes
            Figure figure = new Figure();
            // Rectangle shape
            figure.AddShape(new RectangleShape(new RectangleF(100f, 100f, 300f, 200f)));
            // Ellipse shape to complement the rectangle
            figure.AddShape(new EllipseShape(new RectangleF(150f, 150f, 200f, 100f)));

            // Add the figure to the graphics path
            graphicsPath.AddFigure(figure);

            // Draw the path with a pen
            Pen pen = new Pen(Color.DarkBlue, 3);
            graphics.DrawPath(pen, graphicsPath);

            // Save the bound image
            image.Save();
        }
    }
}