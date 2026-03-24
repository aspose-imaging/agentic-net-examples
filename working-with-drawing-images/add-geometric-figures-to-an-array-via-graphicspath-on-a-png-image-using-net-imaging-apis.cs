using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"c:\temp\output.png";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up PNG options with a file create source
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new PNG image (500x500)
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
            graphics.Clear(Aspose.Imaging.Color.Wheat);

            // Create a graphics path and a figure
            Aspose.Imaging.GraphicsPath graphicsPath = new Aspose.Imaging.GraphicsPath();
            Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();

            // Add a rectangle shape
            figure.AddShape(new RectangleShape(new Aspose.Imaging.RectangleF(10f, 10f, 300f, 300f)));

            // Add an ellipse shape
            figure.AddShape(new EllipseShape(new Aspose.Imaging.RectangleF(50f, 50f, 300f, 300f)));

            // Add a pie shape
            figure.AddShape(new PieShape(
                new Aspose.Imaging.RectangleF(
                    new Aspose.Imaging.PointF(250f, 250f),
                    new Aspose.Imaging.SizeF(200f, 200f)),
                0f,
                45f));

            // Add the figure to the graphics path
            graphicsPath.AddFigure(figure);

            // Draw the path onto the image
            graphics.DrawPath(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2), graphicsPath);

            // Save the image (source is already bound to the file)
            image.Save();
        }
    }
}