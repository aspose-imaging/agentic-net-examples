using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Output PNG file path
        string outputPath = Path.Combine(Environment.CurrentDirectory, "output.png");
        int width = 500;
        int height = 500;

        // Configure PNG options with a file create source
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new PNG image canvas
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, width, height))
        {
            // Initialize graphics for drawing
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
            graphics.Clear(Aspose.Imaging.Color.Wheat);

            // Build a graphics path with a figure containing shapes
            Aspose.Imaging.GraphicsPath graphicsPath = new Aspose.Imaging.GraphicsPath();
            Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();

            // Add a rectangle shape
            figure.AddShape(new RectangleShape(new Aspose.Imaging.RectangleF(50f, 50f, 200f, 150f)));
            // Add an ellipse shape
            figure.AddShape(new EllipseShape(new Aspose.Imaging.RectangleF(100f, 150f, 250f, 200f)));
            // Add a pie shape
            figure.AddShape(new PieShape(new Aspose.Imaging.RectangleF(200f, 200f, 150f, 150f), 0f, 120f));

            // Attach the figure to the graphics path
            graphicsPath.AddFigure(figure);

            // Draw the path using a black pen
            graphics.DrawPath(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2), graphicsPath);

            // Save the image (the file is already bound to the source)
            image.Save();
        }
    }
}