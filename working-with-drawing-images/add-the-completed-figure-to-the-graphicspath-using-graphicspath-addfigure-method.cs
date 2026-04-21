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
        string outputPath = @"C:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up BMP options with a file create source
        BmpOptions bmpOptions = new BmpOptions
        {
            BitsPerPixel = 24,
            Source = new FileCreateSource(outputPath, false)
        };

        // Create a new image (500x500) using the options
        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Clear the background
            graphics.Clear(Color.Wheat);

            // Create a GraphicsPath instance
            GraphicsPath graphicsPath = new GraphicsPath();

            // Create a Figure and add shapes to it
            Figure figure = new Figure();
            figure.AddShape(new RectangleShape(new RectangleF(10f, 10f, 300f, 300f)));
            figure.AddShape(new EllipseShape(new RectangleF(50f, 50f, 300f, 300f)));
            figure.AddShape(new PieShape(
                new RectangleF(new PointF(250f, 250f), new SizeF(200f, 200f)),
                0f, 45f));

            // Add the completed Figure to the GraphicsPath
            graphicsPath.AddFigure(figure);

            // Draw the path with a black pen
            graphics.DrawPath(new Pen(Color.Black, 2), graphicsPath);

            // Save the image (the file is already linked via the source)
            image.Save();
        }
    }
}