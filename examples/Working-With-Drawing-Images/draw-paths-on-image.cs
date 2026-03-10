using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Png.Graphics;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.FileFormats.Svg.Graphics; // For SvgGraphics2D if needed

class DrawPathsExample
{
    static void Main()
    {
        // Define output file path
        string outputPath = @"C:\Temp\draw_paths.png";

        // Create PNG options
        PngOptions pngOptions = new PngOptions();

        // Create a new PNG image with width=500 and height=500
        using (Image image = Image.Create(pngOptions, 500, 500))
        {
            // Initialize Graphics object for drawing
            using (Graphics graphics = new Graphics(image))
            {
                // Clear the canvas with a light background color
                graphics.Clear(Color.Wheat);

                // Create a new GraphicsPath
                GraphicsPath path = new GraphicsPath();

                // Create a Figure to hold shapes
                Figure figure = new Figure();

                // Add a rectangle shape
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));

                // Add an ellipse shape
                figure.AddShape(new EllipseShape(new RectangleF(300f, 100f, 150f, 150f)));

                // Add a pie shape
                figure.AddShape(new PieShape(new RectangleF(150f, 250f, 200f, 200f), 0f, 120f));

                // Add the figure to the path
                path.AddFigure(figure);

                // Draw the path using a black pen of width 3
                graphics.DrawPath(new Pen(Color.Black, 3), path);
            }

            // Save the image to the specified file
            image.Save(outputPath);
        }

        Console.WriteLine($"Image saved to: {outputPath}");
    }
}