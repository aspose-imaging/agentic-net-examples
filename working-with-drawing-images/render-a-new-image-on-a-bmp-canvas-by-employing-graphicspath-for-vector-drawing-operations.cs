using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Output BMP file path (hardcoded)
        string outputPath = @"c:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure BMP options with a bound file source
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        var src = new FileCreateSource(outputPath, false);
        bmpOptions.Source = src;

        int width = 500;
        int height = 500;

        // Create a BMP canvas bound to the output file
        using (Aspose.Imaging.RasterImage canvas = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(bmpOptions, width, height))
        {
            // Initialize graphics for drawing
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);
            graphics.Clear(Aspose.Imaging.Color.Wheat);

            // Build a graphics path with vector shapes
            Aspose.Imaging.GraphicsPath path = new Aspose.Imaging.GraphicsPath();
            Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();

            // Rectangle shape
            figure.AddShape(new RectangleShape(new Aspose.Imaging.RectangleF(50f, 50f, 300f, 300f)));
            // Ellipse shape
            figure.AddShape(new EllipseShape(new Aspose.Imaging.RectangleF(100f, 100f, 200f, 200f)));
            // Pie shape
            figure.AddShape(new PieShape(
                new Aspose.Imaging.RectangleF(
                    new Aspose.Imaging.PointF(150f, 150f),
                    new Aspose.Imaging.SizeF(200f, 200f)),
                0f, 45f));

            // Add the figure to the path
            path.AddFigure(figure);

            // Draw the path onto the canvas
            graphics.DrawPath(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2), path);

            // Save the bound image
            canvas.Save();
        }
    }
}